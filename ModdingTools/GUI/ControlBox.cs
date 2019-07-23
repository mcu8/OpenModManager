using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    public class ControlBox : Control
    {
        public ControlBox()
        {
            var closeButton = new MButtonBorderless();
            var minimizeButton = new MButtonBorderless();
            this.Width = 64;
            this.Height = 32;
            this.Margin = new Padding(0, 0, 0, 0);
            this.Padding = new Padding(0, 0, 0, 0);

            closeButton.Size = new System.Drawing.Size(32, 32);
            minimizeButton.Size = new System.Drawing.Size(32, 32);

            closeButton.Location = new System.Drawing.Point(33, 0);
            minimizeButton.Location = new System.Drawing.Point(0, 0);

            closeButton.Image = Properties.Resources.close;
            minimizeButton.Image = Properties.Resources.minimize;

            closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            minimizeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;

            closeButton.Click += (o, e) =>
            {
                this.FindForm().Close();
            };

            minimizeButton.Click += (o, e) =>
            {
                this.FindForm().WindowState = FormWindowState.Minimized;
            };

            closeButton.Text = "";
            minimizeButton.Text = "";

            closeButton.Parent = this;
            minimizeButton.Parent = this;
        }
    }
}
