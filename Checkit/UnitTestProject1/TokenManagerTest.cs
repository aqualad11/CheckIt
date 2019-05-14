using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using CheckIt.ManagerLayer;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class TokenManagerTest
    {
        [TestMethod]
        public void CreateTokenValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            TokenManager tm = new TokenManager(db);
            UserManager um = new UserManager(db);
            TokenRepository tokenRepo = new TokenRepository(db);
            User user = um.GetSSOUser(new Guid("AC9BCD38-CD7D-4475-8B71-70DF3C359463"));

            //Act
            string jwt = tm.CreateToken(user);
            Token token = tokenRepo.GetToken(jwt, user.userID);

            //Assert
            Assert.IsNotNull(token);
        }
    }
}
