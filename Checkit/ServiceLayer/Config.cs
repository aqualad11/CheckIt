using System;
using System.IO;

namespace CheckIt.ServiceLayer
{
    public class Config
    {
        public string ERROR_LOG_EXT { get; }
        public string TEL_LOG_EXT {get;}
        public string DATE_FORMAT { get; }
        public string DATE_TIME_FORMAT { get; }
        public string LOG_DIRECTORY { get; }
        public string LOG_BACKUP_DIRECTORY { get; }
        public string LOG_ARCHIVE_DIRECTORY { get; }
        public string EMPTY_DIRECTORY { get; }

        public Config()
        {
            ERROR_LOG_EXT = "_Error.json";
            TEL_LOG_EXT = "_Telemetry.json";
            DATE_FORMAT = "yyyy-MM-dd";
            DATE_TIME_FORMAT = "MM/dd/yyyy hh:mm:ss tt ";
            LOG_DIRECTORY = "C:\\Users\\Administrator\\Documents\\Logs"; //Directory.CreateDirectory(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName+"\\Logs").ToString();
            LOG_BACKUP_DIRECTORY = "C:\\Users\\Administrator\\Documents\\LogsBackup"; //Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\LogsBackup";
            LOG_ARCHIVE_DIRECTORY = "C:\\Users\\Administrator\\Documents\\LogArchives"; //Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\LogArchives";
            EMPTY_DIRECTORY = "C:\\Users\\Administrator\\Documents\\EmptyFolderOnPurpose"; //Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\EmptyFolderOnPurpose";
        }

    }
}
