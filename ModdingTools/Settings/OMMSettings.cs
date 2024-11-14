using CUFramework.Dialogs;
using ModdingTools.Engine;
using ModdingTools.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using static ModdingTools.Settings.OMMSettings;

namespace ModdingTools.Settings
{
    public class OMMSettings
    {
        public bool AutoScanDownloadedMods { get; set; } = false;
        public bool Memes { get; set; } = false;
        public bool MultilangCook { get; set; } = false;
        public bool UpdateCheck { get; set; } = true;
        public bool Exporter_ForcePNG { get; set; } = true;
        public bool Flipbook_TrueTransparency { get; set; } = false;
        public string Flipbook_LastIntrpValue { get; set; } = "";
        public int Flipbook_LastColorValue { get; set; } = 0;
        public int Flipbook_LastSize { get; set; } = 8192;
        public bool RmShaderOnCook { get; set; } = false;
        public bool VSCIntegration { get; set; } = false;
        public bool FastCook { get; set; } = false;
        public int LastAction { get; set; } = 0;
        public string VSCCustomPath { get; set; } = "";
        public bool KillGameBeforeCooking { get; set; } = false;
        public bool KillEditorBeforeCooking { get; set; } = false;
        public bool MafiaPunchGameToo { get; set; } = false;
        public bool AlwaysloadedWorkaround { get; set; } = false;

        public enum ArgsDefaultsKeys
        {
            COMP_CompileScript,
            COMP_CookMod,
            COMP_CookModWithFastCookOptionEnabled,
            GAME_StartMap,
            GAME_StartMapWithoutWorkshopMods,
            ED_LaunchEditor,
            ED_LaunchEditorWithSelectedMap
        }

        public static readonly Dictionary<ArgsDefaultsKeys, string> ArgsDefaults = new Dictionary<ArgsDefaultsKeys, string>() {
            { ArgsDefaultsKeys.COMP_CompileScript, "make -FULL -SHORTPATHS -NOPAUSEONSUCCESS -MODSONLY=${ModFolderName}" },
            { ArgsDefaultsKeys.COMP_CookModWithFastCookOptionEnabled, "CookPackages ${ModFolderName} -PROCESSES=${CpuCount} -SKIPMAPS -USERMODE -PLATFORM=PC -NOPAUSEONSUCCESS -FASTCOOK -MULTILANGUAGECOOK=${MlCOptions} -MODSONLY=${ModFolderName}" },
            { ArgsDefaultsKeys.COMP_CookMod, "CookPackages -PLATFORM=PC -NOPAUSEONSUCCESS -FULL -FASTCOOK -MULTILANGUAGECOOK=${MlCOptions} -MODSONLY=${ModFolderName}" },
            { ArgsDefaultsKeys.GAME_StartMap,  "${MapName}" },
            { ArgsDefaultsKeys.GAME_StartMapWithoutWorkshopMods, "${MapName} -SEEKFREELOADING" },
            { ArgsDefaultsKeys.ED_LaunchEditor, "editor -NoGADWarning" },
            { ArgsDefaultsKeys.ED_LaunchEditorWithSelectedMap, "editor -TARGETMOD=${ModFolderName} -NoGADWarning" }
        };

        public class ArgumentsItem
        {
            public ArgsDefaultsKeys Key { get; set; }
            public string Value { get; set; }

            public ArgumentsItem(ArgsDefaultsKeys key, string value)
            {
                Key = key;
                Value = value;
            }

            public ArgumentsItem() { }
        }

        public List<ArgumentsItem> CmdLineArguments { get; set; } = new List<ArgumentsItem>();

        public void ResetArguments(ArgsDefaultsKeys key)
        {
            var result = CmdLineArguments.Where(x => x.Key == key);
            if (result.Any()) CmdLineArguments.Remove(result.First());
        }

        public string GetArgumentsFor(ArgsDefaultsKeys key)
        {
            var result = CmdLineArguments.Where(x => x.Key == key);
            return result.Any() ? result.First().Value : ArgsDefaults[key];
        }

        public void ChangeArgument(ArgsDefaultsKeys key, string value)
        {
            var result = CmdLineArguments.Where(x => x.Key == key);
            if (result.Any())
            {
                result.First().Value = value;
            }
            else
            {
                CmdLineArguments.Add(new ArgumentsItem(key, value));
            }
        }

        public string GetLocalizedArgKeyName(ArgsDefaultsKeys key)
        {
            // ToDo
            return key.ToString();
        }

        public void ResetAllArguments()
        {
            foreach (var x in CmdLineArguments)
            {
                x.Value = ArgsDefaults[x.Key];
            }
        }

        [XmlIgnore]
        private static OMMSettings _Instance;

        [XmlIgnore]
        public static OMMSettings Instance {
            get
            {
                if (_Instance is OMMSettings) return _Instance;
                var cfgRoot = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), "OpenModManager");
                var appCfgPath = Path.Combine(cfgRoot, "OMMConfiguration.xml");

                

                if (File.Exists(appCfgPath))
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(OMMSettings));
                        using (Stream reader = new FileStream(appCfgPath, FileMode.Open))
                        {
                            _Instance = (OMMSettings)serializer.Deserialize(reader);
                            return _Instance;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(CUFramework.Shared.LogLevel.Error, ex.Message);
                        Logger.Log(CUFramework.Shared.LogLevel.Error, ex.ToString());
                    }
                }
                else
                {
                    if (!Directory.Exists(cfgRoot))
                        Directory.CreateDirectory(cfgRoot);
                }

                if (!(_Instance is OMMSettings))
                {
                    _Instance = new OMMSettings();
                    _Instance.Save();
                }

                return _Instance;
            }
        }

        public void Save()
        {
            var cfgRoot = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), "OpenModManager");
            var appCfgPath = Path.Combine(cfgRoot, "OMMConfiguration.xml");
            if (!Directory.Exists(cfgRoot))
                Directory.CreateDirectory(cfgRoot);

            XmlSerializer serializer = new XmlSerializer(typeof(OMMSettings));
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.Unicode };
            using (Stream fs = new FileStream(appCfgPath, FileMode.Create))
            {
                using (XmlWriter writer = XmlWriter.Create(fs, settings))
                {
                    serializer.Serialize(writer, this);
                    writer.Close();
                }
            }
        }
    }
}
