using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    class BorderPanel : Panel
    {
        public BorderPanel() {

            this.Resize += (o, e) =>
            {
                this.Invalidate();
            };
            this.BackColor = ThemeConstants.BackgroundColor;
            this.ForeColor = ThemeConstants.ForegroundColor;
            this.Padding = new Padding(0,0,0,0);
            
            this.Paint += BaseWindow_Paint;
            this.BorderStyle = BorderStyle.None;
        }

        public static void EatControl(Control c)
        {
            var f = new BorderPanel();
            var parentC = c.Parent;
            var loc = c.Location;
            var size = c.Size;
            var index = c.TabIndex;
            var dock = c.Dock;
            var anchor = c.Anchor;

            c.Width -= 5;
            c.Height -= 4;

            if (c is TextBox)
            {
                ((TextBox)c).BorderStyle = BorderStyle.None;
            }

            c.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            c.Location = new Point(2, 2);

            parentC.Controls.Remove(c);
            f.BorderStyle = BorderStyle.None;
            f.Location = loc;
            f.Size = size;
            f.TabIndex = index;
            f.Dock = dock;
            f.Anchor = anchor;
            f.Controls.Add(c);

            parentC.Controls.Add(f);
        }

        private void BaseWindow_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e);
        }

        private int _border = 2;
        public int BorderThickness
        {
            get => _border;
            set
            {
                _border = value;
                Refresh();
            }
        }

        public void DrawBorder(PaintEventArgs e)
        {
            var pen = new Pen(ThemeConstants.BorderColor);
            pen.Width = _border;
           
            var rect = new Rectangle(new Point(0, 0), new Size(this.Width - 2, this.Height - 2));
            e.Graphics.DrawRectangle(pen, rect);
        }
    }
}
