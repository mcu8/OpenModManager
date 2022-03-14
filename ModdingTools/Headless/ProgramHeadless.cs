using CommandLine;
using CUFramework.Shared;
using ModdingTools.Engine;
using ModdingTools.Logging;
using ModdingTools.Logging.Handlers;
using ModdingTools.Modding;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ModdingTools.Headless
{
    public static class ProgramHeadless
    {
        public static bool IsHeadlessMode = false;

        [STAThread]
        public static void MainHeadless(string[] args)
        {
            IsHeadlessMode = true;
            Program.ProcFactory = new ProcessFactory();

            Logger.InitializeLogger();

            bool steam = SteamAPI.Init();
            if (!steam)
            {
                Logger.Log(LogLevel.Error, "SteamAPI initialization failed! (is Steam running/installed?)");
                Environment.Exit(0);
            }

            if (!Environment.Is64BitOperatingSystem || !Environment.Is64BitProcess)
            {
                Logger.Log(LogLevel.Error, "This app needs 64-bit operating environment and operating system!");
                Environment.Exit(0);
            }

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Engine.GameFinder.FindGameDir()));
            Program.Uploader = new ModUploader();
            var result = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args).MapResult(
                (opts) => RunOptionsAndReturnExitCode(opts), //in case parser sucess
                (errs) => HandleParseError(errs)); //in  case parser fail
            Environment.ExitCode = result;
        }

        static void PrintModEntry(ModObject mod)
        {          
            //                      max 32 {1}                     max 32 {34}                  max 22 {67}
            var row = "|                                |                                |                      |";

            var e = row.ToCharArray();

            for (var i = 0; i < Math.Min(31, mod.Name.Length); i++)
            {
                e[2 + i] = mod.Name[i];
            }

            var dname = mod.GetDirectoryName();
            for (var i = 0; i < Math.Min(31, dname.Length); i++)
            {
                e[35 + i] = dname[i];
            }

            var id = mod.GetUploadedId().ToString();
            if (id == "0") id = "[n/a]";
            for (var i = 0; i < Math.Min(21, id.Length); i++)
            {
                e[68 + i] = id[i];
            }

            Logger.Log(LogLevel.Info, new string(e));
        }

        static int RunOptionsAndReturnExitCode(CommandLineOptions o)
        {

            if (!o.NoLogo)
            {
                CommandLineLogger.PrintBanner();
            }

            var exitCode = 0;

            var gamePath = Program.ProcFactory.GetGamePath();
            Logger.Log(LogLevel.Info, "Game path: " + gamePath);

            var ds = new ModDirectorySource("Mods directory", Path.Combine(gamePath, @"HatinTimeGame\Mods"), true);

            if (o.ModList)
            {
                var mod = ds.GetMods();
                Logger.Log(LogLevel.Info, "+----------------------------------------------------------------------------------------+");
                Logger.Log(LogLevel.Info, "|                                        MOD LIST                                        |");
                Logger.Log(LogLevel.Info, "|--------------------------------+--------------------------------+----------------------|");
                Logger.Log(LogLevel.Info, "| MOD NAME                       | MOD DIRECTORY NAME             | STEAM ID             |");
                Logger.Log(LogLevel.Info, "|--------------------------------+--------------------------------+----------------------|");
                foreach (var m in mod)
                {
                    PrintModEntry(m);
                }
                Logger.Log(LogLevel.Info, "+--------------------------------+--------------------------------+----------------------+");
            }
            else
            {
                if (o.TestMap != null)
                {
                    var runner = new ConsoleProcessRunner();
                    runner.RunWithoutWait(Program.ProcFactory.StartMap(o.TestMap));
                    return 0;
                }
                
                if (o.Editor && o.ModName == null)
                {
                    var runner = new ConsoleProcessRunner();
                    runner.RunWithoutWait(Program.ProcFactory.LaunchEditor());
                    return 0;
                }

                if (o.ModName == null)
                {
                    Logger.Log(LogLevel.Error, $"You need to specify mod name!");
                    return -36;
                }

                var mod = ds.GetMods(o.ModName);


                if (mod.Length > 0)
                {
                    var runner = new ConsoleProcessRunner();
                    if (o.Editor)
                    {
                        runner.RunWithoutWait(Program.ProcFactory.LaunchEditor(mod[0].GetDirectoryName()));
                        return 0;
                    }

                    if (o.CompileMod)
                    {
                        bool result = mod[0].CompileScripts(runner, false, false);
                        if (!result)
                        {
                            Logger.Log(LogLevel.Error, $"Script building failed!");
                            return -33;
                        }
                        else
                        {
                            mod[0].Refresh();
                        }
                    }

                    if (o.CookMod)
                    {
                        if (!mod[0].HasAnyScripts() || mod[0].HasCompiledScripts())
                        {
                            bool result = mod[0].CookMod(runner, false, false);
                            if (!result)
                            {
                                Logger.Log(LogLevel.Error, $"Cooking failed!");
                                return -34;
                            }
                        }
                        else
                        {
                            Logger.Log(LogLevel.Error, $"You need to compile scripts first!");
                            return -35;
                        }
                    }
                }
                else
                {
                    Logger.Log(LogLevel.Error, $"Mod {o.ModName} doesn't exists!");
                    return -32;
                }
            }
            return exitCode;
        }

        static int HandleParseError(IEnumerable<Error> errs)
        {
            var result = -2;
            if (errs.Any(x => x is HelpRequestedError || x is VersionRequestedError))
                result = -1;
            return result;
        }
    }
}
