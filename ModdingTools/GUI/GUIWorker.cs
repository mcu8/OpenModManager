using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModdingTools.Windows;

namespace ModdingTools.GUI
{
    public partial class GUIWorker : UserControl
    {
        public GUIWorker()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        public void SetStatus(string text)
        {
            SetStatus(text, Color.Empty);
        }

        public void SetProgress(int value, string text = null)
        {
            if (text == null) text = $"{value}%";
            huehProgressBar1.Value = value;
            huehProgressBar1.Text = text;
        }

        public void SetStatus(string text, Color color)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => SetStatus(text, color)));
                return;
            }

            SetTextOrHideOnNull(color, text);
        }

        public void SetTextOrHideOnNull(string text = null)
        {
            SetTextOrHideOnNull(Color.Empty, text);
        }

        public void SetTextOrHideOnNull(Color color, string text = null)
        {
            if (text == null)
            {
                MainWindow.Instance.SetCard(MainWindow.CardControllerTabs.Mods);
                MainWindow.Instance.ToggleSearchBar(true);
            }
            else
            {
                cuGradientTextBox1.Insert(text, color);
            }
        }
    }
}
