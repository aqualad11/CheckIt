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
                string sourcePath = config.LOG_DIRECTORY;
                Directory.CreateDirectory(sourcePath);
                string targetPath = config.LOG_BACKUP_DIRECTORY;
                Directory.CreateDirectory(targetPath);
                archivingService.CopyLogs(sourcePath, targetPath, 1);
                if (archivingService.IsDirectoryEmpty(targetPath))
                {
                    Console.WriteLine("No Logs were backed up.");
                    return false;
                }

                return true;
            }catch(IOException e)
            {
                Console.WriteLine("Path or file does not exist.");
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
                var archivePath = config.LOG_ARCHIVE_DIRECTORY + "\\Archive_" + archiveDate + ".zip";
                if (File.Exists(archivePath))
                {
                    Console.WriteLine("Archive already exists");
                    return false;
                }
                Directory.CreateDirectory(config.LOG_ARCHIVE_DIRECTORY);

                //other relevant folder paths
                string tempFolder = config.EMPTY_DIRECTORY;
                Directory.CreateDirectory(tempFolder);
                string allLogsPath = config.LOG_DIRECTORY;
                Directory.CreateDirectory(allLogsPath);
                string backupPath = config.LOG_BACKUP_DIRECTORY;
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

        /// <summary>
        /// Utility method to reverse a log archive for a specific date.
        /// Extracts the logs in the archive back to the logs folder
        /// </summary>
        /// <param name="date">Date of the archive to extract</param>
        /// <returns></returns>
        public bool ReverseArchive(string date)
        {
            string archiveDate = date;
            var archivePath = config.LOG_ARCHIVE_DIRECTORY + "\\Archive_" + archiveDate + ".zip";
            string target = config.LOG_DIRECTORY;
            try
            {
                ZipFile.ExtractToDirectory(archivePath, target);
                File.Delete(archivePath);
                return true;
            }catch(FileNotFoundException e)
            {
                Console.WriteLine("There is no Archive with date: " + archiveDate);
                return false;
            }
        }
    }
}
