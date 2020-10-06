using ModdingTools.GUI;
using ModdingTools.Modding;
using ModdingTools.Engine;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ModdingTools.Windows
{
    public partial class ModProperties : BaseWindow
    {
        public ModObject Mod { get; private set; }
        private ModStore Store;
        private string _newIcon = null;
        bool _unsaved;
        bool _saveFeatureHold = true;

        public FormWindowState BackupWindowState { get; set; }
        public bool HasBeenFocused { get; set; }

        private bool HasUnsavedChanges {
            get {
                return _unsaved && !Mod.IsReadOnly;
            }
            set
            {
                if (Mod != null ? Mod.IsReadOnly : false)
                {
                    _unsaved = false;
                    label7.Visible = false;
                    return;
                }
                if (_saveFeatureHold) return;
                _unsaved = value;
                label7.Visible = value;
            }
        }

        public static ModProperties TemporaryHideAllPropertiesWindows()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is ModProperties)
                {
                    var form = (ModProperties)frm;
                    form.BackupWindowState = form.WindowState;
                    form.HasBeenFocused = form == Form.ActiveForm;
                    form.Hide();
                }
            }
            return null;
        }

        public static ModProperties RestoreTemporaryHiddenPropertiesWindows()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is ModProperties)
                {
                    var form = (ModProperties)frm;
                    form.WindowState = form.BackupWindowState;
                    form.Show();
                    if (form.HasBeenFocused) form.Focus();
                }
            }
            return null;
        }

        public static ModProperties GetPropertiesWindowForMod(ModObject mod)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is ModProperties)
                {
                    var form = (ModProperties)frm;
                    if (form.Mod.Equals(mod)) return form;
                }
            }
            return null;
        }

        public ModProperties(ModObject mod)
        {
            this.HandleCreated += ModProperties_HandleCreated;
            InitializeComponent();
            HasUnsavedChanges = false;

            this.Mod = mod;
            this.configList1.OnUpdate += ConfigList1_OnUpdate;
            this.arList1.OnUpdate += ConfigList1_OnUpdate;

            Reload();
        }

        private void ModProperties_HandleCreated(object sender, EventArgs e)
        {
            this.tabController1.Init();
        }

        private void ConfigList1_OnUpdate(object sender, EventArgs e)
        {
            HasUnsavedChanges = true;
        }

        public void Reload()
        {
            _saveFeatureHold = true;
            Mod.Refresh();
            contentBrowser1.LoadMod(Mod);

            levelType.Items.Clear();
            if (Mod.HasAnyMaps())
            {
                levelType.Visible = true;
                label1.Visible = true;

                foreach (var a in ModObject.IniTagToSteamMapping)
                {
                    levelType.Items.Add(a.Value);
                    if (a.Key.Equals(Mod.MapType, StringComparison.InvariantCultureIgnoreCase))
                    {
                        levelType.SelectedItem = a.Value;
                    }
                }
            }
            else
            {
                levelType.Visible = false;
                label1.Visible = false;
            }

            var imageList = new ImageList();
            imageList.ImageSize = new Size(36, 36);

            foreach (var img in Engine.ModClass.ClassToIconMapping)
            {
                imageList.Images.Add(img.Key.ToString(), img.Value);
            }

            this.Text = $"{Mod.Name.ToUpper()} (V. {Mod.Version})";
            this.ModDescriptionEdit.Text = Mod.GetDescription();
            this.modFolderName.Text = Mod.GetDirectoryName();
            this.modName.Text = Mod.Name;
            this.cbOnlineParty.Checked = Mod.IsOnlineParty;
            this.iconView.BackgroundImage = Mod.GetIcon();
            this.chapterInfoInput.Text = Mod.ChapterInfoName;

            this.cbCoOp.Checked = Mod.Coop.ToLower() == "cooponly";
            this.cbOnlineParty.Checked = Mod.IsOnlineParty;
            this.label5.Text = Mod.Version;
            this.lblAuthor.Text = Mod.Author;

            var tags = ModObject.CombineTags(Mod.GetModClasses());

            this.tagsList.Clear();
            this.tagsList.LargeImageList = imageList;

            this.ModClass.Text = Mod.ModClass;

            foreach (var tag in tags)
            {
                if (Engine.ModClass.VisibleTypes.Contains(tag))
                    this.tagsList.Items.Add("Contains " + Engine.ModClass.ClassToNameMapping[tag], tag.ToString());
            }

            if (Mod.HasAnyMaps())
            {
                this.tagsList.Items.Add("Contains map", "Map");
            }

            if (Mod.AssetReplacements.Count > 0)
            {
                this.tagsList.Items.Add("Asset Replace", "AssetReplace");
            }

            if (Mod.AutoGiveItems)
            {
                this.tagsList.Items.Add("Items are available immediately", "AutoGiveItems");
            }

            mButton1.Enabled = Mod.IsReleased;

            arList1.Fill(Mod.AssetReplacements);

            this.configList1.Fill(Mod);
            Debug.WriteLine("ConfigCount: " + Mod.Config.Count);

            var cooked = ReloadFlags();

            if (Mod.IsReadOnly)
            {
                mButton4.Enabled = false;
                mButton5.Enabled = false;
                mButton6.Enabled = false;
                mButton7.Enabled = false;
                mButton8.Enabled = false;
                mButton10.Enabled = false;
                label5.Enabled = false;
                arList1.Enabled = false;
                chapterInfoInput.Enabled = false;
                cbOnlineParty.Enabled = false;
                cbCoOp.Enabled = false;
                levelType.Enabled = false;
                iconView.Enabled = false;
                modName.Enabled = false;
                modFolderName.Enabled = false;
                ModDescriptionEdit.ReadOnly = true;
            }

            comboBox1.Items.Clear();
            panel2.Enabled = false;
            if (cooked)
            {
                //Mod.TestMod(MainWindow.Instance.Runner, "mafia_town");
                comboBox1.Items.Add(new MapItem("hub_spaceship", "Spaceship"));
                comboBox1.Items.Add(new MapItem("mafia_town", "Mafia Town"));
                comboBox1.Items.Add(new MapItem("hatintimeentry", "HatInTimeEntry"));
                comboBox1.Items.Add(new MapItem("??menu", "Main Menu"));

                if (Mod.HasAnyCookedMaps())
                {
                    foreach (var a in Mod.GetCookedMaps())
                    {
                        comboBox1.Items.Add(new MapItem(a));
                    }
                }

                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                panel2.Enabled = true;
            }

            Store = ModStore.LoadForMod(Mod);

            checkBox1.Checked = Store.UseSeparateDescriptionForSteam;
            SteamDescription.Enabled = Store.UseSeparateDescriptionForSteam;
            SteamDescription.Text = Store.GetDescription();

            _saveFeatureHold = false;
            HasUnsavedChanges = false;
        }

        public void ToggleUnlock(bool v)
        {
            foreach (var tab in tabControl2.TabPages)
            {
                if (tab == tab6) continue;
                ((Control)tab).Enabled = v;
            }

            panel1.Enabled = v;
            mButton4.Enabled = v;
            iconView.Enabled = v;
            modName.Enabled = v;
            modFolderName.Enabled = v;
            label5.Enabled = v;
            ModDescriptionEdit.ReadOnly = !v;
            panel2.Enabled = v;
            tabController1.Enabled = v;
        }

        private bool ConditionalReload()
        {
            if (HasUnsavedChanges)
            {
                var result = GUI.MessageBox.Show("You have unsaved changes... Do you want to save them?\n\nClicking \"NO\" will undo any changes to the last saved state!", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveMod();
                    return true;
                }
                else if (result == DialogResult.No)
                {
                    Reload();
                    return true;
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }

                throw new NotImplementedException("WTF?");
            }
            else
            {
                Reload();
                return true;
            }
        }

        private bool ReloadFlags()
        {
            var good = Properties.Resources.ok;
            var bad =  Properties.Resources.delete;

            bool flag =  !string.IsNullOrEmpty(Mod.Name);
            bool flag2 = !string.IsNullOrEmpty(Mod.GetDescription());
            bool flag3 = Utils.DirContainsKey(Mod.GetContentDir(), "*.upk");
            bool flag4 = Utils.DirContainsKey(Mod.GetLocsDir(), "*.int");
            bool flag5 = Utils.DirContainsKey(Mod.GetCookedDir(), "*.u") || Utils.DirContainsKey(Mod.GetCookedDir(), "*.umap");
            bool flag6 = (Mod.HasCompiledScripts() | flag3 | flag4) || Mod.HasAnyMaps();
            bool flag7 = Mod.ValidateIcon();
            bool flag8 = Mod.TagsCompleted(); //todo: tags

            mButton6.Enabled = (flag6 && !contentBrowser1.HasContentError && !Mod.IsLanguagePack);

            var cooked = (flag5 || Mod.IsLanguagePack) && !contentBrowser1.HasContentError;
            flagCook.Image = cooked ? good : bad;
            flagTitle.Image = flag ? good : bad;
            flagDesc.Image = flag2 ? good : bad;
            flagIcon.Image = flag7 ? good : bad;
            flagTags.Image = flag8 ? good : bad;

            mButton8.Enabled = (((flag5 || Mod.IsLanguagePack) && !contentBrowser1.HasContentError) && flag && flag2 && flag7 && flag8);

            return cooked;
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            MainWindow.Instance.Runner.RunWithoutWait(Program.ProcFactory.LaunchEditor(Mod.GetDirectoryName()));
        }

        private void iconView_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "png";
            dlg.Multiselect = false;
            dlg.Filter = "Image file (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(dlg.FileName);
                if (f.Exists)
                {
                    if (f.Length > 1000000)
                    {
                        GUI.MessageBox.Show("Icon must have less than 1MB of size!");
                    }
                    else
                    {
                        var img = Image.FromFile(f.FullName);
                        if (img.Width == img.Height)
                        {
                            if (img.Width < 100)
                            {
                                GUI.MessageBox.Show("Icon must have at least 100x100px size!");
                            }
                            else
                            {
                                iconView.BackgroundImage = img;
                                _newIcon = f.FullName;
                                HasUnsavedChanges = true;
                            }
                        }
                        else
                        {
                            GUI.MessageBox.Show("Icon must be square shaped!");
                        }            
                    }
                }
                else
                {
                    GUI.MessageBox.Show("Invalid file");
                }
            }
        }

        private void btnIconSelector_Click(object sender, EventArgs e)
        {

        }

        private void mButton4_Click(object sender, EventArgs e)
        {
            SaveMod();
        }

        public void SaveMod()
        {
            try
            {
                Mod.AssetReplacements = arList1.Collect();
                Mod.Name = modName.Text;
                Mod.SetDescription(ModDescriptionEdit.Text);
                Mod.ChapterInfoName = chapterInfoInput.Text;
                Mod.IsOnlineParty = cbOnlineParty.Checked;
                Mod.Coop = cbCoOp.Checked ? "CoopOnly" : "";
                Mod.Version = label5.Text;
                Mod.Author = lblAuthor.Text;
                if (Mod.GetDirectoryName() != modFolderName.Text)
                {
                    Mod.RenameDirectory(modFolderName.Text);
                }
                if (levelType.SelectedIndex >= 0 && levelType.SelectedIndex < Mod.AllowedMapTypes.Count())
                {
                    Mod.MapType = Mod.AllowedMapTypes[levelType.SelectedIndex];
                }
                else
                {
                    Mod.MapType = "";
                }

                if (_newIcon != null)
                {
                    var iconE = _newIcon.Split('.');
                    var iconExt = iconE[iconE.Length - 1].ToLower();

                    var allowedExts = new[] { "png", "jpg", "jpeg" };
                    if (!allowedExts.Contains(iconExt))
                    {
                        throw new Exception("Illegal icon extension: " + iconExt);
                    }
 
                    var icon = Path.Combine(Mod.RootPath, "icon." + iconExt);
                    
                    if (File.Exists(icon))
                    {
                        File.Delete(icon);
                    }
                    File.Copy(_newIcon, icon);
                    _newIcon = null;
                    Mod.Icon = "icon." + iconExt;
                }

                Mod.Save();

                Store.SetDescription(SteamDescription.Text);
                Store.UseSeparateDescriptionForSteam = checkBox1.Checked;
                Store.SaveForMod(Mod);

                HasUnsavedChanges = false;

                Reload();
            }
            catch (Exception e)
            {
                GUI.MessageBox.Show(this, e.Message + "\n\n" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            Utils.OpenInExplorer(Mod.RootPath);
        }

        private void modName_Click(object sender, EventArgs e)
        {
            var iw = InputWindow.Ask(this, "Mod name", "Enter the mod name", new InputWindow.NonEmptyValidator(), modName.Text);
            if (iw != null)
            {
                if (modName.Text != iw)
                {
                    modName.Text = iw;
                    HasUnsavedChanges = true;
                }         
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mod.MapType != levelType.SelectedItem.ToString())
            {
                Mod.MapType = levelType.SelectedItem.ToString();
                HasUnsavedChanges = true;
            }     
        }

        private void mButton7_Click(object sender, EventArgs e)
        {
            var d = Mod.TryDetectCIInContent();
            if (d != null)
            {
                if (chapterInfoInput.Text != d)
                {
                    chapterInfoInput.Text = d;
                    HasUnsavedChanges = true;
                }
            }
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            //Reload();
            ConditionalReload();
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            if (Mod.GetUploadedId() > 0)
            {
                Process.Start("steam://openurl/http://steamcommunity.com/sharedfiles/filedetails/?id=" + Mod.GetUploadedId());
            }
        }

        private void modFolderName_Click(object sender, EventArgs e)
        {
            var iw = InputWindow.Ask(this, "Mod folder name", "Enter the mod folder name", new InputWindow.ModNameValidator(), modFolderName.Text);
            if (iw != null)
            {
                if (modFolderName.Text != iw)
                {
                    modFolderName.Text = iw;
                    HasUnsavedChanges = true;
                }
            }
        }

        private void mButton5_Click(object sender, EventArgs e)
        {
            if(!contentBrowser1.HasContentError)
            {
                if (!ConditionalReload()) return;
                ToggleUnlock(false);

                Mod.UnCookMod();
                Task.Factory.StartNew(() =>
                {
                    Mod.CompileScripts(this.processRunner1, false, false);
                    this.Invoke(new MethodInvoker(() => ToggleUnlock(true)));
                    this.Invoke(new MethodInvoker(() => Reload()));
                });
            }
        }

        private void mButton6_Click(object sender, EventArgs e)
        {
            if (!contentBrowser1.HasContentError)
            {
                if (!ConditionalReload()) return;

                if (!Mod.HasCompiledScripts() && Mod.HasAnyScripts())
                {
                    GUI.MessageBox.Show("Please compile scripts first!");
                    return;
                }
                ToggleUnlock(false);
                SaveMod();
                Mod.UnCookMod();
                Task.Factory.StartNew(() =>
                {
                    Mod.CookMod(this.processRunner1, false);
                    this.Invoke(new MethodInvoker(() => ToggleUnlock(true)));
                    this.Invoke(new MethodInvoker(() => Reload()));
                });
            }      
        }

        private void mButton8_Click_1(object sender, EventArgs e)
        {
            if (ConditionalReload())
            {
                new UploadOptions(Mod).ShowDialog(this);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var iw = InputWindow.Ask(this, "Version", "Enter the mod version", new InputWindow.NonEmptyValidator(), label5.Text);
            if (iw != null)
            {
                if (label5.Text != iw)
                {
                    label5.Text = iw;
                    HasUnsavedChanges = true;
                }
            }
        }

        class MapItem
        {
            public string Name;
            public string DisplayName;

            public MapItem(string name, string displayName = null)
            {
                Name = name;
                DisplayName = displayName;
            }

            public override string ToString()
            {
                return DisplayName ?? Name;
            }
        }

        private void mButton9_Click(object sender, EventArgs e)
        {
            var item = (MapItem)comboBox1.SelectedItem;
            Mod.TestMod(MainWindow.Instance.Runner, item.Name == "??menu" ? null : item.Name);
        }

        private void cbOnlineParty_CheckedChanged(object sender, EventArgs e)
        {
            HasUnsavedChanges = true;
        }

        private void cbCoOp_CheckedChanged(object sender, EventArgs e)
        {
            HasUnsavedChanges = true;
        }

        private void chapterInfoInput_TextChanged(object sender, EventArgs e)
        {
            HasUnsavedChanges = true;
        }

        private void ModProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConditionalReload())
            {
                e.Cancel = true;
                return;
            }
            MainWindow.Instance.FocusMe();
        }

        private void ModDescriptionEdit_TextChanged(object sender, EventArgs e)
        {
            HasUnsavedChanges = true;
        }

        private void flagTitle_Click(object sender, EventArgs e)
        {
            modName_Click(sender, e);
        }

        private void flagCook_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tab6;
        }

        private void flagDesc_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tab5;
        }

        private void flagIcon_Click(object sender, EventArgs e)
        {
            iconView_Click(sender, e);
        }

        private void flagTags_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tab1;
        }

        private void lblAuthor_Click(object sender, EventArgs e)
        {
            var iw = InputWindow.Ask(this, "Author", "Enter the mod author", null, lblAuthor.Text);
            if (iw != null)
            {
                if (lblAuthor.Text != iw)
                {
                    lblAuthor.Text = iw;
                    HasUnsavedChanges = true;
                }
            }
        }

        private void ModProperties_Load(object sender, EventArgs e)
        {
        }

        private void tabController1_PageChange(object sender, TabController.TabControllerPageChangeEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Store.UseSeparateDescriptionForSteam = checkBox1.Checked;
            SteamDescription.Enabled = checkBox1.Checked;
            if (!checkBox1.Checked)
            {
                SteamDescription.Text = Store.GetDescription();
            }
            HasUnsavedChanges = true;
        }

        private void SteamDescription_TextChanged(object sender, EventArgs e)
        {
            HasUnsavedChanges = true;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void mButton10_Click(object sender, EventArgs e)
        {
            if (!contentBrowser1.HasContentError)
            {
                if (!ConditionalReload()) return;
                ToggleUnlock(false);
                SaveMod();
                Mod.UnCookMod();
                Task.Factory.StartNew(() =>
                {
                    var compileResult = Mod.CompileScripts(this.processRunner1, false);
                    if (compileResult)
                    {
                        var cookResult = Mod.CookMod(this.processRunner1, false, false);
                        if (!cookResult)
                        {
                            GUI.MessageBox.Show(this, "Cooking the mod was failed! Look at the console output for more info!");
                        }
                    }
                    else
                    {
                        GUI.MessageBox.Show(this, "Compiling scripts was failed! Look at the console output for more info!");
                    }

                    this.Invoke(new MethodInvoker(() => ToggleUnlock(true)));
                    this.Invoke(new MethodInvoker(() => Reload()));
                });
            }
        }
    }
}
