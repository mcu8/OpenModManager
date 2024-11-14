using ModdingTools.Modding;
using ModdingTools.Settings;
using Steamworks;
using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Threading.Tasks;

namespace ModdingTools.Engine
{
    public class ProcessFactory
    {
        public class ExecutableArgumentsPair
        {
            public string  Executable { get; private set; }
            public string Arguments { get; private set; }
            public string WorkingDirectory { get; private set; }
            public string TaskName { get; private set; }
            public Action OnFinish { get; set; }

            public ExecutableArgumentsPair(string taskName, string executable, string arguments, string workingDir, Action onFinish = null)
            {
                this.Executable = executable;
                this.Arguments = arguments;
                this.WorkingDirectory = workingDir;
                this.TaskName = taskName;
                this.OnFinish = onFinish;
            }

            public override string ToString()
            {
                return TaskName + " >> Executable=" + Executable + ", Arguments=" + string.Join(" ", Arguments) + ", WorkingDirectory=" + WorkingDirectory;
            }
        }

        private readonly string GameExecutablePath;
        private readonly string EditorExecutablePath;
        public ProcessFactory(string GameExecutablePath, string EditorExecutablePath)
        {
            this.GameExecutablePath   = GameExecutablePath;
            this.EditorExecutablePath = EditorExecutablePath;
        }

        public ProcessFactory()
        {
            var binaryPath = GameFinder.FindGameDir();
            this.GameExecutablePath = Path.Combine(binaryPath, "HatinTimeGame.exe");
            this.EditorExecutablePath = Path.Combine(binaryPath, "HatinTimeEditor.exe");
        }

        public string GetGamePath()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(this.GameExecutablePath)));
        }

        public ExecutableArgumentsPair GetCompileScript(ModObject mod, bool watcher = false)
        {
            return new ExecutableArgumentsPair(
                !watcher ? "Compiling scripts..." : "Changes in filesystem detected... Recompiling scripts...",
                EditorExecutablePath,
                OMMSettings.Instance.GetArgumentsFor(OMMSettings.ArgsDefaultsKeys.COMP_CompileScript)
                    .Replace("${ModFolderName}", mod.GetDirectoryName()),
                Path.GetDirectoryName(EditorExecutablePath)
            );
        }
        
        public ExecutableArgumentsPair GetCookMod(ModObject mod, bool fast = false, Action onFinish = null)
        {
            var args = fast ?
                OMMSettings.Instance.GetArgumentsFor(OMMSettings.ArgsDefaultsKeys.COMP_CookMod) :
                OMMSettings.Instance.GetArgumentsFor(OMMSettings.ArgsDefaultsKeys.COMP_CookModWithFastCookOptionEnabled);
                
            args = args
                .Replace("${ModFolderName}", mod.GetDirectoryName())
                .Replace("${CpuCount}", "" + Environment.ProcessorCount)
                .Replace("${MlCOptions}", (OMMSettings.Instance.MultilangCook ? "INT+CHN+DEU+ESN+FRA+ITA+JPN+KOR+PTB" : "INT"));
           
            return new ExecutableArgumentsPair(
                "Cooking mod...",
                EditorExecutablePath,
                args,
                Path.GetDirectoryName(EditorExecutablePath),
                onFinish
            );
        }

        public ExecutableArgumentsPair StartMap(string mapName = null, bool bootNormally = false)
        {
            var args = bootNormally ?
                OMMSettings.Instance.GetArgumentsFor(OMMSettings.ArgsDefaultsKeys.GAME_StartMap) :
                OMMSettings.Instance.GetArgumentsFor(OMMSettings.ArgsDefaultsKeys.GAME_StartMapWithoutWorkshopMods);

            if (string.IsNullOrWhiteSpace(mapName))
            {
                // maybe it's not most optimal, but we need to make sure to not have any double whitespaces while the map name is empty...
                args = args
                    .Replace(" ${MapName}", "")
                    .Replace("${MapName} ", "");
            }
            else
            {
                args = args.Replace("${MapName}", mapName);
            }

            return new ExecutableArgumentsPair(
                    "Launching game...",
                    GameExecutablePath,
                    args,
                    Path.GetDirectoryName(GameExecutablePath)
                );
        }

        public ExecutableArgumentsPair StartMapWithAllMods(string mapName = null)
        {
            if (mapName == null) mapName = "titlescreen_final";
            return new ExecutableArgumentsPair(
                "Launching game with workshop mods...",
                Program.GetCLIPath(),
                $"--nologo --testmapall={mapName}",
                Path.GetDirectoryName(GameExecutablePath)
            );
        }

        public ExecutableArgumentsPair LaunchEditor(string modName = null)
        {
            var args = modName == null ?
                OMMSettings.Instance.GetArgumentsFor(OMMSettings.ArgsDefaultsKeys.ED_LaunchEditor) :
                OMMSettings.Instance.GetArgumentsFor(OMMSettings.ArgsDefaultsKeys.ED_LaunchEditorWithSelectedMap).Replace("${ModFolderName}", modName);

            return new ExecutableArgumentsPair(
                "Launching editor...",
                EditorExecutablePath,
                args,
                Path.GetDirectoryName(GameExecutablePath)
            );
        }
    }
}
