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

        public bool UserExists(Guid id)
        {
            User user = userRepo.GetUserbyID(id);
            return user == null ? false : true;
        }

        public bool UserExists(string email)
        {
            User user = userRepo.GetUserbyEmail(email);
            return user == null ? false : true;
        }

        public bool SSOUserExists(Guid ssoID)
        {
            User user = userRepo.GetUserbySSOID(ssoID);
            return user == null ? false : true;
        }

        public User GetUser(Guid id)
        {
            return userRepo.GetUserbyID(id);
        }

        public User GetUser(string email)
        {
            return userRepo.GetUserbyEmail(email);
        }

        public User GetSSOUser(Guid ssoID)
        {
            return userRepo.GetUserbySSOID(ssoID);
        }

        public List<string> ExtractActions(User user)
        {
            List<string> actions = new List<string>();
            foreach(UserAction ua in user.userActions)
            {
                actions.Add(ua.action);
            }
            return actions;
        }
        //TODO: implement new UserRepo
        /// <summary>
        /// adds a new user to the DB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            if(user == null)
            {
                return false;
            }

            userRepo.AddUser(user);
            //TODO: check User was successfully added
            return true;
        }

        //TODO: implement new UserRepo
        /// <summary>
        /// updates user in db
        /// </summary>
        /// <param name="user">pass in updated user</param>
        /// <returns></returns>
        public bool UpdateUser(User user)
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

        //TODO: implement new UserRepo
        /// <summary>
        /// removes user from db
        /// </summary>
        /// <param name="user"></param>
        public bool RemoveUser(User user)
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
