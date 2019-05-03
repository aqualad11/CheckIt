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

        [TestMethod]
        public void ArchivesSuccessfully()
        {
            //Arrange
            bool expected = true;
            //Act
            bool actual = archivingManager.ArchiveLogs();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ArchiveFails()
        {
            //Arrange so that the desired archive exists already
            bool expected = false;

        }
    }
}
