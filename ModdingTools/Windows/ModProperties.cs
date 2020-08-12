using ModdingTools.GUI;
using ModdingTools.Modding;
using ModdingTools.Engine;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ModdingTools.Windows
{
    public partial class ModProperties : BaseWindow
    {
        private ModObject Mod;
        private string _newIcon = null;

        public ModProperties(ModObject mod)
        {
            InitializeComponent();

            this.Mod = mod;
            Reload();
        }

        public void Reload()
        {
            Mod.Refresh();

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

            var tags = ModObject.CombineTags(Mod.GetModClasses());

            this.tagsList.Clear();
            this.tagsList.LargeImageList = imageList;

            foreach (var tag in tags)
            {
                if (ModClass.VisibleTypes.Contains(tag))
                    this.tagsList.Items.Add("Contains " + ModClass.ClassToNameMapping[tag], tag.ToString());
                //textBox1.Text += tag.ToString() + Environment.NewLine;

            }

            arList1.Fill(Mod.AssetReplacements);
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
                        iconView.BackgroundImage = Image.FromFile(f.FullName);
                        _newIcon = f.FullName;
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
            Mod.AssetReplacements = arList1.Collect();
            Mod.Name = modName.Text;
            Mod.SetDescription(ModDescriptionEdit.Text);
            Mod.ChapterInfoName = chapterInfoInput.Text;
            if (Mod.GetDirectoryName() != modFolderName.Text)
            {
                Mod.RenameDirectory(modFolderName.Text);
            }
            if (levelType.SelectedIndex >= 0 && levelType.SelectedIndex < Mod.AllowedMapTypes.Count() && levelType.Visible)
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
            
        }

        private void modFolderName_Click(object sender, EventArgs e)
        {
            var iw = InputWindow.Ask("Mod name", "Enter the mod name", new InputWindow.ModNameValidator(), modFolderName.Text);
            if (iw != null)
            {
                modFolderName.Text = iw;
            }
        }

        private void mButton5_Click(object sender, EventArgs e)
        {
            Mod.CompileScripts(this.processRunner1, true, false);
        }

        private void mButton6_Click(object sender, EventArgs e)
        {
            Mod.CookMod(this.processRunner1, true);
        }
    }
}
