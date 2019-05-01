using System;
using System.IO;

namespace CheckIt.ServiceLayer
{
    public class Config
    {
        private const string ERROR_LOG_EXT = "_Error.json";
        private const string TEL_LOG_EXT = "_Telemetry.json";
        private const string DATE_FORMAT = "MM-dd-yyyy";
        private const string DATE_TIME_FORMAT = "MM/dd/yyyy hh:mm:ss tt ";
        private readonly string LOG_DIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName+"\\Logs";
        private readonly string LOG_BACKUP_DIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\LogsBackup";
        private readonly string LOG_ARCHIVE_DIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\LogArchives";
        private readonly string EMPTY_DIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\EmptyFolderOnPurpose";

        public string GetErrorLogExtension()
        {
            return ERROR_LOG_EXT;
        }
        public string GetTelemetryLogExtension()
        {
            return TEL_LOG_EXT;
        }
        public string GetDateTimeFormat()
        {
            return DATE_TIME_FORMAT;
        }
        public string GetDateFormat()
        {
            return DATE_FORMAT;
        }

        public string GetLogDirectory()
        {
            return LOG_DIRECTORY;
        }
        public string GetBackupsDirectory()
        {
            return LOG_BACKUP_DIRECTORY;
        }
        public string GetArchiveDirectory()
        {
            return LOG_ARCHIVE_DIRECTORY;
        }
        public string GetEmptyDirectory()
        {
            return EMPTY_DIRECTORY;
        }

    }
}
