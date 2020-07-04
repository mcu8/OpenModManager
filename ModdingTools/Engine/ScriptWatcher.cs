using ModdingTools.Modding;
using ModdingTools.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModdingTools.Engine
{
    class ScriptWatcherManager
    {
        private static Dictionary<string, ScriptWatcher> WatcherProcesses = new Dictionary<string, ScriptWatcher>();
        public static void AttachWatcher(ModObject o)
        {
            if (WatcherProcesses.ContainsKey(o.GetDirectoryName()))
            {
                return;
            }
            WatcherProcesses.Add(o.GetDirectoryName(), new ScriptWatcher(o));
        }

        public static void DetachWatcher(ModObject o)
        {
            if (WatcherProcesses.ContainsKey(o.GetDirectoryName()))
            {
                WatcherProcesses[o.GetDirectoryName()].Dispose();
                WatcherProcesses.Remove(o.GetDirectoryName());
            }
        }

        public static bool IsWatcherAttached(ModObject o)
        {
            return WatcherProcesses.ContainsKey(o.GetDirectoryName());
        }
    }

    class ScriptWatcher : IDisposable
    {
        FileSystemWatcher watcher;
        readonly ModObject Mod;

        public ScriptWatcher(ModObject mod)
        {
            this.Mod = mod;
            var path = mod.RootPath;

            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();
            watcher.Path = Path.Combine(path, "Classes");

            /* Watch for changes in LastAccess and LastWrite times, and 
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            // Only watch script files.
            watcher.Filter = "*.uc";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
        }



        // Define the event handlers.

        long lastMillis;
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (Utils.GetUnixTimestamp(DateTime.Now) - lastMillis > 1000)
            {
                lastMillis = Utils.GetUnixTimestamp(DateTime.Now);
            }
            else
            {
                return;
            }

            try
            {
                watcher.EnableRaisingEvents = false;
                if (e.ChangeType == WatcherChangeTypes.Changed)
                {
                    var ph = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(e.FullPath)));
                    Mod.UnCookMod();
                    Task.Factory.StartNew(() =>
                    {
                        MainWindow.Instance.Runner.KillAllWorkers();
                        Mod.CompileScripts(MainWindow.Instance.Runner, true);
                    });
                }

            }
            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
        }

        public void Dispose()
        {
            watcher.Dispose();
        }
    }
}
