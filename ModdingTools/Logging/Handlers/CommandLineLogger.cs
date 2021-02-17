using CUFramework.Shared;
using System;
using System.Runtime.InteropServices;

namespace ModdingTools.Logging.Handlers
{
    public class CommandLineLogger : ILogger
    {
        public void Init()
        {
            Console.Title = "OMM";
        }

        public static void PrintBanner()
        {
            Logger.PrintBoxed(Properties.Resources.Banner + "\n\n" + "[Command Line mode]\nApp build number: " + BuildData.CurrentVersion, ConsoleColor.Yellow);

            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void Append(string text, string sender, LogLevel level)
        {
            string tag = "[" + Logger.GetLoggerDate() + " " + Logger.GetLevelText(level) + "]  ";

            switch (level)
            {
                case LogLevel.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogLevel.Verbose:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            Console.WriteLine(tag + text);
            Console.ResetColor();
        }

        public void Unregister()
        {
        }

        public LogLevel VerbosityLevel()
        {
            return LogLevel.Info;
        }
    }
}
