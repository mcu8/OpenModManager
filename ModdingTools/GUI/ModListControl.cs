using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModdingTools.Engine;
using ModdingTools.Modding;
using ModdingTools.Windows;

namespace ModdingTools.GUI
{
    public partial class ModListControl : UserControl
    {
        public ModListControl()
        {
            InitializeComponent();
            flowLayoutPanel1.Resize += ModListControl_SizeChanged;
            if (DesignMode || Utils.IsVSDesignMode()) panel1.Visible = false;
        }

        private void ModListControl_SizeChanged(object sender, EventArgs e)
        {
            //TriggerUpdate();
        }

        public void TriggerUpdate()
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is CategorySpacer)
                {
                    ((CategorySpacer)ctrl).Width = this.Width - 10 - SystemInformation.VerticalScrollBarWidth;
                }

                if (ctrl is ModTile)
                {
                    RevalidateTile((ModTile)ctrl);
                }
            }
            flowLayoutPanel1.ResumeLayout();
            //flowLayoutPanel1.Update();
        }

        public void RevalidateTile(ModTile tile)
        {
            int offset = 6;
            int xa = 150;
            int width = this.Width - 10 - SystemInformation.VerticalScrollBarWidth;
            int cols = width / (xa + offset);
            int extra = (width - ((xa + offset) * cols));
            int extraAdd = cols > 0 ? extra / cols : 0;
            tile.Width = xa + extraAdd;
        }

        List<ModDirectorySource> sources = new List<ModDirectorySource>();
        public void AddModSource(ModDirectorySource source)
        {
            sources.Add(source);
        }

        public ModDirectorySource[] GetModDirectorySources()
        {
            return sources.ToArray();
        }

        public void RemoveModSource(ModDirectorySource source)
        {
            sources.Remove(source);
        }

        public void ReloadList(Action a = null)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel1.SuspendLayout();
            this.BackgroundImage = Properties.Resources.loading_text;
            Task.Factory.StartNew(() =>
            {

                int i1 = 0;
                int i2 = 0;

                foreach (var source in sources)
                {
                    var mods = source.GetMods();
                    i1 += mods.Length;

                    if (mods.Length > 0)
                    {
                        var space = new CategorySpacer(source.Name, source.Root);
                        space.ToggleState = source.Enabled;
                        space.Width = this.Width - 20 - SystemInformation.VerticalScrollBarWidth;
                        space.HeaderClick += Space_Click;
                        space.Toggle += Toggle;

                        this.Invoke(new MethodInvoker(() =>
                        {  
                            flowLayoutPanel1.Controls.Add(space);
                        }));
                        List<ModTile> tiles = new List<ModTile>();
                        foreach (var d in mods)
                        {
                            i2++;
                            SetStatus("Loading mod " + d.Name + " [" + i2 + " of " + i1 + "]"); 
                            
                            var tile = new ModTile(d);
                            tile.Visible = source.Enabled;
                            tile.Tag = space;
                            RevalidateTile(tile);
                            this.Invoke(new MethodInvoker(() =>
                            {       
                                tiles.Add(tile);
                            }));
                        }
                        var arr = tiles.ToArray();
                        this.Invoke(new MethodInvoker(() =>
                        {
                            flowLayoutPanel1.Controls.AddRange(arr);
                        }));  
                    }
                }
                this.Invoke(new MethodInvoker(() => {
                    flowLayoutPanel1.Visible = true;
                    flowLayoutPanel1.ResumeLayout();
                    this.BackgroundImage = null;
                    SetStatus("Loaded " + i1 + " elements!");
                    SetWorker(null);
                    a?.Invoke();
                }));
            });
           
        }

        public void Filter(string text)
        {
            flowLayoutPanel1.SuspendLayout();
            Task.Factory.StartNew(() =>
            {
                foreach (var ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is ModTile)
                    {
                        var vis = String.IsNullOrEmpty(text.Trim()) ? true : ((ModTile)ctrl).Mod.Name.ToLower().Replace(" ", "").Replace("-", "").Contains(text.ToLower().Replace(" ", "").Replace("-", ""));
                        this.Invoke(new MethodInvoker(() => ((ModTile)ctrl).Visible = vis));
                    }
                }
                this.Invoke(new MethodInvoker(() => flowLayoutPanel1.ResumeLayout()));
            });
        }

        public ModObject GetMod(string dirName)
        {
            foreach (var c in flowLayoutPanel1.Controls)
            {
                if (c is ModTile)
                {
                    var tmp = (ModTile)c;
                    if (tmp.Mod.GetDirectoryName().Equals(dirName))
                    {
                        return tmp.Mod;
                    }
                }
            }
            return null;
        }

        public ModObject[] GetSelectedMods()
        {
            List<ModObject> objects = new List<ModObject>();
            foreach (var ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is ModTile)
                {
                    var tile = (ModTile)ctrl;
                    if (tile.Visible && tile.Checked)
                    {
                        objects.Add(tile.Mod);
                    }
                }
            }
            return objects.ToArray();
        }

        public ModObject[] GetVisibleMods()
        {
            List<ModObject> objects = new List<ModObject>();
            foreach (var ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is ModTile)
                {
                    var tile = (ModTile)ctrl;
                    if (tile.Visible)
                    {
                        objects.Add(tile.Mod);
                    }
                }
            }
            return objects.ToArray();
        }

        private void Toggle(CategorySpacer sender, bool e)
        {
            flowLayoutPanel1.Visible = false;
            foreach (var ct in flowLayoutPanel1.Controls)
            {
                if (ct is ModTile)
                {
                    var o = (ModTile)ct;
                    if (sender.Equals(o.Tag))
                    {
                        o.Visible = e;
                    }
                }
            }
            flowLayoutPanel1.Visible = true;
            TriggerUpdate();
        }

        private void Space_Click(CategorySpacer sender)
        {
            foreach (var ct in flowLayoutPanel1.Controls)
            {
                if (ct is ModTile)
                {
                    var o = (ModTile)ct;
                    if (sender.Equals(o.Tag))
                    {
                        if (o.Visible)
                            o.Checked = !sender.SelectionMode;
                    }
                }
            }
            sender.SelectionMode = !sender.SelectionMode;
            flowLayoutPanel1.Update();
        }

        private void mButtonBorderless1_Click(object sender, EventArgs e)
        {
            ReloadList();
        }

        public void SetStatus(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => SetStatus(text)));
                return;
            }

            SetWorker(text);
            label1.Text = text == null ? "" : text;
        }

        private void mButtonBorderless2_Click(object sender, EventArgs e)
        {
            var mods = GetSelectedMods();
            Task.Factory.StartNew(() =>
            {
                SetStatus("Starting mod cooking...");
                int i = 1;
                foreach (var mod in mods)
                {
                    SetStatus("Cooking mod: " + mod.Name + " [" + i + "/" + mods.Length + "]");
                    mod.CookMod(MainWindow.Instance.Runner, false);
                    i++;
                }
                SetStatus(null);
            });
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void SetWorker(string text = null)
        {
            if (text == null)
            {
                panel1.Visible = false;
                MainWindow.Instance.ToggleSearchBar(true);
            }
            else
            {
                MainWindow.Instance.ToggleSearchBar(false);
                panel1.Visible = true;
                label3.Text = text;
            }
        }
    }
}
