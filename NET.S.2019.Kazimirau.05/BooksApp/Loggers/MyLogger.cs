using NLog;
using NLog.Targets;
using System;
using System.IO;

namespace BooksApp.Loggers
{
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
