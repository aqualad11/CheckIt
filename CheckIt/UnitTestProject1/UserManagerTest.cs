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
        public async Task CreateNormalUserAllValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager userManager = new UserManager(db);

            string email = "newEmail@spyderz.com";
            string fName = "Tony";
            string lName = "Stark";
            DateTime dob = new DateTime(1969, 7, 22);
            string accountType = "user";
            string city = "Los Angeles";
            string state = "California";
            string country = "USA";
            //clientID = null
            //parentID = null
            string password = "ExamplePassword";
            string question1 = "Question1";
            string question2 = "Question2";
            string question3 = "Question3";
            string answer1 = "Answer1";
            string answer2 = "Answer2";
            string answer3 = "Answer3";

            //Act
            await userManager.CreateNormalUser(email, fName, lName, dob, accountType, city, state, country, null, null, password,
                question1, answer1, question2, answer2, question3, answer3);

            //Act
            IUserRepository userRepo = new UserRepository(db);
            User user = userRepo.getUserbyEmail(email);
            Assert.IsNotNull(user);
        }
    }
}
