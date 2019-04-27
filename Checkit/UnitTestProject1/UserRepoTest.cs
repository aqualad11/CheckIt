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
        public void getUserByEmailNotNull()
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
        public void getUserByEmailNull()
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
        public void getUserbyIDNotNull()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            Guid id = new Guid("79F91B37-DC4A-E911-8259-0A64F53465D0");
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
        public void getUserbyIDNull()
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
        /// test GetUserIDbyEmail using existing email
        /// 
        /// </summary>
        [TestMethod]
        public void getUserIDNotNull()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            string email = "example2@gmail.com";
            Guid userID = new Guid("7AF91B37-DC4A-E911-8259-0A64F53465D0");
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
        public void getUserIDNull()
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

        /// <summary>
        /// adds user then calls it by email to confirm it was added
        /// 
        /// </summary>
        [TestMethod]
        public void addUser()
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
        public void updateExistingUser()
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


        /// <summary>
        /// test RemoveUser
        /// expected null
        /// AddUser test must be run first
        /// </summary>
        [TestMethod]
        public void removeExistingUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);

            User user = userRepo.GetUserbyEmail("newTestEmail@gmail.com");

            //Act
            userRepo.RemoveUser(user);
            User expected = userRepo.GetUserbyEmail("newTestEmail@gmail.com");

            //Assert
            Assert.IsNull(expected);
        }


        [TestMethod]
        public void removeNonExistingUser()
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
