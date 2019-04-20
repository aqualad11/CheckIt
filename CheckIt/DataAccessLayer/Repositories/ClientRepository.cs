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
        
        public Client GetClientByID(Guid id)
        {
            Client client = db.Clients.Find(id);
            return client;
        }

        public Client GetClientByName(string name)
        {
            Client client = db.Clients.Where(c => c.name == name).FirstOrDefault();
            return client;
        }

        public void AddClient(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }

        public void RemoveClient(Client client)
        {
            db.Clients.Remove(client);
            db.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
