using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ModdingTools.Modding;
using ModdingTools.Engine;
using System.Diagnostics;

namespace ModdingTools.GUI
{
    public partial class ContentBrowser : UserControl
    {
		public bool HasContentError { get; private set; }

		Dictionary<string, string> Adict = new Dictionary<string, string>
			{
				{ ".upk", "Only Asset Packages (.upk) are allowed in the Content folder." },
				{ ".umap", "Only Unreal Maps (.umap) are allowed in the Maps folder." },
				{ ".int", "Only Localization Files (.int) are allowed in the Localization folder." }
			};

		Dictionary<string, string> BDict = new Dictionary<string, string>
			{
				{ ".upk", "This is an Asset Package (.upk) which goes in the Content folder." },
				{ ".umap", "This is an Unreal Map (.umap) which goes in the Maps folder." },
				{ ".int", "This is a Localization File (.int) which goes in the Localization folder." }
			};

		public ContentBrowser()
        {
            InitializeComponent();
        }

        private struct ContentTreeViewInfo
        {
            public string Filename;

            public string ErrorMessage;

            public ContentTreeViewInfo(string InFilename, string InErrorMessage)
            {
                Filename = InFilename;
                ErrorMessage = InErrorMessage;
            }
        }

		public void LoadMod(ModObject mod)
		{
			HasContentError = false;
			AssetNameLabel.Text = "(none selected)";
			AssetDescriptionLabel.Text = "";

			ContentTreeView.Nodes.Clear();
			IterateContent(ContentTreeView.Nodes, mod, mod.GetContentDir(), ".upk",  true);
			IterateContent(ContentTreeView.Nodes, mod, mod.GetMapsDir(),    ".umap", true);
			IterateContent(ContentTreeView.Nodes, mod, mod.GetLocsDir(),    ".int",  true);
			ContentTreeView.ExpandAll();
		}

		private void IterateContent(TreeNodeCollection root, ModObject mod, string currPath, string acceptExt, bool isBase = false)
		{
			if (!Directory.Exists(currPath))
				return;

			if (isBase)
			{
				var node = root.Add("folder", Path.GetFileName(currPath), "folder", "folder");
				IterateContent(node.Nodes, mod, currPath, acceptExt);
				return;
			}
			foreach (string path in Directory.GetFiles(currPath, "*.*"))
			{
				Debug.WriteLine(GameFinder.GetCookedPcDir());
				var exts = acceptExt.Split('|');
				var extension = Path.GetExtension(path);
				var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
				if (!exts.Contains(acceptExt))
				{
					var treeNode = root.Add("", Path.GetFileName(path), "error", "error");
					var text = "This asset does not belong here.";
					foreach (var a in Adict)
					{
						if (exts.Contains(a.Key)) text += Environment.NewLine + a.Value;
					}

					foreach (var b in BDict)
					{
						if (extension == b.Key) text += Environment.NewLine + b.Value;
					}

					treeNode.Tag = new ContentTreeViewInfo(Path.GetFileName(path), text);
					HasContentError = true;
				}
				else if (fileNameWithoutExtension.ToLower() == mod.GetDirectoryName().ToLower() && !exts.Contains(".int")  && !exts.Contains(".umap"))
				{
					var treeNode = root.Add("", Path.GetFileName(path), "error", "error");
					treeNode.Tag = new ContentTreeViewInfo(Path.GetFileName(path), "Packages can't have the same name as your mod folder.\nAdd a _Content suffix or something. Example:\n" + fileNameWithoutExtension + "_Content" + extension);
					HasContentError = true;
				}
				else if (Utils.FileExists(GameFinder.GetCookedPcDir(), Path.GetFileName(path)))
				{
					var treeNode = root.Add("", Path.GetFileName(path), "error", "error");
					treeNode.Tag = new ContentTreeViewInfo(Path.GetFileName(path), "There's an asset with an identical name in CookedPC.\nPlease give your asset another name.\n(btw don't put your own stuff in CookedPC. Keep it to the mods folder.)");
					HasContentError = true;
				}
				else
				{
					var ext = exts.Contains(".int") ? "localization" : "package";
					var treeNode = root.Add("", Path.GetFileName(path), ext, ext);
					treeNode.Tag = new ContentTreeViewInfo(Path.GetFileName(path), "");
				}
			}
			foreach (var file in Directory.GetDirectories(currPath))
			{
				var node = root.Add("", Path.GetFileName(file), "folder", "folder");
				IterateContent(node.Nodes, mod, file, acceptExt);
			}
		}

		private void ContentTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ContentTreeView.SelectedNode.Tag == null)
            {
                AssetNameLabel.Text = "(none selected)";
                return;
            }
            ContentTreeViewInfo contentTreeViewInfo = (ContentTreeViewInfo)ContentTreeView.SelectedNode.Tag;
            AssetNameLabel.Text = contentTreeViewInfo.Filename;
            AssetDescriptionLabel.Text = contentTreeViewInfo.ErrorMessage;
        }
    }
}
