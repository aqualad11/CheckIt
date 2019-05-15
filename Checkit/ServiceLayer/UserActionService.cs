using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;

namespace CheckIt.ServiceLayer
{

    public class UserActionService
    {
        private UserActionRepository uaRepo;

        public UserActionService(DataBaseContext db)
        {
            uaRepo = new UserActionRepository(db);
        }

        public List<string> GetActions(Guid userID)
        {
            List<string> actions = uaRepo.GetActionsByUserID(userID);
            return actions;
        }


        //TODO: write methods to create default useractions
        public void AddDefaultUserActions(Guid userID)
        {
            //add any new actions for users here
            List<UserAction> actions = new List<UserAction>()
            {
                new UserAction(userID, Actions.SEARCH),
                new UserAction(userID, Actions.WISHLIST),
                new UserAction(userID, Actions.DELETESELF)
            };

            foreach(UserAction ua in actions)
            {
                uaRepo.AddUserAction(ua);
            }
        }


        public void AddAdminUserActions(Guid adminID)
        {
            //TODO: Add admin actions
            List<UserAction> actions = new List<UserAction>()
            {
                //new UserAction(adminID, Actions.SEARCH),
                new UserAction(adminID, Actions.WISHLIST),
                //new UserAction(adminID, Actions.DELETESELF),
                new UserAction(adminID, Actions.ADDUSER),
                new UserAction(adminID, Actions.UPDATEUSER),
                new UserAction(adminID, Actions.DELETEUSER),
                new UserAction(adminID, Actions.GETUSER)
            };

            foreach (UserAction ua in actions)
            {
                uaRepo.AddUserAction(ua);
            }
        }
    }
}
