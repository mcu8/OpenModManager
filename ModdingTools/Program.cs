using CUFramework.Dialogs;
using ModdingTools.Engine;
using ModdingTools.Windows;
using ModdingTools.Windows.Tools;
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
        public static Benchmark Benchmark { get; set; } = null;

        public static string GetAppRoot()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        [STAThread]
        static void Main()
        {
            bool steam = SteamAPI.Init();
            if (!steam)
            {
                CUMessageBox.Show("SteamAPI initialization failed! (is Steam running/installed?)");
                Environment.Exit(0);
            }

            if (!Environment.Is64BitOperatingSystem || !Environment.Is64BitProcess)
            {
                CUMessageBox.Show("This app needs 64-bit operating environment and operating system!");
                Environment.Exit(0);
            }

            Automation.AddAutomationEventHandler(
                eventId: WindowPattern.WindowOpenedEvent,
                element: AutomationElement.RootElement,
                scope: TreeScope.Children,
                eventHandler: OnWindowOpened);

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Engine.GameFinder.FindGameDir()));
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
                        if (Benchmark != null)
                        {
                            Benchmark.Stop();
                        }
                        Meme.StopElevatorMusic();
                    }
                    else if (element.Current.Name.Trim() == "Editor for A Hat in Time (64-bit, DX9)")
                    {
                        Meme.PlayElevatorMusic();
                       
                    }
                }
               
            }
            catch (ElementNotAvailableException)
            {
            }
        }
    }
}
