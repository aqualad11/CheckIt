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
        public void getUserActionsByUserIDNotNull()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid id = new Guid("7AF91B37-DC4A-E911-8259-0A64F53465D0");


            //Act
            List<string> ua = uaRepo.getActionsByUserID(id);

            //Assert 
            Assert.AreEqual(ua.Count, 2);
        }

        /// <summary>
        /// tests getUserActionsByUserID, passing in an empty guid
        /// </summary>
        [TestMethod]
        public void getUserActionsByUserIDNull()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            using (DataBaseContext _db = new DataBaseContext())
            {

            }
                IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid id = new Guid();


            //Act
            List<string> ua = uaRepo.getActionsByUserID(id);

            //Assert 
            Assert.AreEqual(ua.Count, 0);
        }

        /// <summary>
        /// Tests getUsersByAction by passing in a valid action
        /// </summary>
        [TestMethod]
        public void getUsersByActionNotNull()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            string action = "Login";

            //Act
            List<User> ul = uaRepo.getUsersByAction(action);

            //Assert
            Assert.AreEqual(ul.Count, 1);

        }

        /// <summary>
        /// Tests getUsersByAction by passing in an empty action
        /// same result as passing an invalid action or null
        /// </summary>
        [TestMethod]
        public void getUsersByActionNull()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            string action = "";

            //Act
            List<User> ul = uaRepo.getUsersByAction(action);

            //Assert
            Assert.AreEqual(ul.Count, 0);
        }

        /// <summary>
        /// tests addUserAction with valid userID
        /// </summary>
        [TestMethod]
        public void addUserActionValidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid("7BF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "View_Watchlist";
            UserAction ua = new UserAction(userID, action);

            //Act
            uaRepo.addUserAction(ua);
            UserAction newUA = uaRepo.getUserAction(userID, action);

            //Assert
            Assert.IsNotNull(newUA);
        }

        /// <summary>
        /// tests addUserAction with invalid userID
        /// </summary>
        [TestMethod]
        public void addUserActionInvalidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid();
            string action = "View_Watchlist";
            UserAction ua = new UserAction(userID, action);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => uaRepo.addUserAction(ua));
        }


         /// <summary>
        /// Tests getUserAction using valid userID and action
        /// </summary>
        [TestMethod]
        public void getUserActionValidUA()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid("7AF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "Login";

            //Act
            UserAction ua = uaRepo.getUserAction(userID, action);

            //Assert
            Assert.IsNotNull(ua);
        }

        /// <summary>
        /// Tests getUserAction using invalid userID, which has the same result as
        /// using a new Guid
        /// </summary>
        [TestMethod]
        public void getUserActionInvalidUA()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid("7CF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "Search";

            //Act
            UserAction ua = uaRepo.getUserAction(userID, action);

            //Assert
            Assert.IsNull(ua);
        }

        /// <summary>
        /// Tests removeUserAction(UserAction) using valid user
        /// </summary>
        [TestMethod]
        public void removeUserActionValidUA()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid("7BF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "View_Watchlist";
            UserAction ua = uaRepo.getUserAction(userID, action);

            //Act
            uaRepo.removeUserAction(ua);
            UserAction newUA = uaRepo.getUserAction(userID, action);

            //Assert
            Assert.IsNull(newUA);
        }
        
        /// <summary>
        /// Tests removeUserAction(UserAction) using invalid user
        /// </summary>
        [TestMethod]
        public void removeUserActionInvalidUA()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid();
            string action = "View_Watchlist";
            UserAction ua = new UserAction(userID, action);

            //Act => Assert
            Assert.ThrowsException<DbUpdateConcurrencyException>(() => uaRepo.removeUserAction(ua));
            
        }

        /// <summary>
        /// Tests removeUserAction(userID, action) using valid user
        /// </summary>
        [TestMethod]
        public void removeUserActionValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid("7BF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "View_Watchlist";

            //Act
            uaRepo.removeUserAction(userID, action);
            UserAction removedUA = uaRepo.getUserAction(userID, action);

            //Assert
            Assert.IsNull(removedUA);
        }

        /// <summary>
        /// Tests removeUserAction(userID, action) using invalid user
        /// </summary>
        [TestMethod]
        public void removeUserActionInvalid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IUserActionRepository uaRepo = new UserActionRepository(db);
            Guid userID = new Guid();
            string action = "View_Watchlist";

            //Act => Assert
            Assert.ThrowsException<ArgumentNullException>(() => uaRepo.removeUserAction(userID, action));
        }
    }
}
