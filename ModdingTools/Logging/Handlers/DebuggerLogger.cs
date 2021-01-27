using CUFramework.Shared;
using System.Diagnostics;

namespace ModdingTools.Logging.Handlers
{
    public class DebuggerLogger : ILogger
    {

        public void Append(string text, string sender, LogLevel level)
        {
            string tag = "[" + Logger.GetLoggerDate() + "][" + Logger.GetLevelText(level) + "][" + sender + "]";
            Debug.WriteLine(tag + text);
        }

        public void Init()
        {
        }

        public void Unregister()
        {
        }

        public LogLevel VerbosityLevel()
        {
            return LogLevel.Verbose;
        }
    }
}
