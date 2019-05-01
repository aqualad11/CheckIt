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
        public void GetClientByValidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IClientRepository clientRepo = new ClientRepository(db);
            Guid clientID = new Guid("40361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            Client client = clientRepo.GetClientByID(clientID);

            //Assert
            Assert.IsNotNull(client);
        }

        /// <summary>
        /// Tests GetClientByID using invalid ID
        /// </summary>
        [TestMethod]
        public void GetClientByInvalidID()
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
        public void GetClientByValidName()
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
        public void GetClientByInvalidName()
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
        public void AddClient()
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
        public void UpdateValidClient()
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
        public void UpdateInvalidClient()
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
        public void RemoveClient()
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
        public void RemoveInvalidClient()
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
