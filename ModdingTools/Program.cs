using ModdingTools.UEngine;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Automation;
using System.Windows.Forms;

namespace ModdingTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static readonly ProcessFactory ProcFactory = new ProcessFactory();
        public static ModUploader Uploader { get; set; }

        [STAThread]
        static void Main()
        {
            bool steam = SteamAPI.Init();
            if (!steam)
            {
                MessageBox.Show("SteamAPI init failed...");
                Environment.Exit(0);
            }

            System.Windows.Automation.Automation.AddAutomationEventHandler(
                eventId: WindowPattern.WindowOpenedEvent,
                element: AutomationElement.RootElement,
                scope: TreeScope.Children,
                eventHandler: OnWindowOpened);

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolder);
            Directory.SetCurrentDirectory(Path.GetDirectoryName(UEngine.GameFinder.FindGameDir()));
            Uploader = new ModUploader();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        private static void OnWindowOpened(object sender, AutomationEventArgs automationEventArgs)
        {
            try
            {
                var element = sender as AutomationElement;
                if (element != null)
                {
                    if (element.Current.Name.Trim() == "Editor for A Hat in Time (64-bit, DX9, Cooked Editor, PMT)")
                    {
                        Lol.StopElevatorMusic();
                    }
                    else if (element.Current.Name.Trim() == "Editor for A Hat in Time (64-bit, DX9)")
                    {
                        Lol.PlayElevatorMusic();
                    }
                }
               
            }
            catch (ElementNotAvailableException)
            {
            }
        }

        static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
        {
            string folderPath = Path.GetDirectoryName(UEngine.GameFinder.FindGameDir());
            var name = new AssemblyName(args.Name).Name;
            Debug.WriteLine(name);

            Debug.WriteLine("test: " + folderPath);

            string ext = name.EndsWith(".resources") ? ".resources" : name.EndsWith(".dll") ? ".dll" : name.EndsWith(".exe") ? ".exe" : "";

            if (name == "ModManager")
            {
                ext = ".dll";
            }

            string assemblyPath = Path.Combine(folderPath, name + ext);

            Debug.WriteLine("test: " + assemblyPath);

            if (!File.Exists(assemblyPath))
            {
                assemblyPath = Path.Combine(folderPath, name + ext);
                if (!File.Exists(assemblyPath)) return null;
            }

            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            return assembly;
        }
    }
}
