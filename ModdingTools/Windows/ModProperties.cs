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
using CUFramework.Windows;
using CUFramework.Dialogs;
using CUFramework.Controls.Tabs;
using CUFramework.Dialogs.Validators;
using ModdingTools.Windows.Validators;
using System.Globalization;
using CUFramework.Controls;
using ModdingTools.Settings;

namespace ModdingTools.Windows
{
    public partial class ModProperties : CUWindow
    {
        public ModObject Mod { get; private set; }
        private ModStore Store;

        bool _unsaved;
        bool _saveFeatureHold = true;

        private static readonly string RemovalFlag = "!@%^$marked_for_removal";

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
            this.TitlebarColorChanged += ModProperties_FocusChanged;

            Reload();
        }

        private void ModProperties_FocusChanged(object sender, EventArgs e)
        {
            mButton2.BackColor = VisibleTitlebarColor;
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
            comboBox3.SelectedIndex = Math.Min(Math.Max(OMMSettings.Instance.LastAction, 0), comboBox3.Items.Count - 1);

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
            this.cbOnlineParty.Checked = Mod.IsOnlineParty;;
            this.chapterInfoInput.Text = Mod.ChapterInfoName;

            this.cbCoOp.Checked = Mod.Coop.ToLower() == "cooponly";
            this.cbOnlineParty.Checked = Mod.IsOnlineParty;
            this.label5.Text = Mod.Version;
            this.lblAuthor.Text = string.Join(";", Mod.Author);

            if (Mod.SpecialThanks != null)
                this.label20.Text = string.Join(";", Mod.SpecialThanks);

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
                IconViewGif.Enabled = false;
                modName.Enabled = false;
                modFolderName.Enabled = false;
                ModDescriptionEdit.ReadOnly = true;
            }

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            panel2.Enabled = false;


            comboBox2.Items.Add(new MapItem(null, "(none)", true));
            var maps = Mod.GetAllMaps();
            if (maps != null)
            foreach (var a in maps)
            {
                comboBox2.Items.Add(new MapItem(a, null, true));
                if (a.Equals(Mod.IntroductionMap, StringComparison.InvariantCultureIgnoreCase))
                {
                    comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
                }
            }
            if (comboBox2.SelectedIndex < 0)
            {
                comboBox2.SelectedIndex = 0;
            }

            string lastMap = "";
            try
            {
                var flagFile = Path.Combine(Mod.RootPath, ".lastMap");
                if (File.Exists(flagFile))
                    lastMap = File.ReadAllText(flagFile);
            }
            catch (Exception)
            {
            }

            //Mod.TestMod(MainWindow.Instance.Runner, "mafia_town");
            comboBox1.Items.Add(new MapItem("hub_spaceship", "Spaceship", true));
            comboBox1.Items.Add(new MapItem("mafia_town", "Mafia Town", true));
            comboBox1.Items.Add(new MapItem("hatintimeentry", "HatInTimeEntry", true));
            comboBox1.Items.Add(new MapItem("??menu", "Main Menu", true));

            var mapsA = Mod.GetCookedMaps();
            foreach (var a in Mod.GetAllMaps())
            {
                comboBox1.Items.Add(new MapItem(a, null, mapsA == null ? false : mapsA.Contains(a, StringComparer.InvariantCultureIgnoreCase)));
            }

            bool found = false;
            foreach (var a in comboBox1.Items)
            {
                var item = (MapItem)a;
                if (item.Name == lastMap)
                {
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(a);
                    found = true;
                    break;
                }
            }

            if (!found)
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            panel2.Enabled = true;

            Store = ModStore.LoadForMod(Mod);

            LoadGraphics();

            checkBox1.Checked = Store.UseSeparateDescriptionForSteam;
            SteamDescription.Enabled = Store.UseSeparateDescriptionForSteam;
            SteamDescription.Text = Store.GetDescription();

            _saveFeatureHold = false;
            HasUnsavedChanges = false;

            var workshopId = Mod.GetUploadedId();
            if (workshopId > 0)
            {
                this.Text = $"[{workshopId}] {Mod.Name.ToUpper()} (V. {Mod.Version})";
            }
        }

        private void LoadGraphics()
        {
            // icon
            iconView.SizeMode = PictureBoxSizeMode.StretchImage;
            if (Mod.ValidateIcon())
            {
                var loc = Mod.GetIconLocation();
                if (!File.Exists(loc))
                {
                    iconView.Image = Properties.Resources.noimage;
                }
                else
                {
                    iconView.Image = Utils.LoadImageIntoMemory(loc);
                }
            }
            else
            {
                iconView.Image = Properties.Resources.noimage;
            }

            // icon gif
            IconViewGif.SizeMode = PictureBoxSizeMode.StretchImage;
            if (Store.CheckIcon(Mod))
            {
                var loc = Store.GetGifLocation(Mod);
                if (!File.Exists(loc))
                {
                    IconViewGif.Image = Properties.Resources.noimage;
                }
                else
                {
                    IconViewGif.Image = Utils.LoadImageIntoMemory(loc);
                }
            }
            else
            {
                Debug.WriteLine("GIF validation failed...");
                IconViewGif.Image = Properties.Resources.noimage;
            }

            // logo
            panel5.SizeMode = PictureBoxSizeMode.StretchImage;
            {
                var loc = Mod.GetLogoLocation();
                panel5.Image = !File.Exists(loc) ? Properties.Resources.noimage_wide : Utils.LoadImageIntoMemory(loc);
            }

            // splash
            panel8.SizeMode = PictureBoxSizeMode.StretchImage;
            {
                var loc = Mod.GetSplashArtLocation();
                panel8.Image = !File.Exists(loc) ? Properties.Resources.noimage_wide : Utils.LoadImageIntoMemory(loc);
            }

            // background
            panel10.SizeMode = PictureBoxSizeMode.StretchImage;
            {
                var loc = Mod.GetBackgroundLocation();
                panel10.Image = !File.Exists(loc) ? Properties.Resources.noimage_wide : Utils.LoadImageIntoMemory(loc);
            }

            // titlecard
            panel12.SizeMode = PictureBoxSizeMode.StretchImage;
            {
                var loc = Mod.GetTitleCardLocation();
                panel12.Image = !File.Exists(loc) ? Properties.Resources.noimage_wide : Utils.LoadImageIntoMemory(loc);
            }
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
            comboBox1.Enabled = v;
        }

        private bool ConditionalReload()
        {
            if (HasUnsavedChanges)
            {
                var result = CUMessageBox.Show("You have unsaved changes... Do you want to save them?\n\nClicking \"NO\" will undo any changes to the last saved state!", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
            bool flag8 = Mod.TagsCompleted();

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
            PickImage("Icon", ref iconView, true, 1, 100);
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
                Mod.Author = string.IsNullOrEmpty(lblAuthor.Text) ? null : lblAuthor.Text.Split(';');
                Mod.SpecialThanks = string.IsNullOrEmpty(label20.Text) ? null : label20.Text.Split(';');

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

                Dictionary<PictureBox, string> iconTasks = new Dictionary<PictureBox, string>()
                {
                    { iconView, "icon" },
                    { panel5,   "logo" },
                    { panel8,   "splash" },
                    { panel10,  "background" },
                    { panel12,  "titlecard" }
                };

                foreach (var x in iconTasks)
                {
                    if (x.Key.Tag != null)
                    {
                        if (x.Key.Tag != RemovalFlag)
                        {
                            var iconE = ((string)x.Key.Tag).Split('.');
                            var iconExt = iconE[iconE.Length - 1].ToLower();

                            var allowedExts = new[] { "png", "jpg", "jpeg" };
                            if (!allowedExts.Contains(iconExt))
                            {
                                throw new Exception("Illegal icon extension: " + iconExt);
                            }

                            var icon = Path.Combine(Mod.RootPath, x.Value + "." + iconExt);

                            if (File.Exists(icon)) File.Delete(icon);

                            File.Copy((string)x.Key.Tag, icon);
                            x.Key.Tag = null;
                            Mod.SetImageResource(x.Value, x.Value + "." + iconExt);
                        }
                        else
                        {
                            Mod.SetImageResource(x.Value, "");
                        }
                    }
                    else
                    {
                        var test = Mod.GetImageResource(x.Value);
                        if (String.IsNullOrEmpty(test) || !File.Exists(Path.Combine(Mod.RootPath, test)))
                            Mod.SetImageResource(x.Value, "");
                    }
                }

                if (IconViewGif.Tag != null)
                {
                    if (IconViewGif.Tag != RemovalFlag)
                    {
                        var iconE = ((string)IconViewGif.Tag).Split('.');
                        var iconExt = iconE[iconE.Length - 1].ToLower();

                        var allowedExts = new[] { "gif" };
                        if (!allowedExts.Contains(iconExt))
                        {
                            throw new Exception("Illegal icon extension: " + iconExt);
                        }

                        var icon = Path.Combine(Mod.RootPath, "icon_animated." + iconExt);

                        if (File.Exists(icon))
                        {
                            File.Delete(icon);
                        }
                        File.Copy((string)IconViewGif.Tag, icon);
                        IconViewGif.Tag = null;
                        Store.AnimatedIconFileName = "icon_animated." + iconExt;
                    }
                    else
                    {
                        Store.AnimatedIconFileName = "";
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(Store.AnimatedIconFileName) || !File.Exists(Path.Combine(Mod.RootPath, Store.AnimatedIconFileName)))
                        Store.AnimatedIconFileName = "";
                }


                Mod.IntroductionMap = ((MapItem)comboBox2.SelectedItem).Name;

                Mod.Save();

                Store.SetDescription(SteamDescription.Text);
                Store.UseSeparateDescriptionForSteam = checkBox1.Checked;
                Store.SaveForMod(Mod);

                HasUnsavedChanges = false;

                Reload();
            }
            catch (Exception e)
            {
                CUMessageBox.Show(this, e.Message + "\n\n" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            Utils.OpenInExplorer(Mod.RootPath);
        }

        private void modName_Click(object sender, EventArgs e)
        {
            var iw = CUInputWindow.Ask(this, "Mod name", "Enter the mod name", new NonEmptyValidator(), modName.Text);
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
            var iw = CUInputWindow.Ask(this, "Mod folder name", "Enter the mod folder name", new ModNameValidator(), modFolderName.Text);
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
                    Mod.CompileScripts(this.processRunner1.Runner, false, false);
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
                    CUMessageBox.Show("Please compile scripts first!");
                    return;
                }
                ToggleUnlock(false);
                SaveMod();
                Mod.UnCookMod();
                Task.Factory.StartNew(() =>
                {
                    Mod.CookMod(this.processRunner1.Runner, false);
                    this.Invoke(new MethodInvoker(() => ToggleUnlock(true)));
                    this.Invoke(new MethodInvoker(() => Reload()));
                });
            }      
        }

        private void mButton8_Click_1(object sender, EventArgs e)
        {
            if (ConditionalReload())
            {
                var up = new UploadOptions(Mod);
                up.StartPosition = FormStartPosition.CenterParent;
                up.ShowDialog(this);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var iw = CUInputWindow.Ask(this, "Version", "Enter the mod version", new NonEmptyValidator(), label5.Text);
            if (iw != null)
            {
                if (label5.Text != iw)
                {
                    label5.Text = iw;
                    HasUnsavedChanges = true;
                }
            }
        }

        public class MapItem
        {
            public string Name;
            public string DisplayName;
            public bool IsCooked;

            public MapItem(string name, string displayName = null, bool isCooked = false)
            {
                Name = name;
                DisplayName = displayName;
                IsCooked = isCooked;
            }

            public override string ToString()
            {
                return DisplayName ?? Name + (IsCooked ? "" : " [Uncooked!]");
            }
        }

        private void mButton9_Click(object sender, EventArgs e)
        {
            var item = (MapItem)comboBox1.SelectedItem;
            try
            {
                File.WriteAllText(Path.Combine(Mod.RootPath, ".lastMap"), item.Name);
            }
            catch (Exception) { }
            Mod.TestModAllMods(MainWindow.Instance.Runner, item.Name == "??menu" ? null : item.Name);
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
            var iw = ArrayInputWindow.Ask("Author/Credits", "Enter the mod author or credits.\n\n(if you put more than one item, the game will treat it as credits!)", string.IsNullOrEmpty(lblAuthor.Text) ? new string[0] : lblAuthor.Text.Split(';'), new SplitListValidator(';')); 
            //CUInputWindow.Ask(this, "Author", "Enter the mod author", null, lblAuthor.Text);
            if (iw != null)
            {
                var result = string.Join(";", iw);
                if (lblAuthor.Text != result)
                {
                    lblAuthor.Text = result;
                    HasUnsavedChanges = true;
                }
            }
        }

        private void ModProperties_Load(object sender, EventArgs e)
        {
        }

        private void tabController1_PageChange(object sender, CUTabController.TabControllerPageChangeEventArgs e)
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
                if (comboBox3.SelectedIndex > 0)
                {
                    var item = (MapItem)comboBox1.SelectedItem;
                    try
                    {
                        File.WriteAllText(Path.Combine(Mod.RootPath, ".lastMap"), item.Name);
                    }
                    catch (Exception) { }
                } 

                if (!ConditionalReload()) return;
                ToggleUnlock(false);
                SaveMod();

                this.processRunner1.consoleControl1.Clear();

                if (OMMSettings.Instance.KillEditorBeforeCooking)
                    Utils.KillEditor();
                if (OMMSettings.Instance.KillGameBeforeCooking)
                    Utils.KillGame();

                if (ModifierKeys == Keys.Shift)
                {
                    this.processRunner1.Runner.Log("Shift key is pressed - forcing recook", CUFramework.Shared.LogLevel.Success);
                    Mod.UnCookMod();
                }

                if (!OMMSettings.Instance.FastCook)
                {
                    Task.Factory.StartNew(() =>
                    {
                        Mod.UnCookMod();
                        var startTime = DateTime.Now;

                        var cookedStatus = Mod.DoesModNeedToBeCooked();
                        var scriptNeedCooking = cookedStatus != null && (cookedStatus.Contains("[0x1]") || cookedStatus.Contains("[0x2]") || cookedStatus.Contains("[0x0]"));

                        var compileResult = false;

                        if (scriptNeedCooking)
                        {
                            compileResult = Mod.CompileScripts(this.processRunner1.Runner, false, false, false);
                        }
                        else
                        {
                            this.processRunner1.Runner.Log("Scripts are up-to-date! Cooking...", CUFramework.Shared.LogLevel.Success);
                            compileResult = true;
                        }
                        
                        if (compileResult)
                        {
                            var cookResult = Mod.CookMod(this.processRunner1.Runner, false, false);
                            if (!cookResult)
                            {
                                CUMessageBox.Show(this, "Cooking the mod was failed! Look at the console output for more info!");
                            }
                            else
                            {
                                Utils.UpdateFileDates(Mod.GetCookedDir());
                                RunPostCookTask();
                            }
                        }
                        else
                        {
                            CUMessageBox.Show(this, "Compiling scripts was failed! Look at the console output for more info!");
                        }

                        var endTime = DateTime.Now;
                        var taskTime = Math.Round((endTime - startTime).TotalMilliseconds / 1000, 2).ToString(CultureInfo.InvariantCulture);
                        this.processRunner1.Log($"Task finished in {taskTime}s", CUFramework.Shared.LogLevel.Verbose);

                        this.Invoke(new MethodInvoker(() => ToggleUnlock(true)));
                        this.Invoke(new MethodInvoker(() => Reload()));
                    });
                }
                else
                {
                    Task.Factory.StartNew(() =>
                    {
                        var startTime = DateTime.Now;

                        var cookedStatus = Mod.DoesModNeedToBeCooked();
                        var fast = cookedStatus != null && !cookedStatus.Contains("[0x0]") && !cookedStatus.Contains("[0x3]") && !cookedStatus.Contains("[0x4]");
                        var scriptNeedCooking = cookedStatus != null && (cookedStatus.Contains("[0x1]") || cookedStatus.Contains("[0x2]") || cookedStatus.Contains("[0x0]"));


                        this.processRunner1.Log("[Experimental] Fast script cooking is enabled! Please report any issues!", CUFramework.Shared.LogLevel.Warn);
                        this.processRunner1.Log("Current state:", CUFramework.Shared.LogLevel.Info);
                        this.processRunner1.Log(cookedStatus, CUFramework.Shared.LogLevel.Info);
                        if (cookedStatus != null)
                        {
                            if (scriptNeedCooking)
                            {
                                var compileResult = Mod.CompileScripts(this.processRunner1.Runner, false);
                                if (compileResult)
                                {
                                    var cookResult = Mod.CookMod(this.processRunner1.Runner, false, false, fast);
                                    if (!cookResult)
                                    {
                                        CUMessageBox.Show(this, "Cooking the mod was failed! Look at the console output for more info!");
                                    }
                                    else
                                    {
                                        Utils.UpdateFileDates(Mod.GetCookedDir());
                                        RunPostCookTask();
                                    }
                                }
                                else
                                {
                                    CUMessageBox.Show(this, "Compiling scripts was failed! Look at the console output for more info!");
                                }
                            }
                            else
                            {
                                this.processRunner1.Runner.Log("Scripts are up-to-date! Cooking...", CUFramework.Shared.LogLevel.Success);
                                var cookResult = Mod.CookMod(this.processRunner1.Runner, false, false, fast);
                                if (!cookResult)
                                {
                                    CUMessageBox.Show(this, "Cooking the mod was failed! Look at the console output for more info!");
                                }
                                else
                                {
                                    Utils.UpdateFileDates(Mod.GetCookedDir());
                                    RunPostCookTask();
                                }
                            }
                        }
                        else
                        {
                            this.processRunner1.Log("Skipping cooking, everything is up-to-date!", CUFramework.Shared.LogLevel.Success);
                            RunPostCookTask();
                        }
                        var endTime = DateTime.Now;
                        var taskTime = Math.Round((endTime - startTime).TotalMilliseconds / 1000, 2).ToString(CultureInfo.InvariantCulture);
                        this.processRunner1.Log($"Task finished in {taskTime}s", CUFramework.Shared.LogLevel.Verbose);

                        this.Invoke(new MethodInvoker(() => ToggleUnlock(true)));
                        this.Invoke(new MethodInvoker(() => Reload()));
                    });
                }
            }
        }

        private void RunPostCookTask()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => RunPostCookTask()));
                return;
            }

            /* [0] DO NOTHING
               [1] LAUNCH GAME (NO WORKSHOP MODS, SELECTED MAP)
               [2] LAUNCH GAME (WITH WORKSHOP MODS, SELECTED MAP)
            */
            switch (comboBox3.SelectedIndex)
            {
                case 1:
                    cuButton2_Click(null, null);
                    break;
                case 2:
                    mButton9_Click(null, null);
                    break;
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PickImage("Animated icon", ref IconViewGif, true, 1, 100, "gif", "GIF Animation file (*.gif)|*.gif");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UnpickImage(ref IconViewGif, Properties.Resources.noimage);
        }

        private void cuButton1_Click(object sender, EventArgs e)
        {
            if (!contentBrowser1.HasContentError)
            {
                if (!ConditionalReload()) return;
                ToggleUnlock(false);
                Task.Factory.StartNew(() =>
                {
                    if (OMMSettings.Instance.KillEditorBeforeCooking)
                        Utils.KillEditor();
                    if (OMMSettings.Instance.KillGameBeforeCooking)
                        Utils.KillGame();

                    Mod.UnCookMod();

                    if (Mod.CompileScripts(this.processRunner1.Runner, false, false))
                    {
                        this.Invoke(new MethodInvoker(() => {
                            MainWindow.Instance.Runner.RunWithoutWait(Program.ProcFactory.LaunchEditor(Mod.GetDirectoryName()));
                        }));
                    }
                    this.Invoke(new MethodInvoker(() => ToggleUnlock(true)));
                    this.Invoke(new MethodInvoker(() => Reload()));
                });
            }
        }

        // LOGO
        private void panel5_Click(object sender, EventArgs e)
        {
            PickImage("Logo", ref panel5, false, -1, 100);
        }

        private void UnpickImage(ref PictureBox target, Bitmap noImageBitmap)
        {
            if (target.Tag == null && (target.Image == null || target.Image == noImageBitmap)) return;
            target.SizeMode = PictureBoxSizeMode.StretchImage;
            target.Image = null;
            target.Image = noImageBitmap;
            target.Tag = RemovalFlag;
            HasUnsavedChanges = true;
        }

        private void PickImage(string context, ref PictureBox target, bool mustBeSquare, int sizeLimit = -1, int minWidth = 100, string ext = "png", string filter = "Image file (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png")
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ext;
            dlg.Multiselect = false;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(dlg.FileName);
                if (f.Exists)
                {
                    if (sizeLimit > 0 && f.Length > (sizeLimit * 1048576))
                    {
                        CUMessageBox.Show($"{context} must have less than {sizeLimit}MB of size!");
                        return;
                    }
                    var img = Image.FromFile(f.FullName);
                    if (img.Width == img.Height || !mustBeSquare)
                    {
                        if (img.Width < minWidth)
                        {
                            CUMessageBox.Show($"{context} must have at least {minWidth}x{minWidth}px size!");
                        }
                        else
                        {
                            //target.BackgroundImage = img;
                            target.SizeMode = PictureBoxSizeMode.StretchImage;
                            target.Image = null; // dispose old image
                            target.Image = Utils.LoadImageIntoMemory(f.FullName);
                            target.Tag = f.FullName;
                            HasUnsavedChanges = true;
                        }
                    }
                    else
                    {
                        CUMessageBox.Show($"{context} must be square shaped!");
                    }
                }
                else
                {
                    CUMessageBox.Show("Invalid file");
                }
            }
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            PickImage("Splash art", ref panel8, false, -1, 100);
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            PickImage("Background", ref panel10, false, -1, 100);
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            PickImage("Title card", ref panel12, false, -1, 100);
        }

        private void label20_Click(object sender, EventArgs e)
        {
            var iw = ArrayInputWindow.Ask("Special thanks", "Bottom text.", string.IsNullOrEmpty(label20.Text) ? new string[0] : label20.Text.Split(';'), new SplitListValidator(';'));
            if (iw != null)
            {
                var result = string.Join(";", iw);
                if (label20.Text != result)
                {
                    label20.Text = result;
                    HasUnsavedChanges = true;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (MapItem)comboBox2.SelectedItem;
            if (item == null) return;
            if (Mod.IntroductionMap != item.Name)
                HasUnsavedChanges = true;
        }

        private void label23_Click(object sender, EventArgs e)
        {
            UnpickImage(ref panel5, Properties.Resources.noimage_wide);
        }

        private void label24_Click(object sender, EventArgs e)
        {
            UnpickImage(ref panel12, Properties.Resources.noimage_wide);
        }

        private void label25_Click(object sender, EventArgs e)
        {
            UnpickImage(ref panel10, Properties.Resources.noimage_wide);
        }

        private void label26_Click(object sender, EventArgs e)
        {
            UnpickImage(ref panel8, Properties.Resources.noimage_wide);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                var item = (MapItem)comboBox1.SelectedItem;
                cuButton2.Enabled = item.IsCooked;
                mButton9.Enabled = item.IsCooked;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cuButton2_Click(object sender, EventArgs e)
        {
            var item = (MapItem)comboBox1.SelectedItem;
            try
            {
                File.WriteAllText(Path.Combine(Mod.RootPath, ".lastMap"), item.Name);
            }
            catch (Exception) { }
            Mod.TestMod(MainWindow.Instance.Runner, item.Name == "??menu" ? null : item.Name);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OMMSettings.Instance.LastAction = comboBox3.SelectedIndex;
            OMMSettings.Instance.Save();
        }
    }
}
