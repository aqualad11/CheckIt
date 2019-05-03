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
        //New config instance
        private Config config;
        /// <summary>
        /// Instantiates the archiving service and the config file
        /// </summary>
        public ArchivingManager()
        {
            archivingService = new ArchivingService();
            config = new Config();
        }

        /// <summary>
        /// Backup Logs that are older than 30 days to a backup directory
        /// </summary>
        /// <returns>returns a true if backed up successfully</returns>
        public bool BackupLogs()
        {
            try
            {
                string sourcePath = config.GetLogDirectory();
                Directory.CreateDirectory(sourcePath);
                string targetPath = config.GetBackupsDirectory();
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
                var archivePath = config.GetArchiveDirectory() + "\\Archive_" + archiveDate + ".zip";
                Directory.CreateDirectory(config.GetArchiveDirectory());

                //other relevant folder paths
                string tempFolder = config.GetEmptyDirectory();
                Directory.CreateDirectory(tempFolder);
                string allLogsPath = config.GetLogDirectory();
                Directory.CreateDirectory(allLogsPath);
                string backupPath = config.GetBackupsDirectory();
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

        public bool ReverseArchive(string date)
        {
            string archiveDate = date;
            var archivePath = config.GetArchiveDirectory() + "\\Archive_" + archiveDate + ".zip";
            string target = config.GetLogDirectory();
            try
            {
                ZipFile.ExtractToDirectory(archivePath, target);
                DeleteArchivedLogs(config.GetArchiveDirectory());
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("There is no Archive with date: " + archiveDate);
                return false;
            }
        }
    }
}
