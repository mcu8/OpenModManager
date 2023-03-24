using CUFramework.Shared;
using ModdingTools.Headless;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using static ModdingTools.Engine.ProcessFactory;

namespace ModdingTools.Engine
{
    public abstract class AbstractProcessRunner
    {
        public delegate void OnAppClose(int code);
        protected static OnAppClose AppClose = null;

        public delegate void OnAppRun();
        protected static OnAppRun AppRun = null;

        public abstract void Log(string msg, LogLevel level);
        public abstract void SetText(string value);
        public abstract void PreAppRun(bool cleanConsole, string taskName);
        public abstract void PostAppRun();
        public abstract void FinishAppRun();
        public abstract void PreRunWithoutWait();

        public void RunAppAsync(ExecutableArgumentsPair info, bool cleanConsole = true, Action onSuccess = null)
        {
            Debug.WriteLine(info.ToString());
            SetText(info.TaskName);
            RunAppAsync(info.Executable, info.Arguments, info.WorkingDirectory, info.TaskName, info.OnFinish, cleanConsole, onSuccess);
        }

        public bool RunApp(ExecutableArgumentsPair info, bool cleanConsole = true)
        {
            Debug.WriteLine(info.ToString());
            return RunApp(info.Executable, info.Arguments, info.WorkingDirectory, info.TaskName, info.OnFinish, cleanConsole);
        }

        public void RunAppAsync(string exe, string[] args, string cwd = ".", string taskName = "", Action o = null, bool cleanConsole = true, Action onSuccess = null)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    RunApp(exe, args, cwd, taskName, onSuccess, cleanConsole);
                    o?.Invoke();
                }
                catch (Exception e)
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


        protected void RunWithoutWait(string exe, string[] args, string cwd = ".")
        {
            bool poggersMode = false;
            if (!ProgramHeadless.IsHeadlessMode)
                poggersMode = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
            if (poggersMode)
            {
                if (args.Length > 0 && args[0] == "editor")
                {
                    PreRunWithoutWait();      
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
                catch (Exception e)
                {
                    Debug.WriteLine("PECK >> " + e.Message + "\n" + e.ToString());
                }

                runningProcesses.Remove(proc);
            }
            SetText(null);
        }

        protected List<Process> runningProcesses = new List<Process>();
        protected bool RunApp(string exe, string[] args, string cwd = ".", string taskName = "", Action o = null, bool cleanConsole = true)
        {
            PreAppRun(cleanConsole, taskName);

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

            PostAppRun();
            

            AppClose?.Invoke(process.ExitCode);

            if (runningProcesses.Count == 0) SetText(null);

            FinishAppRun();
            o?.Invoke();

            return process.ExitCode == 0;
        }
    }
}
