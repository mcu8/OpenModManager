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

            public ExecutableArgumentsPair(string executable, string[] arguments, string workingDir)
            {
                this.Executable = executable;
                this.Arguments = arguments;
                this.WorkingDirectory = workingDir;
            }

            public override string ToString()
            {
                return "Executable=" + Executable + ", Arguments=" + string.Join(" ", Arguments) + ", WorkingDirectory=" + WorkingDirectory;
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

        public ExecutableArgumentsPair GetCompileScript(ModObject mod)
        {
            return new ExecutableArgumentsPair(
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

            return new ExecutableArgumentsPair(
                Path.Combine(GameFinder.GetSteamDir(), "steam.exe"),
                mapName != null ? new string[] { "-applaunch", GameFinder.AppID, mapName, "-SEEKFREELOADING" } : new string[] { "-applaunch", GameFinder.AppID, "-SEEKFREELOADING" },
                Path.GetDirectoryName(GameExecutablePath)
            );
        }

        public ExecutableArgumentsPair LaunchEditor(string modName = null)
        {
            return new ExecutableArgumentsPair(
                EditorExecutablePath,
                modName != null ? new string[] { "-TARGETMOD=" + modName, "-NoGADWarning" } : new string[] { "-NoGADWarning" },
                Path.GetDirectoryName(GameExecutablePath)
            );
        }

    }
}
