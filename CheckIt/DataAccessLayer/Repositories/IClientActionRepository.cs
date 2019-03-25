using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    interface IClientActionRepository
    {
        ClientAction getClientActionbyID(Guid id);
        List<ClientAction> getClientActionsByClientID(Guid clientID);
        List<string> getActionsByClientID(Guid clientID);

        void addClientAction(ClientAction clientaction);
        void updateClientAction(ClientAction clientaction);//remove this guy
        void removeClientAction(ClientAction clientaction);
    }
}