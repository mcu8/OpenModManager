using ModdingTools.Engine;
using ModdingTools.GUI;
using ModdingTools.Modding;
using ModdingTools.Windows;
using ModManager;
using ModManager.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ModdingTools.Engine
{
    // Temporary solution for mod properties window - I'll rewrite it by my own later...
    class ModManagerPropertiesWrapper
    {
        static bool initialized = false;
        static bool UseWrapper = false;

        static List<Form> openedForms = new List<Form>();

        static ModListForm modListForm;

        public static void Init()
        {
            if (initialized) return;
            modListForm = new ModListForm();      
            initialized = true;
        }

        public static void LaunchPropertiesWindow(ModObject ob)
        {
            if (!UseWrapper)
            {
                new ModProperties(ob).Show();
                return;
            }

            Init();

            var window = new EditMod();

            window.TopLevel = false;
            window.FormBorderStyle = FormBorderStyle.None;
            window.Visible = true;
            window.Dock = DockStyle.Fill;
            window.SetModFolder(ob.RootSource.Root, ob.RootPath, modListForm);

            window.BackColor = System.Drawing.Color.Black;
            window.ForeColor = System.Drawing.Color.White;

            var host = new BaseWindow();
            host.BackColor = System.Drawing.Color.Black;
            host.ForeColor = System.Drawing.Color.White;

            window.Tag = ob;
            host.Tag = ob;

            host.Text = window.Text;
            window.TextChanged += (e, v) => { host.Text = window.Text; };

            // Correct sidebar size
            var panel1 = Utils.GetField<Panel>("panel1", window);
            //panel1.Width += 5;
            panel1.Location = new Point(panel1.Location.X + 3, panel1.Location.Y);
            panel1.Padding = new Padding(0, 0, 0, 0);
            panel1.Margin = new Padding(0, 0, 0, 0);
            panel1.BorderStyle = BorderStyle.None;
            panel1.BackColor = Color.Black;
            panel1.Tag = "notheme";
            panel1.Refresh();

            // Disable textbox for changing mod directory name to avoid conflicts
            var ModFolderEdit = Utils.GetField<TextBox>("ModFolderEdit", window);
            ModFolderEdit.Enabled = false;

            // Hook into save button
            var SaveButton = Utils.GetField<Button>("SaveButton", window);
            SaveButton.Location = new Point(panel1.Width + 3, SaveButton.Location.Y);

            // Hook into GoToFolderButton button
            var GoToFolderButton = Utils.GetField<Button>("GoToFolderButton", window);
            GoToFolderButton.Location = new Point(SaveButton.Location.X + 3 + SaveButton.Width, GoToFolderButton.Location.Y);

            // Hook into refresh button
            var RefreshButton = Utils.GetField<Button>("RefreshButton", window);

            // ViewInWorkshopButton
            var ViewInWorkshopButton = Utils.GetField<Button>("ViewInWorkshopButton", window);
            ViewInWorkshopButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ViewInWorkshopButton.Location = new Point(RefreshButton.Location.X - 3 - ViewInWorkshopButton.Width, ViewInWorkshopButton.Location.Y);

            Utils.CleanEvents(ViewInWorkshopButton);
            ViewInWorkshopButton.Click += (e, v) =>
            {
                var o = Utils.GetModObjectFromControl(e);
                Process.Start("http://steamcommunity.com/sharedfiles/filedetails/?id=" + o.GetUploadedId());
            };

            // Hook into compile scripts button
            var CompileScriptsButton = Utils.GetField<Button>("CompileScriptsButton", window);
            Utils.CleanEvents(CompileScriptsButton);
            CompileScriptsButton.Click += (e, v) =>
            {
                var o = Utils.GetModObjectFromControl(e);
                var p = ((Control)e).FindForm();

                if (Utils.InvokeFunct<bool>(p, "ConditionalValidFolder") && Utils.InvokeFunct<bool>(p, "ConditionalValidContent"))
                {
                    Utils.InvokeMeth(p, "SaveMod");
                    o.UnCookMod();
                    MainWindow.Instance.Runner.RunAppAsync(Program.ProcFactory.GetCompileScript(o));
                }
            };

            // Hook into cook mod button
            var CookModButton = Utils.GetField<Button>("CookModButton", window);
            Utils.CleanEvents(CookModButton);
            Utils.ApplyButtonTheme(CookModButton);
            CookModButton.Click += (e, v) =>
            {
                var o = Utils.GetModObjectFromControl(e);
                var p = ((Control)e).FindForm();

                if (Utils.InvokeFunct<bool>(p, "ConditionalValidFolder") && Utils.InvokeFunct<bool>(p, "ConditionalValidContent"))
                {
                    if (!Utils.GetField<bool>("HasCompiledScripts", p) && !Utils.GetField<bool>("HasAnyMapFiles", p))
                    {
                        GUI.MessageBox.Show("Please compile scripts first!");
                        return;
                    }
                    Utils.InvokeMeth(p, "SaveMod");
                    var c = Program.ProcFactory.GetCookMod(o);
                    c.OnFinish = () =>
                    {
                        window.Invoke(new MethodInvoker(() =>
                        {
                            o.Refresh();
                            window.DoRefresh();
                        }));
                    };
                    MainWindow.Instance.Runner.RunAppAsync(c);
                }
            };

            var WorkshopChangelogEdit = Utils.GetField<TextBox>("WorkshopChangelogEdit", window);
            var AlreadyReleasedButton = Utils.GetField<Control>("AlreadyReleasedButton", window);
            var ChangeLogLabel = Utils.GetField<Control>("ChangeLogLabel", window);
            WorkshopChangelogEdit.Tag = "notheme";

            // SubmitToWorkshopButton_Click
            var SubmitToWorkshopButton = Utils.GetField<Button>("SubmitToWorkshopButton", window);
            Utils.CleanEvents(SubmitToWorkshopButton);
            Utils.ApplyButtonTheme(SubmitToWorkshopButton);
            SubmitToWorkshopButton.Click += (e, v) =>
            {
                var o = Utils.GetModObjectFromControl(e);
                var p = ((Control)e).FindForm();

                var isCuratedItem = Utils.GetField<bool>("IsCuratedItem", p);

                if (!Utils.InvokeFunct<bool>(p, "ConditionalValidFolder"))
                {
                    return;
                }
                Utils.InvokeMeth(p, "SaveMod");
                if (!SubmitToWorkshopButton.Enabled)
                {
                    return;
                }
                string text = Utils.InvokeFunct<string>(p, "DoesModNeedToBeCooked");
                if (text != "")
                {
                    GUI.MessageBox.Show("Your mod cook is out of date, please cook your mod. Error: " + text);
                    return;
                }
                host.Close();
                new UploadOptions(o).ShowDialog(MainWindow.Instance);
            };

            // Make ModDescriptionEdit scrollable
            var ModDescriptionEdit = Utils.GetField<TextBox>("ModDescriptionEdit", window);
            ModDescriptionEdit.ScrollBars = ScrollBars.Vertical;
            ModDescriptionEdit.WordWrap = true;

            // Add border for modname...
            var ModNameEdit = Utils.GetField<TextBox>("ModNameEdit", window);
            BorderPanel.EatControl(ModNameEdit);

            // Replace TabControl with borderless version
            var tabControl1 = Utils.GetField<TabControl>("tabControl1", window);

            var oldLocation = tabControl1.Location;
            var oldSize = tabControl1.Size;
            var oldAnchor = tabControl1.Anchor;
            var oldParent = tabControl1.Parent;

            var InfoPage        = Utils.GetField<TabPage>("InfoPage",       window);
            var ScriptingPage   = Utils.GetField<TabPage>("ScriptingPage",  window);
            var ContentPage     = Utils.GetField<TabPage>("ContentPage",    window);
            var PublishPage     = Utils.GetField<TabPage>("PublishPage",    window);

            var ButtonInfo      = Utils.GetField<Control>("ButtonInfo", window);
            var ButtonScripting = Utils.GetField<Control>("ButtonScripting", window);
            var ButtonContent   = Utils.GetField<Control>("ButtonContent", window);
            var ButtonPublish   = Utils.GetField<Control>("ButtonPublish", window);

            Utils.CleanEvents(ButtonInfo);
            Utils.CleanEvents(ButtonScripting);
            Utils.CleanEvents(ButtonContent);
            Utils.CleanEvents(ButtonPublish);

            ButtonInfo.Width = 42;
            ButtonScripting.Width = 42;
            ButtonContent.Width = 42;
            ButtonPublish.Width = 42;

            oldParent.Controls.Remove(tabControl1);
            //tabControl1.TabPages.Clear();
            //tabControl1.Dispose();

            var tbc = new BorderlessTabControl();
            tbc.Location = oldLocation;
            tbc.Size = oldSize;
            tbc.Anchor = oldAnchor;

            tbc.TabPages.Add(InfoPage);
            tbc.TabPages.Add(ScriptingPage);
            tbc.TabPages.Add(ContentPage);
            tbc.TabPages.Add(PublishPage);

            foreach (var test in tbc.TabPages)
            {
                var t = (TabPage)test;
                Debug.WriteLine("Tab " + t.ToString() + " " + tbc.TabPages.IndexOf(t));
            }

            tbc.TabIndex = 0;
            tbc.SelectedIndexChanged += (e, v) =>
            {
                var p = ((Control)e).FindForm();
                Utils.InvokeMeth(p, "UpdateButtonTab", ButtonInfo, tbc.SelectedTab == InfoPage);
                Utils.InvokeMeth(p, "UpdateButtonTab", ButtonScripting, tbc.SelectedTab == ScriptingPage);
                Utils.InvokeMeth(p, "UpdateButtonTab", ButtonContent, tbc.SelectedTab == ContentPage);
                Utils.InvokeMeth(p, "UpdateButtonTab", ButtonPublish, tbc.SelectedTab == PublishPage);

                tbc.Appearance = TabAppearance.FlatButtons;
                tbc.ItemSize = new Size(0, 1);
                tbc.SizeMode = TabSizeMode.Fixed;
            };

            oldParent.Controls.Add(tbc);

            ButtonInfo.Click += (e, v) =>
            {
                var p = ((Control)e).FindForm();
                tbc.SelectTab(InfoPage);
            };

            ButtonScripting.Click += (e, v) =>
            {
                var p = ((Control)e).FindForm();
                tbc.SelectTab(ScriptingPage);
            };

            ButtonContent.Click += (e, v) =>
            {
                var p = ((Control)e).FindForm();
                tbc.SelectTab(ContentPage);
            };

            ButtonPublish.Click += (e, v) =>
            {
                var p = ((Control)e).FindForm();
                var o = Utils.GetModObjectFromControl(e);
                o.Refresh();
                window.DoRefresh();
                tbc.SelectTab(PublishPage);
                ButtonPublish.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
                SubmitToWorkshopButton.Text = "SUBMIT/UPDATE MOD\nTO THE STEAM WORKSHOP";
                ChangeLogLabel.Visible = false;
                AlreadyReleasedButton.Visible = false;
                WorkshopChangelogEdit.Visible = false;
                ViewInWorkshopButton.Enabled = o.GetUploadedId() > 0;
            };


            RefreshButton.Location = new Point(window.Width - RefreshButton.Width - 3, RefreshButton.Location.Y);
            Utils.CleanEvents(RefreshButton);
            RefreshButton.Click += (e, v) =>
            {
                var o = Utils.GetModObjectFromControl(e);
                window.DoRefresh();
                MainWindow.Instance.ReloadModList();
                SubmitToWorkshopButton.Text = "SUBMIT/UPDATE MOD\nTO THE STEAM WORKSHOP";
                ChangeLogLabel.Visible = false;
                AlreadyReleasedButton.Visible = false;
                WorkshopChangelogEdit.Visible = false;
                ViewInWorkshopButton.Enabled = o.GetUploadedId() > 0;
            };

            tabControl1 = tbc;

            tabControl1.Visible = true;
            tabControl1.Margin = new Padding(0, 0, 0, 0);
            tabControl1.Padding = new System.Drawing.Point(0, 0);
            tabControl1.Left += 10;
            tabControl1.Width -= 10;
            // OMG it's very long section... Only just for removing TabControl border

            // Hide uneccessary header
            var Header = Utils.GetField<Panel>("Header", window);
            Header.Visible = false;

            // Apply OMM theme
            Utils.ApplyTheme(window);

            host.Icon = MainWindow.Instance.Icon;

            host.FormClosed += Host_FormClosed;

            host.Shown += (obx, e) => {
                var o = (ModObject)((BaseWindow)obx).Tag;
                ViewInWorkshopButton.Enabled = o.GetUploadedId() > 0;
            };

            host.Controls.Add(window);
            host.Show();

            openedForms.Add(host);

            Utils.InvokeMeth(window, "UpdateButtonTab", ButtonInfo, tbc.SelectedTab == InfoPage);
            Utils.InvokeMeth(window, "UpdateButtonTab", ButtonScripting, tbc.SelectedTab == ScriptingPage);
            Utils.InvokeMeth(window, "UpdateButtonTab", ButtonContent, tbc.SelectedTab == ContentPage);
            Utils.InvokeMeth(window, "UpdateButtonTab", ButtonPublish, tbc.SelectedTab == PublishPage);

            tbc.Appearance = TabAppearance.FlatButtons;
            tbc.ItemSize = new Size(0, 1);
            tbc.SizeMode = TabSizeMode.Fixed;
        }

        private static void Host_Shown(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        static bool hidden = false;
        public static void TmpHideForms()
        {
            if (hidden) return;
            foreach (var f in openedForms)
            {
                f.Hide();
            }
            hidden = true;
        }

        public static void UnhideForms()
        {
            foreach (var f in openedForms)
            {
                f.Show();
            }
            hidden = false;
        }

        private static void Host_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                openedForms.Remove((Form)sender);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message + "\n" + ex.ToString());
            }
        }
    }
}

