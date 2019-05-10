using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Log;
namespace LogTest
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        public void CreateTelemetryLogPass()
        {
            //Arrange
            Config config = new Config();
            LogManager tlogger = new LogManager();
            string uid = "0001";

            var info1 = new Telemetry
            {
                userID = uid,
                dateTime = DateTime.UtcNow.ToString(config.GetDateTimeFormat()),
                description = "user has logged in"

            };

            //Act
            bool actual = tlogger.LogTelemetry(info1);
            bool expected = true;

            //Assert

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CreateErrorLogPass()
        {
            //Arrange
            Config config = new Config();
            LogManager elogger = new LogManager();
            string uid = "0001";
            int a = 1;
            int b = 0;
            int quotient;
            bool actual = false;

            try
            {
                quotient = a / b;
            }
            catch (Exception e) {

                actual= elogger.LogError(uid, e);
            }

            //Act
            bool expected = true;

            //Assert

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CheckCountMoreThan100()
        {
            //Act
            LogManager mgr = new LogManager();
            int count = 101;

            //Act
            bool expected = false;
            bool actual = mgr.CheckCount(count);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckCountLessThan100()
        {
            //Act
            LogManager mgr = new LogManager();
            int count = 99;

            //Act
            bool expected = true;
            bool actual = mgr.CheckCount(count);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
