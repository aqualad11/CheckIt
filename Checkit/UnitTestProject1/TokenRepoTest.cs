using System;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class TokenRepoTest
    {
        /// <summary>
        /// Tests to get valid Token from Database
        /// </summary>
        [TestMethod]
        public void GetTokenValidToken()
        {
            //Arrange 
            string jwt = "SampleJWT1";
            Guid userID = new Guid("d48e08a1-f75e-e911-a305-00d86115b2e0");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());

            //Act
            Token token = tokenRepo.GetToken(jwt, userID);

            //Assert
            Assert.AreEqual(token.jwt, jwt);
        }

        /// <summary>
        /// Tests to get an invalid Token from Database
        /// </summary>
        [TestMethod]
        public void GetTokenVInvlidToken()
        {
            //Arrange 
            string jwt = "NonExistantJWT";
            Guid userID = new Guid();
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());

            //Act
            Token token = tokenRepo.GetToken(jwt, userID);

            //Assert
            Assert.IsNull(token);
        }

        [TestMethod]
        public void AddValidToken()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid("d98e08a1-f75e-e911-a305-00d86115b2e0");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = new Token(jwt, userID);

            //Act 
            bool add = tokenRepo.AddToken(token);

            //Assert
            Assert.IsTrue(add);
        }

        [TestMethod]
        public void AddDuplicateToken()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid("d98e08a1-f75e-e911-a305-00d86115b2e0");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = new Token(jwt, userID);

            //Act 
            bool add = tokenRepo.AddToken(token);

            //Assert
            Assert.IsFalse(add);
        }

        [TestMethod]
        public void AddTokenInvalidUser()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid();
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = new Token(jwt, userID);

            //Act 
            bool add = tokenRepo.AddToken(token);

            //Assert
            Assert.IsFalse(add);
        }

        [TestMethod]
        public void UpdateTokenValid()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid("d98e08a1-f75e-e911-a305-00d86115b2e0");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = tokenRepo.GetToken(jwt, userID);

            //Act
            token.valid = false;
            bool update = tokenRepo.UpdateToken(token);

            //Assert
            Assert.IsTrue(update);
        }

        [TestMethod]
        public void UpdateTokenInvalid()
        {
            //Arrange
            string jwt = "nonExistantToken";
            Guid userID = new Guid("d98e08a1-f75e-e911-a305-00d86115b2e0");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = new Token(jwt, userID);

            //Act
            token.valid = false;
            bool update = tokenRepo.UpdateToken(token);

            //Assert
            Assert.IsFalse(update);
        }

        [TestMethod]
        public void RemoveTokenValid()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid("d98e08a1-f75e-e911-a305-00d86115b2e0");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = tokenRepo.GetToken(jwt, userID);

            //Act
            bool remove = tokenRepo.RemoveToken(token);

            //Assert
            Assert.IsTrue(remove);
        }

        [TestMethod]
        public void RemoveTokenInvalid()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid();
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = tokenRepo.GetToken(jwt, userID);

            //Act
            bool remove = tokenRepo.RemoveToken(token);

            //Assert
            Assert.IsFalse(remove);
        }

    }
}
