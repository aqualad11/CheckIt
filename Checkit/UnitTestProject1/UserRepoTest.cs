using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIt.DataAccessLayer.Repositories;
using CheckIt.DataAccessLayer;
using System.Data.Entity.Infrastructure;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class UserRepoTest
    {
        /// <summary>
        /// tests getUserByEmail
        /// expected to return user
        /// </summary>
        [TestMethod]
        public void UserRepository_GetUserByEmail_Successful()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            User user;

            //Act
            user = userRepo.GetUserbyEmail("example2@gmail.com");

            //Assert
            Assert.IsNotNull(user);
            
        }

        /// <summary>
        /// tests getUserByEmail
        /// expected to return null
        /// </summary>
        [TestMethod]
        public void UserRepository_GetUserByEmail_Invalid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            User user;

            //Act
            user = userRepo.GetUserbyEmail("nonexistent@gmail.com");

            //Assert
            Assert.IsNull(user);
        }

        /// <summary>
        /// test GetUserbyID
        /// expected to return user
        /// </summary>
        [TestMethod]
        public void UserRepository_GetUserbyID_ValidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            Guid id = new Guid("44361F37-036B-E911-AA03-021598E9EC9E");
            User user;

            //Act
            user = userRepo.GetUserbyID(id);

            //Assert
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// test GetUserbyID
        /// expected to return null
        /// </summary>
        [TestMethod]
        public void UserRepository_GetUserbyID_InvalidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            Guid id = new Guid();
            User user;

            //Act
            user = userRepo.GetUserbyID(id);

            //Assert
            Assert.IsNull(user);
        }


        /// <summary>
        /// Tests GetUserBySSOID using a valid ssoID
        /// </summary>
        [TestMethod]
        public void UserRepository_GetUserbySSOID_ValidSSOID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            Guid ssoID = new Guid("C822DE9E-95DD-49B3-BFD9-0A14EF76ADBC");
            User user;

            //Act
            user = userRepo.GetUserbySSOID(ssoID);

            //Assert
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Tests GetUserBySSOID using an invalid ssoID
        /// </summary>
        [TestMethod]
        public void UserRepository_GetUserbySSOID_InvalidSSOID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            Guid ssoID = new Guid();

            //Act
            User user = userRepo.GetUserbySSOID(ssoID);

            //Assert
            Assert.IsNull(user);
        }


        /// <summary>
        /// test GetUserIDbyEmail using existing email
        /// </summary>
        [TestMethod]
        public void UserRepository_GetUserIDbyEmail_ValidEmail()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            string email = "example2@gmail.com";
            Guid userID = new Guid("45361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            Guid id = userRepo.GetUserIDbyEmail(email);

            //Assert
            Assert.AreEqual(userID, id);

        }

        /// <summary>
        /// test GetUserIDbyEmail using empty string
        /// same result as if null was passed in
        /// </summary>
        [TestMethod]
        public void UserRepository_GetUserIDbyEmail_InvalidEmail()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            string email = "";
            Guid userID = new Guid();

            //Act
            Guid id = userRepo.GetUserIDbyEmail(email);

            //Assert
            Assert.AreEqual(id,userID);
        }

        [TestMethod]
        public void UserRepository_GetCountOfAllUsers_Successful()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            int expected = 23;

            //Act
            int actual = userRepo.GetCountOfAllUsers();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserRepository_GetCount_Successful()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            int expected = 24;
            int month = 5;
            int year = 2019;

            //Act
            int actual = userRepo.GetCount(month, year);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// adds user then calls it by email to confirm it was added
        /// </summary>
        [TestMethod]
        public void UserRepository_AddUser_Successful()
        {
            //Arrange
            User user = new User()
            {
                userEmail = "testUser@gmail.com"
            };

            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);

            //Act
            userRepo.AddUser(user);
            User user2 = userRepo.GetUserbyEmail("testUser@gmail.com");

            //Assert
            Assert.IsNotNull(user2);
        }

        /// <summary>
        /// test UpdateUser
        /// must call AddUser() test first
        /// </summary>
        [TestMethod]
        public void UserRepository_UpdateUser_ValidUser()
        {
            //Arrange 
            string newEmail = "newTestEmail@gmail.com";
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);

            User user = userRepo.GetUserbyEmail("testUser@gmail.com");
            user.userEmail = newEmail;

            //Act
            userRepo.UpdateUser(user);
            User updatedUser = userRepo.GetUserbyEmail("newTestEmail@gmail.com");

            //Assert
            Assert.AreEqual(newEmail, updatedUser.userEmail);
        }

        //TODO:
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserRepository_UpdateUser_InvalidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            User user = new User("NonExisitngUser@gmail.com", "user");

            //Act => Assert
            Assert.ThrowsException<System.Data.Entity.Infrastructure.DbUpdateConcurrencyException>(() => userRepo.UpdateUser(user));

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserRepository_UpdateUser_NullUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);

            //Act => Assert
            Assert.ThrowsException<System.ArgumentNullException>(() => userRepo.UpdateUser(null));
        }

        /// <summary>
        /// test RemoveUser
        /// expected null
        /// AddUser test must be run first
        /// </summary>
        [TestMethod]
        public void UserRepository_RemoveUser_ValidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);

            User user = userRepo.GetUserbyEmail("newTestEmail@gmail.com");

            //Act
            userRepo.RemoveUser(user);
            //User expected = userRepo.GetUserbyEmail("newTestEmail@gmail.com");
            User expected = userRepo.GetUserbyEmail("newTestEmail@gmail.com");

            //Assert
            Assert.IsNull(expected);
        }

        /// <summary>
        /// Test RemoveUser using a nonexisting user
        /// </summary>
        [TestMethod]
        public void UserRepository_RemoveUser_InvalidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);

            User user = new User()
            {
                userEmail = "newUser@email.com"
            };

            //Act => Assert
            Assert.ThrowsException<InvalidOperationException>(() => userRepo.RemoveUser(user));
        }
    }
}
