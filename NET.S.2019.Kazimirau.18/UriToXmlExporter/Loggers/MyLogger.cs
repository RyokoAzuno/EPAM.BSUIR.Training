using System.Configuration;
using NLog;
using NLog.Targets;

namespace UriToXmlExporter.Loggers
{
    /// <summary>
    /// Class-wrapper for NLog
    /// </summary>
    public class MyLogger
    {
        public static Logger GetLogger()
        {
            FileTarget target = LogManager.Configuration.FindTargetByName("logfile") as FileTarget;
            string fullPath = ConfigurationManager.AppSettings["LoggerStoragePath"];
            target.FileName = fullPath;

            return LogManager.GetCurrentClassLogger();
        }
    }
}
