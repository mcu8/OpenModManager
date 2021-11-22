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
    public partial class AboutWindow : CUWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
            label3.Text = $"App build number: {BuildData.CurrentVersion}";
        }

        private void cuButton2_Click(object sender, EventArgs e)
        {
            Utils.StartInDefaultBrowser("https://hat.ovh");
        }

        private void cuButton3_Click(object sender, EventArgs e)
        {
            Utils.StartInDefaultBrowser("https://github.com/mcu8/OpenModManager");
        }

        private void cuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cuButton4_Click(object sender, EventArgs e)
        {
            Utils.StartInDefaultBrowser("https://twitter.com/mcu82");
        }

        private void cuButton5_Click(object sender, EventArgs e)
        {
            Process.Start("steam://openurl/https://steamcommunity.com/id/m_cu8/myworkshopfiles/?appid=253230");
        }

        private void cuButton6_Click(object sender, EventArgs e)
        {
            new ChangelogWindow(true).ShowDialog(this);
        }
    }
}
