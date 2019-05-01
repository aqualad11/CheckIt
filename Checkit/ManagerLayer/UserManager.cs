using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.ServiceLayer;
using CheckIt;
using CheckIt.DataAccessLayer;

namespace CheckIt.ManagerLayer
{
    public class UserManager
    {
        private UserService userService;
        private ClientService clientService;
    
        public UserManager(DataBaseContext db)
        {
            userService = new UserService(db);
            clientService = new ClientService(db);
        }

        /// <summary>
        /// Creates a default user with just an email. ClientID, parentID, and ssoID are all set to null.
        /// Height is set to 2.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User CreateDefaultUser(string email)
        {
            string atype = "user";
            //check if user exists
            if(userService.UserExists(email))
            {
                throw new UserExistsException("Email is already registered in our system");
            }

            //create user
            User user = new User(email, atype);

            //add User to db
            userService.AddUser(user);

            //get and return user
            return userService.GetUser(email);

        }

        /// <summary>
        /// Creates a user with all the parameters passed in ecxcept for ssoID.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="atype"></param>
        /// <param name="clientID"></param>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public User CreateUser(string email, string atype, Guid clientID, Guid parentID)
        {
            //check if user exists
            if (userService.UserExists(email))
            {
                throw new UserExistsException("Email is already registered in our system");
            }

            //check if client exists
            if(!clientService.ClientExists(clientID))
            {
                throw new ClientDoesNotExistException("Client does not exist in our database");
            }

            //Check if parent user exists
            if(!userService.UserExists(parentID))
            {
                throw new UserDoesNotExistException("Parent User does not exist in our database");
            }
            int height = 2;
            User user = new User(email, atype, height, clientID, parentID);

            //add User to db
            userService.AddUser(user);

            //get and return user
            return userService.GetUser(email);

        }

        //SSOController will check if SSO user exists before running this method
        /// <summary>
        /// Creates a default user using ssoID and user's email
        /// </summary>
        /// <param name="ssoID"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public User CreateSSOUser(Guid ssoID, string email)
        {
            string atype = "user";
            //Check if user exists without ssoID
            if (userService.UserExists(email))
            {
                //get existing user
                User user = userService.GetUser(email);
                //if user does not have ssoID, add it
                if(user.ssoID == null)
                {
                    //add ssoID to user
                    user.ssoID = ssoID;
                    //update User
                    userService.UpdateUser(user);
                    return user;
                }
                
            }

            //if user exists and already has it's own ssoID or user does not exist we
            //create a new user
            User newUser = new User(email, atype, ssoID);
            userService.AddUser(newUser);
            return userService.GetUser(email);
        }

        public bool SSOUserExists(Guid ssoID)
        {
            return userService.SSOUserExists(ssoID);
        }

        public bool UserExists(string email)
        {
            return userService.UserExists(email);
        }

        public User GetSSOUser(Guid ssoID)
        {
            return userService.GetSSOUser(ssoID);
        }
        
    }
}
