using ModdingTools.GUI;
using ModdingTools.Modding;
using ModdingTools.UEngine;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModdingTools
{
    public partial class MainWindow : BaseWindow
    {
        public static MainWindow Instance { get; private set; }

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();

            modListControl1.AddModSource(new ModDirectorySource("Mods directory", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods")));
            modListControl1.AddModSource(new ModDirectorySource("Mods directory (disabled)", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods\Disabled")));
            modListControl1.AddModSource(new ModDirectorySource("Downloaded mods", GameFinder.GetWorkshopDir(), false, true));
            modListControl1.AddModSource(new ModDirectorySource("Downloaded mods (disabled)", Path.Combine(GameFinder.GetWorkshopDir(), "Disabled"), false, true));

            modListControl1.ReloadList();
        }

        public ModDirectorySource[] GetModSources()
        {
            return modListControl1.GetModDirectorySources();
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
            Utils.KillEditor();
        }
    }
}
