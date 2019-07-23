using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    public class MButtonBorderless : System.Windows.Forms.Button
    {
        public MButtonBorderless()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.FlatAppearance.BorderSize = 0;
            this.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
        }
    }
}
