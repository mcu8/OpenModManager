using CUFramework.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace ModdingTools.Logging
{
    static class Logger
    {
        private static Dictionary<string, ILogger> HANDLER_REGISTRY { get; set; }

        private static bool IsInitialized = false;
        public static void InitializeLogger()
        {
            HANDLER_REGISTRY = new Dictionary<string, ILogger>();

            if (Debugger.IsAttached)
                RegisterOutputHandler("DebuggerLogger", new Logging.Handlers.DebuggerLogger());

            RegisterOutputHandler("CommandLineLogger", new Logging.Handlers.CommandLineLogger());

            IsInitialized = true;
        }

        public static void RegisterOutputHandler(string name, ILogger handler)
        {
            if (!HANDLER_REGISTRY.ContainsKey(name))
            {
                HANDLER_REGISTRY.Add(name, handler);
                HANDLER_REGISTRY[name].Init();
            }
        }

        public static void UnregisterOutputHandler(string name)
        {
            if (HANDLER_REGISTRY.ContainsKey(name))
            {
                HANDLER_REGISTRY[name].Unregister();
                HANDLER_REGISTRY.Remove(name);
            }
        }

        public static string GetLoggerDate()
        {
            System.DateTime regDate = System.DateTime.Now;
            return regDate.ToString("HH:mm:ss");
        }

        public static string GetLevelText(LogLevel level)
        {
            return level.ToString();
        }

        public static void Log(LogLevel Level, string Message, string Sender = "")
        {
            if (!IsInitialized) InitializeLogger();
            if ((Message != null))
            {
                if (Message.Contains("\n"))
                {
                    foreach (string msg in Message.Split('\n'))
                    {
                        SendToHandlers(msg, Sender, Level);
                    }
                }
                else
                {
                    SendToHandlers(Message, Sender, Level);
                }
            }
        }

        public static void PrintBoxed(string text, ConsoleColor color)
        {

            Console.ResetColor();
            string[] lines = text.Split('\n');

            for (int i = 0; i != lines.Length; i++)
            {
                lines[i] = lines[i].Replace("\n", String.Empty);
                lines[i] = lines[i].Replace("\r", String.Empty);
                lines[i] = lines[i].Replace("\t", String.Empty);
            }

            int total = (lines.Length <= 1 ? text.Length : lines.Max(a => a.Length)) + 6;

            string x = "";
            string y = "";
            for (int i = 0; i != total; i++)
            {
                x += "█";
            }
            for (int i = 0; i != total - 2; i++)
            {
                y += " ";
            }

            for (int i = 0; i < lines.Length; i++)
            {
                while (lines[i].Length < total - 6)
                {
                    lines[i] += " ";
                }
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write(" ");
            Console.ForegroundColor = color;
            Console.Write(x);
            Console.WriteLine("");
            Console.ResetColor();
            Console.Write(" ");
            Console.ForegroundColor = color;
            Console.Write("█");
            Console.ResetColor();
            Console.Write(y);
            Console.ForegroundColor = color;
            Console.Write("█");

            foreach (var line in lines)
            {
                Console.WriteLine("");
                Console.ResetColor();
                Console.Write(" ");
                Console.ForegroundColor = color;
                Console.Write("█");
                Console.ResetColor();
                Console.Write("  " + line + "  ");
                Console.ForegroundColor = color;
                Console.Write("█");
                Console.ResetColor(); 
            }

            Console.WriteLine("");

            Console.Write(" ");
            Console.ForegroundColor = color;
            Console.Write("█");
            Console.ResetColor();
            Console.Write(y);
            Console.ForegroundColor = color;
            Console.WriteLine("█");
            Console.ResetColor();
            Console.Write(" ");
            Console.ForegroundColor = color;
            Console.Write(x);
            Console.ResetColor();
            Console.WriteLine("");
        }

        private static void SendToHandlers(string text, string sender, LogLevel level)
        {
            foreach (var entity in new List<ILogger>(HANDLER_REGISTRY.Values))
            {
                if (level < entity.VerbosityLevel()) continue;
                entity.Append(text, sender, level);
            }
        }
    }
}
