using CommandLine;
using CUFramework.Dialogs;
using CUFramework.Shared;
using ModdingTools.Engine;
using ModdingTools.Headless;
using ModdingTools.Logging;
using ModdingTools.Settings;
using ModdingTools.Windows;
using ModdingTools.Windows.Tools;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace ModdingTools
{
    static class Program
    {
        public static SteamWorkshopStorage SWS { get; set; }

        public static ProcessFactory ProcFactory;
        public static ModUploader Uploader { get; set; }
        public static Benchmark Benchmark { get; set; } = null;
 
        public static string GetAppRoot()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        public static string AssemblyPath
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetFullPath(path);
            }
        }

        public static string GetCLIPath()
        {
            if (Debugger.IsAttached && !ProgramHeadless.IsHeadlessMode)
            {
                return Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AssemblyPath)))), "ModdingTools.Cli\\bin\\Debug\\ModdingTools.Cli.exe");
            }
            else
            {
                return Path.Combine(Path.GetDirectoryName(AssemblyPath), "ModdingTools.Cli.exe");
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            AttachBugTracker();
            MainGUI(args);
        }

        public static bool FixUpdater()
        {
            Utils.KillUpdater(); 

            var updaterFileA = Path.Combine(GetAppRoot(), "ModdingTools.Updater.exe");
            var updaterFilePdbA = Path.Combine(GetAppRoot(), "ModdingTools.Updater.pdb");

            var updaterFileB = Path.Combine(GetAppRoot(), "ModdingTools.Updater.New.exe");
            var updaterFilePdbB = Path.Combine(GetAppRoot(), "ModdingTools.Updater.New.pdb");

            bool result = false;
            if (File.Exists(updaterFileB))
            {
                if (File.Exists(updaterFileA)) File.Delete(updaterFileA);
                if (File.Exists(updaterFilePdbA)) File.Delete(updaterFilePdbA);

                File.Move(updaterFileB, updaterFileA);
                File.Move(updaterFilePdbB, updaterFilePdbA);
                result = true;
            }
            return result;
        }

        private static void AttachBugTracker()
        {
            if (!Debugger.IsAttached)
            {
                // Add the event handler for handling UI thread exceptions to the event.
                Application.ThreadException += (sender, e)
                    => FatalExceptionObject(e);

                // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                // Add the event handler for handling non-UI thread exceptions to the event.
                AppDomain.CurrentDomain.UnhandledException += (sender, e)
                    => FatalExceptionObject(e.ExceptionObject);

                //  This AppDomain-wide event provides a mechanism to prevent exception escalation policy (which, by default, terminates the process) from triggering.
                //  Each handler is passed a UnobservedTaskExceptionEventArgs instance, which may be used to examine the exception and to mark it as observed.
                TaskScheduler.UnobservedTaskException += (sender, e)
                    => FatalExceptionObject(e);

                // Add the event handler for handling UI thread exceptions to the event.
                System.Windows.Threading.Dispatcher.CurrentDispatcher.UnhandledException += (sender, e)
                    => FatalExceptionObject(e);
            }
        }

        static bool isReported = false;
        static int threads;
        public static void FatalExceptionObject(object exc)
        {
            if (!Debugger.IsAttached)
            {
                if (isReported)
                {
                    CloseApp(1);
                }

                var e = exc as Exception;
                if (e == null)
                {
                    e = new NotSupportedException(
                        "Unhandled exception doesn't derive from System.Exception: "
                        + exc.ToString()
                    );
                }

                threads = Process.GetCurrentProcess().Threads.Count;

                var x = new StringBuilder();
                x.AppendLine("Failed to launch OMM: ");
                x.AppendLine(e.Message);
                x.AppendLine(e.StackTrace);
                if (e.InnerException != null)
                {
                    x.AppendLine("---[inner exception]---");
                    x.AppendLine(e.InnerException.Message);
                    x.AppendLine(e.InnerException.StackTrace);
                }
                x.AppendLine("");
                x.AppendLine("Threads: " + threads);

                MessageBox.Show(x.ToString());
                isReported = true;
                CloseApp(1);
            }
        }

        public static void CloseApp(int i)
        {
            Debug.WriteLine("Closing application...");
            if (!Debugger.IsAttached)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(i);
            }
        }

        static void MainGUI(string[] args)
        {
            // Window border looks like shit on Windows 11.. so change the color to something else
            ThemeConstants.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);

            //throw new Exception("test");
            if (GameFinder.FindGameDir() == null)
            {
                CUMessageBox.Show("Failed to find the game directory! Please specify the path to the original ModManager.exe manually!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OpenFileDialog ov = new OpenFileDialog();
                ov.CheckFileExists = true;
                ov.FileName = "ModManager.exe";
                ov.Filter = "ModManager.exe|ModManager.exe";

                if (ov.ShowDialog() == DialogResult.OK)
                {
                    string dir = Path.Combine(Path.GetDirectoryName(ov.FileName), "Win64");
                    File.WriteAllText("GameDirPath.dat", dir);
                    if (GameFinder.FindGameDir() == null)
                    {
                        CUMessageBox.Show($"Failed to find the game files in '{dir}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                Environment.Exit(1);
            }

            Utils.UpdateAppId(734880);

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

            ProcFactory = new ProcessFactory();

            Automation.AddAutomationEventHandler(
                eventId: WindowPattern.WindowOpenedEvent,
                element: AutomationElement.RootElement,
                scope: TreeScope.Children,
                eventHandler: OnWindowOpened);

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Engine.GameFinder.FindGameDir()));
            Uploader = new ModUploader();
            SWS = new SteamWorkshopStorage(Path.Combine(Engine.GameFinder.GetModsDir(), "SteamWorkshop.ini"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            SetRPData();
        }

        private static void SetRPData()
        {
            SteamFriends.SetRichPresence("gamelocation", "OpenModManager");
            SteamFriends.SetRichPresence("status", "I'm using OpenModManager!\nhttps://github.com/mcu8/OpenModManager");
            SteamFriends.SetRichPresence("steam_display", "#Status");
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
