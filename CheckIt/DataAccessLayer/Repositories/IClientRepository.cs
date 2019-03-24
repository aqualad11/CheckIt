using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IClientRepository
    {
        public Client getClientByID(Guid id)
    }
}
