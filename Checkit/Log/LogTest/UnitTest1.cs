using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Log;
namespace LogTest
{
    [TestClass]
    public class UnitTest1
    {
        bool actual;

        [TestMethod]
        public void CreateErrorLogPass()
        {
            //Arrange
            LogManager elogger = new LogManager("ErrorLogTest.json");
            string id = "54645";
            
            //Act

            try
            {
                divide(4, 0);
            }
            catch (Exception ex) {

                actual = elogger.LogError(id,ex);
            }

            bool expected = true;

            //Assert

            Assert.AreEqual(actual, expected);
        }

        public static int divide(int a, int b)
        {
            return a / b;
        }
    }
}
