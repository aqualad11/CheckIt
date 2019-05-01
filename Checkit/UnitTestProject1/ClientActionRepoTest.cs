using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class ClientActionRepoTest 
    {
        /// <summary>
        /// Tests GetActionsByClientID using valid clientID
        /// </summary>
        [TestMethod]
        public void GetActionsByValidClientID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("42361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            List<string> actions = clientActionRepo.GetActionsByClientID(clientID);

            //Assert
            Assert.AreEqual(actions.Count, 3);

        }

        /// <summary>
        /// Tests GetActionsByClientID using invalid clientID
        /// </summary>
        [TestMethod]
        public void GetActionsByInvalidClientID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid();

            //Act
            List<string> actions = clientActionRepo.GetActionsByClientID(clientID);

            //Assert
            Assert.AreEqual(actions.Count, 0);

        }


        /// <summary>
        /// Tests GetClientAction(clientID, action) using a valid clientID and action
        /// </summary>
        [TestMethod]
        public void GetClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("40361F37-036B-E911-AA03-021598E9EC9E");
            string action = "Login";

            //Act
            ClientAction ca = clientActionRepo.GetClientAction(clientID, action);

            //Assert
            Assert.IsNotNull(ca);
        }

        /// <summary>
        /// Tests GetClientAction(clientID, action) using a valid clientID and invalid action
        /// </summary>
        [TestMethod]
        public void GetClientActionValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("6CF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "NotARealAction";

            //Act
            ClientAction ca = clientActionRepo.GetClientAction(clientID, action);

            //Assert
            Assert.IsNull(ca);
        }

        /// <summary>
        /// Tests GetClientsByAction using a valid Action
        /// </summary>
        /// <param name="action"></param>
        [TestMethod]
        public void GetClientsByValidAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            string action = "Update";

            //Act
            List<Client> clients = clientActionRepo.GetClientsByAction(action);

            //Assert
            Assert.AreEqual(clients.Count, 3);
        }

        /// <summary>
        /// Tests GetClientsByAction using a invalid Action
        /// </summary>
        [TestMethod]
        public void GetClientsByInvalidAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            string action = "NotAnAction";

            //Act
            List<Client> clients = clientActionRepo.GetClientsByAction(action);

            //Assert
            Assert.AreEqual(clients.Count, 0);
        }

        /// <summary>
        /// Tests AddClientAction using valid Client
        /// </summary>
        [TestMethod]
        public void AddValidClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("41361F37-036B-E911-AA03-021598E9EC9E");
            string action = "Search";
            ClientAction ca = new ClientAction(clientID, action);

            //Act
            clientActionRepo.AddClientAction(ca);
            ClientAction addedCA = clientActionRepo.GetClientAction(clientID, action);

            //Assert
            Assert.IsNotNull(addedCA);
        }

        /// <summary>
        /// Tests AddClientAction using an invalid Client
        /// </summary>
        [TestMethod]
        public void AddInvalidClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid();
            string action = "Search";
            ClientAction ca = new ClientAction(clientID, action);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => clientActionRepo.AddClientAction(ca));
            
        }

        /// <summary>
        /// Tests RemoveClientAction using valid clientaction
        /// </summary>
        [TestMethod]
        public void RemoveValidClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("41361F37-036B-E911-AA03-021598E9EC9E");
            string action = "Search";
            ClientAction ca = clientActionRepo.GetClientAction(clientID, action);

            //Act
            clientActionRepo.RemoveClientAction(ca);
            ClientAction removedCA = clientActionRepo.GetClientAction(clientID, action);

            //Assert
            Assert.IsNull(removedCA);
        }

        /// <summary>
        /// Tests RemoveClientAction using invalid clientaction
        /// </summary>
        [TestMethod]
        public void RemoveInvalidClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("6DF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "Search";
            ClientAction ca = new ClientAction(clientID, action);

            //Act => Assert
            Assert.ThrowsException<InvalidOperationException>(() => clientActionRepo.RemoveClientAction(ca));
        }

    }
}
