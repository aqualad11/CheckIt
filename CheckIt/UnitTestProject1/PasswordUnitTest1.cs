using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIt.ServiceLayer;
using System;

namespace PasswordUnitTest
{
    [TestClass]
    public class PasswordUnitTest1
    {
        [TestMethod]
        public async Task TestPasswordPass()
        {
            //Arange
            string password; // Create a password to be passed into the method. 
            int expected; // We assume that the incorrect password passed in will return 1 - 1 indicates that the password is insecure
            int actual; // The var that will call the method to see if what was actually was true is the same as expected.
            password = "Hello123;"; //Assign password a value that is known the fail. 
            expected = 0;
            //Act
            actual = await PasswordService.ValidatePassword(password);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public async Task TestPasswordFail()
        {
            //Arrange
            string password;
            int expected;
            int actual;
            expected = 1;
            password = "password"; //This password is a uncompromised password.
            //Act
            actual = await PasswordService.ValidatePassword(password);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public async Task TestPasswordNoParam()
        {
            //Arrange
            string password;
            int expected;
            int actual;
            password = ""; //Sending in a password that is not long enough for the specified hash of PCheck
            expected = 3;
            //Act
            actual = await PasswordService.ValidatePassword(password);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests both CreateSalt and GetPasswordHash by first creating a salt, converting it
        /// to a string as that is how it will be stored, then converting it back to a byteArray,
        /// create a passwordHash using both the orignal salt and the converted salt
        /// </summary>
        [TestMethod]
        public void saltAndPasswordHashTest()
        {
            //Arrange
            string password = "HelloWorld";
            byte[] salt = PasswordService.CreateSalt();
            string salty = Convert.ToBase64String(salt);
            byte[] salt2 = Convert.FromBase64String(salty);

            //Act
            string passwordHash1 = PasswordService.GetPasswordHash(password, salt);
            string passwordHash2 = PasswordService.GetPasswordHash(password, salt2);

            //Assert
            Assert.AreEqual(passwordHash1, passwordHash2);
        }
    }
}
