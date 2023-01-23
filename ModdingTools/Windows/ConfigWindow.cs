using CUFramework.Windows;
using ModdingTools.Engine;
using ModdingTools.GUI;
using ModdingTools.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.Windows
{
    public partial class ConfigWindow : CUWindow
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
            checkBox1.Checked = !OMMSettings.Instance.AutoScanDownloadedMods;
            checkBox2.Checked = OMMSettings.Instance.Memes;
            checkBox4.Checked = OMMSettings.Instance.MultilangCook;
            checkBox3.Checked = OMMSettings.Instance.RmShaderOnCook;
            checkBox5.Checked = OMMSettings.Instance.UpdateCheck;
            checkBox6.Checked = OMMSettings.Instance.FastCook;
            checkBox7.Checked = OMMSettings.Instance.VSCIntegration;
            checkBox8.Checked = OMMSettings.Instance.KillGameBeforeCooking;
            checkBox9.Checked = OMMSettings.Instance.KillEditorBeforeCooking;
            checkBox10.Checked = OMMSettings.Instance.MafiaPunchGameToo;
        }

        private void SaveSettings()
        {
            OMMSettings.Instance.AutoScanDownloadedMods = !checkBox1.Checked;
            OMMSettings.Instance.Memes = checkBox2.Checked;
            OMMSettings.Instance.MultilangCook = checkBox4.Checked;
            OMMSettings.Instance.RmShaderOnCook = checkBox3.Checked;
            OMMSettings.Instance.UpdateCheck = checkBox5.Checked;
            OMMSettings.Instance.FastCook = checkBox6.Checked;
            OMMSettings.Instance.VSCIntegration = checkBox7.Checked;
            OMMSettings.Instance.KillGameBeforeCooking = checkBox8.Checked;
            OMMSettings.Instance.KillEditorBeforeCooking = checkBox9.Checked;
            OMMSettings.Instance.MafiaPunchGameToo = checkBox10.Checked;
            OMMSettings.Instance.Save();
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

        private void label1_Click(object sender, EventArgs e)
        {
            Utils.StartInDefaultBrowser("https://marketplace.visualstudio.com/items?itemName=EliotVU.uc");
        }
    }
}
