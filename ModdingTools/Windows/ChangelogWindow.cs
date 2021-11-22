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
        public ChangelogWindow()
        {
            InitializeComponent();
            webBrowser1.Navigate(BuildData.ChangeLogUrl);
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
