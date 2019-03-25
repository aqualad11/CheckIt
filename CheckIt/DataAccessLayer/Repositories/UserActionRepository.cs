using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    class UserActionRepository : IUserActionRepository
    {
        private DataBaseContext db;

        public UserActionRepository(DataBaseContext db)
        {
            this.db = db;
        }
        
        public List<string> getActionsByUserID(Guid userID)
        {
            var actions = db.UserActions.Where(u => u.userID == userID).Select(a => a.action).ToList();
            return actions;
        }

        public UserAction getUserActionByID(Guid useractionID)
        {
            var useraction = db.UserActions.Where(u => u.actionID == useractionID).FirstOrDefault();
            return useraction;
        }

        public List<UserAction> getUserActionsByUserID(Guid userID)
        {
            var actions = db.UserActions.Where(u => u.userID == userID).ToList();
            return actions;
        }

        public List<User> getUsersByAction(string action)
        {
            var users = db.UserActions.Where(u => u.action == action).Select(u => u.User).ToList();
            return users;
        }

        public void addUserAction(UserAction useraction)
        {
            db.UserActions.Add(useraction);
            db.SaveChanges();
        }

        public void removeUserAction(UserAction useraction)
        {
            db.Entry(useraction).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void updateUserAction(UserAction useraction)
        {
            db.UserActions.Remove(useraction);
            db.SaveChanges();
        }
    }
}
