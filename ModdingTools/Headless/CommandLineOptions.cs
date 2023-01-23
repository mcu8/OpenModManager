using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModdingTools.Headless
{
    class CommandLineOptions
    {
        [Option(Group = "task", HelpText = "Compile scripts")]
        public bool CompileMod { get; set; }

        [Option(Group = "task", HelpText = "Cook mod")]
        public bool CookMod { get; set; }

        [Option(Group = "task", HelpText = "Print mod list")]
        public bool ModList { get; set; }

        [Option(Group = "task", HelpText = "Launch editor")]
        public bool Editor { get; set; }

        [Option("testmap", HelpText = "Test map", Group = "task")]
        public string TestMap { get; set; }

        [Option("testmapall", HelpText = "Test map (all mods)", Group = "task")]
        public string TestMapAll { get; set; }

        [Option("mod", HelpText = "Mod folder name")]
        public string ModName { get; set; }

        [Option("nologo", HelpText = "Hide banner", Default = false)]
        public bool NoLogo { get; set; }
    }
}
