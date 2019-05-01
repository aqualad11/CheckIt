using System;

namespace CheckIt.ServiceLayer
{
    public interface IArchivingService
    {
        bool OlderThanMonths(string file, int months);
        DateTime LogFileDate(string logFile);
        void MoveLogs(string sourcePath, string targetPath, int months);
        void CopyLogs(string sourcePath, string targetPath, int months);
        string GetProjectPath();
        string GetCurrentDate();

    }
}
