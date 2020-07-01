using ModdingTools.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools
{
    public partial class ConfigWindow : BaseWindow
    {
        public ConfigWindow()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                LoadSettings();
            }
        }

        private void LoadSettings()
        {
            checkBox1.Checked = !Properties.Settings.Default.AutoScanDownloadedMods;
            checkBox2.Checked = Properties.Settings.Default.Memes;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.AutoScanDownloadedMods = !checkBox1.Checked;
            Properties.Settings.Default.Memes = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }
    }
}
