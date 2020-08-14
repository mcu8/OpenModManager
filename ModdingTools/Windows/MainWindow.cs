﻿using ModdingTools.GUI;
using ModdingTools.Modding;
using ModdingTools.Engine;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using ModdingTools.Windows.Tools;
using System.Drawing;

namespace ModdingTools.Windows
{
    public partial class MainWindow : BaseWindow
    {
        public static MainWindow Instance { get; private set; }
        private UpdateChecker UpdateChk;

        public MainWindow()
        {
            if (!DesignMode)
            {
                Utils.CleanUpTrash(GameFinder.FindGameDir());
            }  

            Instance = this;
            InitializeComponent();

            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());

            ToggleConsole(false);

            modListControl1.AddModSource(new ModDirectorySource("Mods directory", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods"), true));
            modListControl1.AddModSource(new ModDirectorySource("Mods directory (disabled)", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods\Disabled"), true, true, true));

            var autoLoad = Properties.Settings.Default.AutoScanDownloadedMods;

            modListControl1.AddModSource(new ModDirectorySource("Downloaded mods", GameFinder.GetWorkshopDir(), autoLoad, false, true));
            modListControl1.AddModSource(new ModDirectorySource("Downloaded mods (disabled)", Path.Combine(GameFinder.GetWorkshopDir(), "Disabled"), autoLoad, false, true));

            modListControl1.ReloadList();

            SetModListState(null);

            Automation.AddAutomationEventHandler(
            WindowPattern.WindowOpenedEvent,
            AutomationElement.RootElement,
            TreeScope.Children,
            (sender, e) =>
            {
                var element = sender as AutomationElement;

                Console.WriteLine("new window opened");
            });

            UpdateChk = new UpdateChecker(BuildData.CurrentVersion, BuildData.UpdateUrl, new Action(() => {
                this.Invoke(new MethodInvoker(() =>
                {
                    var dialog = GUI.MessageBox.Show(this, "New version of OpenModManager is avaiable!\nDo you want to download it?", "Update checker", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes)
                    {
                        Process.Start(BuildData.ReleasesPage);
                    }
                }));
            }));
        }

        public ModDirectorySource[] GetModSources()
        {
            return modListControl1.GetModDirectorySources();
        }

        public void ToggleSearchBar(bool v)
        {
            mTextBox1.Enabled = v;
            if (!v)
            {
                mTextBox1.Text = "";
            }
        }

        public void ToggleConsole(bool v)
        {
            modListControl1.Visible = !v;
        }

        public ProcessRunner Runner => processRunner1;

        private void mButton1_Click(object sender, System.EventArgs e)
        {
            Runner.RunWithoutWait(Program.ProcFactory.LaunchEditor());
        }

        public void ReloadModList()
        {
            modListControl1.ReloadList(); 
        }

        private void mButton3_Click(object sender, System.EventArgs e)
        {
            Runner.KillAllWorkers();
            Utils.KillEditor();
            Meme.StopElevatorMusic();
            if (!Program.Uploader.IsUploaderRunning)
                ToggleConsole(false);
        }

        public void SetModListState(string value)
        {
            if (modListControl1 == null)
                return;

            modListControl1.SetWorker(value);
        }

        public void SetModListStatus(string value)
        {
            if (modListControl1 == null)
                return;

            modListControl1.SetStatus(value);
        }

        private void mButton4_Click(object sender, EventArgs e)
        {
            string modsRoot = Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods");
            var modName = InputWindow.Ask("New mod", "Please enter mod folder name", new InputWindow.ModNameValidator());

            if (modName == null)
                return;

            string modPath = Path.Combine(modsRoot, modName);
            string modInfoPath = Path.Combine(modPath, "modinfo.ini");

            Directory.CreateDirectory(modPath);

            using (StreamWriter sW = File.CreateText(modInfoPath))
            {
                sW.WriteLine("[Info]");
                sW.WriteLine("name=" + modName);
                sW.WriteLine("author=\"Me\"");
                sW.WriteLine("description=\"Hello this is my all new mod!\"");
                sW.WriteLine("version=\"1.0.0\"");
                sW.WriteLine("is_cheat=false");
                sW.WriteLine("icon=icon.jpg");
            }

            modListControl1.ReloadList(() => {
                new ModProperties(modListControl1.GetMod(modName)).Show();
            });
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            new ConfigWindow().ShowDialog();
        }

        private void mTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (mTextBox1.Enabled)
                modListControl1.Filter(mTextBox1.Text);
        }

        private void MainWindow_ResizeBegin(object sender, EventArgs e)
        {
            modListControl1.SuspendLayout();
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {

            modListControl1.Width += 1;
            modListControl1.Width -= 1;
            modListControl1.TriggerUpdate();
            modListControl1.ResumeLayout();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            UpdateChk.CheckForUpdatesAsync();
        }

        private void mButton5_Click(object sender, EventArgs e)
        {
            borderlessTabControl1.SelectedIndex = borderlessTabControl1.SelectedIndex == 0 ? 1 : 0;
            mButton5.BackColor = borderlessTabControl1.SelectedIndex == 0 ? Color.Black : ThemeConstants.BorderColor;
        }

        private void mButton6_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.ForeColor = Color.White;
            mButton6.BackColor = ThemeConstants.BorderColor;
            contextMenuStrip1.Show(new Point(Location.X + mButton6.Location.X, Location.Y + mButton6.Location.Y + mButton6.Height));
        }

        private void assetExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AssetRipper().ShowDialog(this);
        }

        private void flipbookGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FlipbookGenerator().ShowDialog(this);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            mButton6.BackColor = Color.Black;
        }
    }
}
