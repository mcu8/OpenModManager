using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ModdingTools.GUI.Dialogs;
using ModdingTools.Windows;

// stolen from my old project lol
// seems to be based on this https://www.c-sharpcorner.com/blogs/creating-customized-message-box-with-animation-effect-in-windows-form
namespace ModdingTools.GUI
{
    public static class MessageBox
    {
        public static DialogResult Show(string message)
        {
            return Show(null, message, "Information", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static DialogResult Show(Form parent, string message)
        {
            return Show(parent, message, "Information", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(null, message, title, buttons, icon);
        }

        public static DialogResult Show(Form parent, string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            if (MainWindow.Instance is MainWindow)
            {
                parent = MainWindow.Instance;
            }

            DialogResult dl = DialogResult.None;

            if (parent != null)
            {
                if (parent.IsHandleCreated)
                {
                    if (parent.InvokeRequired)
                    {
                        parent.Invoke(new MethodInvoker(() => {
                            dl = MsgBox.Show(parent, message, title, buttons, icon, MsgBox.AnimateStyle.None);
                        }));
                    }
                    else
                    {
                        dl = MsgBox.Show(parent, message, title, buttons, icon, MsgBox.AnimateStyle.None);
                    }
                }
                else
                {
                    dl = MsgBox.Show(parent, message, title, buttons, icon, MsgBox.AnimateStyle.None);
                }
            }
            else
            {
                dl = MsgBox.Show(parent, message, title, buttons, icon, MsgBox.AnimateStyle.None);
            }

            return dl;
        }

        public static DialogResult Show(string message, string title)
        {
            return Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

namespace ModdingTools.GUI.Dialogs
{
    public class MsgBox : BaseWindow
    {
        private const int CS_DROPSHADOW = 0x20000;
        private static MsgBox _msgBox;
        private Panel _plHeader = new Panel();
        private Panel _plFooter = new Panel();
        private Panel _plIcon = new Panel();
        private PictureBox _picIcon = new PictureBox();
        private FlowLayoutPanel _flpButtons = new FlowLayoutPanel();
        //private Label _lblTitle;
        private Label _lblMessage;
        private List<Button> _buttonCollection = new List<Button>();
        private static DialogResult _buttonResult = new DialogResult();

        private static Timer _timer;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);

        private MsgBox(bool u = true)
        {
            if ((u == false))
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }

            //this.Padding = new System.Windows.Forms.Padding(3);
            this.Width = 400;

            this.MinimumSize = new Size(10, 10);
            this.ControlBoxVisible = false;

 

            _lblMessage = new Label();
            _lblMessage.ForeColor = Color.White;
            _lblMessage.Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Regular, GraphicsUnit.Pixel);
            _lblMessage.AutoSize = true;
            _lblMessage.MaximumSize = new Size(350, int.MaxValue);
            _lblMessage.Dock = DockStyle.Fill;
            _lblMessage.Padding = new Padding(0, 40, 0, 0);

            _flpButtons.FlowDirection = FlowDirection.RightToLeft;
            _flpButtons.Dock = DockStyle.Fill;

            _plHeader.Dock = DockStyle.Fill;
            _plHeader.Padding = new Padding(20);
            _plHeader.Controls.Add(_lblMessage);

            _plFooter.Dock = DockStyle.Bottom;
            _plFooter.Padding = new Padding(2);
            _plFooter.BackColor = Color.FromArgb(47, 47, 48);
            _plFooter.Height = 40;
            _plFooter.Controls.Add(_flpButtons);

            _picIcon.Width = 64;
            _picIcon.Height = 64;
            _picIcon.Location = new Point(30, 50);


            _plIcon.Dock = DockStyle.Left;
            _plIcon.Padding = new Padding(20);
            _plIcon.Width = 120;
            _plIcon.Controls.Add(_picIcon);

            this.Controls.Add(_plHeader);
            this.Controls.Add(_plIcon);
            this.Controls.Add(_plFooter);
        }

        public static void Show(string message)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;

            MessageBeep(0);
            _msgBox.ShowDialog();

        }

        public static void Show(string message, string title)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox.Text = title;
            _msgBox.Size = MsgBox.MessageSize();

            MessageBeep(0);
            _msgBox.ShowDialog();
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox.Text = title;
            _msgBox._plIcon.Hide();

            MsgBox.InitButtons(buttons);

            _msgBox.Size = MsgBox.MessageSize();

            MessageBeep(0);
            _msgBox.ShowDialog();

            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox.Text = title;

            MsgBox.InitButtons(buttons);
            MsgBox.InitIcon(icon);

            _msgBox.Size = MsgBox.MessageSize();
            MessageBeep(0);
            _msgBox.ShowDialog();

            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon, AnimateStyle style, bool us)
        {
            _msgBox = new MsgBox(us);
            _msgBox._lblMessage.Text = message;
            _msgBox.Text = title;
            _msgBox.Height = 0;

            MsgBox.InitButtons(buttons);
            MsgBox.InitIcon(icon);

            _timer = new Timer();
            Size formSize = MsgBox.MessageSize();

            switch (style)
            {
                case MsgBox.AnimateStyle.SlideDown:
                    _msgBox.Size = new Size(formSize.Width, 0);
                    _timer.Interval = 1;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;
                case MsgBox.AnimateStyle.FadeIn:
                    _msgBox.Size = formSize;
                    _msgBox.Opacity = 0;
                    _timer.Interval = 20;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;
                case MsgBox.AnimateStyle.ZoomIn:
                    _msgBox.Size = new Size(formSize.Width + 100, formSize.Height + 100);
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    _timer.Interval = 1;
                    break;
                case MsgBox.AnimateStyle.None:
                    _msgBox.Size = formSize;
                    break;
            }

            if (!(style == AnimateStyle.None))
            {
                _timer.Tick += timer_Tick;
                _timer.Start();
            }
            MessageBeep(0);
            _msgBox.ShowDialog();

            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon, AnimateStyle style)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox.Text = title;
            _msgBox.Height = 0;

            MsgBox.InitButtons(buttons);
            MsgBox.InitIcon(icon);

            _timer = new Timer();
            Size formSize = MsgBox.MessageSize();

            switch (style)
            {
                case MsgBox.AnimateStyle.SlideDown:
                    _msgBox.Size = new Size(formSize.Width, 0);
                    _timer.Interval = 1;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;
                case MsgBox.AnimateStyle.FadeIn:
                    _msgBox.Size = formSize;
                    _msgBox.Opacity = 0;
                    _timer.Interval = 20;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;
                case MsgBox.AnimateStyle.ZoomIn:
                    _msgBox.Size = new Size(formSize.Width + 100, formSize.Height + 100);
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    _timer.Interval = 1;
                    break;
                case MsgBox.AnimateStyle.None:
                    _msgBox.Size = formSize;
                    break;
            }

            if (!(style == AnimateStyle.None))
            {
                _timer.Tick += timer_Tick;
                _timer.Start();
            }
            MessageBeep(0);
            _msgBox.ShowDialog();

            return _buttonResult;
        }

        public static DialogResult Show(IWin32Window owner, string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon, AnimateStyle style)
        {
            _msgBox = new MsgBox();
            _msgBox._lblMessage.Text = message;
            _msgBox.Text = title;
            _msgBox.Owner = (Form)owner;

            MsgBox.InitButtons(buttons);
            MsgBox.InitIcon(icon);

            _msgBox.Size = MsgBox.MessageSize();

            _timer = new Timer();
            Size formSize = MsgBox.MessageSize();

            switch (style)
            {
                case MsgBox.AnimateStyle.SlideDown:
                    _msgBox.Size = new Size(formSize.Width, 0);
                    _timer.Interval = 1;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;
                case MsgBox.AnimateStyle.FadeIn:
                    _msgBox.Size = formSize;
                    _msgBox.Opacity = 0;
                    _timer.Interval = 20;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;
                case MsgBox.AnimateStyle.ZoomIn:
                    _msgBox.Size = new Size(formSize.Width + 100, formSize.Height + 100);
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    _timer.Interval = 1;
                    break;
            }
            if (!(style == AnimateStyle.None))
            {
                _timer.Tick += timer_Tick;
                _timer.Start();
            }
            MessageBeep(0);

            _msgBox.ShowDialog();

            return _buttonResult;
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            AnimateMsgBox animate = (AnimateMsgBox)timer.Tag;

            switch (animate.Style)
            {
                case MsgBox.AnimateStyle.SlideDown:
                    if (_msgBox.Height < animate.FormSize.Height)
                    {
                        _msgBox.Height += 17;
                        _msgBox.Invalidate();
                    }
                    else
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }
                    break;
                case MsgBox.AnimateStyle.FadeIn:
                    if (_msgBox.Opacity < 1)
                    {
                        _msgBox.Opacity += 0.1;
                        _msgBox.Invalidate();
                    }
                    else
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }
                    break;
                case MsgBox.AnimateStyle.ZoomIn:
                    if (_msgBox.Width > animate.FormSize.Width)
                    {
                        _msgBox.Width -= 17;
                        _msgBox.Invalidate();
                    }
                    if (_msgBox.Height > animate.FormSize.Height)
                    {
                        _msgBox.Height -= 17;
                        _msgBox.Invalidate();
                    }
                    break;
            }
        }

        private static void InitButtons(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    _msgBox.InitAbortRetryIgnoreButtons();
                    break;
                case MessageBoxButtons.OK:
                    _msgBox.InitOKButton();
                    break;
                case MessageBoxButtons.OKCancel:
                    _msgBox.InitOKCancelButtons();
                    break;
                case MessageBoxButtons.RetryCancel:
                    _msgBox.InitRetryCancelButtons();
                    break;
                case MessageBoxButtons.YesNo:
                    _msgBox.InitYesNoButtons();
                    break;
                case MessageBoxButtons.YesNoCancel:
                    _msgBox.InitYesNoCancelButtons();
                    break;
            }

            foreach (Button btn in _msgBox._buttonCollection)
            {
                btn.Padding = new Padding(3);
                btn.Height = 30;
                _msgBox._flpButtons.Controls.Add(btn);
            }
        }

        private static void InitIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.None:
                    _msgBox._picIcon.Image = Properties.Resources.msg_app;
                    break;
                case MessageBoxIcon.Error:
                    _msgBox._picIcon.Image = Properties.Resources.msg_error;
                    break;
                case MessageBoxIcon.Information:
                    _msgBox._picIcon.Image = Properties.Resources.msg_info;
                    break;
                case MessageBoxIcon.Question:
                    _msgBox._picIcon.Image = Properties.Resources.msg_question;
                    break;
                case MessageBoxIcon.Warning:
                    _msgBox._picIcon.Image = Properties.Resources.msg_exc;
                    break;
            }
        }

        private void InitAbortRetryIgnoreButtons()
        {
            Button btnAbort = new MButton();
            btnAbort.Text = "INTERRUPT";
            btnAbort.Click += ButtonClick;

            Button btnRetry = new MButton();
            btnRetry.Text = "RETRY";
            btnRetry.Click += ButtonClick;

            Button btnIgnore = new MButton();
            btnIgnore.Text = "IGNORE";
            btnIgnore.Click += ButtonClick;

            this._buttonCollection.Add(btnAbort);
            this._buttonCollection.Add(btnRetry);
            this._buttonCollection.Add(btnIgnore);
        }

        private void InitOKButton()
        {
            Button btnOK = new MButton();
            btnOK.Text = "OK";
            btnOK.Click += ButtonClick;

            this._buttonCollection.Add(btnOK);
        }

        private void InitOKCancelButtons()
        {
            Button btnOK = new MButton();
            btnOK.Text = "OK";
            btnOK.Click += ButtonClick;

            Button btnCancel = new MButton();
            btnCancel.Text = "CANCEL";
            btnCancel.Click += ButtonClick;


            this._buttonCollection.Add(btnOK);
            this._buttonCollection.Add(btnCancel);
        }

        private void InitRetryCancelButtons()
        {
            Button btnRetry = new MButton();
            btnRetry.Text = "OK";
            btnRetry.Click += ButtonClick;

            Button btnCancel = new MButton();
            btnCancel.Text = "CANCEL";
            btnCancel.Click += ButtonClick;


            this._buttonCollection.Add(btnRetry);
            this._buttonCollection.Add(btnCancel);
        }

        private void InitYesNoButtons()
        {
            Button btnYes = new MButton();
            btnYes.Text = "YES";
            btnYes.Click += ButtonClick;

            Button btnNo = new MButton();
            btnNo.Text = "NO";
            btnNo.Click += ButtonClick;


            this._buttonCollection.Add(btnYes);
            this._buttonCollection.Add(btnNo);
        }

        private void InitYesNoCancelButtons()
        {
            Button btnYes = new MButton();
            btnYes.Text = "INTERRUPT";
            btnYes.Click += ButtonClick;

            Button btnNo = new MButton();
            btnNo.Text = "RETRY";
            btnNo.Click += ButtonClick;

            Button btnCancel = new MButton();
            btnCancel.Text = "CANCEL";
            btnCancel.Click += ButtonClick;

            this._buttonCollection.Add(btnYes);
            this._buttonCollection.Add(btnNo);
            this._buttonCollection.Add(btnCancel);
        }


        private static void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "INTERRUPT":
                    _buttonResult = DialogResult.Abort;
                    break;
                case "RETRY":
                    _buttonResult = DialogResult.Retry;
                    break;
                case "IGNORE":
                    _buttonResult = DialogResult.Ignore;
                    break;
                case "OK":
                    _buttonResult = DialogResult.OK;
                    break;
                case "CANCEL":
                    _buttonResult = DialogResult.Cancel;
                    break;
                case "YES":
                    _buttonResult = DialogResult.Yes;
                    break;
                case "NO":
                    _buttonResult = DialogResult.No;
                    break;
            }

            _msgBox.Dispose();
        }

        private static Size MessageSize()
        {
            Graphics g = _msgBox.CreateGraphics();

            Size maxSize = new Size(500, int.MaxValue);
            _msgBox._lblMessage.Size = _msgBox._lblMessage.GetPreferredSize(maxSize);

            var height = _msgBox._lblMessage.Height + 80;

            if (height < 200)
            {
                height = 200;
            }

            return new Size(550, height);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
            Pen pen = new Pen(Color.FromArgb(0, 151, 251));

            g.DrawRectangle(pen, rect);
        }

        public enum AnimateStyle
        {
            SlideDown = 1,
            FadeIn = 2,
            ZoomIn = 3,
            None = 4
        }
    }

    class AnimateMsgBox
    {
        public Size FormSize;

        public MsgBox.AnimateStyle Style;
        public AnimateMsgBox(Size formSize, MsgBox.AnimateStyle style)
        {
            this.FormSize = formSize;
            this.Style = style;
        }
    }
}
