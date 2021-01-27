using CommandLine;
using CUFramework.Shared;
using ModdingTools.Engine;
using ModdingTools.Logging;
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
    static class ProgramHeadless
    {
        [STAThread]
        public static void MainHeadless(string[] args)
        {
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

        static int RunOptionsAndReturnExitCode(CommandLineOptions o)
        {
            var exitCode = 0;

            var ds = new ModDirectorySource("Mods directory", Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame\Mods"), true);

            if (o.ModName == null)
            {
                Logger.Log(LogLevel.Error, $"You need to specify mod name!");
                return -36;
            }

            var mod = ds.GetMods(o.ModName);
            if (mod.Length > 0)
            {
                var runner = new ConsoleProcessRunner();
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
