using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IUserActionRepository
    {
        
        UserAction GetUserAction(Guid userID, string action);
        List<string> GetActionsByUserID(Guid userID);
        List<User> GetUsersByAction(string action);

        void AddUserAction(UserAction useraction);
        void RemoveUserAction(UserAction useraction);
        //bool RemoveUserAction(Guid userID, string action);
    }
}
