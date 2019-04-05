using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IUserActionRepository
    {
        //UserAction getUserActionByID(Guid useractionID);
        //List<UserAction> getUserActionsByUserID(Guid userID);//look into deleting this
        UserAction getUserAction(Guid userID, string action);
        List<string> getActionsByUserID(Guid userID);
        List<User> getUsersByAction(string action);

        void addUserAction(UserAction useraction);
        void removeUserAction(UserAction useraction);
        void removeUserAction(Guid userID, string action);
    }
}
