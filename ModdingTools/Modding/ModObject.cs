using IniParser.Model;
using ModdingTools.GUI;
using ModdingTools.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using UELib;
using UELib.Core;
using UELib.Engine;
using static ModdingTools.Engine.ModClass;
using ModdingTools.Windows.Tools;

namespace ModdingTools.Modding
{
    public class ModObject
    {
        public string Name              { get; set; }
        public string Author            { get; set; }
        public string Description       { get; set; }
        public string Version           { get; set; }
        public bool   IsCheat           { get; set; }
        public string Icon              { get; set; }
        public string ChapterInfoName   { get; set; }

        public int CuratedSteamId       { get; set; }
        public int PlayableSteamId      { get; set; }

        public bool IsOnlineParty       { get; set; }
        public bool HasSkin             { get; set; }
        public bool HasHatFlair         { get; set; }
        public bool AutoGiveItems       { get; set; }
        public bool HasPlayableCharacter { get; set; }
        public bool IsLanguagePack      { get; set; }
        public bool HasWeapon           { get; set; }
        public string MapType           { get; set; }
        public string GameMod           { get; set; }
        public string Coop              { get; set; }
        public string ModClass          { get; set; }

        public List<ModConfigItem> Config  { get; set; }

        public Dictionary<string, string> AssetReplacements;

        public string[] AllowedMapTypes = new[] {
            "TimeRift", 
            "SingleTimePiece", 
            "MultiTimePiece"
        };

        public static readonly Dictionary<string, string> IniTagToSteamMapping = new Dictionary<string, string>
        {
            { "TimeRift",                "Time Rift"                 },
            { "SingleTimePiece",         "Single TimePiece Level"    },
            { "MultiTimePiece",          "Multi TimePiece Level"     }
        };

        IniParser.Parser.IniDataParser Parser;

        public string RootPath { get; private set; }
        public ModDirectorySource RootSource { get; private set; }

        public string[] GetIniTags()
        {
            List<string> tmp = new List<string>();
            if (IsOnlineParty)
                tmp.Add("Online Party");
            if (HasSkin)
                tmp.Add("Dye");
            if (HasHatFlair)
                tmp.Add("Hat Flair");
            if (AutoGiveItems)
                tmp.Add("Available Instantly");
            if (HasPlayableCharacter)
                tmp.Add("Playable Character");
            if (IsLanguagePack)
                tmp.Add("Language Pack");
            if (HasWeapon)
                tmp.Add("Weapon");
            if (AllowedMapTypes.Contains(MapType))
                tmp.Add(IniTagToSteamMapping[MapType]);

            return tmp.ToArray();
        }

        public string GetDescription()
        {
            return this.Description.Replace("[br]", Environment.NewLine);
        }

        public void SetDescription(string desc)
        {
            this.Description = desc.Replace(Environment.NewLine, "[br]");
        }

        public string GetIniPath()
        {
            return Path.Combine(RootPath, "modinfo.ini");
        }

        public string GetDirectoryName()
        {
            return Path.GetFileName(RootPath);
        }

        public void RenameDirectory(string newName)
        {
            Utils.CleanupAttrib(RootPath);
            Utils.MoveDirDos(RootPath, Path.Combine(RootSource.Root, newName));
            this.RootPath = Path.Combine(RootSource.Root, newName);
        }

        // returns null if not
        public string DoesModNeedToBeCooked()
        {
            var ex = new Dictionary<DateTime?, string>
            {
                { Utils.YoungestInDir(GetCookedDir(),  new[] { "*.u", "*.umap" }),   "No cook"                       },
                { Utils.YoungestInDir(GetClassesDir(), new[] { "*.uc"          }),   "Scripts need to be recooked"   },
                { Utils.YoungestInDir(GetContentDir(), new[] { "*.upk"         }),   "Content needs to be recooked"  },
                { Utils.YoungestInDir(GetMapsDir(),    new[] { "*.umap"        }),   "Maps need to be recooked"      }
            };

            foreach (var k in ex)
            {
                if (ex.First().Value == k.Value)
                {
                    if (!k.Key.HasValue) return k.Value;
                }
                else
                {
                    if (k.Key.HasValue && DateTime.Compare(ex.First().Key.Value, k.Key.Value) < 0)
                        return k.Value;
                }
            }
            return null;
        }

        public void ChangeModSource(ModDirectorySource source)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            var newRoot = Path.Combine(source.Root, Path.GetFileName(RootPath));
            Utils.CleanupAttrib(RootPath);
            Utils.MoveDir(RootPath, newRoot);
            this.RootPath = newRoot;
            this.RootSource = source;
        }

        public void UnCookMod()
        {
            var path = GetCookedDir();
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path, "*.u"))
                {
                    File.Delete(file);
                }
                foreach (var file in Directory.GetFiles(path, "*.upk"))
                {
                    File.Delete(file);
                }
                foreach (var file in Directory.GetFiles(path, "*.umap"))
                {
                    File.Delete(file);
                }
            }
        }

        public static ModClass.ModClassType[] CombineTags(ModClass[] source)
        {
            List<ModClass.ModClassType> mc = new List<ModClass.ModClassType>();
            foreach (var s in source)
            {
                if (!mc.Contains(s.ClassType))
                {
                    mc.Add(s.ClassType);
                }
            }
            return mc.ToArray();
        }

        public string GetClassesDir()
        {
            return Path.Combine(RootPath, "Classes");
        }

        public string GetMapsDir()
        {
            return Path.Combine(RootPath, "Maps");
        }

        public string GetContentDir()
        {
            return Path.Combine(RootPath, "Content");
        }

        public string GetCookedDir()
        {
            return Path.Combine(RootPath, "CookedPC");
        }

        public string GetCompiledScriptsDir()
        {
            return Path.Combine(RootPath, "CompiledScripts");
        }

        public string GetLocsDir()
        {
            return Path.Combine(RootPath, "Localization");
        }

        ModClass[] ModClassCache = null;
        public ModClass[] GetModClasses(bool skipCache = false)
        {
            List<ModClass> mlc = new List<ModClass>();
            if (ModClassCache != null && !skipCache)
            {
                return ModClassCache;
            }

            var path = GetClassesDir();

            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path, "*.uc", SearchOption.AllDirectories))
                {
                    mlc.Add(new ModClass(file));
                }
            }
            ModClassCache = mlc.ToArray();
            return ModClassCache;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ModObject)) return false;
            var c = (ModObject)obj;
            return (c.GetDirectoryName().ToLower() == this.GetDirectoryName().ToLower());
        }

        public override int GetHashCode()
        {
            return this.GetDirectoryName().ToLower().GetHashCode();
        }

        public bool CookMod(AbstractProcessRunner runner, bool async = true, bool cleanConsole = true)
        {
            if (async)
            {
                runner.RunAppAsync(Program.ProcFactory.GetCookMod(this));
                return true; // async task always return true
            }
            else
            {
                return runner.RunApp(Program.ProcFactory.GetCookMod(this), cleanConsole);
            }
        }

        public void TestMod(AbstractProcessRunner runner, string mapName = null)
        {
            runner.RunWithoutWait(Program.ProcFactory.StartMap(mapName));
        }

        public bool CompileScripts(AbstractProcessRunner runner, bool async = true, bool watcher = false)
        {
            if (async)
            {
                runner.RunAppAsync(Program.ProcFactory.GetCompileScript(this, watcher));
                return true; // async task always return true
            }
            else
            {
                return runner.RunApp(Program.ProcFactory.GetCompileScript(this, watcher));
            }
        }

        public ModObject(string rootPath, ModDirectorySource parent)
        {
            this.RootPath = rootPath;
            this.RootSource = parent;
            Parser = new IniParser.Parser.IniDataParser();
            Parser.Configuration.AllowDuplicateKeys = true;
            Refresh();
        }

        public bool IsReleased => GetUploadedId() > 0;

        public void Refresh()
        {
            Debug.WriteLine("Refreshing mod...");
            var ini = Utils.ReadStringFromFile(GetIniPath());
            IniData info = Parser.Parse(ini);

            AssetReplacements = new Dictionary<string, string>();
            Config = new List<ModConfigItem>();

            var i = info["Info"];
            // Parse "Info" section
            this.Name = TryGet(i, "name", "New mod");
            this.Author = TryGet(i, "author", "Me");
            this.Description = TryGet(i, "description", "Hello this is my all new mod!");
            this.Version = TryGet(i, "version", "1.0.0");

            this.IsCheat = bool.Parse(TryGet(i, "is_cheat", "false"));
            this.Icon = TryGet(i, "icon");
            this.ChapterInfoName = TryGet(i, "ChapterInfoName", "");
            this.ModClass = TryGet(i, "modclass", "");

            // Parse "Tags" section
            var t = info["Tags"];
            this.MapType              = TryGet(t, "MapType"); // TimeRift, SingleTimePiece, MultiTimePiece
            this.IsOnlineParty        = TryGet(t, "OnlineParty", "0").Equals("1");
            this.HasSkin              = TryGet(t, "HasSkin", "0").Equals("1");
            this.HasHatFlair          = TryGet(t, "HasHatFlair", "0").Equals("1");
            this.AutoGiveItems        = TryGet(t, "AutoGiveItems", "0").Equals("1");
            this.HasPlayableCharacter = TryGet(t, "HasPlayableCharacter", "0").Equals("1");
            this.IsLanguagePack       = TryGet(t, "IsLanguagePack", "0").Equals("1");
            this.Coop                 = TryGet(t, "Coop", "");
           

            if (!this.IsReadOnly)
                GetModClasses(true);

            // ok, let's the fun begin... I hate this
            bool parse = false;
            int lastMode = -1;
            string lastArVal = null;

            // parse ARs
            foreach (var ln in ini.Split('\n'))
            {
                if (!parse && ln.Contains("[AssetReplace]"))
                {
                    parse = true;
                    continue;
                }
                else if (parse && ln.Trim().StartsWith("[") && ln.Trim().EndsWith("]"))
                {
                    parse = false;
                    break;
                }

                if (parse)
                {
                    var lns = ln.Trim(); // remove extra characters
                    if (string.IsNullOrEmpty(lns)) continue; // skip empty lines
                    if (lns[0] == '#' || lns[0] == ';') continue; // skip comments

                    var kv = lns.Split('=');
                    if (kv.Count() == 2)
                    {
                        var key = kv[0].Trim();
                        var val = kv[1].Trim();

                        int mode = (key == "+Asset") ? 0 : (key == "NewAsset") ? 1 : 2;
                        // 0 - Asset, 1 - NewAsset, 2 - Invalid, -1 - None

                        if (mode == 1 && lastMode == 0)
                        {
                            if (lastArVal == null)
                            {
                                throw new Exception("Invalid AssetReplacement section [code: 2]! Did you edited it by hand?");
                            }
                            AssetReplacements.Add(lastArVal, val);
                        }
                        else if (mode == 0)
                        {
                            lastArVal = val;
                        }
                        else if (mode == 2)
                        {
                            throw new Exception("Invalid AssetReplacement section [code: 1]! Did you edited it by hand?");
                        }
                        lastMode = mode;
                    }
                    else
                    {
                        throw new Exception("AssetReplacement parse error!");
                    }
                }
            }

            parse = false;
            lastMode = -1;
            bool configStart = false;
            ModConfigItem tmp = null;
            // parse Config
            foreach (var ln in ini.Split('\n'))
            {
                if (!parse && ln.Contains("[Configs]"))
                {
                    parse = true;
                    configStart = false;
                    continue;
                }
                else if (parse && ln.Trim().StartsWith("[") && ln.Trim().EndsWith("]"))
                {
                    parse = false;
                    configStart = false;
                    if (tmp != null)
                    {
                        Config.Add(tmp);
                    }
                    tmp = null;
                    break;
                }

                if (parse)
                {
                    var lns = ln.Trim(); // remove extra characters
                    if (string.IsNullOrEmpty(lns)) continue; // skip empty lines
                    if (lns[0] == '#' || lns[0] == ';') continue; // skip comments

                    var kv = lns.Split('=');
                    if (kv.Count() == 2)
                    {
                        var key = kv[0].Trim().ToLower();
                        var val = IniUnQuote(kv[1].Trim()).TrimStart('"').TrimEnd('"');

                        Debug.WriteLine($" KEY: {key}, VALUE: {val}");

                        int mode = (key == "+config") ? 0 : 1;
                        // 0 - Asset, 1 - NewAsset, 2 - Invalid, -1 - None

                        if (mode == 0)
                        {
                            configStart = true;
                            if (tmp != null)
                            {
                                Config.Add(tmp);
                            }
                            tmp = new ModConfigItem();
                            tmp.PropertyName = val;
                        }
                        if (configStart)
                        {
                            if (tmp == null)
                            {
                                throw new Exception("Invalid Config section [code: 2]! Did you edited it by hand?");
                            }
                            if (key.StartsWith("option[") && key.EndsWith("]"))
                            {
                                tmp.Options.Add(int.Parse(key.Split('[')[1].Split(']')[0]), val);
                            }
                            else
                            {
                                switch (key)
                                {
                                    case "name":
                                        tmp.Name = val;
                                        break;
                                    case "description":
                                        tmp.Description = val;
                                        break;
                                    case "default":
                                        tmp.DefaultIndex = int.Parse(val);
                                        break;
                                }
                            }
                        }
                        lastMode = mode;
                    }
                    else
                    {
                        throw new Exception("Config parse error!");
                    }
                }
            }
            if (tmp != null)
            {
                Config.Add(tmp);
            }
        }

        public bool HasClass(ModClassType @type)
        {
            return GetModClasses().Where(x => x.ClassType == @type).Count() > 0;
        }

        public bool HasAnyMaps()
        {
            if (!Directory.Exists(GetMapsDir())) return false;
            return Directory.GetFiles(GetMapsDir(), "*.umap").Length > 0;
        }

        public bool HasAnyCookedMaps()
        {
            if (!Directory.Exists(GetCookedDir())) return false;
            return Directory.GetFiles(GetCookedDir(), "*.umap").Length > 0;
        }

        public string[] GetCookedMaps()
        {
            if (!Directory.Exists(GetCookedDir())) return null;
            List<string> maps = new List<string>();
            foreach (var x in Directory.GetFiles(GetCookedDir(), "*.umap"))
            {
                maps.Add(Path.GetFileNameWithoutExtension(x));
            }
            return maps.ToArray();
        }

        public string TryDetectCIInContent()
        {
            if (!Directory.Exists(GetContentDir())) return null;
            foreach (var c in Directory.GetFiles(GetContentDir(), "*.upk"))
            {
                var d = TryDetectCI(Path.GetFileNameWithoutExtension(c));
                if (d != null) return d;
            }
            return null;
        }

        public bool HasCompiledScripts()
        {
            return Utils.DirContainsKey(GetCompiledScriptsDir(), "*.u");
        }

        public bool HasAnyScripts()
        {
            return Utils.DirContainsKey(GetClassesDir(), "*.uc");
        }

        public string TryDetectCI(string packageName)
        {
            try
            {
                using (var pkg = UnrealLoader.LoadFullPackage(Path.Combine(GetContentDir(), packageName + ".upk"), FileAccess.Read))
                {
                    foreach (var obj in pkg.Objects)
                    {
                        if (obj.Class.Name == "Hat_ChapterInfo")
                        {
                            if (obj.Outer == null)
                            {
                                return $"{obj.Package.PackageName}.{obj.Name}";
                            }
                            else
                            {
                                return $"{obj.Package.PackageName}.{obj.Outer.Name}.{obj.Name}";
                            }
                        }
                    }
                }            
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + Environment.NewLine + e.ToString());
            }
            return null;
        }

        public string MakeARClass()
        {
            var classDir = GetClassesDir();
            var className = $"{GetDirectoryName()}_AutoGenGameModClass";
            var classContent = $"class {className} extends GameMod;";

            var cp = Path.Combine(classDir, $"{className}.uc");
            
            if (File.Exists(cp)) return className; // don't edit existing class
            if (!Directory.Exists(classDir))
            {
                Directory.CreateDirectory(classDir);
            }

            File.WriteAllText(cp, classContent);
            return className;
        }

        public bool IsReadOnly => RootSource.IsReadOnly;

        public bool ValidateIcon()
        {
            if (string.IsNullOrEmpty(Icon)) return false;
            return ValidateIcon(Path.Combine(RootPath, Icon));
        }

        public static bool ValidateIcon(string path)
        {
            FileInfo f = new FileInfo(path);
            if (f.Exists)
            {
                if (f.Length > 1000000)
                {
                    return false;
                }
                else
                {
                    var img = Image.FromFile(f.FullName);
                    if (img.Width / img.Height == 1)
                    {
                        if (img.Width < 100)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public Image GetIcon()
        {
            var noIconImage = Properties.Resources.noimage;
            if (Icon == null)
                return noIconImage;

            var path = Path.Combine(RootPath, Icon);

            try
            {
                if (!ValidateIcon())
                    return noIconImage;
                Image img;
                using (var bmpTemp = new Bitmap(path))
                {
                    img = FlipbookGenerator.ResizeImage(new Bitmap(bmpTemp), 200, 200);
                }
                return img;
            }
            catch (Exception)
            {
                return noIconImage;
            }
        }

        public void Delete()
        {
            Utils.CleanupAttrib(RootPath);
            Directory.Delete(RootPath, true);   
        }

        private string TryGet(KeyDataCollection context, string key, string def = null)
        {
            if (context.ContainsKey(key))
                return CleanString(context[key]);
            return CleanString(def);
        }

        private string CleanString(string data)
        {
            if (data == null) return null;
            if (data.StartsWith("\"") && data.EndsWith("\""))
                data = data.Substring(1, data.Length - 2);
            return data.Replace("\\\"", "\"");
        }

        private void AppendIni(KeyDataCollection context, string key, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            var data = new KeyData(key);
            data.Value = value;
            context.AddKey(data);
        }

        public long GetUploadedId()
        {
            return Program.SWS.GetIdForMod(this);
        }

        public void SetUploadedId(long id)
        {
            Program.SWS.SetIdForMod(this, id);
        }


        public bool DetectIsLanguagePack()
        {
            if (!Directory.Exists(GetLocsDir())) return false;
            if (HasAnyMaps() || HasAnyScripts()) return false;

            return true;
        }

        public bool TagsCompleted()
        {
            if (HasAnyMaps() && string.IsNullOrEmpty(MapType)) return false;
            return true;
        }

        // here we PECKIN GO!
        public void Save()
        {
            IniData info = new IniData();
            info.Configuration.AssigmentSpacer = "";

            var i = info["Info"];
   
            // Store "Info" section
            AppendIni(i, "name", IniQuote(this.Name));
            AppendIni(i, "author", IniQuote(this.Author));
            AppendIni(i, "description", IniQuote(this.Description));
            AppendIni(i, "version", IniQuote(this.Version));
            AppendIni(i, "version", IniQuote(this.Version));

            AppendIni(i, "is_cheat", this.IsCheat ? "true" : "false");
            AppendIni(i, "icon", this.Icon);
            AppendIni(i, "ChapterInfoName", this.ChapterInfoName);

            ApplyTag(info, "isLanguagePack", DetectIsLanguagePack() ? "1" : "");

            if (HasAnyMaps())
            {
                ApplyTag(info, "MapType", MapType);
            }

            ApplyTag(info, "OnlineParty", IsOnlineParty ? "1" : "");
            ApplyTag(info, "Coop", Coop);

            bool autoEquip = false;
            bool hasModClass = false;
            foreach (var c in GetModClasses())
            {
                if (!c.IsIniAccessible)
                {
                    if (c.IsGameModClass)
                    {
                        AppendIni(i, "modclass", c.ClassName);
                        hasModClass = true;
                    }
                    if (c.IsAutoAwardItem)
                    {
                        autoEquip = true;
                    }
                    continue;
                }
                ApplyTag(info, c.IniKey, "1");
            }

            if (!hasModClass && AssetReplacements.Count() > 0)
            {
                AppendIni(i, "modclass", MakeARClass());
            }

            if (autoEquip)
            {
                ApplyTag(info, "AutoGiveItems", "1");
            }

            // asset replacement storage
            var builder = new StringBuilder();
            if (AssetReplacements.Count > 0)
            {
                ApplyTag(info, "AssetReplace", "1");

                builder.AppendLine("[AssetReplace]");

                foreach (var a in AssetReplacements)
                {
                    builder.AppendLine($"+Asset={a.Key}");
                    builder.AppendLine($"NewAsset={a.Value}");
                }
            }

            // configs replacement storage
            if (Config.Count > 0)
            {
                builder.AppendLine("[Configs]");

                foreach (var a in Config)
                {
                    builder.AppendLine(a.ToString());
                }
            }

            var iniContent = $"{info}{Environment.NewLine}{builder}";

            Parser.Parse(iniContent); // just for a check, it should throw the exception if something weird happens
            File.WriteAllText(Path.Combine(RootPath, "modinfo.ini"), iniContent);
        }

        private void ApplyTag(IniData ini, string key, string value)
        {
            if (string.IsNullOrEmpty(key)) return;
            if (!string.IsNullOrEmpty(value))
            {
                ini["Tags"].AddKey(key, value);
            }
        }

        public static string IniQuote(string data)
        {
            return $"\"{data.Replace("\"", "\\\"")}\"";
        }

        public static string IniUnQuote(string data)
        {
            return $"\"{data.Replace("\\\"", "\"")}\"";
        }


        public class ModConfigItem
        {
            public string PropertyName;
            public string Name;
            public string Description;
            public int DefaultIndex;
            public SortedDictionary<int, string> Options;

            public ModConfigItem()
            {
                PropertyName = "";
                Name = "";
                Description = "";
                DefaultIndex = 0;
                Options = new SortedDictionary<int, string>();
            }

            public override string ToString()
            {
                var build = new StringBuilder();
                build.AppendLine($"+Config={PropertyName}");
                build.AppendLine($"Name={IniQuote(Name)}");
                build.AppendLine($"Description={IniQuote(Description)}");
                build.AppendLine($"Default={DefaultIndex}");
                foreach (var opt in Options)
                {
                    build.AppendLine($"Option[{opt.Key}]={IniQuote(opt.Value)}");
                }
                return build.ToString();
            }
        }
    }
}
