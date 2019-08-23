using ModdingTools.GUI;
using ModdingTools.Modding;
using ModdingTools.UEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools
{
    public partial class ModProperties : BaseWindow
    {
        private ModObject Mod;
        public ModProperties(ModObject mod)
        {
            InitializeComponent();

            this.Mod = mod;

            var imageList = new ImageList();
            imageList.ImageSize = new Size(36, 36);

            foreach (var img in ModClass.ClassToIconMapping)
            {
                imageList.Images.Add(img.Key.ToString(), img.Value);
            }

            this.Text = mod.Name.ToUpper();
            this.ModDescriptionEdit.Text = mod.GetDescription();
            this.ModFolderEdit.Text = mod.GetDirectoryName();
            this.ModNameEdit.Text = mod.Name;
            this.iconView.BackgroundImage = mod.GetIcon();

            var tags = ModObject.CombineTags(mod.GetModClasses());

            this.tagsList.LargeImageList = imageList;

            foreach (var tag in tags)
            {
                this.tagsList.Items.Add("Contains " + ModClass.ClassToNameMapping[tag], tag.ToString());
                //textBox1.Text += tag.ToString() + Environment.NewLine;
            }
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            MainWindow.Instance.Runner.RunWithoutWait(Program.ProcFactory.LaunchEditor(Mod.GetDirectoryName()));
        }
    }
}
