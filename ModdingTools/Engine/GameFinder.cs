using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModdingTools.Engine
{
    public class GameFinder
    {
        public const string AppID = "253230";

        public static string GetSteamDir()
        {
            var key = @"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam";
            if (Environment.Is64BitOperatingSystem)
            {
                key = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam";
            }
            return (string)Registry.GetValue(key, "InstallPath", null);
        }

        public static string GetWorkshopDir()
        {
            return Path.Combine(GetSteamDir(), @"steamapps\workshop\content", AppID);
        }

        public static string FindGameDir()
        {
            var strSteamInstallPath = GetSteamDir();

            if (strSteamInstallPath != null && Directory.Exists(strSteamInstallPath))
            {
                var libPathes = new List<string>();
                libPathes.Add(strSteamInstallPath);

                var libFile = File.ReadAllLines(Path.Combine(strSteamInstallPath, "steamapps\\libraryfolders.vdf"));
                int i = 0;
                foreach (var line in libFile)
                {
                    if (i >= 4)
                    {
                        var d = line.Trim().Split('"');
                        if (d.Count() == 5)
                        {
                            libPathes.Add(d[3].Replace(@"\\", @"\"));
                        }
                    }
                    i++;
                }

                foreach (var lib in libPathes)
                {
                    var testPath = Path.Combine(lib, "steamapps\\common\\HatinTime\\Binaries\\Win64");
                    var gamePath = Path.Combine(testPath, "HatinTimeGame.exe");
                    var editorPath = Path.Combine(testPath, "HatinTimeEditor.exe");

                    if (File.Exists(gamePath) && File.Exists(editorPath))
                    {
                        return testPath;
                    }
                }
            }
            return null;
        }
    }
}
