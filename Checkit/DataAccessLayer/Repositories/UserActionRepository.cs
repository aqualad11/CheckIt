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

        /// <summary>
        /// Gets user action using user's ID and action string
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="action"></param>
        /// <returns>Corresponding UserAction or null if it doesn't exist.</returns>
        public UserAction GetUserAction(Guid userID, string action)
        {
            var userAction = db.UserActions.Where(u => u.userID == userID && u.action == action).Select(u => u).FirstOrDefault();
            return userAction;
        }

        /// <summary>
        /// Returns list of actions as strings that correspond to that user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Returns list of actions or an empty list.</returns>
        public List<string> GetActionsByUserID(Guid userID)
        {
            var actions = db.UserActions.Where(u => u.userID == userID).Select(a => a.action).ToList();
            return actions;
        }

        /// <summary>
        /// Gets all the users based on an action.
        /// </summary>
        /// <param name="action"></param>
        /// <returns>List of Users that have that action</returns>
        public List<User> GetUsersByAction(string action)
        {
            var users = db.UserActions.Where(u => u.action == action).Select(u => u.User).ToList();
            return users;
        }

        /// <summary>
        /// Adds UserAction to the database
        /// </summary>
        /// <param name="useraction"></param>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException">Thrown when user does not exist</exception>
        public void AddUserAction(UserAction useraction)
        {
            db.UserActions.Add(useraction);
            db.SaveChanges();
        }

        /// <summary>
        /// Removes UserAction from database
        /// </summary>
        /// <param name="useraction"></param>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException">Thrown if UserAction does not exist</exception>
        public void RemoveUserAction(UserAction useraction)
        {
            db.Entry(useraction).State = EntityState.Deleted;
            db.SaveChanges();
        }

        /*
        public void RemoveUserAction(Guid userID, string action)
        {
            try
            {
                UserAction ua = db.UserActions.Where(u => u.userID == userID && u.action == action).FirstOrDefault();
                db.UserActions.Remove(ua);
                db.SaveChanges();

            }catch(Exception)
            {

            }
        }
        */
    }
}
