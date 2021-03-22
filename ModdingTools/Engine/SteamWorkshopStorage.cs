using ModdingTools.Modding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModdingTools.Engine
{
    public class SteamWorkshopStorage
    {
        Dictionary<string, ulong> SteamWorkshopData;
        private string FileName;

        public SteamWorkshopStorage(string fileName)
        {
            SteamWorkshopData = new Dictionary<string, ulong>(StringComparer.InvariantCultureIgnoreCase);
            this.FileName = fileName;
            Reload();
        }

        public ulong GetIdForMod(ModObject mod)
        {
            var dirname = mod.GetDirectoryName();
            if (SteamWorkshopData.ContainsKey(dirname)) 
                return SteamWorkshopData[dirname];
            return 0;
        }

        public void SetIdForMod(ModObject mod, ulong value)
        {
            var dirname = mod.GetDirectoryName();
            if (SteamWorkshopData.ContainsKey(dirname))
                SteamWorkshopData[dirname] = value;
            else
                SteamWorkshopData.Add(dirname, value);
            Save();
        }

        // New parser for the SteamWorkshop.ini file, maybe that will avoid parser mistakes... hopefully :huehpain:
        private void Reload()
        {
            SteamWorkshopData.Clear();

            if (!File.Exists(FileName)) return; // just do nothing if it doesn't exists

            var data = File.ReadAllLines(FileName);

            var nextLineShouldHaveValue = false;
            var cachedPrevLineName = "";
            foreach (var line in data)
            {
                var sanitized = line.Trim();
                if (sanitized.StartsWith("#") || sanitized.StartsWith("//") || string.IsNullOrEmpty(sanitized)) continue; // skip comments and empty lines

                if (sanitized.StartsWith("[") && sanitized.EndsWith("]"))
                {
                    cachedPrevLineName = sanitized.TrimStart('[').TrimEnd(']');
                    nextLineShouldHaveValue = true;
                }
                else if (nextLineShouldHaveValue && sanitized.Split('=')[0].Trim().StartsWith("WorkshopId"))
                {
                    SteamWorkshopData.Add(cachedPrevLineName, ulong.Parse(sanitized.Split('=')[1].Trim()));
                    nextLineShouldHaveValue = false;
                    cachedPrevLineName = "";
                }
            }
        }

        public void Save()
        {
            var b = new StringBuilder();
            foreach (var e in SteamWorkshopData)
            {
                if (e.Value <= 0) continue; // skip empty values
                b.AppendLine($"[{e.Key}]");
                b.AppendLine($"WorkshopId={e.Value}");
                b.AppendLine("");
            }
            File.WriteAllText(FileName, b.ToString());
        }
    }
}
