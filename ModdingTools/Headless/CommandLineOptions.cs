using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModdingTools.Headless
{
    class CommandLineOptions
    {
        [Option(Group = "build", HelpText = "Compile scripts")]
        public bool CompileMod { get; set; }

        [Option(Group = "build", HelpText = "Cook mod")]
        public bool CookMod { get; set; }

        [Option("mod", HelpText = "Mod folder name")]
        public string ModName { get; set; }
    }
}
