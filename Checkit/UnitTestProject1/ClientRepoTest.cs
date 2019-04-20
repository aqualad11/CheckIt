using System;
using System.Data.Entity.Infrastructure;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class ClientRepoTest 
    {
        /// <summary>
        /// Tests GetClientByID using valid ID
        /// </summary>
        [TestMethod]
        public void getClientByValidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Guid clientID = new Guid("6CF91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            Client client = clientRepo.GetClientByID(clientID);

            //Assert
            Assert.IsNotNull(client);
        }

        /// <summary>
        /// Tests GetClientByID using invalid ID
        /// </summary>
        [TestMethod]
        public void getClientByInvalidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Guid clientID = new Guid();

            //Act
            Client client = clientRepo.GetClientByID(clientID);

            //Assert
            Assert.IsNull(client);
        }

        /// <summary>
        /// Tests GetClientByName using valid client name
        /// </summary>
        [TestMethod]
        public void getClientByValidName()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            string clientName = "Finance";

            //Act
            Client client = clientRepo.GetClientByName(clientName);

            //Assert
            Assert.IsNotNull(client);
        }

        /// <summary>
        /// Tests GetClientByName using invalid client name
        /// </summary>
        [TestMethod]
        public void getClientByInvalidName()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            string clientName = "HelloWorld";

            //Act
            Client client = clientRepo.GetClientByName(clientName);

            //Assert
            Assert.IsNull(client);
        }

        /// <summary>
        /// Tests AddClient using valid client
        /// </summary>
        [TestMethod]
        public void addClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client newClient = new Client("Corporate");

            //Act
            clientRepo.AddClient(newClient);
            Client addedClient = clientRepo.GetClientByName("Corporate");

            //Assert
            Assert.IsNotNull(addedClient);
        }

        /// <summary>
        /// Tests UpdateClient using valid client
        /// </summary>
        [TestMethod]
        public void updateValidClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client client = clientRepo.GetClientByName("Corporate");
            string newName = "NotCorporate";
            client.name = newName;

            //Act
            clientRepo.UpdateClient(client);
            Client updatedClient = clientRepo.GetClientByName(newName);

            //Assert
            Assert.AreEqual(updatedClient.name, newName);
        }

        /// <summary>
        /// Tests UpdateClient using an invalid client
        /// </summary>
        [TestMethod]
        public void updateInvalidClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client client = new Client("NonexistantClient");

            //Act
            Assert.ThrowsException<DbUpdateConcurrencyException>(() => clientRepo.UpdateClient(client));
        }

        /// <summary>
        /// Tests RemoveClient using existing client
        /// </summary>
        /// <param name="client"></param>
        [TestMethod]
        public void removeClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client client = clientRepo.GetClientByName("NotCorporate");

            //Act 
            clientRepo.RemoveClient(client);
            Client removedClient = clientRepo.GetClientByName("NotCorporate");

            //Assert
            Assert.IsNull(removedClient);
        }

        /// <summary>
        /// Tests RemoveClient using nonexisting client
        /// </summary>
        [TestMethod]
        public void removeInvalidClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client client = new Client("Hellooo");

            //Act => Assert
            Assert.ThrowsException<InvalidOperationException>(() => clientRepo.RemoveClient(client));
        }
    }
}
