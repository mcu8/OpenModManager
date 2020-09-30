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
using System.Windows.Input;
using System.Drawing;

namespace ModdingTools.GUI
{
    public partial class ProcessRunner : UserControl
    {
        public delegate void OnAppClose(int code);
        private static OnAppClose AppClose = null;

        public delegate void OnAppRun();
        private static OnAppRun AppRun = null;

        public enum LogLevel
        {
            Verbose, Info, Success, Warn, Error
        }

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

        public bool RunApp(ExecutableArgumentsPair info, bool cleanConsole = true)
        {
            Debug.WriteLine(info.ToString());
            return RunApp(info.Executable, info.Arguments, info.WorkingDirectory, info.TaskName, info.OnFinish, cleanConsole);
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

                if (value == null) Text = "";
                else Text = value;
            }
        }

        private void RunWithoutWait(string exe, string[] args, string cwd = ".")
        {
            bool poggersMode = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
            if (poggersMode)
            {
                if (args.Length > 0 && args[0] == "editor")
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        Program.Benchmark = new Windows.Tools.Benchmark();
                        Program.Benchmark.StartPosition = FormStartPosition.CenterScreen;
                        Program.Benchmark.TopMost = true;
                        Program.Benchmark.Show();
                    }));
                }
            }
             

            Process process = new Process();
            process.StartInfo.FileName = exe;
            process.StartInfo.Arguments = string.Join(" ", args);
            process.StartInfo.WorkingDirectory = cwd;

            process.Start();

            if (poggersMode)
            {
                if (Program.Benchmark != null)
                {
                    Program.Benchmark.Start();
                }
            }
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
        private bool RunApp(string exe, string[] args, string cwd = ".", string taskName = "", Action o = null, bool cleanConsole = true)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                if (cleanConsole) textBox1.Clear();
                Log(taskName, LogLevel.Verbose);
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
                        var level = LogLevel.Info;
                        while (process != null && !process.HasExited)
                        {
                            string text = mLogPipe.Read();
                            //Debug.WriteLine(text);

                            if (text.StartsWith("`~[~`")) // control code
                            {
                                var raw = text.Split('`');
                                var code = raw[raw.Length - 1].Trim();

                                switch (code)
                                {
                                    case "Reset":
                                        level = LogLevel.Info;
                                        break;
                                    case "1111":
                                        level = LogLevel.Info;
                                        break;
                                    case "1101":
                                        level = LogLevel.Warn;
                                        break;
                                    case "1001":
                                        level = LogLevel.Error;
                                        break;
                                    case "0101":
                                        level = LogLevel.Success;
                                        break;
                                    default:
                                        Debug.WriteLine("Code not implemented: " + code);
                                        break;
                                }
                            }
                            else if (text.Length > 0)
                            {
                                Log(text.Replace("\r\n", ""), level);
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
                    Log("Process exited with exit code: " + process.ExitCode, process.ExitCode != 0 ? LogLevel.Warn : LogLevel.Verbose);
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

            return process.ExitCode == 0;
        }

        public void Log(string msg, LogLevel level)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => Log(msg, level)));
                return;
            }
            mButton3.Visible = true;

            var color = Color.White;
            switch(level)
            {
                case LogLevel.Error:
                    color = Color.Red;
                    break;
                case LogLevel.Warn:
                    color = Color.Yellow;
                    break;
                case LogLevel.Info:
                    color = Color.White;
                    break;
                case LogLevel.Success:
                    color = Color.Green;
                    break;
                case LogLevel.Verbose:
                    color = Color.Gray;
                    break;
            }

            AppendLoggerText($"[{GetLoggerDate()}][{level.ToString()}] {msg}{Environment.NewLine}", color);
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();

            MainWindow.Instance.SetModListStatus(msg.Trim('-'));
        }

        public void AppendLoggerText(string text, Color color)
        {
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.SelectionLength = 0;

            textBox1.SelectionColor = color;
            textBox1.AppendText(text);
            textBox1.SelectionColor = textBox1.ForeColor;
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