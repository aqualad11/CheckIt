using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    class ClientRepository : IClientRepository
    {
        private DataBaseContext db;

        public ClientRepository(DataBaseContext db)
        {
            this.db = db;
        }
        
        public Client getClientByID(Guid id)
        {
            Client client = db.Clients.Find(id);
            return client;
        }

        public Client getClientByName(string name)
        {
            Client client = db.Clients.Where(c => c.name == name).FirstOrDefault();
            return client;
        }

        public void addClient(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }

        public void removeClient(Client client)
        {
            db.Clients.Remove(client);
            db.SaveChanges();
        }

        public void updateClient(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
