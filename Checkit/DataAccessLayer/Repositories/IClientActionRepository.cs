using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IClientActionRepository
    {
        ClientAction GetClientAction(Guid clientID, string action);
        List<string> GetActionsByClientID(Guid clientID);
        List<Client> GetClientsByAction(string action);

        void AddClientAction(ClientAction clientaction);
        void RemoveClientAction(ClientAction clientaction);
    }
}