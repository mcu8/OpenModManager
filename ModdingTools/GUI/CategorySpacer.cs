using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    public partial class CategorySpacer : UserControl
    {

        public delegate void OnToggle(CategorySpacer sender, bool state);
        public OnToggle Toggle = null;

        public delegate void OnHeaderClick(CategorySpacer sender);
        public OnHeaderClick HeaderClick = null;

        public CategorySpacer(string title, string subtitle)
        {
            InitializeComponent();
            this.panel1.BackColor = ThemeConstants.BorderColor;
            this.label2.Text = title;
            this.label1.Text = subtitle;
        }

        public bool SelectionMode { get; set; }

        private bool _ToggleState;
        public bool ToggleState
        {
            get
            {
                return _ToggleState;
            }
            set
            {
                _ToggleState = value;
                mButtonBorderless1.Image = (value) ? Properties.Resources.icon_044 : Properties.Resources.icon_043;
                Toggle?.Invoke(this, value);
            }
        }

        private void mButtonBorderless1_Click(object sender, EventArgs e)
        {
            ToggleState = !ToggleState;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Utils.OpenInExplorer(label1.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            HeaderClick?.Invoke(this);
        }
    }
}
