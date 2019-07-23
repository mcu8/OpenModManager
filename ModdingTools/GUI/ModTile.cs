using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModdingTools.Modding;

namespace ModdingTools.GUI
{
    public partial class ModTile : UserControl
    {
        public ModObject Mod { get; private set; }
        private Color OriginalColor;

        public ModTile(ModObject mod)
        {
            InitializeComponent();

            OriginalColor = this.BackColor;

            this.Mod = mod;
            this.panel1.BackgroundImage = mod.GetIcon();
            this.label1.Text = mod.Name + "\n(" + mod.GetDirectoryName() + ")";

            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            CheckBox1_CheckedChanged(null, null);

            this.MouseEnter += ModTile_MouseEnter;
            this.MouseLeave += ModTile_MouseLeave;

            this.panel1.MouseEnter += ModTile_MouseEnter;
            this.panel1.MouseLeave += ModTile_MouseLeave;

            this.label1.MouseEnter += ModTile_MouseEnter;
            this.label1.MouseLeave += ModTile_MouseLeave;

            checkBox1.Cursor = Cursors.Arrow;

            this.Click += ModTile_Click;
            this.panel1.Click += ModTile_Click;
            this.label1.Click += ModTile_Click;
        }

        private void ModTile_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = checkBox1.Checked ? ThemeConstants.BorderColor : ThemeConstants.TileUnselected;
        }

        private void ModTile_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = ControlPaint.Light(checkBox1.Checked ? ThemeConstants.BorderColor : ThemeConstants.TileUnselected);
        }

        private void ModTile_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                this.Checked = !this.Checked;
            }
            else
            {
                if (!this.Checked)
                {
                    var prop = new ModProperties(this.Mod);
                    prop.Show();
                }
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = checkBox1.Checked ? ThemeConstants.BorderColor : ThemeConstants.TileUnselected;
            this.Cursor = checkBox1.Checked ? Cursors.Arrow : Cursors.Hand;
        }

        public MainWindow GetParentForm()
        {
            return (MainWindow)this.ParentForm;
        }

        public bool Checked
        {
            get => checkBox1.Checked;
            set => checkBox1.Checked = value;
        }

        private void compileScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mod.CompileScripts(GetParentForm().Runner);
        }

        private void cookModToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mod.CookMod(GetParentForm().Runner);
        }

        private void titleScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mod.TestMod(GetParentForm().Runner);
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenInExplorer(Mod.RootPath);
        }
    }
}
