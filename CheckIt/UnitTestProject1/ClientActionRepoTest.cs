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
        /// Tests getActionsByClientID using valid clientID
        /// </summary>
        [TestMethod]
        public void getActionsByValidClientID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("6EF91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            List<string> actions = clientActionRepo.getActionsByClientID(clientID);

            //Assert
            Assert.AreEqual(actions.Count, 3);

        }

        /// <summary>
        /// Tests getActionsByClientID using invalid clientID
        /// </summary>
        [TestMethod]
        public void getActionsByInvalidClientID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid();

            //Act
            List<string> actions = clientActionRepo.getActionsByClientID(clientID);

            //Assert
            Assert.AreEqual(actions.Count, 0);

        }

        /// <summary>
        /// Tests getClientActionbyID using a valid clientAction ID
        /// </summary>
        [TestMethod]
        public void getClientActionbyValidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientAction = new Guid("70F91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            ClientAction ca = clientActionRepo.getClientActionbyID(clientAction);

            //Assert
            Assert.IsNotNull(ca);

        }

        /// <summary>
        /// Tests getClientActionbyID using a invalid clientAction ID
        /// </summary>
        [TestMethod]
        public void getClientActionbyInvalidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientAction = new Guid();

            //Act
            ClientAction ca = clientActionRepo.getClientActionbyID(clientAction);

            //Assert
            Assert.IsNull(ca);
        }

        /// <summary>
        /// Tests getClientAction(clientID, action) using a valid clientID and action
        /// </summary>
        [TestMethod]
        public void getClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("6CF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "Login";

            //Act
            ClientAction ca = clientActionRepo.getClientAction(clientID, action);

            //Assert
            Assert.IsNotNull(ca);
        }

        /// <summary>
        /// Tests getClientAction(clientID, action) using a valid clientID and invalid action
        /// </summary>
        [TestMethod]
        public void getClientActionValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("6CF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "NotARealAction";

            //Act
            ClientAction ca = clientActionRepo.getClientAction(clientID, action);

            //Assert
            Assert.IsNull(ca);
        }

        /// <summary>
        /// Tests getClientsByAction using a valid Action
        /// </summary>
        /// <param name="action"></param>
        [TestMethod]
        public void getClientsByValidAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            string action = "Update";

            //Act
            List<Client> clients = clientActionRepo.getClientsByAction(action);

            //Assert
            Assert.AreEqual(clients.Count, 3);
        }

        /// <summary>
        /// Tests getClientsByAction using a invalid Action
        /// </summary>
        [TestMethod]
        public void getClientsByInvalidAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            string action = "NotAnAction";

            //Act
            List<Client> clients = clientActionRepo.getClientsByAction(action);

            //Assert
            Assert.AreEqual(clients.Count, 0);
        }

        /// <summary>
        /// Tests addClientAction using valid Client
        /// </summary>
        [TestMethod]
        public void addValidClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("6DF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "Search";
            ClientAction ca = new ClientAction(clientID, action);

            //Act
            clientActionRepo.addClientAction(ca);
            ClientAction addedCA = clientActionRepo.getClientAction(clientID, action);

            //Assert
            Assert.IsNotNull(addedCA);
        }

        /// <summary>
        /// Tests addClientAction using an invalid Client
        /// </summary>
        [TestMethod]
        public void addInvalidClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid();
            string action = "Search";
            ClientAction ca = new ClientAction(clientID, action);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => clientActionRepo.addClientAction(ca));
            
        }

        /// <summary>
        /// Tests removeClientAction using valid clientaction
        /// </summary>
        [TestMethod]
        public void removeValidClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("6DF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "Search";
            ClientAction ca = clientActionRepo.getClientAction(clientID, action);

            //Act
            clientActionRepo.removeClientAction(ca);
            ClientAction removedCA = clientActionRepo.getClientAction(clientID, action);

            //Assert
            Assert.IsNull(removedCA);
        }

        /// <summary>
        /// Tests removeClientAction using invalid clientaction
        /// </summary>
        [TestMethod]
        public void removeInvalidClientAction()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientActionRepository clientActionRepo = new ClientActionRepository(db);
            Guid clientID = new Guid("6DF91B37-DC4A-E911-8259-0A64F53465D0");
            string action = "Search";
            ClientAction ca = new ClientAction(clientID, action);

            //Act => Assert
            Assert.ThrowsException<InvalidOperationException>(() => clientActionRepo.removeClientAction(ca));
        }
        
    }
}
