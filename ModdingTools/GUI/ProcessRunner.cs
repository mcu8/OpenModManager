using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static ModdingTools.UEngine.ProcessFactory;

namespace ModdingTools.GUI
{
    public partial class ProcessRunner : UserControl
    {
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);

        private const int GWL_STYLE         = -16;         // hex constant for style changing
        private const int WS_BORDER         = 0x00800000;  // window with border
        private const int WS_CAPTION        = 0x00C00000;  // window with a title bar
        private const int WS_SYSMENU        = 0x00080000;  // window with no borders etc.
        private const int WS_MINIMIZEBOX    = 0x00020000;  // window with minimizebox
        private const int SW_MAXIMIZE       = 3;
        private const int SW_SHOW           = 5;
        private const int SW_MINIMIZE       = 6;
        private const int SW_RESTORE        = 9;
        private const int SWP_NOSIZE        = 0x0001;
        private const int SWP_NOMOVE        = 0x0002;
        private const int SWP_NOACTIVATE    = 0x0010;
        private const int HWND_BOTTOM       = 1;

        public delegate void OnAppClose(int code);
        private static OnAppClose AppClose = null;

        public delegate void OnAppRun();
        private static OnAppRun AppRun = null;

        public ProcessRunner()
        {
            InitializeComponent();

            this.SizeChanged += (o, e) =>
            {
                UpdateConsoleSize();
            };

            SetText("");

            label2.BackColor = ThemeConstants.BorderColor;
            label2.ForeColor = ThemeConstants.TitleBarForeground;
        }

        IntPtr hndl;
        const int offset = 5;
        public void EatWindow(IntPtr handle)
        {
            hndl = handle;
            SetParent(handle, this.Handle);
            SetWindowLong(handle, GWL_STYLE, 0x00040000);
            SetWindowPos(Handle, HWND_BOTTOM, 0, 24, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);

            UpdateConsoleSize();

            ShowWindow(handle, SW_RESTORE);  // Next, restore it if it was minimized
        }

        public void UpdateConsoleSize()
        {
            if (hndl != IntPtr.Zero && IsWindow(hndl))
                MoveWindow(hndl, -1 * (offset), -1 * (offset) + 25, this.Width + (offset * 2) - 2, (this.Height + (offset * 2)) - 24, true);
            else
                hndl = IntPtr.Zero;
        }

        public void RunAppAsync(ExecutableArgumentsPair info)
        {
            Debug.WriteLine(info.ToString());
            RunAppAsync(info.Executable, info.Arguments, info.WorkingDirectory);
        }

        public void RunAppAsync(string exe, string[] args, string cwd = ".")
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    RunApp(exe, args, cwd);
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message + "\n" + e.StackTrace);
                }
            });
        }

        public void RunWithoutWait(ExecutableArgumentsPair info)
        {
            Debug.WriteLine(info.ToString());
            RunWithoutWait(info.Executable, info.Arguments, info.WorkingDirectory);
        }

        public override string Text { get => label1.Text; set => label1.Text = value; }

        public void SetText(string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => Text = value));
            }
            else
            {
                Text = value;
            }
        }

        private void RunWithoutWait(string exe, string[] args, string cwd = ".")
        {
            Process process = new Process();
            process.StartInfo.FileName = exe;
            process.StartInfo.Arguments = string.Join(" ", args);
            process.StartInfo.WorkingDirectory = cwd;

            process.Start();
        }

        bool isCancelling = false;
        public void CancelAllWorkers()
        {
            isCancelling = true;
        }

        
        private void RunApp(string exe, string[] args, string cwd = ".")
        {
            AppRun?.Invoke();
            SetText("Please wait...");

            Process process = new Process();
            process.StartInfo.FileName = exe;
            process.StartInfo.Arguments = string.Join(" ", args);
            process.StartInfo.WorkingDirectory = cwd;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

            process.Start();

            while (!process.HasExited && process.MainWindowHandle == IntPtr.Zero)
            {
                System.Threading.Thread.Sleep(100); // Don't hog the CPU
                process.Refresh(); // You need this since `MainWindowHandle` is cached
            }

            this.Invoke(new MethodInvoker(() =>
            {
                EatWindow(process.MainWindowHandle);
            }));

            while (!process.HasExited && !isCancelling)
            {
                System.Threading.Thread.Sleep(100);
            }

            AppClose?.Invoke(process.ExitCode);
            SetText("");
        }
    }
}