using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModdingTools.Windows;
using ModdingTools.Modding;

namespace ModdingTools.GUI
{
    public partial class ConfigList : UserControl
    {
        private static int BarOffset = 10;
        private ModObject ModObj;

        public ConfigList()
        {
            InitializeComponent();
        }

        public void Fill(ModObject o)
        {
            ModObj = o;

            this.flowLayoutPanel1.SuspendLayout();

            this.flowLayoutPanel1.Controls.Clear();
            foreach (var item in o.Config)
            {
                var e = new ConfigItem(item, o);
                e.Padding = new Padding(0);
                e.Width = flowLayoutPanel1.ClientSize.Width - BarOffset;
                this.flowLayoutPanel1.Controls.Add(e);
            }
            this.flowLayoutPanel1.ResumeLayout();

            UpdateWidths();
        }

        public void Append(ModObject.ModConfigItem conf, ModObject o)
        {
            this.flowLayoutPanel1.SuspendLayout();

            var e = new ConfigItem(conf, o);
            e.Padding = new Padding(0);
            e.Width = flowLayoutPanel1.ClientSize.Width - BarOffset;
            this.flowLayoutPanel1.Controls.Add(e);

            this.flowLayoutPanel1.ResumeLayout();

            UpdateWidths();
        }

        private void UpdateWidths(bool useHack = true)
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var a in flowLayoutPanel1.Controls)
            {
                if (a is ConfigItem)
                {
                    ((Control)a).Width = flowLayoutPanel1.ClientSize.Width - BarOffset;
                }
            }
            flowLayoutPanel1.ResumeLayout();

            if (useHack)
            {
                this.flowLayoutPanel1.Width -= 1;
                this.flowLayoutPanel1.Width += 1; // little hack to force-update the layout
            }
        }

        private void mButtonBorderless1_Click(object sender, EventArgs e)
        {
            var cfg = new ModObject.ModConfigItem();
            ModObj.Config.Add(cfg);
            Append(cfg, ModObj);
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            UpdateWidths(false);
        }
    }
}
