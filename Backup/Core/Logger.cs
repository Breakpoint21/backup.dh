using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Backup.Core
{
    class Logger
    {
        public enum Level
        {
             ERROR, WARNING, INFO, EVENT, DEBUG, DIAGNOSTIC
        }

        private static FileInfo logFile = null;

        public static void init()
        {
            logFile = new FileInfo(@"backup.log");
            if (!logFile.Exists)
            {
                try
                {
                    logFile.Create();
                }
                catch (UnauthorizedAccessException)
                {
                    Console.Error.WriteLine("No Permission to create a Logfile!");
                }
                catch (IOException)
                {
                    Console.Error.WriteLine("Error during creating Logfile");
                }
            }

        }

        public static void SummaryLog(string message, DirectoryInfo dest)
        {
            FileInfo log = new FileInfo(dest.FullName + Path.DirectorySeparatorChar + "summary.log");
            if (!log.Exists)
            {
                log.Create();
            }
            if (logFile != null)
            {
                using (StreamWriter logWriter = log.AppendText())
                {
                    logWriter.Write(message);
                    logWriter.Flush();
                    logWriter.Close();
                }
            }
        }

        public static void Log(string message, Level level)
        {
            string logMessage;
            StringBuilder builder = new StringBuilder();
            switch (level)
            {
                case Level.ERROR:
                    builder.AppendFormat("[ERROR]      {0} : {1}", DateTime.Now.ToString("yyyy.MM.dd - HH:mm"), message);
                    break;
                case Level.WARNING:
                    builder.AppendFormat("[WARNING]    {0} : {1}", DateTime.Now.ToString("yyyy.MM.dd - HH:mm"), message);
                    break;
                case Level.INFO:
                    builder.AppendFormat("[INFO]       {0} : {1}", DateTime.Now.ToString("yyyy.MM.dd - HH:mm"), message);
                    break;
                case Level.EVENT:
                    builder.AppendFormat("[EVENT]      {0} : {1}", DateTime.Now.ToString("yyyy.MM.dd - HH:mm"), message);
                    break;
                case Level.DEBUG:
                    builder.AppendFormat("[DEBUG]      {0} : {1}", DateTime.Now.ToString("yyyy.MM.dd - HH:mm"), message);
                    break;
                case Level.DIAGNOSTIC:
                    builder.AppendFormat("[DIAGNOSTIC] {0} : {1}", DateTime.Now.ToString("yyyy.MM.dd - HH:mm"), message);
                    Console.WriteLine(builder.ToString());
                    break;
                default:
                    break;
            }
            logMessage = builder.ToString();
            if (logFile != null)
            {
                using (StreamWriter logWriter = logFile.AppendText())
                {
                    logWriter.WriteLine(logMessage);
                    logWriter.Flush();
                    logWriter.Close();
                }
            }
        }
    }
}
