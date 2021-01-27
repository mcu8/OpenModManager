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
using CUFramework.Shared;
using CUFramework.Controls;

namespace ModdingTools.GUI
{
    public partial class ProcessRunner : UserControl
    {
        public GUIProcessRunner Runner { get; private set; }

        public ProcessRunner()
        {
            InitializeComponent();
            Runner = new GUIProcessRunner(this);

            SetText(null);
            mButton3.Visible = false;
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
                    MainWindow.Instance.GuiWorker.SetStatus(value);
                }

                if (value == null) Text = "";
                else Text = value;
            }
        }

        public void Log(string msg, LogLevel level)
        {
            if (level >= LogLevel.Info)
            {
                MainWindow.Instance.GuiWorker.SetStatus(msg, CUConsoleControl.GetLevelColor(level));
            }
            consoleControl1.Log(msg, level);
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            Runner.KillAllWorkers();
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            consoleControl1.Clear();
        }
    }
}