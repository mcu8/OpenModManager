﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModdingTools.Windows;

namespace ModdingTools.GUI
{
    public partial class ARItem : UserControl
    {
        public ARItem(string target, string replacement)
        {
            InitializeComponent();
            label4.Text = target;
            label3.Text = replacement;
        }

        public string Target => label4.Text;
        public string Replacement => label3.Text;

        private void mButtonBorderless1_Click(object sender, EventArgs e)
        {
            if (this.Parent is FlowLayoutPanel)
            {
                this.Parent.Controls.Remove(this);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var a = InputWindow.Ask("AR Editor", "Please, enter the original asset name", new InputWindow.ARValidator(), label4.Text);
            if (a != null)
            {
                label4.Text = a;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var a = InputWindow.Ask("AR Editor", "Please, enter the replacement asset name", new InputWindow.ARValidator(), label3.Text);
            if (a != null)
            {
                label3.Text = a;
            }
        }
    }
}
