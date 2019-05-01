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
        public void GetUserByEmailValid()
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
        public void GetUserByEmailInvalid()
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
        public void GetUserbyIDValid()
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
        /// Tests GetUserBySSOID using a valid ssoID
        /// </summary>
        [TestMethod]
        public void GetUserbySSOIDValid()
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
        public void GetUserbySSOIDInvalid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            Guid ssoID = new Guid();

            //Act
            User user = userRepo.GetUserbyID(ssoID);

            //Assert
            Assert.IsNull(user);
        }

        /// <summary>
        /// test GetUserbyID
        /// expected to return null
        /// </summary>
        [TestMethod]
        public void GetUserbyIDInvalid()
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
        /// </summary>
        [TestMethod]
        public void GetUserIDValid()
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
        public void GetUserIDInvalid()
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
        public void AddUser()
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
        public void UpdateExistingUser()
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
        [TestMethod]
        public void UpdateNonExistingUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserRepository userRepo = new UserRepository(db);
            User user = new User("NonExisitngUser@gmail.com", "user");

            //Act => Assert
            Assert.ThrowsException<System.Data.Entity.Infrastructure.DbUpdateConcurrencyException>(() => userRepo.UpdateUser(user));

        }

        [TestMethod]
        public void UpdateUserNull()
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
        public void RemoveExistingUser()
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
        public void RemoveNonExistingUser()
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
