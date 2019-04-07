using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using CheckIt.Authorization;

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
            User user = userRepo.getUserbyID(id);
            return user == null ? false : true;
        }

        public bool userExists(string email)
        {
            User user = userRepo.getUserbyEmail(email);
            return user == null ? false : true;
        }

        public User getUser(Guid id)
        {
            return userRepo.getUserbyID(id);
        }

        public User getUser(string email)
        {
            return userRepo.getUserbyEmail(email);
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

            userRepo.addUser(user);
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
            User temp = userRepo.getUserbyEmail(user.userEmail);
            if(temp == null)
            {
                return false;
            }

            userRepo.updateUser(user);
            return true;
        }

        /// <summary>
        /// removes user from db
        /// </summary>
        /// <param name="user"></param>
        public bool removeUser(User user)
        {
            //simultaniously checks that user is not null and that user exists in db
            User temp = userRepo.getUserbyEmail(user.userEmail);
            if(temp == null)
            {
                return false;
            }

            userRepo.removeUser(user);
            return true;
        }

        
    }
}
