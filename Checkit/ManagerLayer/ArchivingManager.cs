using CheckIt.ServiceLayer;
using System;
using System.IO;
using System.IO.Compression;

namespace CheckIt.ManagerLayer
{
    public class ArchivingManager
    {
        //New archivingService interface
        private IArchivingService archivingService;
        /// <summary>
        /// Instantiates the archiving service
        /// </summary>
        public ArchivingManager()
        {
            archivingService = new ArchivingService();
        }

        /// <summary>
        /// Backup Logs that are older than 30 days to a backup directory
        /// </summary>
        /// <returns>returns a true if backed up successfully</returns>
        public bool BackupLogs()
        {
            try
            {
                string sourcePath = archivingService.GetProjectPath() + "\\Logs";
                Directory.CreateDirectory(sourcePath);
                string targetPath = archivingService.GetProjectPath() + "\\LogsBackup";
                Directory.CreateDirectory(targetPath);
                archivingService.CopyLogs(sourcePath, targetPath, 1);

                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Archive Logs that are older than 2 years to an archive in a separate directory
        /// </summary>
        /// <returns>returns a true if archived successfully</returns>
        public bool ArchiveLogs()
        {
            try
            {
                //archive information
                string archiveDate = archivingService.GetCurrentDate();
                var archivePath = archivingService.GetProjectPath() + "\\LogArchives" + "\\Archive_" + archiveDate + ".zip";
                Directory.CreateDirectory(archivingService.GetProjectPath() + "\\LogArchives");

                //other relevant folder paths
                string tempFolder = archivingService.GetProjectPath() + "\\EmptyFolderOnPurpose";
                Directory.CreateDirectory(tempFolder);
                string allLogsPath = archivingService.GetProjectPath() + "\\Logs";
                Directory.CreateDirectory(allLogsPath);
                string backupPath = archivingService.GetProjectPath() + "\\LogsBackup";
                Directory.CreateDirectory(backupPath);

                //moves all logs to the tempFolder, creates a zip from that folder to archive folder, then deletes contents of tempFolder
                archivingService.MoveLogs(allLogsPath, tempFolder, 24);
                ZipFile.CreateFromDirectory(tempFolder, archivePath);
                DeleteArchivedLogs(tempFolder);

                //moves all backup logs(already archived) to tempFolder then deletes them
                archivingService.MoveLogs(backupPath, tempFolder, 24);
                DeleteArchivedLogs(tempFolder);

                return true;
            }catch(Exception e)
            {
                return false;
            }
           

        }

        /// <summary>
        /// Deletes all contents of a directory
        /// </summary>
        /// <param name="path">The path of the directory to empty out</param>
        public void DeleteArchivedLogs(string path)
        {
            DirectoryInfo folderToEmpty = new DirectoryInfo(path);
            foreach(FileInfo file in folderToEmpty.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in folderToEmpty.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
