using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    public class MButton : System.Windows.Forms.Button
    {
        public MButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = ThemeConstants.BorderColor;
            this.FlatAppearance.BorderColor = ThemeConstants.BorderColor;
            this.FlatAppearance.BorderSize = 1;
            this.ForeColor = ThemeConstants.ForegroundColor;

            this.MouseEnter += MButton_MouseEnter;
            this.MouseLeave += MButton_MouseLeave;
        }

        private void MButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void MButton_MouseEnter(object sender, EventArgs e)
        {
            
        }
    }
}
