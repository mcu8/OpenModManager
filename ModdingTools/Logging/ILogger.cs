using CUFramework.Shared;

namespace ModdingTools.Logging
{
    interface ILogger
    {
        void Init();
        void Append(string text, string sender, LogLevel level);
        void Unregister();
        LogLevel VerbosityLevel();
    }
}
