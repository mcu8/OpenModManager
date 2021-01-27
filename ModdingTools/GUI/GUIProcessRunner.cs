using CUFramework.Shared;
using ModdingTools.Engine;
using ModdingTools.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    public class GUIProcessRunner : AbstractProcessRunner
    {
        ProcessRunner Parent;
        public GUIProcessRunner(ProcessRunner parent)
        {
            this.Parent = parent;
        }

        public override void FinishAppRun()
        {
            Parent.Invoke(new MethodInvoker(() =>
            {
                MainWindow.Instance.ToggleConsole(false);
            }));
        }

        public override void Log(string msg, LogLevel level)
        {
            Parent.Log(msg, level);
        }

        public override void PostAppRun()
        {
            if (runningProcesses.Count == 0)
                Parent.Invoke(new MethodInvoker(() =>
                {
                    Parent.mButton3.Visible = false;
                }));
        }

        public override void PreAppRun(bool cleanConsole, string taskName)
        {
            Parent.Invoke(new MethodInvoker(() =>
            {
                if (cleanConsole) Parent.consoleControl1.Clear();
                Parent.consoleControl1.Log(taskName, LogLevel.Verbose);
                MainWindow.Instance.CallWorker();
                Parent.mButton3.Visible = true;
            }));
        }

        public override void PreRunWithoutWait()
        {
            Parent.Invoke(new MethodInvoker(() =>
            {
                Program.Benchmark = new Windows.Tools.Benchmark();
                Program.Benchmark.StartPosition = FormStartPosition.CenterScreen;
                Program.Benchmark.TopMost = true;
                Program.Benchmark.Show();
            }));
        }

        public override void SetText(string value)
        {
            Parent.SetText(value);
        }
    }
}
