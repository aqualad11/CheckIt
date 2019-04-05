using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public class UserActionRepository : IUserActionRepository
    {
        private DataBaseContext db;
        
        public UserActionRepository(DataBaseContext db)
        {
            this.db = db;
        }

        public UserAction getUserAction(Guid userID, string action)
        {
            var userAction = db.UserActions.Where(u => u.userID == userID && u.action == action).Select(u => u).FirstOrDefault();
            return userAction;
        }

        public List<string> getActionsByUserID(Guid userID)
        {
            var actions = db.UserActions.Where(u => u.userID == userID).Select(a => a.action).ToList();
            return actions;
        }

        public List<User> getUsersByAction(string action)
        {
            var users = db.UserActions.Where(u => u.action == action).Select(u => u.User).ToList();
            return users;
        }

        /// <summary>
        /// Throws System.Data.Entity.Infrastructure.DbUpdateException if user does not exist
        /// should be handled in ServiceLayer
        /// </summary>
        /// <param name="useraction"></param>
        public void addUserAction(UserAction useraction)
        {
            db.UserActions.Add(useraction);
            db.SaveChanges();
        }

        /// <summary>
        /// Throws System.Data.Entity.Infrastructure.DbUpdateConcurrencyException if userAction does not exist
        /// in DB. Should be handled in ServiceLayer by making sure it is a valid userAction
        /// </summary>
        /// <param name="useraction"></param>
        public void removeUserAction(UserAction useraction)
        {
            db.Entry(useraction).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void removeUserAction(Guid userID, string action)
        {
            UserAction ua = db.UserActions.Where(u => u.userID == userID && u.action == action).FirstOrDefault();
            db.UserActions.Remove(ua);
            db.SaveChanges();
        }
    }
}
