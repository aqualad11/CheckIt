using System;
using System.Data.Entity.Infrastructure;
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
            Guid userID = new Guid("44361F37-036B-E911-AA03-021598E9EC9E");
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
        public void GetTokenInvalidToken()
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

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void AddValidToken()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid("F98A70A1-056B-E911-AA03-021598E9EC9E");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = new Token(jwt, userID);

            //Act 
            tokenRepo.AddToken(token);
            Token addedToken = tokenRepo.GetToken(jwt, userID);

            //Assert
            Assert.IsNotNull(addedToken);
        }

        /// <summary>
        /// Tests AddToken using a duplicate token.
        /// Must be run after AddValidToken()
        /// </summary>
        [TestMethod]
        public void AddDuplicateToken()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid("F98A70A1-056B-E911-AA03-021598E9EC9E");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = new Token(jwt, userID);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => tokenRepo.AddToken(token));
        }

        /// <summary>
        /// Tests AddToken using an invalid Token.
        /// </summary>
        [TestMethod]
        public void AddTokenInvalidUser()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid();
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = new Token(jwt, userID);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => tokenRepo.AddToken(token));
        }

        /// <summary>
        /// Tests UpdateToken using a valid Token.
        /// Must be called after AddTokenValid
        /// </summary>
        [TestMethod]
        public void UpdateTokenValid()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid("F98A70A1-056B-E911-AA03-021598E9EC9E");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = tokenRepo.GetToken(jwt, userID);

            //Act
            token.valid = false;
            tokenRepo.UpdateToken(token);
            Token newToken = tokenRepo.GetToken(jwt, userID);

            //Assert
            Assert.IsFalse(newToken.valid);
            
        }

        /// <summary>
        /// Tests UpdateToken using an invalid Token
        /// </summary>
        [TestMethod]
        public void UpdateTokenInvalid()
        {
            //Arrange
            string jwt = "nonExistantToken";
            Guid userID = new Guid("F98A70A1-056B-E911-AA03-021598E9EC9E");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = new Token(jwt, userID);

            //Act => Assert
            Assert.ThrowsException<DbUpdateConcurrencyException>(() => tokenRepo.UpdateToken(token));
        }

        /// <summary>
        /// Tests RemoveToken using a valid Token.
        /// Must be called after UpdateTokenValid.
        /// </summary>
        [TestMethod]
        public void RemoveTokenValid()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid("F98A70A1-056B-E911-AA03-021598E9EC9E");
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = tokenRepo.GetToken(jwt, userID);

            //Act
            tokenRepo.RemoveToken(token);
            Token newToken = tokenRepo.GetToken(jwt, userID);

            //Assert
            Assert.IsNull(newToken);
        }

        /// <summary>
        /// Tests RemoveToken using an invalid Token.
        /// </summary>
        [TestMethod]
        public void RemoveTokenInvalid()
        {
            //Arrange
            string jwt = "testJWT";
            Guid userID = new Guid();
            ITokenRepository tokenRepo = new TokenRepository(new DataBaseContext());
            Token token = new Token(jwt, userID);

            //Act => Assert
            Assert.ThrowsException<InvalidOperationException>(() => tokenRepo.RemoveToken(token));
        }

    }
}
