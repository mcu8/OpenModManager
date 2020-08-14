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

namespace ModdingTools.Windows
{
    public partial class ModProperties : BaseWindow
    {
        private ModObject Mod;
        private string _newIcon = null;

        public ModProperties(ModObject mod)
        {
            InitializeComponent();

            foreach (var tab in tabControl2.Pages)
            {
                if (tab == tabControl2.SelectedTab)
                {
                    tab.BackColor = Color.FromArgb(32, 32, 32);
                    
                }
                else
                {
                    tab.BackColor = Color.FromArgb(80, 80, 80);
                }
            }

            this.Mod = mod;
            Reload();
        }

        public void Reload()
        {
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

            foreach (var img in ModClass.ClassToIconMapping)
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

            var tags = ModObject.CombineTags(Mod.GetModClasses());

            this.tagsList.Clear();
            this.tagsList.LargeImageList = imageList;

            foreach (var tag in tags)
            {
                if (ModClass.VisibleTypes.Contains(tag))
                    this.tagsList.Items.Add("Contains " + ModClass.ClassToNameMapping[tag], tag.ToString());
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

            mButton1.Enabled = Mod.GetUploadedId() > 0;

            arList1.Fill(Mod.AssetReplacements);

            ReloadFlags();

            if (Mod.IsReadOnly)
            {
                mButton4.Enabled = false;
                mButton5.Enabled = false;
                mButton6.Enabled = false;
                mButton7.Enabled = false;
                mButton8.Enabled = false;
                label5.Enabled = false;
                arList1.Enabled = false;
                chapterInfoInput.Enabled = false;
                cbOnlineParty.Enabled = false;
                cbCoOp.Enabled = false;
                levelType.Enabled = false;
                iconView.Enabled = false;
                modName.Enabled = false;
                modFolderName.Enabled = false;
            }
        }

        public void ToggleUnlock(bool v)
        {
            foreach (var tab in tabControl2.Tabs)
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
        }

        private void ReloadFlags()
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

            flagCook.Image = (flag5 || Mod.IsLanguagePack) && !contentBrowser1.HasContentError ? good : bad;
            flagTitle.Image = flag ? good : bad;
            flagDesc.Image = flag2 ? good : bad;
            flagIcon.Image = flag7 ? good : bad;
            flagTags.Image = flag8 ? good : bad;

            mButton8.Enabled = (((flag5 || Mod.IsLanguagePack) && !contentBrowser1.HasContentError) && flag && flag2 && flag7 && flag8);
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
            dlg.Filter = "PNG image file (*.png)|*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(dlg.FileName);
                if (f.Exists)
                {
                    if (f.Length > 2000000)
                    {
                        GUI.MessageBox.Show("Icon must have less than 2MB of size!");
                    }
                    else
                    {
                        var img = Image.FromFile(f.FullName);
                        if (img.Width / img.Height == 1)
                        {
                            if (img.Width < 100)
                            {
                                GUI.MessageBox.Show("Icon must have at least 100x100px size!");
                            }
                            else
                            {
                                iconView.BackgroundImage = img;
                                _newIcon = f.FullName;
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
            Mod.AssetReplacements = arList1.Collect();
            Mod.Name = modName.Text;
            Mod.SetDescription(ModDescriptionEdit.Text);
            Mod.ChapterInfoName = chapterInfoInput.Text;
            Mod.IsOnlineParty = cbOnlineParty.Checked;
            Mod.Coop = cbCoOp.Checked ? "CoopOnly" : "";
            Mod.Version = label5.Text;
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
                var icon = Path.Combine(Mod.RootPath, "icon.png");
                if (File.Exists(icon))
                {
                    File.Delete(icon);
                }
                File.Copy(_newIcon, icon);
                _newIcon = null;
                Mod.Icon = "icon.png";
            }

            Mod.Save();
            Reload();
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            Utils.OpenInExplorer(Mod.RootPath);
        }

        private void modName_Click(object sender, EventArgs e)
        {
            var iw = InputWindow.Ask("Mod name", "Enter the mod name", new InputWindow.NonEmptyValidator(), modName.Text);
            if (iw != null)
            {
                modName.Text = iw;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mod.MapType = levelType.SelectedItem.ToString();
        }

        private void mButton7_Click(object sender, EventArgs e)
        {
            var d = Mod.TryDetectCIInContent();
            if (d != null)
            {
                chapterInfoInput.Text = d;
            }
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            if (Mod.GetUploadedId() > 0)
            {
                Process.Start("http://steamcommunity.com/sharedfiles/filedetails/?id=" + Mod.GetUploadedId());
            }
        }

        private void modFolderName_Click(object sender, EventArgs e)
        {
            var iw = InputWindow.Ask("Mod folder name", "Enter the mod folder name", new InputWindow.ModNameValidator(), modFolderName.Text);
            if (iw != null)
            {
                modFolderName.Text = iw;
            }
        }

        private void mButton5_Click(object sender, EventArgs e)
        {
            if(!contentBrowser1.HasContentError)
            {
                ToggleUnlock(false);
                SaveMod();
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
            new UploadOptions(Mod).ShowDialog(this);
        }

        private void tabControl2_PageChanging(object sender, Manina.Windows.Forms.PageChangingEventArgs e)
        {
            if (!((Control)tab1).Enabled)
            {
                e.Cancel = true;
                return;
            }

            e.NewPage.BackColor = Color.FromArgb(32, 32, 32);
            e.CurrentPage.BackColor = Color.FromArgb(80,80,80);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var iw = InputWindow.Ask("Version", "Enter the mod version", new InputWindow.NonEmptyValidator(), label5.Text);
            if (iw != null)
            {
                label5.Text = iw;
            }
        }
    }
}
