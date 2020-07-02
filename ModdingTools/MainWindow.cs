using ModdingTools.GUI;
using ModdingTools.Modding;
using ModdingTools.UEngine;
using ModManager.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace ModdingTools
{
    public partial class MainWindow : BaseWindow
    {
        public static MainWindow Instance { get; private set; }

        public MainWindow()
        {
            if (!DesignMode)
            {
                try
                {
                    ModManagerProxy.Init();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("PECK >> " + e.Message + "\n" + e.ToString());
                }

                Utils.CleanUpTrash(GameFinder.FindGameDir());
            }

            Instance = this;
            InitializeComponent();

            ToggleConsole(false);

            modListControl1.AddModSource(new ModDirectorySource("Mods directory", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods"), true));
            modListControl1.AddModSource(new ModDirectorySource("Mods directory (disabled)", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods\Disabled"), true));

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
            processRunner1.Visible = v;
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
            if (!Program.Uploader.isRunning)
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
            var modPrompt = new TextInputForm("New mod", "Please enter mod folder name");

            modPrompt.StartPosition = FormStartPosition.CenterParent;

            if (modPrompt.ShowDialog() != DialogResult.OK)
                return;

            if (!Regex.IsMatch(modPrompt.Result, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Invalid characters in mod folder name - you can only use numbers and letters and _");
                return;
            }

            string modName = modPrompt.Result;
            string modPath = Path.Combine(modsRoot, modName);
            string modInfoPath = Path.Combine(modPath, "modinfo.ini");

            if (File.Exists(modInfoPath))
            {
                MessageBox.Show("There's already a mod with name \"" + modName + "\". Please delete it or set it up.");
                return;
            }

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
                ModManagerProxy.LaunchPropertiesWindow(modListControl1.GetMod(modName));
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
    }
}
