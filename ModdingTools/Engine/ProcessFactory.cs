using ModdingTools.Modding;
using Steamworks;
using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Threading.Tasks;

namespace ModdingTools.Engine
{
    public class ProcessFactory
    {
        public class ExecutableArgumentsPair
        {
            public string  Executable { get; private set; }
            public string[] Arguments { get; private set; }
            public string WorkingDirectory { get; private set; }
            public string TaskName { get; private set; }
            public Action OnFinish { get; set; }

            public ExecutableArgumentsPair(string taskName, string executable, string[] arguments, string workingDir, Action onFinish = null)
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
                Properties.Settings.Default.KeepConsoleOpen ? 
                new string[]
                {
                    "make",
                    "-FULL",
                    "-SHORTPATHS",
                    "-MODSONLY=" + mod.GetDirectoryName()
                } : new string[]{
                    "make",
                    "-FULL",
                    "-SHORTPATHS",
                    "-NOPAUSEONSUCCESS",
                    "-MODSONLY=" + mod.GetDirectoryName()
                },
                Path.GetDirectoryName(EditorExecutablePath)
            );
        }

        public ExecutableArgumentsPair GetCookMod(ModObject mod)
        {
            return new ExecutableArgumentsPair(
                "Cooking mod...",
                EditorExecutablePath,
                Properties.Settings.Default.KeepConsoleOpen ?
                new string[]
                {
                    "CookPackages",
                    "-PLATFORM=PC",
                    "-FULL",
                    "-FASTCOOK",
                    "-MULTILANGUAGECOOK=" + (Properties.Settings.Default.MultilangCook ? "INT+CHN+DEU+ESN+FRA+ITA+JPN+KOR+PTB" : "INT"),
                    "-MODSONLY=" + mod.GetDirectoryName()
                } : new string[]
                {
                    "CookPackages",
                    "-PLATFORM=PC",
                    "-NOPAUSEONSUCCESS",
                    "-FULL",
                    "-FASTCOOK",
                    "-MULTILANGUAGECOOK=" + (Properties.Settings.Default.MultilangCook ? "INT+CHN+DEU+ESN+FRA+ITA+JPN+KOR+PTB" : "INT"),
                    "-MODSONLY=" + mod.GetDirectoryName()
                },
                Path.GetDirectoryName(EditorExecutablePath)
            );
        }

        public ExecutableArgumentsPair StartMap(string mapName = null)
        {
            return new ExecutableArgumentsPair(
                "Launching game...",
                GameExecutablePath,
                mapName != null ? new string[] { mapName, "-SEEKFREELOADING" } : new string[] { "-SEEKFREELOADING" },
                Path.GetDirectoryName(GameExecutablePath)
            );
        }

        public ExecutableArgumentsPair LaunchEditor(string modName = null)
        {
            return new ExecutableArgumentsPair(
                "Launching editor...",
                EditorExecutablePath,
                modName != null ? new string[] { "editor", "-TARGETMOD=" + modName, "-NoGADWarning" } : new string[] { "editor", "-NoGADWarning" },
                Path.GetDirectoryName(GameExecutablePath)
            );
        }
    }
}
