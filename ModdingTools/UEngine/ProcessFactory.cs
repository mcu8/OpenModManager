using ModdingTools.Modding;
using System.IO;

namespace ModdingTools.UEngine
{
    public class ProcessFactory
    {
        public class ExecutableArgumentsPair
        {
            public string  Executable { get; private set; }
            public string[] Arguments { get; private set; }
            public string WorkingDirectory { get; private set; }
            public string TaskName { get; private set; }

            public ExecutableArgumentsPair(string taskName, string executable, string[] arguments, string workingDir)
            {
                this.Executable = executable;
                this.Arguments = arguments;
                this.WorkingDirectory = workingDir;
                this.TaskName = taskName;
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
                new string[]
                {
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
                new string[]
                {
                    "CookPackages",
                    "-PLATFORM=PC",
                    "-NOPAUSEONSUCCESS",
                    "-FULL",
                    "-FASTCOOK",
                    "-MULTILANGUAGECOOK=INT",
                    "-MODSONLY=" + mod.GetDirectoryName()
                },
                Path.GetDirectoryName(EditorExecutablePath)
            );
        }

        public ExecutableArgumentsPair StartMap(string mapName = null)
        {
            /*return new ExecutableArgumentsPair(
                GameExecutablePath,
                mapName != null ? new string[] { mapName, "-SEEKFREELOADING" } : new string[] { "-SEEKFREELOADING" },
                Path.GetDirectoryName(GameExecutablePath)
            );*/


            // Little hacky, but works - bypass annoying Steam confirmation window
            // EDIT-1 - doesn't work anymore...

            return new ExecutableArgumentsPair(
                "Launging game",
                Path.Combine(GameFinder.GetSteamDir(), "steam.exe"),
                mapName != null ? new string[] { "-applaunch", GameFinder.AppID, mapName, "-SEEKFREELOADING" } : new string[] { "-applaunch", GameFinder.AppID, "-SEEKFREELOADING" },
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

        public ExecutableArgumentsPair UploadMod(string modName, bool isCuratedItem, string changelog = null)
        {
            // TODO: better changelog filter
            return new ExecutableArgumentsPair(
                "Uploading mod...",
                EditorExecutablePath,
                changelog == null ? new string[] { "Hat_SteamWorkshopCommandlet", "update", (isCuratedItem ? "curated" : "playable"), "\"" + modName + "\""} : new string[] { "Hat_SteamWorkshopCommandlet", "update", (isCuratedItem ? "curated" : "playable"), "\"" + modName + "\"", "\"" + changelog + "\"" },
                Path.GetDirectoryName(GameExecutablePath)
            );
        }

    }
}
