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
        public MainWindow()
        {
            InitializeComponent();

            modListControl1.AddModSource(new ModDirectorySource("Mods directory", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods")));
            modListControl1.AddModSource(new ModDirectorySource("Downloaded mods", GameFinder.GetWorkshopDir(), false));

            modListControl1.ReloadList();
        }

        public ProcessRunner Runner => processRunner1;

        private void mButton1_Click(object sender, System.EventArgs e)
        {
            Runner.RunWithoutWait(Program.ProcFactory.LaunchEditor());
        }
    }
}
