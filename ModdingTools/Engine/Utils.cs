using ModdingTools.GUI;
using ModdingTools.Modding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Drawing;
using System.IO;

namespace ModdingTools.Engine
{
    public class Utils
    {
        public static string[] Split(string source, string key)
        {
            return source.Split(new[] { key }, StringSplitOptions.None);
        }

        public static string ClearWhitespaces(string source, bool keepSingleSpace = true)
        {
            return Regex.Replace(source, @"\s+", keepSingleSpace ? " " : "");
        }

        public static bool CollectionContains(string find, string[] haystack)
        {
            foreach (var item in haystack)
            {
                if (item.Equals(find))
                {
                    return true;
                }
            }
            return false;
        }

        public static Image LoadImageIntoMemory(string imageFile)
        {
            MemoryStream ms = new MemoryStream();
            using (FileStream stream = new FileStream(imageFile, FileMode.Open, FileAccess.Read))
            {
                Image imgTemp = Image.FromStream(stream);
                imgTemp.Save(ms, imgTemp.RawFormat);
                byte[] temparray = ms.ToArray();
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(Image));
                return (Image)tc.ConvertFrom(temparray);
            }
        }

        public static bool IsVSDesignMode()
        {
            return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
        }

        public static void CleanUpTrash(string gamedir)
        {
            var path1 = Path.Combine(gamedir, "HatinTimeGame/EditorCookedPC/LocalShaderCache-PC-D3D-SM3.upk");
            if (File.Exists(path1))
                File.Delete(path1);
        }

        public static void OpenInExplorer(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + path + "\"");
        }

        public static void StartInDefaultBrowser(string url)
        {
            try
            {
                Process.Start("rundll32", "url.dll,FileProtocolHandler \"" + url + "\"");
            }
            catch (Exception)
            {
            }
        }

        public static void KillEditor()
        {
            System.Diagnostics.Process.Start("taskkill.exe", "/F /IM HatInTimeEditor.exe");
        }

        public static long GetUnixTimestamp(DateTime t)
        {
            return (long)t.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static bool FileExists(string PathToLook, string Filename, string FileToIgnore = "")
        {
            if (!Directory.Exists(PathToLook)) return false;
            return Directory.GetFiles(PathToLook, Filename, SearchOption.AllDirectories).Length != 0;
        }

        public static string FindPackage(string name)
        {
            var lookupA = Directory.GetFiles(GameFinder.GetEditorCookedPcDir(), name + ".upk", SearchOption.AllDirectories);
            if (lookupA.Length > 0) return lookupA.First();

            var lookupB = Directory.GetFiles(GameFinder.GetModsDir(), name + ".upk", SearchOption.AllDirectories);
            if (lookupB.Length > 0) return lookupB.First();

            var lookupC = Directory.GetFiles(GameFinder.GetWorkshopDir(), name + ".upk", SearchOption.AllDirectories);
            return lookupC.First();
        }

        public static string ReadStringFromFile(string path)
        {
            var result = "";
            using (var s = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var tr = new StreamReader(s))
            {
                result = tr.ReadToEnd();
            }
            return result;
        }

        public static DateTime? YoungestInDir(string PathToFolder, string[] FileFilters)
        {
            if (!Directory.Exists(PathToFolder))
            {
                return null;
            }
            DateTime? result = null;
            foreach (string searchPattern in FileFilters)
            {
                var files = Directory.GetFiles(PathToFolder, searchPattern, SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var lastWriteTime = File.GetLastWriteTime(file);
                    if (!result.HasValue || DateTime.Compare(lastWriteTime, result.Value) < 0)
                    {
                        result = lastWriteTime;
                    }
                }
            }
            return result;
        }

        public static bool DirContainsKey(string folder, string keyword)
        {
            if (!Directory.Exists(folder)) return false;
            return Directory.GetFiles(folder, keyword, SearchOption.AllDirectories).Length > 0;
        }

        public static void MoveDir(string source, string target)
        {
            DirectoryCopy(source, target, true);
            Directory.Delete(source, true);
        }

        // OK, I'm peckin' gave up with Directory.Move - old DOS "move" command somehow ALWAYS works
        public static void MoveDirDos(string source, string target)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = $"/c move \"{Path.GetFullPath(source)}\" \"{Path.GetFullPath(target)}\"";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
        }

        public static void CleanupAttrib(string pFolderPath, bool recursive = true)
        {
            if (recursive)
            {
                try
                {
                    foreach (string Folder in Directory.GetDirectories(pFolderPath))
                    {
                        CleanupAttrib(Folder);
                    }
                }
                catch (Exception)
                {
                }
            }

            foreach (string file in Directory.GetFiles(pFolderPath))
            {
                try
                {
                    var pPath = Path.Combine(pFolderPath, file);
                    FileInfo fi = new FileInfo(pPath);

                    File.SetAttributes(pPath, FileAttributes.Normal);
                }
                catch (Exception)
                {
                }
            }
        }

        // https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
