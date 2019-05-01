using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;

namespace ServiceLayer
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
                new UserAction(userID, "Search"),
                new UserAction(userID, "Watchlist"),
                new UserAction(userID, "SeeData"),
                new UserAction(userID, "DeleteSelf")
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
                new UserAction(adminID, "Search"),
                new UserAction(adminID, "Watchlist"),
                new UserAction(adminID, "SeeData"),
                new UserAction(adminID, "DeleteSelf")
            };

            foreach (UserAction ua in actions)
            {
                uaRepo.AddUserAction(ua);
            }
        }
    }
}
