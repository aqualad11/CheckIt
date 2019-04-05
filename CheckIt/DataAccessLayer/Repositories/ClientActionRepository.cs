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

        public ClientAction getClientActionbyID(Guid id)
        {
            ClientAction ca = db.ClientActions.Where(c => c.clientActionID == id).FirstOrDefault();
            return ca;
        }

        public ClientAction getClientAction(Guid clientID, string action)
        {
            ClientAction ca = db.ClientActions.Where(c => c.clientID == clientID && c.action == action).FirstOrDefault();
            return ca;
        }

        //returns a list of actions as a list of Clientactions
        public List<ClientAction> getClientActionsByClientID(Guid clientID)
        {
            List<ClientAction> clientactions = db.ClientActions.Where(c => c.clientID == clientID).ToList();
            return clientactions;
        }

        //returns a list of actions as a list of strings
        public List<string> getActionsByClientID(Guid clientID)
        {
            List<string> clientactions = db.ClientActions.Where(c => c.clientID == clientID).Select(c => c.action).ToList();
            return clientactions;
        }

        public List<Client> getClientsByAction(string action)
        {
            List<Client> clients = db.ClientActions.Where(c => c.action == action).Select(c => c.Client).ToList();
            return clients;
        }
        
        public void addClientAction(ClientAction clientaction)
        {
            db.ClientActions.Add(clientaction);
            db.SaveChanges();
        }

        public void updateClientAction(ClientAction clientaction)
        {
            db.Entry(clientaction).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void removeClientAction(ClientAction clientaction)
        {
            db.ClientActions.Remove(clientaction);
            db.SaveChanges();
        }


    }
}
