using CUFramework.Windows;
using ModdingTools.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModdingTools.Windows.Tools
{
    public partial class Benchmark : CUWindow
    {
        public Benchmark()
        {
            InitializeComponent(); 
        }

        bool closing = false;

        Stopwatch sw = new Stopwatch();
        public void Start()
        {
            sw.Start();

            Task.Factory.StartNew(() =>
            {
                while(sw.IsRunning)
                {
                    if (closing) return;
                    try
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            label1.Text = sw.Elapsed.ToString(@"hh\:mm\:ss\.fff");
                        }));
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    Thread.Sleep(10);
                }
                this.Invoke(new MethodInvoker(() =>
                {
                    label1.ForeColor = Color.Green;
                }));
            });
        }

        public void Stop()
        {
            sw.Stop();
        }

        private void Benchmark_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
        }
    }
}
