using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class UserActionRepoTest
    {

        /// <summary>
        /// tests getUserActionsByUserID by passing a valid userID
        /// </summary>
        [TestMethod]
        public void UserActionRepository_GetActionsByUserID_ValidUserID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid id = new Guid("44361F37-036B-E911-AA03-021598E9EC9E");


            //Act
            List<string> ua = uaRepo.GetActionsByUserID(id);

            //Assert 
            Assert.AreEqual(ua.Count, 2);
        }

        /// <summary>
        /// tests getUserActionsByUserID, passing in an empty guid
        /// </summary>
        [TestMethod]
        public void UserActionRepository_GetActionsByUserID_NullID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            using (DataBaseContext _db = new DataBaseContext())
            {

            }
                IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid id = new Guid();


            //Act
            List<string> ua = uaRepo.GetActionsByUserID(id);

            //Assert 
            Assert.AreEqual(ua.Count, 0);
        }

        /// <summary>
        /// Tests GetUsersByAction by passing in a valid action
        /// </summary>
        [TestMethod]
        public void UserActionRepository_GetUsersByAction_ValidAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            string action = "Search";

            //Act
            List<User> ul = uaRepo.GetUsersByAction(action);

            //Assert
            Assert.AreEqual(2, ul.Count);

        }

        /// <summary>
        /// Tests GetUsersByAction by passing in an empty action
        /// same result as passing an invalid action or null
        /// </summary>
        [TestMethod]
        public void UserActionRepository_GetUsersByAction_NullAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            string action = "";

            //Act
            List<User> ul = uaRepo.GetUsersByAction(action);

            //Assert
            Assert.AreEqual(ul.Count, 0);
        }
        
        /// <summary>
        /// Tests GetUserAction using valid userID and action
        /// </summary>
        [TestMethod]
        public void UserActionRepository_GetUserAction_ValidUA()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid("44361F37-036B-E911-AA03-021598E9EC9E");
            string action = "Login";

            //Act
            UserAction ua = uaRepo.GetUserAction(userID, action);

            //Assert
            Assert.IsNotNull(ua);
        }

        /// <summary>
        /// Tests GetUserAction using invalid userID, which has the same result as
        /// using a new Guid
        /// </summary>
        [TestMethod]
        public void UserActionRepository_GetUserAction_InvalidUA()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid("7CF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "Search";

            //Act
            UserAction ua = uaRepo.GetUserAction(userID, action);

            //Assert
            Assert.IsNull(ua);
        }

        /// <summary>
        /// tests AddUserAction with valid userID
        /// </summary>
        [TestMethod]
        public void UserActionRepository_AddUserAction_ValidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid("F98A70A1-056B-E911-AA03-021598E9EC9E");
            string action = "View_Watchlist";
            UserAction ua = new UserAction(userID, action);

            //Act
            uaRepo.AddUserAction(ua);
            UserAction newUA = uaRepo.GetUserAction(userID, action);

            //Assert
            Assert.IsNotNull(newUA);
        }

        /// <summary>
        /// tests AddUserAction with invalid userID
        /// </summary>
        [TestMethod]
        public void UserActionRepository_AddUserAction_InvalidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid();
            string action = "View_Watchlist";
            UserAction ua = new UserAction(userID, action);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => uaRepo.AddUserAction(ua));
        }

        /// <summary>
        /// Tests RemoveUserAction(UserAction) using valid user
        /// </summary>
        [TestMethod]
        public void UserActionRepository_RemoveUserAction_ValidUA()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid("F98A70A1-056B-E911-AA03-021598E9EC9E");
            string action = "View_Watchlist";
            UserAction ua = new UserAction(userID, action);
                //uaRepo.GetUserAction(userID, action);

            //Act
            uaRepo.RemoveUserAction(ua);
            UserAction newUA = uaRepo.GetUserAction(userID, action);

            //Assert
            Assert.IsNull(newUA);
            
        }
        
        /// <summary>
        /// Tests RemoveUserAction(UserAction) using invalid user
        /// </summary>
        [TestMethod]
        public void UserActionRepository_RemoveUserAction_InvalidUA()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid();
            string action = "View_Watchlist";
            UserAction ua = new UserAction(userID, action);

            //Act => Assert
            Assert.ThrowsException<DbUpdateConcurrencyException>(() => uaRepo.RemoveUserAction(ua));
            
        }

        
    }
}
