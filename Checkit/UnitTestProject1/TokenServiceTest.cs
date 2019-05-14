using System;
using System.Collections.Generic;
using CheckIt.DataAccessLayer;
using CheckIt.ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class TokenServiceTest
    {
        [TestMethod]
        public void GetAllTokensValidUser()
        {
            //Arrange 
            DataBaseContext db = new DataBaseContext();
            TokenService tokenService = new TokenService(db);
            Guid userID = new Guid("44361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            List<Token> tokens = tokenService.GetAllTokens(userID);

            //Arrange
            Assert.AreEqual(4, tokens.Count);
        }

        [TestMethod]
        public void GetAllValidTokensValidUser()
        {
            //Arrange 
            DataBaseContext db = new DataBaseContext();
            TokenService tokenService = new TokenService(db);
            Guid userID = new Guid("44361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            List<Token> tokens = tokenService.GetAllValidTokens(userID);

            //Arrange
            Assert.AreEqual(3, tokens.Count);
        }

        [TestMethod]
        public void GetAllInvalidTokensValidUser()
        {
            //Arrange 
            DataBaseContext db = new DataBaseContext();
            TokenService tokenService = new TokenService(db);
            Guid userID = new Guid("44361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            List<Token> tokens = tokenService.GetAllInvalidTokens(userID);

            //Arrange
            Assert.AreEqual(1, tokens.Count);
        }

        [TestMethod]
        public void AddTokenValidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            TokenService tokenService = new TokenService(db);
            Guid userID = new Guid("44361F37-036B-E911-AA03-021598E9EC9E");
            string jwt = "TokenServiceTest3";

            //Act
            bool success = tokenService.AddToken(jwt, userID);

            //Assert
            Assert.IsTrue(success);
        }
    }
}
