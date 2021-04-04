using ModdingTools.GUI;
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
using CUFramework.Windows;
using CUFramework.Dialogs;
using CUFramework.Controls;
using ModdingTools.Windows.Validators;
using Steamworks;

namespace ModdingTools.Windows
{
    public partial class MainWindow : CUWindow
    {
        public static MainWindow Instance { get; private set; }
        private UpdateChecker UpdateChk;

        private ModListControl modListControl1;
        private ProcessRunner processRunner1;
        public GUIWorker GuiWorker { get; private set; }

        // Don't ask, just add :)
        private string[] FunnyTexts = new[] { 
            "GAMEDAT ANNIVERSARY EDITION",
            ":S_:",
            "MODDING",
            "GAMING",
            "LOWRESMU EDITION",
            "NOT CRASH MY EDITOR EDITION",
            "HUEH",
            "HEUH",
            "RIFT COLLAPSE, OR UR KNEECAPS ~ SuperInkLink 2020",
            "PLAY FAREWELL",
            "DO NOT RESEARCH",
            "CHAT, SAY POGGERS",
            "ALWAYSLOADED",
            "FATAL ERROR 0x0"
        };

        public enum CardControllerTabs
        {
            Mods, Console, Worker
        }

        public MainWindow()
        {
            if (!DesignMode)
                Utils.CleanUpTrash(GameFinder.FindGameDir());

            Instance = this;
            InitializeComponent();

            this.Text = "OPEN MOD MANAGER - FOR A HAT IN TIME  [" + FunnyTexts[new Random().Next(FunnyTexts.Length)] + "]";

            GuiWorker = new GUIWorker(); // must be first!
            cardController1.AddCard(CardControllerTabs.Worker.ToString().ToLower(), GuiWorker);

            modListControl1 = new ModListControl();
            cardController1.AddCard(CardControllerTabs.Mods.ToString().ToLower(), modListControl1);

            processRunner1 = new ProcessRunner();  
            cardController1.AddCard(CardControllerTabs.Console.ToString().ToLower(), processRunner1);   

            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new CUMenuColorTable());

            this.TitlebarColorChanged += MainWindow_TitlebarColorChanged;
            this.Shown += MainWindow_Shown;
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Delay(LoadModCategories, 100);
        }

        private void MainWindow_TitlebarColorChanged(object sender, EventArgs e)
        {
            mButton6.BackColor = mButton5.BackColor = mButton2.BackColor = VisibleTitlebarColor;
            mButton6.FlatAppearance.BorderColor = mButton5.FlatAppearance.BorderColor = mButton2.FlatAppearance.BorderColor = VisibleTitlebarColor;
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

        public AbstractProcessRunner Runner => processRunner1.Runner;

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

        private void mButton4_Click(object sender, EventArgs e)
        {
            string modsRoot = Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods");
            var modName = CUInputWindow.Ask(this, "New mod", "Please enter a mod folder name", new ModNameValidator());

            if (modName == null)
                return;

            string modPath = Path.Combine(modsRoot, modName);
            string modInfoPath = Path.Combine(modPath, "modinfo.ini");

            Directory.CreateDirectory(modPath);
            Directory.CreateDirectory(Path.Combine(modPath, "Classes"));
            Directory.CreateDirectory(Path.Combine(modPath, "Content"));
            Directory.CreateDirectory(Path.Combine(modPath, "Maps"));
            Directory.CreateDirectory(Path.Combine(modPath, "Localization"));
            Directory.CreateDirectory(Path.Combine(modPath, "Localization", "INT"));

            using (StreamWriter sW = File.CreateText(modInfoPath))
            {
                sW.WriteLine("[Info]");
                sW.WriteLine("name=" + modName);
                sW.WriteLine("author=\"" + SteamFriends.GetPersonaName().Replace("\"", "\\\"") + "\"");
                sW.WriteLine("description=\"Hello this is my all new mod!\"");
                sW.WriteLine("version=\"1.0.0\"");
                sW.WriteLine("is_cheat=false");
                sW.WriteLine("icon=icon.jpg");
            }

            modListControl1.ReloadList(() => {
                var mod = modListControl1.GetMod(modName);
                var mp = ModProperties.GetPropertiesWindowForMod(mod);
                if (mp != null)
                {
                    mp.Show();
                    mp.WindowState = FormWindowState.Normal;
                    mp.Focus();
                }
                else
                {
                    mp = new ModProperties(mod);
                    mp.StartPosition = FormStartPosition.CenterParent;
                    mp.Show(this.FindForm());
                }
            });
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            var conf = new ConfigWindow();
            conf.StartPosition = FormStartPosition.CenterParent;
            conf.ShowDialog();
        }

        private void mTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (mTextBox1.Enabled)
                modListControl1.Filter(mTextBox1.Text);
        }

        private void MainWindow_ResizeBegin(object sender, EventArgs e)
        {
           // modListControl1.SuspendLayout();
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            
            //modListControl1.ResumeLayout();
        }

        private void MainWindow_Load(object z, EventArgs x)
        {
            GuiWorker.SetTextOrHideOnNull("Loading...");
            CallWorker();//SetCard(CardControllerTabs.Worker);

            //SetCard(CardControllerTabs.Worker);

            Debug.WriteLine("Setup update checker...");

            UpdateChk = new UpdateChecker(BuildData.CurrentVersion, BuildData.UpdateUrl, new Action(() => {
                this.Invoke(new MethodInvoker(() =>
                {
                    var dialog = CUMessageBox.Show(this, "New version of OpenModManager is avaiable!\nDo you want to download it?", "Update checker", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes)
                    {
                        Process.Start(BuildData.ReleasesPage);
                    }
                }));
            }));

            Automation.AddAutomationEventHandler(
                WindowPattern.WindowOpenedEvent,
                AutomationElement.RootElement,
                TreeScope.Children,
            (sender, e) =>
            {
                var element = sender as AutomationElement;
                Console.WriteLine("new window opened");
            });

            UpdateChk.CheckForUpdatesAsync();
        }

        public void LoadModCategories()
        {
            
            modListControl1.AddModSource(new ModDirectorySource("Mods directory", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods"), true));
            modListControl1.AddModSource(new ModDirectorySource("Mods directory (disabled)", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods\Disabled"), true, true, true));

            var autoLoad = Properties.Settings.Default.AutoScanDownloadedMods;

            modListControl1.AddModSource(new ModDirectorySource("Downloaded mods", GameFinder.GetWorkshopDir(), autoLoad, false, true));
            modListControl1.AddModSource(new ModDirectorySource("Downloaded mods (disabled)", Path.Combine(GameFinder.GetWorkshopDir(), "Disabled"), autoLoad, false, true));
            
            modListControl1.ReloadList(() => {
                SetCard(CardControllerTabs.Mods);
            });
        }

        public void SetCard(CardControllerTabs tab)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => SetCard(tab)));
                return;
            }
            if (tab != CardControllerTabs.Worker)
            {
                GuiWorker.SetProgress(0, "...");
            }
            panel1.Visible = (tab == CardControllerTabs.Mods);
            cardController1.SetCard(tab.ToString().ToLower());
        }

        private void mButton5_Click(object sender, EventArgs e)
        {
            SetCard(cardController1.CurrentCard == processRunner1 ? CardControllerTabs.Mods : CardControllerTabs.Console);
            mButton5.BackColor = cardController1.CurrentCard == modListControl1 ? Color.Black : ThemeConstants.BorderColor;
        }

        private void mButton6_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.ForeColor = Color.White;
            mButton6.BackColor = ThemeConstants.BorderColor;
            contextMenuStrip1.Show(new Point(Location.X + mButton6.Location.X, Location.Y + mButton6.Location.Y + mButton6.Height));
        }

        private void assetExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var w = new AssetRipper();
            w.StartPosition = FormStartPosition.CenterParent;
            w.ShowDialog(this);
        }

        private void flipbookGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var w = new FlipbookGenerator();
            w.StartPosition = FormStartPosition.CenterParent;
            w.ShowDialog(this);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            mButton6.BackColor = Color.Black;
        }

        public void FocusMe()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Focus();
        }

        public void CallWorker()
        {
            ToggleSearchBar(false);
            SetCard(MainWindow.CardControllerTabs.Worker);
        }

        private void cuButton1_Click(object sender, EventArgs e)
        {
            var w = new AboutWindow();
            w.StartPosition = FormStartPosition.CenterParent;
            w.ShowDialog(this);
        }
    }
}
