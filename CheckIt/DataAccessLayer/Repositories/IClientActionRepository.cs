using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IClientActionRepository
    {
        ClientAction getClientActionbyID(Guid id);
        ClientAction getClientAction(Guid clientID, string action);
        List<string> getActionsByClientID(Guid clientID);
        List<Client> getClientsByAction(string action);

        void addClientAction(ClientAction clientaction);
        void removeClientAction(ClientAction clientaction);
    }
}