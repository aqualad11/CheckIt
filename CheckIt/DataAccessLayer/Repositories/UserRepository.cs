using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataBaseContext db;

        public UserRepository(DataBaseContext db)
        {
            this.db = db;
        }

        public User GetUserbyEmail(string email)
        {
            var user = db.Users.Where(u => u.userEmail == email).FirstOrDefault();
            return user;
        }

        public User GetUserbyID(Guid userID)
        {
            var user = db.Users.Where(u => u.userID == userID).FirstOrDefault();
            return user;
        }

        public Guid GetUserIDbyEmail(string email)
        {
            Guid userID = db.Users.Where(u => u.userEmail == email).Select(u => u.userID).FirstOrDefault();
            return userID;
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        //throws System.Data.Entity.Infrastructure.DbUpdateConcurrencyException
        //if user does not exist in DB
        //throws System.ArgumentNullException
        //if user is null
        public void UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        //TODO: figure out where to handle an empty user or user that does not exist
        //throws System.InvalidOperationException if user not found
        //throws ArgumentNullException if null user passed in
        public void RemoveUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
