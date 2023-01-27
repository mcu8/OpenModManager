using CUFramework.Dialogs.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ModdingTools.Windows.Validators
{
    public class ModNameValidator : IValidator
    {
        public string Validate(string inputText)
        {
            if (inputText.Length < 3)
            {
                return "Mod name should have at least 3 characters";
            }

            if (!Regex.IsMatch(inputText, @"^[a-zA-Z0-9_]+$"))
            {
                return "Invalid characters in mod folder name - you can only use numbers and letters and _";
            }

            if (inputText.ToLower().Trim() == "newmod" || inputText.ToLower().Trim() == "mymod")
            {
                return "Seriously? Give it some more unique name...";
            }

            string modName = inputText;
            string modsRoot = Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods");
            string modPath = Path.Combine(modsRoot, modName);
            string modInfoPath = Path.Combine(modPath, "modinfo.ini");

            if (File.Exists(modInfoPath))
            {
                return "There's already a mod with name \"" + modName + "\". Please delete it or set it up.";
            }

            return null;
        }
    }

    public class ARValidator : IValidator
    {
        public string Validate(string inputText)
        {

            if (!Regex.IsMatch(inputText, @"[A-Za-z0-9]{1,255}\'[A-Za-z0-9\.\-_]{1,255}\'$"))
            {
                return "Invalid asset name!\nIt should look something like this: StaticMesh'MyPackage.MyMesh'";
            }
            return null;
        }
    }

    public class WildcardValidator : IValidator
    {
        public string Validate(string inputText)
        {
            var e = inputText.Trim().Replace("/", "\\");
            if (e.StartsWith("\\") || e.StartsWith(".\\"))
                return "Use only relative file paths here!";

            if (e.Contains(".."))
                return "No, you can't use .. here...";

            if (e.Contains("<") || e.Contains(">") || e.Contains("]") || e.Contains("|") || e.Contains("?") || e.Contains("\"") || e.Contains(":"))
                return "No, you can't use []|?<>\": characters here...";

            if (e.EndsWith("\\"))
                return "Don't add \\ character at the end... If you want to exclude directory contents, type 'DirectoryName\\*' instead!";

            var exploded = e.Split('\\');
            if (exploded.Length > 1)
            {
                for (var x = 0; x != exploded.Length - 2; x++)
                    if (exploded[x].Contains("*"))
                        return "No, you can't use wildcards in the top directory names!";
            }

            return null;
        }
    }

    public class SplitListValidator : IValidator
    {
        char SplitChar;
        public SplitListValidator(char splitChar)
        {
            this.SplitChar = splitChar;
        }

        public string Validate(string inputText)
        {
            if (inputText.Contains(SplitChar))
            {
                return $"Item shouldn't contain the '{SplitChar}' character.";
            }
            return null;
        }
    }
}
