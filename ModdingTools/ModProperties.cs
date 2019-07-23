using ModdingTools.GUI;
using ModdingTools.Modding;
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

            this.Text = mod.Name.ToUpper();
            this.ModDescriptionEdit.Text = mod.GetDescription();
            this.ModFolderEdit.Text = mod.GetDirectoryName();
            this.ModNameEdit.Text = mod.Name;

            var tags = ModObject.CombineTags(mod.GetModClasses());
            foreach (var tag in tags)
            {
                textBox1.Text += tag.ToString() + Environment.NewLine;
            }
        }
    }
}
