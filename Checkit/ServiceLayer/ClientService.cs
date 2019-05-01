using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;

namespace CheckIt.ServiceLayer
{
    public class ClientService
    {
        private ClientRepository clientRepo;

        public ClientService(DataBaseContext db)
        {
            clientRepo = new ClientRepository(db);
        }

        /// <summary>
        /// Gets client from database using the client's ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Client or null if client does not exist.</returns>
        public Client GetClient(Guid id)
        {
            Client client = clientRepo.GetClientByID(id);
            return client;
        }

        /// <summary>
        /// Gets client from database using the client's name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Client or null if client does not exist</returns>
        public Client GetClient(string name)
        {
            Client client = clientRepo.GetClientByName(name);
            return client;
        }

        //TODO: fix this
        /// <summary>
        /// Checks if client exists in the database using the client's ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if user exist, false otherwise</returns>
        public bool ClientExists(Guid id)
        {
            if(id == null)
            {
                return false;
            }
            Client client = clientRepo.GetClientByID(id);
            return client == null ? false : true; 
        }

        /// <summary>
        /// Checks if client exists in the database using the client's name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True if user exist, false otherwise.</returns>
        public bool ClientExists(string name)
        {
            Client client = clientRepo.GetClientByName(name);
            return client == null ? false : true;
        }

        /// <summary>
        /// Adds Client object to database.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>True if user is valid and successfully added to database, otherwise returns false.</returns>
        public bool AddClient(Client client)
        {
            if(client == null)
            {
                return false;
            }
            clientRepo.AddClient(client);
            return true;
        }

        /// <summary>
        /// Updates client on the database.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>True if client exists and successfuly updated, otherwise return false.</returns>
        public bool UpdateClient(Client client)
        {
            if(ClientExists(client.clientID))
            {
                clientRepo.UpdateClient(client);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes client from database.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>True if client exists and successfuly removed, otherwise return false.</returns>
        public bool RemoveClient(Client client)
        {
            if(ClientExists(client.clientID))
            {
                clientRepo.RemoveClient(client);
                if(!ClientExists(client.clientID))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
