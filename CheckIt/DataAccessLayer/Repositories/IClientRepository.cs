using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IClientRepository
    {
        Client GetClientByID(Guid id);
        Client GetClientByName(string name);

        void AddClient(Client client);
        void UpdateClient(Client client);
        void RemoveClient(Client client);
    }
}
