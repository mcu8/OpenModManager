using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ModdingTools
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

        public static void OpenInExplorer(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + path + "\"");
        }
    }
}
