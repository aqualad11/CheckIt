using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IClientRepository
    {
        Client getClientByID(Guid id);
        Client getClientByName(string name);

        void addClient(Client client);
        void updateClient(Client client);
        void removeClient(Client client);
    }
}
