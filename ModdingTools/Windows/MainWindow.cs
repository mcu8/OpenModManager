using ModdingTools.GUI;
using ModdingTools.Modding;
using ModdingTools.Engine;
using ModManager.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

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
                try
                {
                    ModManagerPropertiesWrapper.Init();
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
                ModManagerPropertiesWrapper.LaunchPropertiesWindow(modListControl1.GetMod(modName));
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
        }
    }
}
