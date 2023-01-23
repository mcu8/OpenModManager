using CommandLine;
using CUFramework.Shared;
using ModdingTools.Engine;
using ModdingTools.Logging;
using ModdingTools.Logging.Handlers;
using ModdingTools.Modding;
using ModdingTools.Settings;
using ModdingTools.Windows;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ModdingTools.Headless
{
    public static class ProgramHeadless
    {
        public static bool IsHeadlessMode = false;

        [STAThread]
        public static void MainHeadless(string[] args)
        {
            if (!Environment.Is64BitOperatingSystem || !Environment.Is64BitProcess)
            {
                Logger.Log(LogLevel.Error, "This app needs 64-bit operating environment and operating system!");
                Environment.Exit(0);
            }

            IsHeadlessMode = true;
            Program.ProcFactory = new ProcessFactory();

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Engine.GameFinder.FindGameDir()));

            Logger.InitializeLogger();

            // if just compile - skip unecessary stuff - we need to work fast :)
            // hopefully we don't need the SteamAPI to just compile scripts...
            if (args.Length == 2 && (
                args[0] == "c" ||
                args[0] == "cc" ||
                args[0] == "ce" ||
                args[0] == "cg" || 
                args[0] == "cm" ||
                args[0] == "ci" ||
                args[0] == "cn") && args[1].ToLower().EndsWith(".uc"))
            {
                var compResult = CompileMod(args[1], args[0]);
                Environment.Exit(compResult);
            }


            Program.Uploader = new ModUploader();
            Program.SWS = new SteamWorkshopStorage(Path.Combine(Engine.GameFinder.GetModsDir(), "SteamWorkshop.ini"));

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
                if (o.TestMapAll != null)
                {
                    RunSteamAPI(true);
                    var runner = new ConsoleProcessRunner();
                    runner.RunWithoutWait(Program.ProcFactory.StartMap(o.TestMapAll, true));
                    Thread.Sleep(100);
                    // restore appid
                    Utils.UpdateAppId(734880);
                    return 0;
                }

                if (o.TestMap != null)
                {
                    RunSteamAPI(false);
                    var runner = new ConsoleProcessRunner();
                    runner.RunWithoutWait(Program.ProcFactory.StartMap(o.TestMap));
                    Thread.Sleep(100);
                    // restore appid
                    Utils.UpdateAppId(734880);
                    return 0;
                }
                
                if (o.Editor && o.ModName == null)
                {
                    RunSteamAPI(false);
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

        private static void RunSteamAPI(bool useAltSteamId)
        {
            Utils.UpdateAppId(useAltSteamId ? 253230 : 734880);
            bool steam = SteamAPI.Init();
            if (!steam)
            {
                Logger.Log(LogLevel.Error, "SteamAPI initialization failed! (is Steam running/installed?)");
                Environment.Exit(0);
            }
        }

        public static int CompileMod(string scriptPath, string command)
        {
            Console.WriteLine(OMMSettings.Instance.KillGameBeforeCooking);
            //OMMSettings.Instance.KillGameBeforeCooking = false;
            //OMMSettings.Instance.Save();
           Console.ReadKey();
            return 0;


            if (command == "ce" || command == "cg" || command == "cm" || command == "ci" || command == "cn")
            {
                if (OMMSettings.Instance.KillEditorBeforeCooking)
                    Utils.KillEditor();
                if (OMMSettings.Instance.KillGameBeforeCooking)
                    Utils.KillGame();
                Thread.Sleep(150);
            }

            var gamePath = Program.ProcFactory.GetGamePath();
            Logger.Log(LogLevel.Info, "Game path: " + gamePath);
            var ds = new ModDirectorySource("Mods directory", Path.Combine(gamePath, @"HatinTimeGame\Mods"), true);
            var mod = ds.FindModByScriptPath(scriptPath);
            if (mod == null)
            {
                Logger.Log(LogLevel.Error, "Failed to find mod for current script file!");
                return -1;
            }
            else
            {
                var runner = new ConsoleProcessRunner();
                var cookedStatus = mod.DoesModNeedToBeCooked();
                var fast = OMMSettings.Instance.FastCook && cookedStatus != null && !cookedStatus.Contains("[0x0]") && !cookedStatus.Contains("[0x3]") && !cookedStatus.Contains("[0x4]");
                var scriptNeedCooking = cookedStatus != null && (cookedStatus.Contains("[0x1]") || cookedStatus.Contains("[0x2]") || cookedStatus.Contains("[0x0]"));
                if (cookedStatus == null)
                {
                    Logger.Log(LogLevel.Info, "Nothing to cook");
                }
                else
                {
                    Logger.Log(LogLevel.Info, "Starting mod building, reason(s): \n" + cookedStatus);
                    bool result;
                    if (scriptNeedCooking)
                    {
                        Logger.Log(LogLevel.Info, "Running CompileScripts task...");
                        result = mod.CompileScripts(runner, false, false);
                        if (!result)
                        {
                            Logger.Log(LogLevel.Error, $"Script building failed!");
                            return -33;
                        }
                        else
                        {
                            mod.Refresh();
                        }
                    }
                    else
                    {
                        Logger.Log(LogLevel.Info, "Scripts are up to date, skipping...");
                    }

                    if (command == "cc" || command == "ce" || command == "cg" || command == "cm" || command == "ci" || command == "cn")
                    {
                        if (!mod.HasAnyScripts() || mod.HasCompiledScripts())
                        {
                            Logger.Log(LogLevel.Info, "Running CookMod task..." + (fast ? " (fast script cooking mode)" : ""));
                            result = mod.CookMod(runner, false, false, fast);
                            if (!result)
                            {
                                Logger.Log(LogLevel.Error, $"Cooking failed!");
                                return -34;
                            }
                            Utils.UpdateFileDates(mod.GetCookedDir());
                        }
                        else
                        {
                            Logger.Log(LogLevel.Error, $"You need to compile scripts first!");
                            return -35;
                        }
                    }
                }

                if (command == "ce" || command == "cg" || command == "cm" || command == "ci" || command == "cn")
                {
                    if (command == "ci" || command == "cn")
                    {
                        // spoof to game appid to load workshop mods
                        Utils.UpdateAppId(253230);
                    }
                    else
                    {
                        Utils.UpdateAppId(734880);
                    }

                    bool steam = SteamAPI.Init();
                    if (!steam)
                    {
                        Logger.Log(LogLevel.Error, "SteamAPI initialization failed! (is Steam running/installed?)");
                        Environment.Exit(0);
                    }

                    switch (command)
                    {
                        case "ce":
                            runner.RunWithoutWait(Program.ProcFactory.LaunchEditor(mod.GetDirectoryName()));
                            break;
                        case "cg":
                        case "ci":
                            runner.RunWithoutWait(Program.ProcFactory.StartMap(mod.GetLastMap(), command == "ci"));

                            Thread.Sleep(1000);
                            // restore appid
                            Utils.UpdateAppId(734880);
                            break;
                        case "cm":
                        case "cn":
                            var chooser = new MapChooser(mod);
                            chooser.ShowDialog();
                            runner.RunWithoutWait(Program.ProcFactory.StartMap(mod.GetLastMap(), command == "cn"));

                            Thread.Sleep(1000);
                            // restore appid
                            Utils.UpdateAppId(734880);
                            break;
                        default:
                            throw new Exception("NOT IMPLEMENTED!!!!1");
                    }
                }
                return 0;
            }
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
