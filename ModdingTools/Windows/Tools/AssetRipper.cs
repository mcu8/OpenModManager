using CUFramework.Dialogs;
using CUFramework.Windows;
using ModdingTools.Engine;
using ModdingTools.GUI;
using ModdingTools.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UELib;

namespace ModdingTools.Windows.Tools
{
    public partial class AssetRipper : CUWindow
    {
        public AssetRipper()
        {
            InitializeComponent();
            checkBox1.Checked = OMMSettings.Instance.Exporter_ForcePNG;
        }

        struct ExportTask
        {
            public string Name;
            public string[] Spl;
            public UModelFacade.ExportType Type;
        }

        struct FacadeTask
        {
            public string Root;
            public string Package;
            public string AssetName;
            public string Extension;
            public string FileName;
            public string Group;
            public UModelFacade.ExportType ExportType;
        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            var tasks = new Dictionary<string, List<ExportTask>>(StringComparer.OrdinalIgnoreCase);
            var ftasks = new List<FacadeTask>();

            int line = 0;
            foreach (var a in mTextBox1.Lines)
            {
                line++;
                if (string.IsNullOrWhiteSpace(a)) continue;

                var pattern = new Regex(@"([A-Za-z0-9]{1,255})\'([A-Za-z0-9\.\-_]{1,255})\'$");
                var match = pattern.Matches(a);

                if (match.Count != 1 || match[0].Groups.Count != 3)
                {
                    CUMessageBox.Show(this, $"Invalid input at line {line}!");
                    return;
                }

                try
                {
                    var type = match[0].Groups[1].Value;
                    var objName = match[0].Groups[2].Value;
                    var spl = objName.Split('.');
                    var package = spl[0];

                    var parserType = (UModelFacade.ExportType)Enum.Parse(typeof(UModelFacade.ExportType), type);
                    

                    if (!tasks.ContainsKey(package))
                        tasks.Add(package, new List<ExportTask>());
                    tasks[package].Add(new ExportTask
                    {
                        Name = objName,
                        Type = parserType,
                        Spl = spl
                    });
                }
                catch (Exception ex)
                {
                    CUMessageBox.Show(ex.Message + "\n\n" + ex);
                    return;
                }
            }

            try
            {
                foreach (var task in tasks)
                {
                    var pkg = Utils.FindPackage(task.Key);
                    var loader = UnrealLoader.LoadFullPackage(pkg, System.IO.FileAccess.Read);
                    if (loader != null)
                    {
                        foreach (var o in loader.Objects)
                        {
                            foreach (var sub in task.Value)
                            {
                                if (o.Name.Equals(sub.Spl.Last(), StringComparison.InvariantCultureIgnoreCase) && o.Class.Name.Equals(sub.Type.ToString(), StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (sub.Spl.Count() >= 3)
                                    {
                                        var x = sub.Spl.Skip(1).Reverse();
                                        var curr = o;
                                        var shouldContinue = true;
                                        foreach (var y in x)
                                        {
                                            if (curr != null && y.Equals(curr.Name))
                                            {
                                                shouldContinue = true;
                                                curr = curr.Outer;
                                                continue;
                                            }
                                            shouldContinue = false;
                                            break;
                                        }
                                        if (!shouldContinue)
                                        {
                                            Debug.WriteLine(o.Outer.Name + " >> Outer invalid");
                                            continue;
                                        }
                                    }


                                    var ext = UModelFacade.GetExtensionForType(sub.Type, checkBox1.Checked);
                                    if (ext == null)
                                    {
                                        CUMessageBox.Show(this, "Unsupported type: " + sub.Type);
                                        return;
                                    }

                                    ftasks.Add(new FacadeTask
                                    {
                                        Root = Path.GetDirectoryName(pkg),
                                        Package = task.Key,
                                        AssetName = sub.Spl.Last(),
                                        ExportType = sub.Type,
                                        FileName = sub.Name,
                                        Extension = ext,
                                        Group = string.Join(".", sub.Spl.Skip(1).Take(sub.Spl.Length - 2))
                                    });
                                }
                            }
                        }
                    }
                }

                if (ftasks.Count > 0)
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();
                     
                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            var facade = new UModelFacade();
                            var work = Path.Combine(fbd.SelectedPath, "OMMExport_" + Utils.GetUnixTimestamp(DateTime.Now));
                            if (!Directory.Exists(work))
                            {
                                Directory.CreateDirectory(work);
                            }

                            cuProgressBar1.MaxValue = ftasks.Count();
                            cuProgressBar1.Value = 0;
                            panel1.Enabled = false;
                            Task.Factory.StartNew(() =>
                            {
                                int i = 0;
                                foreach (var t in ftasks)
                                {
                                    this.Invoke(new MethodInvoker(() =>
                                    {
                                        cuProgressBar1.Text = t.FileName;
                                        cuProgressBar1.Invalidate();
                                    }));
                                    var res = facade.Export(t.Root, t.Package, t.AssetName, t.Group, t.ExportType, Path.Combine(work, t.FileName + t.Extension), checkBox1.Checked);
                                    if (!res)
                                    {
                                        this.Invoke(new MethodInvoker(() =>
                                        {
                                            CUMessageBox.Show(this, "Export failed for asset:\n" + t.FileName);
                                            panel1.Enabled = true;
                                        }));
                                        return;
                                    }
                                    this.Invoke(new MethodInvoker(() =>
                                    {
                                        i++;
                                        cuProgressBar1.Value = i;
                                        cuProgressBar1.Invalidate();
                                    }));
                                }
                                this.Invoke(new MethodInvoker(() => CUMessageBox.Show(this, $"Assets exported successfully! [{ftasks.Count()} items]")));
                                Utils.OpenInExplorer(work);

                                this.Invoke(new MethodInvoker(() =>
                                {
                                    cuProgressBar1.Text = $"Done! [{ftasks.Count()} items]";
                                    cuProgressBar1.Invalidate();
                                    panel1.Enabled = true;
                                }));
                            });              
                        }
                    }
                }
                else
                {
                    CUMessageBox.Show(this, "No assets found!");
                }
            }
            catch (Exception ex)
            {
                CUMessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }

        private void AssetRipper_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            OMMSettings.Instance.Exporter_ForcePNG = checkBox1.Checked;
            OMMSettings.Instance.Save();
        }
    }
}
