using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    
    public class BaseWindow : Form
    {
        Label titleBar;
        ControlBox box;
        public BaseWindow()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MinimumSize = new Size(800, 480);

            this.StartPosition = FormStartPosition.CenterScreen;
            
            titleBar = new Label();
            titleBar.Height = 32;
            titleBar.Parent = this;

            this.SizeChanged += ((o, e) =>
            {
                titleBar.Width = this.Width - _border;
                box.Location = new Point(titleBar.Width - box.Width, 0);
            });

            this.Resize += (o, e) =>
            {
                this.Invalidate();
            };

            this.Paint += BaseWindow_Paint;
            this.titleBar.MouseDown += Header_MouseDown;
           

            this.ForeColor = ThemeConstants.ForegroundColor;
            this.BackColor = ThemeConstants.BackgroundColor;

           
            this.box = new ControlBox();

            if (!p_IsControlBoxVisible)
            {
                this.box.Visible = false;
            }

            InitTitleBar();
        }

        private bool p_IsControlBoxVisible = true;
        [Browsable(true)]
        [Category("OMM")]
        public bool ControlBoxVisible
        {
            get
            {
                return p_IsControlBoxVisible;
            }
            set
            {
                p_IsControlBoxVisible = value;
                this.box.Visible = p_IsControlBoxVisible;
            }
        }

        private bool p_IsResizable = true;
        [Browsable(true)]
        [Category("OMM")]
        public bool IsResizable
        {
            get
            {
                return p_IsResizable;
            }
            set
            {
                p_IsResizable = value;
            }
        }

        public void InitTitleBar()
        {
            titleBar.BackColor = ThemeConstants.TitleBarBackground;
            titleBar.ForeColor = ThemeConstants.TitleBarForeground;
            titleBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            titleBar.Padding = new Padding(10, 0, 0, 0);
            titleBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            
            titleBar.Margin = new Padding(0, 0, 0, 0);

            this.Padding = new Padding(_border, _border, _border, _border);

            titleBar.Location = new System.Drawing.Point(_border / 2, _border / 2);

            box.Parent = titleBar;
            
           // box.Anchor = AnchorStyles.Right;
        }

        private void BaseWindow_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e);
        }

        private int _border = 4;
        public int BorderThickness
        {
            get => _border;
            set
            {
                _border = value;
                InitTitleBar();
                Refresh();
            }
        }

        public void DrawBorder(PaintEventArgs e)
        {
            var pen = new Pen(ThemeConstants.BorderColor);
            pen.Width = _border;
            var rect = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));
            e.Graphics.DrawRectangle(pen, rect);          
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.titleBar.Capture = false;
                const int WM_NCLBUTTONDOWN = 0xa1;
                const int HTCAPTION = 0x2;
                Message msg = Message.Create(this.Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }

        public override string Text {
            get {
                return base.Text;
            }
            set
            {
                base.Text = value;
                titleBar.Text = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        protected override void WndProc(ref Message m)
        {
            if (!p_IsResizable)
            {
                base.WndProc(ref m);
                return;
            }

            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }
    }
}
