using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private DataBaseContext db;

        public ClientRepository(DataBaseContext db)
        {
            this.db = db;
        }
        
        /// <summary>
        /// Gets Client using the client's ID.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns>Client, or null if not found.</returns>
        public Client GetClientByID(Guid clientID)
        {
            Client client = db.Clients.Find(clientID);
            return client;
        }

        /// <summary>
        /// Gets Client using client's name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Client, or null if not found.</returns>
        public Client GetClientByName(string name)
        {
            Client client = db.Clients.Where(c => c.name == name).FirstOrDefault();
            return client;
        }

        /// <summary>
        /// Adds Client to database.
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }

        /// <summary>
        /// Removes Client from Database.
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="System.InvalidOperationException">Thrown if Client does not exist in database</exception>
        public void RemoveClient(Client client)
        {
            db.Clients.Remove(client);
            db.SaveChanges();
        }

        /// <summary>
        /// Updates Client in database.
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateConcurrencyException">Thrown if client does not exist in database.</exception>
        public void UpdateClient(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
