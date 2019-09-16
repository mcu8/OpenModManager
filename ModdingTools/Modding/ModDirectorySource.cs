using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ModdingTools.Modding
{
    public class ModDirectorySource
    {
        public string Root             { get; private set; }
        public string Name             { get; private set; }

        public bool IsReadOnly         { get; private set; }
        public bool Enabled            { get; set; }
        public bool AutoLoad           { get; set; }

        public ModObject[] GetMods()
        {
            List<ModObject> mods = new List<ModObject>();
            if (!AutoLoad)
                return mods.ToArray();

            var paths = Directory.GetDirectories(Root);
            foreach (var path in paths)
            {
                var modIniPath = Path.Combine(path, "modinfo.ini");
                if (File.Exists(modIniPath))
                {
                    try
                    {
                        var mod = new ModObject(path, this);
                        mods.Add(mod);
                    }
                    catch (Exception ex) {
                        Debug.WriteLine(":sealnyon: Oopsie woopsie!\n" + ex.Message + "\n" + ex.ToString());
                    }
                }
            }
            return mods.ToArray();
        }

        public ModDirectorySource(string name, string path, bool autoLoad, bool defaultEnabled = true, bool isReadOnly = false)
        {
            this.Name = name;
            this.Root = path;
            this.AutoLoad = autoLoad;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            this.Enabled = defaultEnabled;
            this.IsReadOnly = isReadOnly;
        }
    }
}
