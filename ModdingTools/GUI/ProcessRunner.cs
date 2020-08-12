using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static ModdingTools.Engine.ProcessFactory;
using System.Collections.Generic;
using ModdingTools.Engine;
using ModdingTools.Windows;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace ModdingTools.GUI
{
    public partial class ProcessRunner : UserControl
    {
        public delegate void OnAppClose(int code);
        private static OnAppClose AppClose = null;

        public delegate void OnAppRun();
        private static OnAppRun AppRun = null;

        public ProcessRunner()
        {
            InitializeComponent();

            SetText(null);

            label2.BackColor = ThemeConstants.BorderColor;
            label2.ForeColor = ThemeConstants.TitleBarForeground;

            mButton3.BackColor = ThemeConstants.BorderColor;
            mButton3.ForeColor = ThemeConstants.TitleBarForeground;

            mButton1.BackColor = ThemeConstants.BorderColor;
            mButton1.ForeColor = ThemeConstants.TitleBarForeground;

            mButton3.Visible = false;
        }

        public void RunAppAsync(ExecutableArgumentsPair info)
        {
            Debug.WriteLine(info.ToString());
            SetText(info.TaskName);
            RunAppAsync(info.Executable, info.Arguments, info.WorkingDirectory, info.TaskName, info.OnFinish);
        }

        public void RunApp(ExecutableArgumentsPair info)
        {
            Debug.WriteLine(info.ToString());
            RunApp(info.Executable, info.Arguments, info.WorkingDirectory, info.TaskName, info.OnFinish);
        }

        public void RunAppAsync(string exe, string[] args, string cwd = ".", string taskName = "", Action o = null)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    RunApp(exe, args, cwd, taskName);
                    o?.Invoke();
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

        public void SetText(string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => SetText(value)));
            }
            else
            {
                if (MainWindow.Instance != null)
                {
                    MainWindow.Instance.SetModListState(value);
                }
                   
                if (value == null)
                {
                    ModManagerPropertiesWrapper.UnhideForms();
                }
                else
                {
                    ModManagerPropertiesWrapper.TmpHideForms();
                }

                if (value == null) Text = "";
                else Text = value;
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

        public void KillAllWorkers()
        {
            while (runningProcesses.Count > 0)
            {
                var proc = runningProcesses[0];
                try
                {
                    if (!proc.HasExited)
                    {
                        proc.Kill();
                    }
                }
                catch(Exception e)
                {
                    Debug.WriteLine("PECK >> " + e.Message + "\n" + e.ToString());
                }

                runningProcesses.Remove(proc);
            }
            SetText(null);
        }

        List<Process> runningProcesses = new List<Process>();
        private void RunApp(string exe, string[] args, string cwd = ".", string taskName = "", Action o = null)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                textBox1.Clear();
                Log(taskName);
            }));

            NamedPipe mLogPipe;
            Thread mOutputThread = null;

            AppRun?.Invoke();

            SetText(taskName);

            Process process = new Process();
            process.StartInfo.FileName = exe;
            process.StartInfo.Arguments = string.Join(" ", args);
            process.StartInfo.WorkingDirectory = cwd;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardInput = true;
            process.EnableRaisingEvents = true;

            process.Start();
            runningProcesses.Add(process);
            SetText(taskName);

           
            mLogPipe = new NamedPipe();
            if (mLogPipe.Connect(process))
            {
                if (mOutputThread != null && mOutputThread.IsAlive)
                {
                    mOutputThread.Abort();
                }
                mOutputThread = new Thread(() => {
                    Debug.WriteLine("Pipe open");
                    try
                    {
                        while (process != null && !process.HasExited)
                        {
                            string text = mLogPipe.Read();
                            if (text.Length > 0 && !text.StartsWith("`~[~`"))
                            {
                                Log(text.Replace("\r\n", ""));
                            }
                        }
                    }
                    catch (ThreadAbortException)
                    {
                    }
                    catch (Exception)
                    {
                    }
                    Debug.WriteLine("Pipe close");
                });
                mOutputThread.Start();
            }

            while (!process.HasExited && !isCancelling)
            {
                Thread.Sleep(300);
            }

            Meme.StopElevatorMusic();

            if (runningProcesses.Contains(process))
                runningProcesses.Remove(process);

            this.Invoke(new MethodInvoker(() =>
            {
                if (runningProcesses.Count == 0)
                    mButton3.Visible = false;
            }));

            AppClose?.Invoke(process.ExitCode);

            if (runningProcesses.Count == 0) SetText(null);

            this.Invoke(new MethodInvoker(() =>
            {
                MainWindow.Instance.ToggleConsole(false);
            }));
        }

        public void Log(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => Log(msg)));
                return;
            }
            mButton3.Visible = true;
            textBox1.AppendText($"[{GetLoggerDate()}] {msg}{Environment.NewLine}");
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();

            MainWindow.Instance.SetModListStatus(msg.Trim('-'));
        }

        public static string GetLoggerDate()
        {
            System.DateTime regDate = System.DateTime.Now;
            return regDate.ToString("HH:mm:ss");
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            KillAllWorkers();
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}