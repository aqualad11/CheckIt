using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public class ClientActionRepository : IClientActionRepository
    {
        private DataBaseContext db;
 

        public ClientActionRepository(DataBaseContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Gets ClientAction with client's ID and action name
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="action"></param>
        /// <returns>ClientAction, or null if not found.</returns>
        public ClientAction GetClientAction(Guid clientID, string action)
        {
            ClientAction ca = db.ClientActions.Where(c => c.clientID == clientID && c.action == action).FirstOrDefault();
            return ca;
        }

        /// <summary>
        /// Gets client's action using client's ID
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns>List<String></returns>
        public List<string> GetActionsByClientID(Guid clientID)
        {
            List<string> clientactions = db.ClientActions.Where(c => c.clientID == clientID).Select(c => c.action).ToList();
            return clientactions;
        }

        /// <summary>
        /// Gets all the clients that share the same action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public List<Client> GetClientsByAction(string action)
        {
            List<Client> clients = db.ClientActions.Where(c => c.action == action).Select(c => c.Client).ToList();
            return clients;
        }
        
        /// <summary>
        /// Adds ClientAction to Database
        /// </summary>
        /// <param name="clientaction"></param>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException">Thrown if client does not exist in database.</exception>
        public void AddClientAction(ClientAction clientaction)
        {
            db.ClientActions.Add(clientaction);
            db.SaveChanges();
        }

        /// <summary>
        /// Removes ClientAction from the database.
        /// </summary>
        /// <param name="clientaction"></param>
        /// <exception cref="System.InvalidOperationException">Thrown if ClientAction does not exist in database.</exception>
        public void RemoveClientAction(ClientAction clientaction)
        {
            db.ClientActions.Remove(clientaction);
            db.SaveChanges();
        }


    }
}
