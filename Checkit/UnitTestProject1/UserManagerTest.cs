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
        /// <summary>
        /// Tests UserManager.CreateDefaultUser with a valid user
        /// </summary>
        [TestMethod]
        public void CreateDefaultUserValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager um = new UserManager(db);

            string email = "newEmail@spyderz.com";
            

            //Act
            um.CreateDefaultUser(email);
            
            //Assert
            Assert.IsTrue(um.UserExists(email));
        }

        /// <summary>
        /// Tests UserManager.CreateDefaultUser with am invalid user
        /// </summary>
        [TestMethod]
        public void CreateDefaultUserInValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager um = new UserManager(db);

            string email = "example1@gmail.com";

            //Act => Assert
            Assert.ThrowsException<UserExistsException>(() => um.CreateDefaultUser(email));
        }

        /// <summary>
        /// Tests UserManager.CreateUser with all valid parameters
        /// </summary>
        [TestMethod]
        public void CreatUserValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager um = new UserManager(db);

            string email = "newerEmail@spyderz.com";
            string atype = "user";
            Guid clientID = new Guid("d08e08a1-f75e-e911-a305-00d86115b2e0");
            Guid parentID = new Guid("d48e08a1-f75e-e911-a305-00d86115b2e0");

            //Act
            um.CreateUser(email, atype, clientID, parentID);

            //Assert
            Assert.IsTrue(um.UserExists(email));

        }

        /// <summary>
        /// Tests UserManager.CreateUser with an invalid user
        /// </summary>
        [TestMethod]
        public void CreateUserInvalidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager um = new UserManager(db);
            string email = "newerEmail@spyderz.com";
            string atype = "user";
            Guid clientID = new Guid("d08e08a1-f75e-e911-a305-00d86115b2e0");
            Guid parentID = new Guid("d48e08a1-f75e-e911-a305-00d86115b2e0");


            //Act => Assert
            Assert.ThrowsException<UserExistsException>(() => um.CreateUser(email, atype, clientID, parentID));

        }

        /// <summary>
        /// Tests UserManager.CreateUser with an invalid client
        /// </summary>
        [TestMethod]
        public void CreateUserInvalidClientID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager um = new UserManager(db);
            string email = "wrongClient@spyderz.com";
            string atype = "user";
            Guid clientID = new Guid();
            Guid parentID = new Guid("d48e08a1-f75e-e911-a305-00d86115b2e0");

            //Act => Assert
            Assert.ThrowsException<ClientDoesNotExistException>(() => um.CreateUser(email, atype, clientID, parentID));
        }

        /// <summary>
        /// Tests UserManager.CreateUser with an invalid parent
        /// </summary>
        [TestMethod]
        public void CreateUserInvalidParentID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager um = new UserManager(db);
            string email = "wrongParent@spyderz.com";
            string atype = "user";
            Guid clientID = new Guid("d08e08a1-f75e-e911-a305-00d86115b2e0");
            Guid parentID = new Guid();


            //Act => Assert
            Assert.ThrowsException<UserDoesNotExistException>(() => um.CreateUser(email, atype, clientID, parentID));
        }

        /// <summary>
        /// Tests UserManager.CreateSSOUser with a valid user
        /// </summary>
        [TestMethod]
        public void CreateSSOUserValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager um = new UserManager(db);
            Guid ssoID = Guid.NewGuid();
            string email = "ssoUser@gmail.com";

            //Act
            User user = um.CreateSSOUser(ssoID, email);

            //Assert
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Tests UserManager.CreateSSOUser with an existing user without an ssoID
        /// </summary>
        [TestMethod]
        public void CreateSSOUserExistingEmailNoSSOID()
        {
            //Arrange 
            DataBaseContext db = new DataBaseContext();
            UserManager um = new UserManager(db);
            Guid ssoID = Guid.NewGuid();
            string email = "SSOUserWOutSSOID@email.com";
            um.CreateDefaultUser(email);



            //Act
            User user = um.CreateSSOUser(ssoID, email);

            //Assert
            Assert.AreEqual(ssoID, user.ssoID);
        }

        //run this test after running UserManager.CreateSSOUser will create a duplicate user with the same email
        /// <summary>
        /// Tests UserManager.CreateSSOUser with an existing user with an ssoID
        /// </summary>
        [TestMethod]
        public void CreateSSOExistingSSOUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            UserManager um = new UserManager(db);
            Guid ssoID = Guid.NewGuid();
            string email = "SSOUserWOutSSOID@email.com";
            

            //Act
            User user = um.CreateSSOUser(ssoID, email);

            //Assert
            Assert.AreEqual(ssoID, user.ssoID);

        }
    }

}
