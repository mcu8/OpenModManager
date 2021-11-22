using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModdingTools.Engine;
using ModdingTools.Modding;
using ModdingTools.Windows;

namespace ModdingTools.GUI
{
    public partial class ModListControl : UserControl
    {
        public List<ModTile> TileCache = new List<ModTile>();
        Timer _timer = new Timer();

        public ModListControl()
        {
            InitializeComponent();
            label5.Text = "APP BUILD NUMBER: " + BuildData.CurrentVersion;
            _timer.Tick += _timer_Tick;
            _timer.Interval = 10;
            this.SizeChanged += ModListControl_SizeChanged;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            TriggerUpdate();
            _timer.Stop();
        }

        private void ModListControl_SizeChanged(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Start();
        }

        public void TriggerUpdate()
        {
            Debug.WriteLine("UPDATE!!!");
            modContainer.Hide();
            foreach (var ctrl in TileCache)
            {
                RevalidateTile(ctrl);
            }
            modContainer.Show();
        }

        public void RevalidateTile(ModTile tile)
        {
            if (tile.Parent == null) return;
            int offset = (tile.Parent.Padding.Left + tile.Margin.Left)*2;
            int xa = 150;
            int width = tile.Parent.Width;
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
            modContainer.Controls.Clear();
            TileCache.Clear();
            modContainer.Visible = false;
            MainWindow.Instance.SetCard(MainWindow.CardControllerTabs.Worker);
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
                        var container = new TableLayoutPanel();
                        container.Dock = DockStyle.Top;
                        container.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        container.AutoSize = true;

                        var space = new CategorySpacer(source.Name, source.Root);
                        space.ToggleState = source.Enabled;
                        //space.Width = this.Width - 20 - SystemInformation.VerticalScrollBarWidth;
                        space.HeaderClick += Space_Click;
                        space.Toggle += Toggle;
                        space.Dock = DockStyle.Top;

                        List<ModTile> tiles = new List<ModTile>();
                        foreach (var d in mods)
                        {
                            i2++;
                            MainWindow.Instance.GuiWorker.SetStatus("Loading mod " + d.Name + " [" + i2 + " of " + i1 + "]");
                            
                            this.Invoke(new MethodInvoker(() =>
                            {
                                ModTile tile = null;
                                tile = new ModTile(d);
                                tile.Visible = source.Enabled;
                                tile.Tag = space;
                                TileCache.Add(tile);
                                tiles.Add(tile);
                                //RevalidateTile(tile);
                            }));
                        }
                        var arr = tiles.ToArray();
                        this.Invoke(new MethodInvoker(() =>
                        {
                            var panel = new FlowLayoutPanel();
                            panel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                            panel.Dock = DockStyle.Top;
                            panel.Controls.AddRange(arr);
                            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                            panel.AutoSize = true;
                            panel.FlowDirection = FlowDirection.LeftToRight;
                            container.Controls.Add(space);
                            container.RowCount++;
                            container.Controls.Add(panel);
                            container.RowCount++;
                            modContainer.Controls.Add(container);
                            modContainer.RowCount++;
                        }));
                        
                    }
                }
                this.Invoke(new MethodInvoker(() => {        
                    this.BackgroundImage = null;
                    SetStatus("Loaded " + i1 + " elements!");
                    MainWindow.Instance.SetCard(MainWindow.CardControllerTabs.Mods);
                    a?.Invoke();
                    modContainer.Visible = true;
                    _timer.Start();
                }));
            });
           
        }

        private void SetStatus(string txt)
        {
            label1.Text = txt;
            MainWindow.Instance.GuiWorker.SetStatus(txt);
        }

        public void Filter(string text)
        {
            modContainer.Visible = false;
            Task.Factory.StartNew(() =>
            {
                foreach (var ctrl in TileCache)
                {
                    var vis = String.IsNullOrEmpty(text.Trim()) ? true : ((ModTile)ctrl).Mod.Name.ToLower().Replace(" ", "").Replace("-", "").Contains(text.ToLower().Replace(" ", "").Replace("-", ""));
                    this.Invoke(new MethodInvoker(() => ((ModTile)ctrl).Visible = vis));
                }
                this.Invoke(new MethodInvoker(() => modContainer.Visible = true));
            });
        }

        public ModObject GetMod(string dirName)
        {
            foreach (var c in TileCache)
            {
                if (c.Mod.GetDirectoryName().Equals(dirName))
                {
                    return c.Mod;
                }
            }
            return null;
        }

        public ModObject[] GetSelectedMods()
        {
            List<ModObject> objects = new List<ModObject>();
            foreach (var ctrl in TileCache)
            {
                var tile = (ModTile)ctrl;
                if (tile.Visible && tile.Checked)
                {
                    objects.Add(tile.Mod);
                }
            }
            return objects.ToArray();
        }

        public ModObject[] GetVisibleMods()
        {
            List<ModObject> objects = new List<ModObject>();
            foreach (var ctrl in TileCache)
            {
                var tile = (ModTile)ctrl;
                if (tile.Visible)
                {
                    objects.Add(tile.Mod);
                }
            }
            return objects.ToArray();
        }

        private void Toggle(CategorySpacer sender, bool e)
        {
            modContainer.Visible = false;
            foreach (var ct in TileCache)
            {
                var o = (ModTile)ct;
                if (sender.Equals(o.Tag))
                {
                    o.Visible = e;
                }
            }
            modContainer.Visible = true;
            TriggerUpdate();
        }

        private void Space_Click(CategorySpacer sender)
        {
            foreach (var o in TileCache)
            {
                if (sender.Equals(o.Tag))
                {
                    if (o.Visible)
                        o.Checked = !sender.SelectionMode;
                }
            }
            sender.SelectionMode = !sender.SelectionMode;
            modContainer.Update();
        }

        private void mButtonBorderless1_Click(object sender, EventArgs e)
        {
            ReloadList();
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

        private void label5_Click(object sender, EventArgs e)
        {
            new ChangelogWindow(true).ShowDialog(this);
        }
    }
}
