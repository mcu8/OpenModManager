using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModdingTools.Windows;
using ModdingTools.Windows.Validators;
using CUFramework.Dialogs;

namespace ModdingTools.GUI
{
    public partial class ARList : UserControl
    {
        private static int BarOffset = 10;

        public ARList()
        {
            InitializeComponent();
        }

        public void Fill(Dictionary<string, string> dictonary)
        {
            this.flowLayoutPanel1.SuspendLayout();

            this.flowLayoutPanel1.Controls.Clear();
            foreach (var item in dictonary)
            {
                var e = new ARItem(item.Key, item.Value);
                e.Padding = new Padding(0);
                e.Width = flowLayoutPanel1.ClientSize.Width - BarOffset;
                this.flowLayoutPanel1.Controls.Add(e);
            }
            this.flowLayoutPanel1.ResumeLayout();

            UpdateWidths();
        }

        public void Append(string key, string val)
        {
            this.flowLayoutPanel1.SuspendLayout();

            var e = new ARItem(key, val);
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
                if (a is ARItem)
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

        public Dictionary<string, string> Collect()
        {
            var d = new Dictionary<string, string>();
            foreach (var a in flowLayoutPanel1.Controls)
            {
                if (a is ARItem)
                {
                    var item = (ARItem)a;
                    d.Add(item.Target, item.Replacement);
                }
            }
            return d;
        }

        private void CUButtonBorderless1_Click(object sender, EventArgs e)
        {
            string source = CUInputWindow.Ask(this, "Asset Replacement: from", "Enter the asset name which you want to replace", new ARValidator());
            if (source != null)
            {
                if (Collect().Where(item => item.Key.ToLowerInvariant() == source.ToLowerInvariant()).Count() > 0)
                {
                    CUMessageBox.Show("ARList already contains item with key: " + source, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string target = CUInputWindow.Ask(this, "Asset Replacement: to", $"Replacement: {source}{Environment.NewLine}Enter the target asset name", new ARValidator());
                if (target != null)
                {
                    Append(source, target);
                    CallOnUpdateEvent();
                }
            }
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            UpdateWidths(false);
        }

        public event EventHandler<EventArgs> OnUpdate;
        public virtual void CallOnUpdateEvent()
        {
            OnUpdate?.Invoke(this, new EventArgs());
        }
    }
}
