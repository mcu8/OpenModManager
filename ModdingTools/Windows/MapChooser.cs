using CUFramework.Windows;
using ModdingTools.Modding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static ModdingTools.Windows.ModProperties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModdingTools.Windows
{
    public partial class MapChooser : CUWindow
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;

        private ModObject Mod;
        public MapChooser(ModObject o)
        {
            InitializeComponent();
            Mod = o;

            this.HandleCreated += MapChooser_HandleCreated;

            string lastMap = "";
            try
            {
                var flagFile = Path.Combine(Mod.RootPath, ".lastMap");
                if (File.Exists(flagFile))
                    lastMap = File.ReadAllText(flagFile);
            }
            catch (Exception)
            {
            }

            comboBox1.Items.Add(new MapItem("hub_spaceship", "Spaceship"));
            comboBox1.Items.Add(new MapItem("mafia_town", "Mafia Town"));
            comboBox1.Items.Add(new MapItem("hatintimeentry", "HatInTimeEntry"));
            comboBox1.Items.Add(new MapItem("??menu", "Main Menu"));
  
            var maps = Mod.GetCookedMaps();
            if (maps != null)
                foreach (var a in maps)
                {
                    comboBox1.Items.Add(new MapItem(a));
                    if (a.Equals(Mod.IntroductionMap, StringComparison.InvariantCultureIgnoreCase))
                    {
                        comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                    }
                }
            if (comboBox1.SelectedIndex < 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            if (string.IsNullOrEmpty(lastMap)) return;

            foreach(var x in comboBox1.Items)
            {
                var item = (MapItem)x;
                if (item.Name.Equals(lastMap, StringComparison.InvariantCultureIgnoreCase))
                {
                    comboBox1.SelectedItem = x;
                    break;
                }
            }
        }

        private void MapChooser_HandleCreated(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        public string GetSelectedMap()
        {
            return ((MapItem)comboBox1.SelectedItem).Name;
        }

        private void mButton9_Click(object sender, EventArgs e)
        {
            var item = (MapItem)comboBox1.SelectedItem;
            try
            {
                File.WriteAllText(Path.Combine(Mod.RootPath, ".lastMap"), item.Name);
            }
            catch (Exception) { }
            this.DialogResult = DialogResult.OK;
        }
    }
}
