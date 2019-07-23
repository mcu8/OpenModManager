using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ModdingTools.Modding;

namespace ModdingTools.GUI
{
    public partial class ModListControl : UserControl
    {
        public ModListControl()
        {
            InitializeComponent();
            flowLayoutPanel1.Resize += ModListControl_SizeChanged;
        }

        private void ModListControl_SizeChanged(object sender, EventArgs e)
        {
            TriggerUpdate();
        }

        private void TriggerUpdate()
        {
            foreach (var ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is CategorySpacer)
                {
                    ((CategorySpacer)ctrl).Width = this.Width - 20 - SystemInformation.VerticalScrollBarWidth;
                }

            }
            flowLayoutPanel1.Update();
        }

        List<ModDirectorySource> sources = new List<ModDirectorySource>();
        public void AddModSource(ModDirectorySource source)
        {
            sources.Add(source);
        }

        public void RemoveModSource(ModDirectorySource source)
        {
            sources.Remove(source);
        }

        public void ReloadList()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Visible = false;
            foreach (var source in sources)
            {
                var mods = source.GetMods();

                if (mods.Length > 0)
                {
                    var space = new CategorySpacer(source.Name, source.Root);
                    space.ToggleState = source.Enabled;
                    space.Width = this.Width - 20 - SystemInformation.VerticalScrollBarWidth;
                    space.HeaderClick += Space_Click;
                    space.Toggle += Toggle;
                    flowLayoutPanel1.Controls.Add(space);
                    foreach (var d in mods)
                    {
                        var tile = new ModTile(d);
                        tile.Visible = source.Enabled;
                        tile.Tag = space;
                        flowLayoutPanel1.Controls.Add(tile);
                    }
                }  
            }
            flowLayoutPanel1.Visible = true;
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
    }
}
