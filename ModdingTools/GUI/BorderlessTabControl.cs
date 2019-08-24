using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    // Source:
    // https://stackoverflow.com/questions/23247941/c-sharp-how-to-remove-tabcontrol-border

    public partial class BorderlessTabControl : TabControl
    {
        public BorderlessTabControl()
        {
            if (!this.DesignMode) this.Multiline = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !this.DesignMode)
                m.Result = new IntPtr(1);
            else
                base.WndProc(ref m);
        }
    }
}
