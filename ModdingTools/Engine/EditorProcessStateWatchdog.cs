using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ModdingTools.Engine
{
    internal class EditorProcessStateWatchdog
    {
        public bool IsEditorRunning { get; private set; }

        public event EventHandler EditorStateChanged;

        public EditorProcessStateWatchdog() {
            var th = new Thread(ThreadWorker);
            th.IsBackground = true;
            th.Start();
        }

        private void ThreadWorker()
        {
            while (true)
            {
                try
                {
                    var x = Process.GetProcessesByName("HatinTimeEditor");
                    var isRunning = x != null && x.Length > 0;
                    if (isRunning != IsEditorRunning)
                    {
                        IsEditorRunning = isRunning;
                        // trigger state change
                        EditorStateChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
                catch (Exception) { } // nah
                Thread.Sleep(5000);
            }
        }
    }
}
