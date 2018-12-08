using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIt.Authorizations;
using CheckIt.DataAccessLayer;

namespace AuthorizationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAuthorizeActionPass()
        {
            //Arrange
            string email = "example@gmail.com";
            List<string> actions = new List<string>()
            {
                "login",
                "adduser",
                "search"
            };
            int height = 2;
            string action = "adduser";

            IToken token = new Token(email, actions, height);
            //Act
            bool expected = true;
            bool actual = Authorization.AuthorizeAction(token, action);
            //Assert
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void TestUUPermissionSameHeight()
        {
            //Arrange
            string email = "example1000@gmail.com";
            List<string> actions = new List<string>()
            {
                "Login",
                "Update",
                "Search"
            };
            int height = 2;
            string action = "adduser";
            IToken token = new Token(email, actions, height);
            string user2email = "example@gmail.com";
            //Act
            bool expected = false;
            bool actual = Authorization.UserToUserPermission(token, user2email);
            //Assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void TestUUPermissionDiffHeightPass()
        {
            //Arrange
            string email = "example1000@gmail.com";
            List<string> actions = new List<string>()
            {
                "Login",
                "Update",
                "Search"
            };
            int height = 1;
            
            IToken token = new Token(email, actions, height);
            string user2email = "example@gmail.com";
            //Act
            bool expected = true;
            bool actual = Authorization.UserToUserPermission(token, user2email);
            //Assert
            Assert.AreEqual(expected, actual);


        }


        [TestMethod]
        public void TestUUPermissionDiffHeightFail()
        {
            //Arrange
            string email = "example1000@gmail.com";
            List<string> actions = new List<string>()
            {
                "Login",
                "Update",
                "Search"
            };
            int height = 2;
            string action = "adduser";
            IToken token = new Token(email, actions, height);
            string user2email = "example1@gmail.com";
            //Act
            bool expected = true;
            bool actual = Authorization.UserToUserPermission(token, user2email);
            //Assert
            Assert.AreNotEqual(expected, actual);


        }
    }
}
