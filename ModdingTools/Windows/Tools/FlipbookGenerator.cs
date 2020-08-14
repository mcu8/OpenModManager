using ModdingTools.Engine;
using ModdingTools.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.Windows.Tools
{
    public partial class FlipbookGenerator : BaseWindow
    {
        public FlipbookGenerator()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.editorcrashedhueh4;
        }

        public List<Image> GetFramesFromAnimatedGIF(Image img)
        {
            List<Image> imageList = new List<Image>();
            int Length = img.GetFrameCount(FrameDimension.Time);

            int size = img.Width > img.Height ? img.Width : img.Height;

            for (int i = 0; i < Length; i++)
            {
                img.SelectActiveFrame(FrameDimension.Time, i);
                
                imageList.Add(Transparent2Color(ResizeImage(img, size, size), panel1.BackColor));
            }

            return imageList;
        }

        public Bitmap Transparent2Color(Bitmap bmp1, Color target)
        {
            Bitmap bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
            Rectangle rect = new Rectangle(Point.Empty, bmp1.Size);
            using (Graphics G = Graphics.FromImage(bmp2))
            {
                G.Clear(target);
                G.DrawImageUnscaledAndClipped(bmp1, rect);
            }
            return bmp2;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void mButton1_Click(object sender, EventArgs e)
        {

           try
            {
                var entryPoint = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.DefaultExt = "gif";
                dlg.Multiselect = false;
                dlg.InitialDirectory = entryPoint;
                dlg.Filter = "GIF animation file (*.gif)|*.gif";
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                var gif = Image.FromFile(dlg.FileName);


                var output = Path.Combine(Program.GetAppRoot(), "out.png");


                // just forgive my shitty maths... maybe it's the easiest way to do that :hueh:
                List<Image> frames = GetFramesFromAnimatedGIF(gif);

                double frameW = frames[0].Width;

                var frameCount = frames.Count();

                double size = frameCount;
                int level = 1;
                while (true)
                {
                    double search = Math.Pow(level, 2);
                    if (size < search) break;
                    level++;
                }

                size = level * frameW;

                Debug.WriteLine("Level: " + level);
                Debug.WriteLine("FrameCnt: " + frameCount);

                var remain = (level * level) - frameCount;

                Debug.WriteLine("Remain: " + remain);

                if (remain > 0)
                {
                    for (int xy = 0; xy != remain; xy++)
                    {
                        frames.Add(new Bitmap(frames.Last()));
                    }
                }

                var bmp = new Bitmap((int)size, (int)size);
                var canvas = Graphics.FromImage(bmp);
                canvas.Clear(SystemColors.AppWorkspace);

                int line = 0;
                int nIndex = 0;
                foreach (Image img in frames)
                {
                    canvas.DrawImage(img, new Point((int)frameW * nIndex, (int)frameW * line));
                    img.Dispose();

                    if (nIndex == level - 1)
                    {
                        nIndex = 0;
                        line++;
                    }
                    else
                    {
                        nIndex++;
                    }
                }

                int x = 1;
                while (true)
                {
                    double search = Math.Pow(2, x);
                    if ((int)size <= search) break;
                    x++;
                }

                x = (int)Math.Pow(2, x);
                if (x > 4096)
                {
                    x = 4096; // max texture size in UE3
                }

                canvas.Dispose();

                var n = ResizeImage(bmp, x, x);
                bmp.Dispose();
       
                label1.Text = $"Size: {x}x{x}px\nRows: {level}\nColumns: {level}\n\nAmount of empty space: {remain + (remain > 0 ? " (filled by duplicating the last frame)" : "")}";

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "png";
                sfd.FileName = "flipbook_" + Path.GetFileNameWithoutExtension(dlg.FileName);
                sfd.Filter = $"PNG File (*.png)|*.png";
                sfd.InitialDirectory = entryPoint;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    n.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    n.Dispose();
                    pictureBox1.ImageLocation = sfd.FileName;
                }
            }
            catch (Exception ex)
            {
                GUI.MessageBox.Show($"{ex.Message}\n\n{ex}");
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = dlg.Color;
            }
        }
    }
}
