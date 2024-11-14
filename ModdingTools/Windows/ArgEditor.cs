using CUFramework.Windows;
using ModdingTools.GUI;
using ModdingTools.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ModdingTools.Settings.OMMSettings;

namespace ModdingTools.Windows
{
    public partial class ArgEditor : CUWindow
    {
        private static int BarOffset = 30;

        public ArgEditor()
        {
            InitializeComponent();
            Init();
            UpdateWidths();
        }

        public void Init()
        {
            this.flowLayoutPanel1.SuspendLayout();

            this.flowLayoutPanel1.Controls.Clear();
            foreach (ArgsDefaultsKeys item in Enum.GetValues(typeof(OMMSettings.ArgsDefaultsKeys)))
            {
                var e = new ArgEditorItem(item);
                e.Padding = new Padding(0);
                e.Width = flowLayoutPanel1.ClientSize.Width - BarOffset;
                this.flowLayoutPanel1.Controls.Add(e);
            }
            this.flowLayoutPanel1.ResumeLayout();
        }

        private void UpdateWidths(bool useHack = true)
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (var a in flowLayoutPanel1.Controls)
            {
                if (a is ArgEditorItem)
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

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void ArgEditor_SizeChanged(object sender, EventArgs e)
        {
            UpdateWidths(false);
        }
    }
}
