using System;
using System.IO;
using NLog;
using NLog.Targets;

namespace BooksApp.Loggers
{
    // Custorm wrapper for NLog
    public static class MyLogger
    {
        public static Logger GetLogger()
        {
            FileTarget target = LogManager.Configuration.FindTargetByName("logfile") as FileTarget;
            string fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\AppData\\" + "LogFile.txt";
            target.FileName = fullPath;

            return LogManager.GetCurrentClassLogger();
        }
    }
}
