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
        /// <summary>
        /// Constructor for ClientActionRepository 
        /// </summary>
        /// <param name="db"></param>
        public ClientActionRepository(DataBaseContext db)
        {
            this.db = db;
        }

        public ClientAction GetClientAction(Guid clientID, string action)
        {
            ClientAction ca = db.ClientActions.Where(c => c.clientID == clientID && c.action == action).FirstOrDefault();
            return ca;
        }

        //returns a list of actions as a list of strings
        public List<string> GetActionsByClientID(Guid clientID)
        {
            List<string> clientactions = db.ClientActions.Where(c => c.clientID == clientID).Select(c => c.action).ToList();
            return clientactions;
        }

        public List<Client> GetClientsByAction(string action)
        {
            List<Client> clients = db.ClientActions.Where(c => c.action == action).Select(c => c.Client).ToList();
            return clients;
        }
        
        public void AddClientAction(ClientAction clientaction)
        {
            db.ClientActions.Add(clientaction);
            db.SaveChanges();
        }

        public void RemoveClientAction(ClientAction clientaction)
        {
            db.ClientActions.Remove(clientaction);
            db.SaveChanges();
        }


    }
}
