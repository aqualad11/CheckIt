using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    class UserRepository : IUserRepository
    {
        private DataBaseContext db;

        public UserRepository(DataBaseContext db)
        {
            this.db = db;
        }

        public User getUserbyEmail(string email)
        {
            var user = db.Users.Where(u => u.userEmail == email).FirstOrDefault();
            return user;
        }

        public User getUserbyID(Guid userID)
        {
            var user = db.Users.Where(u => u.userID == userID).FirstOrDefault();
            return user;
        }

        public void addUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void removeUser(User user)
        {
            db.Entry(user).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void updateUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
