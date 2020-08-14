using ModdingTools.Engine;
using ModdingTools.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UELib;
using UELib.Core;
using UELib.Engine;

namespace ModdingTools.Windows.Tools
{
    public partial class AssetRipper : BaseWindow
    {
        public AssetRipper()
        {
            InitializeComponent();
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            // SoundCue'HatinTime_Voice_SubconNoose.SoundCues.01_why_hello_there'
            var pattern = new Regex(@"([A-Za-z0-9]{1,255})\'([A-Za-z_0-9\.]{1,255})\'$");
            var match = pattern.Matches(mTextBox1.Text);

            if (match.Count != 1 || match[0].Groups.Count != 3)
            {
                GUI.MessageBox.Show(this, "Invalid input!");
            } 

            try
            {
                var type = match[0].Groups[1].Value;
                var objName = match[0].Groups[2].Value;
                var spl = objName.Split('.');
                var package = spl[0];

                var parserType = (UModelFacade.ExportType)Enum.Parse(typeof(UModelFacade.ExportType), type);
                var pkg = Utils.FindPackage(package);
                var loader = UnrealLoader.LoadFullPackage(pkg, System.IO.FileAccess.Read);
                if (loader != null)
                {
                    foreach (var o in loader.Objects)
                    {
                        if (o.Name.Equals(spl.Last(), StringComparison.InvariantCultureIgnoreCase) && o.Class.Name.Equals(type, StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (spl.Count() == 3)
                            {
                                if (!o.Outer.Name.Equals(spl[1], StringComparison.InvariantCultureIgnoreCase))
                                {
                                    Debug.WriteLine(o.Outer.Name + " >> Outer invalid");
                                    continue;
                                }
                            }

                            SaveFileDialog dlg = new SaveFileDialog();
                            var ext = UModelFacade.GetExtensionForType(parserType);
                            dlg.DefaultExt = ext.TrimStart('.');
                            dlg.FileName = objName;
                            dlg.Filter = $"{parserType} (*{ext})|*{ext}";
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                var facade = new UModelFacade();
                                var result = facade.Export(package, spl.Last(), parserType, dlg.FileName);
                                GUI.MessageBox.Show(this, result ? "File exported sucessfully!" : "Export failed!");
                            }
                            return;
                        }
                    }
                }
                GUI.MessageBox.Show(this, "Asset not found!");

            }
            catch (Exception ex)
            {
                GUI.MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }

        private void AssetRipper_Load(object sender, EventArgs e)
        {

        }
    }

    public class UMyTexture : UObject
    {
        public override string Decompile()
        {
            var output = base.Decompile();
            return output + "\r\n\tUMyTexture has its own decompile output!";
        }
    }
}
