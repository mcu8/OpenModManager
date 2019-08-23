using ModdingTools.GUI;
using ModdingTools.Modding;
using ModManager;
using ModManager.Forms;
using System.Windows.Forms;

namespace ModdingTools
{
    // Temporary solution for mod properties window - I'll rewrite it by my own later...
    class ModManagerProxy
    {
        static bool initialized = false;

        static ModListForm modListForm;

        static void Init()
        {
            if (initialized) return;
            modListForm = new ModListForm();      
            initialized = true;
        }

        public static void LaunchPropertiesWindow(ModObject ob)
        {
            Init();

            var window = new EditMod();

            window.TopLevel = false;
            window.FormBorderStyle = FormBorderStyle.None;
            window.Visible = true;
            window.Dock = System.Windows.Forms.DockStyle.Fill;
            window.SetModFolder(ob.RootSource.Root, ob.RootPath, modListForm);

            window.BackColor = System.Drawing.Color.Black;
            window.ForeColor = System.Drawing.Color.White;

            var host = new BaseWindow();
            host.BackColor = System.Drawing.Color.Black;
            host.ForeColor = System.Drawing.Color.White;

            window.Tag = ob;
            host.Tag = ob;

            Utils.ApplyTheme(window);

            host.Text = window.Text;
            window.TextChanged += (e, v) => { host.Text = window.Text; };

            var RefreshButton = Utils.GetField<Button>("RefreshButton", window);
            Utils.CleanEvents(RefreshButton);
            RefreshButton.Click += (e, v) =>
            {
                MainWindow.Instance.ReloadModList();
            };

            var Header = Utils.GetField<Panel>("Header", window);
            Header.Visible = false;

            var tabControl1 = Utils.GetField<TabControl>("tabControl1", window);
            tabControl1.Visible = true;
            tabControl1.Margin = new Padding(0, 0, 0, 0);
            tabControl1.Padding = new System.Drawing.Point(0,0);
            tabControl1.Left += 10;
            tabControl1.Width -= 10;

            var panel1 = Utils.GetField<Panel>("panel1", window);
            panel1.Width += 5;
            panel1.Padding = new Padding(0, 0, 0, 0);
            panel1.Margin = new Padding(0, 0, 0, 0);

            var CookModButton = Utils.GetField<Button>("CookModButton", window);
            Utils.CleanEvents(CookModButton);

            CookModButton.Click += (e, v) =>
            {
                var o = Utils.GetModObjectFromControl(e);
                var p = ((Control)e).FindForm();

                if (Utils.InvokeFunct<bool>(p, "ConditionalValidFolder")  && Utils.InvokeFunct<bool>(p, "ConditionalValidContent"))
                {
                    if (!Utils.GetField<bool>("HasCompiledScripts", p) && !Utils.GetField<bool>("HasAnyMapFiles", p))
                    {
                        MessageBox.Show("Please compile scripts first!");
                        return;
                    }
                    Utils.InvokeMeth(p, "SaveMod");
                    MainWindow.Instance.Runner.RunAppAsync(Program.ProcFactory.GetCookMod(o));
                }  
            };

            host.Controls.Add(window);
            host.Show();
        }
    }
}

