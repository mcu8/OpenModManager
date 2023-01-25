using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModdingTools.Updater
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var args = Environment.GetCommandLineArgs();
            if (Process.GetCurrentProcess().ProcessName.Equals("ModdingTools.Updater", StringComparison.InvariantCultureIgnoreCase))
            {
                AttachBugTracker();

                // Enable TLS 1.2 & 1.1 because .Net Framework 4.0 doesn't have it enabled by default
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)(768 | 3072);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
            else
            {
                Process.Start(Path.Combine(GetAppRoot(), "ModdingTools.exe"));
                Environment.Exit(0);
            }
        }

        public static string GetAppRoot()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
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
                x.AppendLine("Failed to launch OMM Updater: ");
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
    }
}
