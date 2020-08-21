using ModdingTools.GUI;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ModdingTools.Windows
{
    public partial class InputWindow : BaseWindow
    {

        public InputValidator Validator = null;

        public InputWindow()
        {
            InitializeComponent();
        }

        public static string Ask(Control parent, string title, string text, InputValidator validator = null, string def = "", bool multiline = false)
        {
            if (MainWindow.Instance.InvokeRequired)
            {
                var output = "";
                MainWindow.Instance.Invoke(new MethodInvoker(() =>
                {
                    output = InputWindow.Ask(parent, title, text, validator);
                }));
                return output;
            }

            var t = new InputWindow();
            if (parent == null) parent = Form.ActiveForm;
            if (parent == null && MainWindow.Instance is MainWindow) parent = MainWindow.Instance;

            t.Validator = validator;
            t.label1.Text = text;
            t.Text = title;
            t.InputBox.Text = def;
            t.StartPosition = FormStartPosition.CenterParent;

            if (multiline)
            {
                t.InputBox.Location = new System.Drawing.Point(t.InputBox.Location.X, t.InputBox.Location.Y - t.InputBox.Height);
                t.InputBox.Multiline = true;
                t.label1.Height -= t.InputBox.Height;
                t.InputBox.ScrollBars = ScrollBars.Vertical;
                t.InputBox.WordWrap = true;
                t.InputBox.Height *= 2;
            }

            if (t.ShowDialog(parent.FindForm()) == DialogResult.OK)
            {
                return t.InputBox.Text;
            }

            return null;
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            if (Validator != null)
            {
                var val = Validator.Validate(InputBox.Text);
                if (val != null)
                {
                    GUI.MessageBox.Show(this, val, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public interface InputValidator
        {
            // null if OK, error string if error
            string Validate(string inputText);
        }

        public class ModNameValidator : InputValidator
        {
            public string Validate(string inputText)
            {
                if (inputText.Length < 3)
                {
                    return "Mod name should have at least 3 characters";
                }

                if (!Regex.IsMatch(inputText, @"^[a-zA-Z0-9_]+$"))
                {
                    return "Invalid characters in mod folder name - you can only use numbers and letters and _";
                }

                if (inputText.ToLower().Trim() == "newmod" || inputText.ToLower().Trim() == "mymod")
                {
                    return "Seriously? Give it some more unique name...";
                }

                string modName = inputText;
                string modsRoot = Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods");
                string modPath = Path.Combine(modsRoot, modName);
                string modInfoPath = Path.Combine(modPath, "modinfo.ini");

                if (File.Exists(modInfoPath))
                {
                    return "There's already a mod with name \"" + modName + "\". Please delete it or set it up.";
                }

                return null;
            }
        }

        public class ARValidator : InputValidator
        {
            public string Validate(string inputText)
            {
                
                if (!Regex.IsMatch(inputText, @"[A-Za-z0-9]{1,255}\'[A-Za-z_0-9\.]{1,255}\'$"))
                {
                    return "Invalid asset name!\nIt should look something like this: StaticMesh'MyPackage.MyMesh'";
                }
                return null;
            } 
        }

        public class NonEmptyValidator : InputValidator
        {
            public string Validate(string inputText)
            {
                return string.IsNullOrEmpty(inputText) ? "That field cannot be empty!" : null;
            }
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mButton2_Click(null, null);
            }
        }
    }
}
