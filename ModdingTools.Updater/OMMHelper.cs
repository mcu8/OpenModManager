using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModdingTools.Updater
{
    public class OMMHelper
    {
        public struct DownloadData
        {
            public string URL;
            public string SHA256;

            public bool IsValid()
            {
                return !string.IsNullOrWhiteSpace(URL)
                    && URL.StartsWith("https://")
                    && !string.IsNullOrWhiteSpace(SHA256)
                    && SHA256.Length == 64;
            }

            public bool Verify(string filePath)
            {
                using (var sha = System.Security.Cryptography.SHA256.Create())
                {
                    using (FileStream fileStream = File.OpenRead(filePath))
                    {
                        var hash = BitConverter.ToString(sha.ComputeHash(fileStream)).Replace("-", string.Empty);
                        return hash.Equals(SHA256, StringComparison.InvariantCultureIgnoreCase);
                    }
                }
            }

            public override string ToString()
            {
                return $"URL: {URL}\nSHA256: {SHA256}\nIsValid: {IsValid()}";
            }
        }

        public static DownloadData GetUpdateData()
        {
            // Well, I should parse this json file by using Newtonsoft.JSON...
            // ...but I don't want to add any extra dependencies just for that one file lol
            var baseUrl = "https://api.github.com/repos/mcu8/OpenModManager/releases/latest";
            string jsonData;
            using(var wc = new WebClient())
            {
                wc.Headers.Add("User-agent", "OpenModManager.Updater/1.0");
                jsonData = wc.DownloadString(baseUrl);
            }

            // get "browser_download_url" tag... the harder way :p
            if (string.IsNullOrEmpty(jsonData)) 
                throw new Exception("Unable to find download URL... [1]");

            var data = new DownloadData();

            var x = jsonData.Split(new string[] { "\"browser_download_url\":\"" }, StringSplitOptions.None);
            if (x.Length > 1)
            {
                foreach (var e in x)
                {
                    var result = e.Split('"')[0];
                    if (result.StartsWith("https://") && result.EndsWith("-bin.zip"))
                        data.URL = result;
                    else if (result.StartsWith("https://") && result.EndsWith("-bin.zip.sha256"))
                    {
                        using (var wc = new WebClient())
                        {
                            wc.Headers.Add("User-agent", "OpenModManager.Updater/1.0");
                            data.SHA256 = wc.DownloadString(result).Split(' ')[0];
                        }
                    }

                    if (data.IsValid()) return data;
                }
            }
            else
            {
                throw new Exception("Unable to find download URL... [3]");
            }

            // well, probably an error
            throw new Exception("Unable to find download URL... [2]");
        }

        public static void KillOMM()
        {
            KillProcessByImageName("ModdingTools", false);
            KillProcessByImageName("ModdingTools.Cli", false);
        }

        public static void KillProcessByImageName(string name, bool async)
        {
            if (async)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (var x in Process.GetProcessesByName(name))
                        x.Kill();
                });
            }
            else
            {
                foreach (var x in Process.GetProcessesByName(name))
                    x.Kill();
            }
        }

        public static void ExtractZIP(string zipFilePath, string targetFolderPath)
        {
            Type fso = Type.GetTypeFromProgID("Shell.Application");
            dynamic fsoi = Activator.CreateInstance(fso);
            dynamic files = fsoi.NameSpace(Path.GetFullPath(zipFilePath)).items;
            fsoi.NameSpace(Path.GetFullPath(targetFolderPath)).CopyHere(files, 16 | 4 | 8);
        }
    }
}
