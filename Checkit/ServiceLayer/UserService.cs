using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;


namespace CheckIt.ServiceLayer
{
    public class UserService
    {
        private UserRepository userRepo;

        public UserService(DataBaseContext db)
        {
            userRepo = new UserRepository(db);
        }

        public bool userExists(Guid id)
        {
            User user = userRepo.GetUserbyID(id);
            return user == null ? false : true;
        }

        public bool userExists(string email)
        {
            User user = userRepo.GetUserbyEmail(email);
            return user == null ? false : true;
        }

        public User getUser(Guid id)
        {
            return userRepo.GetUserbyID(id);
        }

        public User getUser(string email)
        {
            return userRepo.GetUserbyEmail(email);
        }

        /// <summary>
        /// adds a new user to the DB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool addUser(User user)
        {
            if(user == null)
            {
                return false;
            }

            userRepo.AddUser(user);
            //TODO: check User was successfully added
            return true;
        }

        /// <summary>
        /// updates user in db
        /// </summary>
        /// <param name="user">pass in updated user</param>
        /// <returns></returns>
        public bool updateUser(User user)
        {
            //simultaniously checks that user is not null and that user exists in db
            User temp = userRepo.GetUserbyEmail(user.userEmail);
            if(temp == null)
            {
                return false;
            }

            userRepo.UpdateUser(user);
            return true;
        }

        /// <summary>
        /// removes user from db
        /// </summary>
        /// <param name="user"></param>
        public bool removeUser(User user)
        {
            //simultaniously checks that user is not null and that user exists in db
            User temp = userRepo.GetUserbyEmail(user.userEmail);
            if(temp == null)
            {
                return false;
            }

            userRepo.RemoveUser(user);
            return true;
        }

        
    }
}
