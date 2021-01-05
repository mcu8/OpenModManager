using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModdingTools.Modding;
using ModdingTools.Engine;
using ModdingTools.Windows;
using System.Diagnostics;
using CUFramework.Controls;
using CUFramework.Dialogs;

namespace ModdingTools.GUI
{
    public partial class ModTile : UserControl
    {
        public ModObject Mod { get; private set; }
        private Color OriginalColor;

        public ModTile(ModObject mod)
        {
            InitializeComponent();

            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new CUMenuColorTable());
            contextMenuStrip1.BackColor = ThemeConstants.BackgroundColor;
            contextMenuStrip1.ForeColor = ThemeConstants.ForegroundColor; 

            OriginalColor = this.BackColor;

            this.Mod = mod;
            this.panel1.BackgroundImage = mod.GetIcon();
            this.label1.Text = mod.Name + "\n(" + mod.GetDirectoryName() + ")";

            this.panel2.Visible = mod.IsReleased;

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

            scriptWatcherToolStripMenuItem2.Checked = ScriptWatcherManager.IsWatcherAttached(Mod);

            RevalidateBG();
        }

        private void RevalidateBG(ToolStripItemCollection col = null)
        {
            if (col == null)
                col = contextMenuStrip1.Items;
            foreach (var item in col)
            {
                if (item is ToolStripMenuItem)
                {
                    var it = ((ToolStripMenuItem)item);
                    it.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    it.BackColor = ThemeConstants.BackgroundColor;
                    it.ForeColor = ThemeConstants.ForegroundColor;

                    if (it.HasDropDownItems)
                    {
                        RevalidateBG(it.DropDownItems);
                    }
                }
            }
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
                    this.Mod.Refresh();
                    var mp = ModProperties.GetPropertiesWindowForMod(this.Mod);
                    if (mp != null) {  
                        mp.Show();
                        mp.WindowState = FormWindowState.Normal;
                        mp.Focus();
                    }
                    else
                    {
                        var props = new ModProperties(this.Mod);
                        props.StartPosition = FormStartPosition.CenterParent;
                        props.ToCenterParent = this.ParentForm;
                        props.Show();
                    }
                    //prop.Show();
                }
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = checkBox1.Checked ? ThemeConstants.BorderColor : ThemeConstants.TileUnselected;
            this.Cursor = checkBox1.Checked ? Cursors.Arrow : Cursors.Hand;
        }

        public bool Checked
        {
            get => checkBox1.Checked;
            set => checkBox1.Checked = value;
        }

        private void compileScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mod.CompileScripts(MainWindow.Instance.Runner);
        }

        private void cookModToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mod.CookMod(MainWindow.Instance.Runner);
        }

        private void titleScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mod.TestMod(MainWindow.Instance.Runner);
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenInExplorer(Mod.RootPath);
        }

        private void moveoToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var menu = moveToToolStripMenuItem;
            menu.DropDownItems.Clear();
            foreach (var modSource in MainWindow.Instance.GetModSources())
            {
                if ((modSource.IsReadOnly && modSource.Name != "Mods directory (disabled)") || Mod.RootSource == modSource)
                    continue;

                var item = new ToolStripMenuItem(modSource.Name, null, (obj, args) => {
                    var o = (ToolStripMenuItem)obj;
                    var t = (ModDirectorySource)o.Tag;
                    this.Mod.ChangeModSource(t);

                    MainWindow.Instance.ReloadModList();
                });

                item.Name = modSource.Name;
                item.Text = modSource.Name;
                item.Tag = modSource;

                menu.DropDownItems.Add(item);
            }
            RevalidateBG();
        }

        private void mafiaTownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mod.TestMod(MainWindow.Instance.Runner, "mafia_town");
        }

        private void spaceshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mod.TestMod(MainWindow.Instance.Runner, "hub_spaceship");
        }

        private void scriptWatcherToolStripMenuItem2_Click(object sender, EventArgs e)
        { 
            if (ScriptWatcherManager.IsWatcherAttached(Mod))
            {
                ScriptWatcherManager.DetachWatcher(Mod);
            }
            else
            {
                ScriptWatcherManager.AttachWatcher(Mod);
            }

            scriptWatcherToolStripMenuItem2.Checked = ScriptWatcherManager.IsWatcherAttached(Mod);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            CleanupTests();

            cookModToolStripMenuItem.Enabled = !Mod.IsReadOnly;
            testModToolStripMenuItem.Enabled = !Mod.IsReadOnly;
            scriptingToolStripMenuItem.Enabled = !Mod.IsReadOnly;

            var test = new ContentBrowser();
            test.LoadMod(Mod);

            var result = test.HasContentError;
            test.Dispose();

            bool flag5 = Utils.DirContainsKey(Mod.GetCookedDir(), "*.u") || Utils.DirContainsKey(Mod.GetCookedDir(), "*.umap");
            var cooked = (flag5 || Mod.IsLanguagePack) && !result;

            compileScriptsToolStripMenuItem.Enabled = !Mod.IsReadOnly && !result && Mod.HasAnyScripts();
            cookModToolStripMenuItem1.Enabled = !Mod.IsReadOnly && !result && !(!Mod.HasCompiledScripts() && Mod.HasAnyScripts());
            testModToolStripMenuItem.Enabled = cooked && !Mod.IsReadOnly;

            if (Mod.HasAnyMaps() && testModToolStripMenuItem.Enabled)
            {
                testModToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator() {Tag = "toDelete", BackColor = ThemeConstants.BackgroundColor });
                foreach (var map in Mod.GetCookedMaps())
                {
                    var item = new ToolStripMenuItem() { Tag = "toDelete", Text = map };
                    item.Click += (s, a) =>
                    {
                        var y = (ToolStripMenuItem)s;
                        Mod.TestMod(MainWindow.Instance.Runner, y.Text);
                    };
                    testModToolStripMenuItem.DropDownItems.Add(item);
                }
            }
            RevalidateBG();
        }

        private void CleanupTests()
        {
            List<object> pendingRemoval = new List<object>();
            foreach (var i in testModToolStripMenuItem.DropDownItems)
            {
                if (((ToolStripItem)i).Tag == null) continue;
                if (((ToolStripItem)i).Tag.ToString().Equals("toDelete"))
                {
                    pendingRemoval.Add(i);
                }
            }
            foreach (var i in pendingRemoval)
            {
                testModToolStripMenuItem.DropDownItems.Remove((ToolStripItem)i);
            }
        }

        private void deleteModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = CUMessageBox.Show(null, "Do you REALLY want to delete '" + Mod.Name + "'?\nThis CANNOT BE UNDONE!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
            if (result == DialogResult.Yes)
            {
                Mod.Delete();
                MainWindow.Instance.ReloadModList();
            }
        }

        private void hatInTimeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mod.TestMod(MainWindow.Instance.Runner, "hatintimeentry");
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Process.Start("steam://openurl/http://steamcommunity.com/sharedfiles/filedetails/?id=" + Mod.GetUploadedId());
        }
    }
}
