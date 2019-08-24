﻿using IniParser.Model;
using ModdingTools.GUI;
using ModdingTools.UEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ModdingTools.Modding
{
    public class ModObject
    {
        public string Name              { get; set; }
        public string Author            { get; set; }
        public string Description       { get; set; }
        public string Version           { get; set; }
        public bool   IsCheat           { get; set; }
        public string Icon              { get; set; }
        public string ChapterInfoName   { get; set; }

        public int CuratedSteamId       { get; set; }
        public int PlayableSteamId      { get; set; }

        IniParser.Parser.IniDataParser Parser;

        public string RootPath { get; private set; }
        public ModDirectorySource RootSource { get; private set; }

        public string GetDescription()
        {
            return this.Description.Replace("[br]", Environment.NewLine).Trim('"');
        }

        public string GetIniPath()
        {
            return Path.Combine(RootPath, "modinfo.ini");
        }

        public string GetDirectoryName()
        {
            return Path.GetFileName(RootPath);
        }

        public void RenameDirectory(string newName)
        {
            Directory.Move(RootPath, Path.Combine(RootSource.Root, newName));
        }

        public void ChangeModSource(ModDirectorySource source)
        {
            var newRoot = Path.Combine(source.Root, Path.GetFileName(RootPath));
            Directory.Move(RootPath, newRoot);
            this.RootPath = newRoot;
            this.RootSource = source;
        }

        public void UnCookMod()
        {
            var path = Path.Combine(RootPath, "CookedPC");
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path, "*.u"))
                {
                    File.Delete(file);
                }
                foreach (var file in Directory.GetFiles(path, "*.upk"))
                {
                    File.Delete(file);
                }
            }
        }

        public static ModClass.ModClassType[] CombineTags(ModClass[] source)
        {
            List<ModClass.ModClassType> mc = new List<ModClass.ModClassType>();
            foreach (var s in source)
            {
                if (!mc.Contains(s.ClassType))
                {
                    mc.Add(s.ClassType);
                }
            }
            return mc.ToArray();
        }

        public ModClass[] GetModClasses()
        {
            List<ModClass> mc = new List<ModClass>();
            var path = Path.Combine(RootPath, "Classes");

            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path, "*.uc", SearchOption.AllDirectories))
                {
                    mc.Add(new ModClass(file));
                }
            }
            return mc.ToArray();
        }

        public void CookMod(ProcessRunner runner, bool async = true)
        {
            if (async)
            {
                runner.RunAppAsync(Program.ProcFactory.GetCookMod(this));
            }
            else
            {
                runner.RunApp(Program.ProcFactory.GetCookMod(this));
            }
        }

        public void TestMod(ProcessRunner runner, string mapName = null)
        {
            runner.RunWithoutWait(Program.ProcFactory.StartMap(mapName));
        }

        public void CompileScripts(ProcessRunner runner, bool async = true, bool watcher = false)
        {
            if (async)
            {
                runner.RunAppAsync(Program.ProcFactory.GetCompileScript(this, watcher));
            }
            else
            {
                runner.RunApp(Program.ProcFactory.GetCompileScript(this, watcher));
            }
        }

        public ModObject(string rootPath, ModDirectorySource parent)
        {
            this.RootPath = rootPath;
            this.RootSource = parent;

            Parser = new IniParser.Parser.IniDataParser();
            IniData info = Parser.Parse(File.ReadAllText(GetIniPath()));

            var i                   = info["Info"];
            // Parse "Info" section
            this.Name               = TryGet(i, "name",         "???");
            this.Author             = TryGet(i, "author",       "???");
            this.Description        = TryGet(i, "description",  "???");
            this.Version            = TryGet(i, "version",      "???");

            this.IsCheat            = bool.Parse(TryGet(i, "is_cheat", "false"));
            this.Icon               = TryGet(i, "icon");
            this.ChapterInfoName    = TryGet(i, "ChapterInfoName", "???");

            // TODO: Parse "Tags" section
        }

        public bool IsReadOnly => RootSource.IsReadOnly;

        public Image GetIcon()
        {
            var noIconImage = Properties.Resources.close;
            if (Icon == null)
                return noIconImage;

            var path = Path.Combine(RootPath, Icon);

            try
            {
                Image img;
                using (var bmpTemp = new Bitmap(path))
                {
                    img = new Bitmap(bmpTemp);
                }
                return img;
            }
            catch (Exception)
            {
                return noIconImage;
            }
        }

        private string TryGet(KeyDataCollection context, string key, string def = null)
        {
            if (context.ContainsKey(key))
                return context[key];
            return def;
        }

        public void Save()
        {
            //TODO
        }
        
    }
}
