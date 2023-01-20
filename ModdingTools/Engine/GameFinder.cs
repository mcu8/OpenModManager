
//#define STEAM_NO_REGISTRY_TEST

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

#if STEAM_NO_REGISTRY_TEST
        public static string GetSteamDir()
        {
            return null;
        }
#else
        public static string GetSteamDir()
        {
            try
            {
                var key = @"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam";
                if (Environment.Is64BitOperatingSystem)
                {
                    key = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam";
                }
                return (string)Registry.GetValue(key, "InstallPath", null);
            }
            catch
            {
                // if it somehow fails... we don't care lol
                return null;
            }
        }
#endif

        public static string GetWorkshopDir()
        {
            var steamDir = GetSteamDir();
            if (steamDir == null || !Directory.Exists(steamDir))
            {
                // fallback to more cheap dir detection... probably using Proton or bad Steam install?

                // the funny
                var baseDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(FindGameDir()))));
                return Path.Combine(baseDir, @"workshop\content", AppID);
            }
            return Path.Combine(steamDir, @"steamapps\workshop\content", AppID);
        }

        public static string GetModsDir()
        {
            return Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(FindGameDir())), "HatInTimeGame", "Mods");
        }

        public static string GetSrcDir()
        {
            return Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(FindGameDir())), "Development", "Src");
        }

        public static string GetCookedPcDir()
        {
            return Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(FindGameDir())), "HatInTimeGame", "CookedPC");
        }

        public static string GetEditorCookedPcDir()
        {
            return Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(FindGameDir())), "HatInTimeGame", "EditorCookedPC");
        }

        // Cache that, cuz we changing the working dir - must be absolute!
        private static string CachedGameDir = null;
        public static string FindGameDir()
        {
            if (CachedGameDir != null)
                return CachedGameDir;

            if (File.Exists("GameDirPath.dat"))
            {
                try
                {
                    var testPath = File.ReadAllText("GameDirPath.dat");
                    var gamePath = Path.Combine(testPath, "HatinTimeGame.exe");
                    var editorPath = Path.Combine(testPath, "HatinTimeEditor.exe");

                    if (File.Exists(gamePath) && File.Exists(editorPath))
                    {
                        CachedGameDir = Path.GetFullPath(testPath);
                        return testPath;
                    }
                    else
                    {
                        File.Delete("GameDirPath.dat");
                    }
                }
                catch (Exception)
                {
                    File.Delete("GameDirPath.dat");
                }
            }

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
                        CachedGameDir = Path.GetFullPath(testPath);
                        return testPath;
                    }
                }
            }
            return null;
        }
    }
}
