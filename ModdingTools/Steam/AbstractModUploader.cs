using CUFramework.Dialogs;
using ModdingTools.Engine;
using ModdingTools.Modding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.Steam
{
    // time to rewrite that mess...

    // Remember: you can use only one isntance of uploader at once!!!
    public abstract partial class AbstractModUploader
    {
        public bool IsUploaderRunning { get; protected set; } = false;

        // return true if success, otherwise false
        public bool UpdateOrUploadMod(ModObject mod, string changelog, string[] tags, bool keepUnCooked, bool keepScripts, int visibility, string description)
        {
            if (IsUploaderRunning)
            {
                GetParentForm().Invoke(new MethodInvoker(() => {
                    CUMessageBox.Show(GetParentForm(), "Only one uploader instance can run at once!");
                }));
                return false;
            }
        }

        private void PrepareUploadFolder(ModObject mod, bool keepScripts, bool keepUncookedContent)
        {
            var tmpDir = Path.Combine(Program.GetAppRoot(), "uploader_tmp");
            if (Directory.Exists(tmpDir))
                Directory.Delete(tmpDir, true);
            Directory.CreateDirectory(tmpDir);

            Utils.DirectoryCopy(mod.RootPath, tmpDir, true);

            if (!keepScripts)
            {
                if (Directory.Exists(Path.Combine(tmpDir, "CompiledScripts")))
                    Directory.Delete(Path.Combine(tmpDir, "CompiledScripts"), true);
                if (Directory.Exists(Path.Combine(tmpDir, "Classes")))
                    Directory.Delete(Path.Combine(tmpDir, "Classes"), true);
            }

            if (!keepUncookedContent)
            {
                if (Directory.Exists(Path.Combine(tmpDir, "Maps")))
                    Directory.Delete(Path.Combine(tmpDir, "Maps"), true);
                if (Directory.Exists(Path.Combine(tmpDir, "Content")))
                    Directory.Delete(Path.Combine(tmpDir, "Content"), true);
            }
        }
    }
}
