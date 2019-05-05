using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIt.ManagerLayer;
using CheckIt.ServiceLayer;
using System.IO;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class ArchivingTest
    {
        ArchivingManager archivingManager = new ArchivingManager();
        ArchivingService archivingService = new ArchivingService();
        Config config = new Config();

        [TestMethod]
        public void ArchivesSuccessfully()
        {
            //Arrange
            bool expected = true;
            //Act
            bool actual = archivingManager.ArchiveLogs();
            //return to normal after actual is set
            archivingManager.ReverseArchive(archivingService.GetCurrentDate());
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ArchiveFails()
        {
            //Arrange so that the desired archive exists already
            bool expected = false;
            string date = archivingService.GetCurrentDate();
            //Creates a zip file
            archivingManager.ArchiveLogs();

            //Act
            bool actual = archivingManager.ArchiveLogs();
            //return to normal after actual is set
            archivingManager.ReverseArchive(archivingService.GetCurrentDate());
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCopy()
        {
            //Arrange so that the empty folder is empty
            int expected = 6;
            archivingManager.DeleteArchivedLogs(config.EMPTY_DIRECTORY);

            //Act
            archivingService.CopyLogs(config.LOG_DIRECTORY, config.EMPTY_DIRECTORY,0);
            int actual = System.IO.Directory.GetFiles(config.EMPTY_DIRECTORY).Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMove()
        {
            //Arrange so that the empty folder is empty
            int expected = 0;
            archivingManager.DeleteArchivedLogs(config.EMPTY_DIRECTORY);

            //Act
            archivingService.MoveLogs(config.LOG_DIRECTORY, config.EMPTY_DIRECTORY, 0);
            int actual = System.IO.Directory.GetFiles(config.LOG_DIRECTORY).Length;
            //move back logs after actual is set
            archivingService.MoveLogs(config.EMPTY_DIRECTORY, config.LOG_DIRECTORY, 0);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange so that the empty folder is empty
            int expected = 0;
            archivingManager.DeleteArchivedLogs(config.EMPTY_DIRECTORY);

            //Act
            archivingService.CopyLogs(config.LOG_DIRECTORY, config.EMPTY_DIRECTORY, 0);
            archivingManager.DeleteArchivedLogs(config.EMPTY_DIRECTORY);
            int actual = System.IO.Directory.GetFiles(config.EMPTY_DIRECTORY).Length;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestBackup()
        {
            //Arrange so that the empty folder is empty
            int expected = 4;
            archivingManager.DeleteArchivedLogs(config.LOG_BACKUP_DIRECTORY);

            //Act
            archivingManager.BackupLogs();
            int actual = System.IO.Directory.GetFiles(config.LOG_BACKUP_DIRECTORY).Length;
            //clear backup logs after actual is set
            //archivingManager.DeleteArchivedLogs(config.LOG_BACKUP_DIRECTORY);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
