using CUFramework.Shared;
using ModdingTools.Engine;
using ModdingTools.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModdingTools.Headless
{
    public class ConsoleProcessRunner : AbstractProcessRunner
    {
        public override void FinishAppRun()
        {
        }

        public override void Log(string msg, LogLevel level)
        {
            Logger.Log(level, msg);
        }

        public override void PostAppRun()
        {
        }

        public override void PreAppRun(bool cleanConsole, string taskName)
        {
            Logger.PrintBoxed($"Starting task: {taskName}...", ConsoleColor.White);
        }

        public override void PreRunWithoutWait()
        {
        }

        public override void SetText(string value)
        {
            Console.Title = value??"";
        }
    }
}
