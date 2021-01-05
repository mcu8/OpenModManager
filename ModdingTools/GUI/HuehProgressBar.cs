using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    public class HuehProgressBar : System.Windows.Forms.Control
    {
        Timer Timer;
        Image i1, i2, i3;
        const float scale = 0.4f;

        private int _oldValue = -1;
        private string _oldText = null;
        public int Value { get; set; } = 0;
        public new string Text { get; set; } = "...";
        public HuehProgressBar()
        {
            this.DoubleBuffered = true;

            i1 = ResizeImage(Properties.Resources.heeh_1b, scale);
            i2 = ResizeImage(Properties.Resources.heeh_2, scale);
            i3 = ResizeImage(Properties.Resources.heeh_3, scale);

            this.Paint += Form1_Paint;

            this.Timer = new Timer();
            Timer.Interval = 10;
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        public static Image ResizeImage(Image image, float sc)
        {
            var new_width = image.Width * sc;
            var new_height = image.Height * sc;
            Bitmap new_image = new Bitmap((int)new_width, (int)new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var startPos = this.Height - i3.Height * 1;
            var clipOff = 20;

            var drawBrush = new SolidBrush(this.ForeColor);
            var drawFont = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style, this.Font.Unit);
            var drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Far;

            int posX = this.Width - (int)(i1.Width * 1.2f); //this.Width / 2 - i3.Width / 2;

            float progress = (this.Height - i3.Height - i1.Height) * (Math.Min((float)Value, 100f) / 100f);
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.DrawImage(i2, new Rectangle(posX, startPos - (int)progress, i3.Width, (int)progress + clipOff));
            e.Graphics.DrawImage(i3, posX, startPos);

            var y = startPos - (i1.Height) - progress + clipOff;
            e.Graphics.DrawImage(i1, posX, y);

            e.Graphics.DrawString(Text, drawFont, drawBrush, posX - clipOff, y + clipOff / 2, drawFormat);
            drawFont.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_oldText != Text || _oldValue != Value)
            {
                _oldText = Text;
                _oldValue = Value;
                this.Refresh();
            }    
        }
    }
}
