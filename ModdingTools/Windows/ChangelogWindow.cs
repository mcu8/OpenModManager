using CUFramework.Windows;
using ModdingTools.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.Windows
{
    public partial class ChangelogWindow : CUWindow
    {
        public ChangelogWindow(bool changelogOnly = false)
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.DocumentText = "<body style=\"background: #111111\"></body>";
            webBrowser1.Navigate(BuildData.ChangeLogUrl + "?ver=" + BuildData.CurrentVersion);
            if (changelogOnly)
            {
                this.IsResizable = true;
                this.IsCloseButtonEnabled = true;
                this.ControlBoxVisible = true;
                tableLayoutPanel1.Visible = false;
                label2.Visible = false;
                webBrowser1.Dock = DockStyle.Fill;
                this.Text = "CHANGELOG";
            }
        }

        private void cuButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void cuButton2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
