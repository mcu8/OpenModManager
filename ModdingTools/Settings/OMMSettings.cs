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
            CompileScript,
            CookMod,
            CookModFast,
            StartMap,
            StartMapSeekFree,
            LaunchEditor,
            LaunchEditorWithSelectedMap
        }

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

        private static readonly Dictionary<ArgsDefaultsKeys, string> ArgsDefaults = new Dictionary<ArgsDefaultsKeys, string>() {
            { ArgsDefaultsKeys.CompileScript, "make -FULL -SHORTPATHS -NOPAUSEONSUCCESS -MODSONLY=${ModFolderName}" },
            { ArgsDefaultsKeys.CookMod, "CookPackages ${ModFolderName} -PROCESSES=${CpuCount} -SKIPMAPS -USERMODE -PLATFORM=PC -NOPAUSEONSUCCESS -FASTCOOK -MULTILANGUAGECOOK=${MlCOptions} -MODSONLY=${ModFolderName}" },
            { ArgsDefaultsKeys.CookModFast, "CookPackages -PLATFORM=PC -NOPAUSEONSUCCESS -FULL -FASTCOOK -MULTILANGUAGECOOK=${MlCOptions} -MODSONLY=${ModFolderName}" },
            { ArgsDefaultsKeys.StartMap,  "${MapName}" },
            { ArgsDefaultsKeys.StartMapSeekFree, "${MapName} -SEEKFREELOADING" },
            { ArgsDefaultsKeys.LaunchEditor, "editor -NoGADWarning" },
            { ArgsDefaultsKeys.LaunchEditorWithSelectedMap, "editor -TARGETMOD=${ModFolderName} -NoGADWarning" }
        };

        public List<ArgumentsItem> CmdLineArguments = new List<ArgumentsItem>() {
            new ArgumentsItem(ArgsDefaultsKeys.CompileScript, ArgsDefaults[ArgsDefaultsKeys.CompileScript]),
            new ArgumentsItem(ArgsDefaultsKeys.CookMod, ArgsDefaults[ArgsDefaultsKeys.CookMod]),
            new ArgumentsItem(ArgsDefaultsKeys.CookModFast, ArgsDefaults[ArgsDefaultsKeys.CookModFast]),
            new ArgumentsItem(ArgsDefaultsKeys.StartMap, ArgsDefaults[ArgsDefaultsKeys.StartMap]),
            new ArgumentsItem(ArgsDefaultsKeys.StartMapSeekFree, ArgsDefaults[ArgsDefaultsKeys.StartMapSeekFree]),
            new ArgumentsItem(ArgsDefaultsKeys.LaunchEditor, ArgsDefaults[ArgsDefaultsKeys.LaunchEditor]),
            new ArgumentsItem(ArgsDefaultsKeys.LaunchEditorWithSelectedMap, ArgsDefaults[ArgsDefaultsKeys.LaunchEditorWithSelectedMap])
        };

        public void ResetArguments(ArgsDefaultsKeys key)
        {
            CmdLineArguments.Where(x => x.Key == key).First().Value = ArgsDefaults[key];
        }

        public string GetArgumentsFor(ArgsDefaultsKeys key)
        {
            var result = CmdLineArguments.Where(x => x.Key == key).FirstOrDefault(null);
            return result != null ? result.Value : ArgsDefaults[key];
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
            //Stream fs = new FileStream(, FileMode.Create);
            using (XmlWriter writer = XmlWriter.Create(appCfgPath, settings))
            {
                serializer.Serialize(writer, this);
                writer.Close();
            }
        }
    }
}
