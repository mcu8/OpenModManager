using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    class MTextBox : TextBox
    {
        const int WM_NCPAINT = 0x85;
        const uint RDW_INVALIDATE = 0x1;
        const uint RDW_IUPDATENOW = 0x100;
        const uint RDW_FRAME = 0x400;

        public MTextBox()
        {
            this.BackColor = ThemeConstants.BackgroundColor;
            this.ForeColor = ThemeConstants.ForegroundColor;

            this.MouseEnter += MTextBox_MouseEnter;
            this.MouseLeave += MTextBox_MouseLeave;
        }

        private void MTextBox_MouseLeave(object sender, EventArgs e)
        {
            _borderColor = BorderColor;
        }

        private void MTextBox_MouseEnter(object sender, EventArgs e)
        {
            _borderColor = ControlPaint.LightLight(borderColor);
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
        Color borderColor = ThemeConstants.BorderColor;
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
                    RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
            }
        }
        Color _borderColor = ThemeConstants.BorderColor;


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT && BorderColor != Color.Transparent &&
                BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
            {
                var hdc = GetWindowDC(this.Handle);
                using (var g = Graphics.FromHdcInternal(hdc))
                {
                    using (var p = new Pen(_borderColor))
                        g.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
                    using (var p = new Pen(this.BackColor))
                        g.DrawRectangle(p, new Rectangle(1, 1, Width - 3, Height - 3));
                    using (var p = new Pen(this.BackColor))
                        g.DrawRectangle(p, new Rectangle(2, 2, Width - 5, Height - 5));
                }
                ReleaseDC(this.Handle, hdc);
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
                   RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
        }
    }
}
