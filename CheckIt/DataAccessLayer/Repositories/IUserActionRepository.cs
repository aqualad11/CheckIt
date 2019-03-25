using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    interface IUserActionRepository
    {
        UserAction getUserActionByID(Guid useractionID);
        List<UserAction> getUserActionsByUserID(Guid userID);
        List<string> getActionsByUserID(Guid userID);
        List<User> getUsersByAction(string action);

        void addUserAction(UserAction useraction);
        void updateUserAction(UserAction useraction);//may need to remove this
        void removeUserAction(UserAction useraction);
    }
}
