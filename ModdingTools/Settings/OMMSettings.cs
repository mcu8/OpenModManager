using CUFramework.Dialogs;
using ModdingTools.Engine;
using ModdingTools.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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

        // ToDo: remove after few months lol
        public void Migrate()
        {
            var oldConfigPath = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), "m_cu8_m_cube");
            if (Directory.Exists(oldConfigPath))
            {
                AutoScanDownloadedMods = Properties.Settings.Default.AutoScanDownloadedMods;
                Memes = Properties.Settings.Default.Memes;
                MultilangCook = Properties.Settings.Default.MultilangCook;
                UpdateCheck = Properties.Settings.Default.UpdateCheck;
                Exporter_ForcePNG = Properties.Settings.Default.Exporter_ForcePNG;
                Flipbook_TrueTransparency = Properties.Settings.Default.Flipbook_TrueTransparency;
                Flipbook_LastIntrpValue = Properties.Settings.Default.Flipbook_LastIntrpValue;
                Flipbook_LastColorValue = Properties.Settings.Default.Flipbook_LastColorValue;
                Flipbook_LastSize = Properties.Settings.Default.Flipbook_LastSize;
                RmShaderOnCook = Properties.Settings.Default.RmShaderOnCook;
                VSCIntegration = Properties.Settings.Default.VSCIntegration;
                FastCook = Properties.Settings.Default.FastCook;
                LastAction = Properties.Settings.Default.LastAction;
                VSCCustomPath = Properties.Settings.Default.VSCCustomPath;
                KillGameBeforeCooking = Properties.Settings.Default.KillGameBeforeCooking;
                KillEditorBeforeCooking = Properties.Settings.Default.KillEditorBeforeCooking;
                MafiaPunchGameToo = Properties.Settings.Default.MafiaPunchGameToo;

                Save();
                Directory.Delete(oldConfigPath, true);

                CUMessageBox.Show("Configuration migrated successfully!");
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
            Stream fs = new FileStream(appCfgPath, FileMode.Create);
            using (XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode))
            {
                serializer.Serialize(writer, this);
                writer.Close();
            }   
        }
    }
}
