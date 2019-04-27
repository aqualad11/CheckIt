using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using CheckIt.ManagerLayer;
using CheckIt.ServiceLayer;
using System.Threading.Tasks;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class UserManagerTest
    {
        [TestMethod]
        public async Task CreateDefaultUserAllValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager userManager = new UserManager(db);

            string email = "newEmail@spyderz.com";
            

            //Act
            userManager.CreateDefaultUser(email);

            //Act
            IUserRepository userRepo = new UserRepository(db);
            User user = userRepo.GetUserbyEmail(email);
            Assert.IsNotNull(user);
        }
    }
}
