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
        /// Tests getClientByID using valid ID
        /// </summary>
        [TestMethod]
        public void getClientByValidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Guid clientID = new Guid("6CF91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            Client client = clientRepo.getClientByID(clientID);

            //Assert
            Assert.IsNotNull(client);
        }

        /// <summary>
        /// Tests getClientByID using invalid ID
        /// </summary>
        [TestMethod]
        public void getClientByInvalidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Guid clientID = new Guid();

            //Act
            Client client = clientRepo.getClientByID(clientID);

            //Assert
            Assert.IsNull(client);
        }

        /// <summary>
        /// Tests getClientByName using valid client name
        /// </summary>
        [TestMethod]
        public void getClientByValidName()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            string clientName = "Finance";

            //Act
            Client client = clientRepo.getClientByName(clientName);

            //Assert
            Assert.IsNotNull(client);
        }

        /// <summary>
        /// Tests getClientByName using invalid client name
        /// </summary>
        [TestMethod]
        public void getClientByInvalidName()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            string clientName = "HelloWorld";

            //Act
            Client client = clientRepo.getClientByName(clientName);

            //Assert
            Assert.IsNull(client);
        }

        /// <summary>
        /// Tests addClient using valid client
        /// </summary>
        [TestMethod]
        public void addClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client newClient = new Client("Corporate");

            //Act
            clientRepo.addClient(newClient);
            Client addedClient = clientRepo.getClientByName("Corporate");

            //Assert
            Assert.IsNotNull(addedClient);
        }

        /// <summary>
        /// Tests updateClient using valid client
        /// </summary>
        [TestMethod]
        public void updateValidClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client client = clientRepo.getClientByName("Corporate");
            string newName = "NotCorporate";
            client.name = newName;

            //Act
            clientRepo.updateClient(client);
            Client updatedClient = clientRepo.getClientByName(newName);

            //Assert
            Assert.AreEqual(updatedClient.name, newName);
        }

        /// <summary>
        /// Tests updateClient using an invalid client
        /// </summary>
        [TestMethod]
        public void updateInvalidClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client client = new Client("NonexistantClient");

            //Act
            Assert.ThrowsException<DbUpdateConcurrencyException>(() => clientRepo.updateClient(client));
        }

        /// <summary>
        /// Tests removeClient using existing client
        /// </summary>
        /// <param name="client"></param>
        [TestMethod]
        public void removeClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client client = clientRepo.getClientByName("NotCorporate");

            //Act 
            clientRepo.removeClient(client);
            Client removedClient = clientRepo.getClientByName("NotCorporate");

            //Assert
            Assert.IsNull(removedClient);
        }

        /// <summary>
        /// Tests removeClient using nonexisting client
        /// </summary>
        [TestMethod]
        public void removeInvalidClient()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Client client = new Client("Hellooo");

            //Act => Assert
            Assert.ThrowsException<InvalidOperationException>(() => clientRepo.removeClient(client));
        }
    }
}
