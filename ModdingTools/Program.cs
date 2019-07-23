using ModdingTools.UEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ModdingTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static readonly ProcessFactory ProcFactory = new ProcessFactory();

        [STAThread]
        static void Main()
        {
            //MessageBox.Show(new ModClass(@"C:\Program Files (x86)\Steam\steamapps\common\HatinTime\HatinTimeGame\Mods\SpaceMetro_map\Classes\SpaceMetro_DWTrains.uc").ToString());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
