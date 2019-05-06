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
        private UserActionService uaService; 
    
        public UserManager(DataBaseContext db)
        {
            userService = new UserService(db);
            clientService = new ClientService(db);
            uaService = new UserActionService(db);
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

            //get user from the database to add UserActions
            user = userService.GetUser(email);
            uaService.AddDefaultUserActions(user.userID);

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
            
            //set default height
            int height = 2;
            
            //create user
            User user = new User(email, atype, height, clientID, parentID);

            //add User to db
            userService.AddUser(user);

            //get user from database to add useractions
            user = userService.GetUser(email);
            uaService.AddDefaultUserActions(user.userID);

            //return user
            return user;

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
            //create a new user and add them to the database
            User newUser = new User(email, atype, ssoID);
            userService.AddUser(newUser);

            //retrieve user from database to both confirm existence and to add useractions
            newUser = userService.GetUser(email);
            uaService.AddDefaultUserActions(newUser.userID);

            return newUser;
        }

        /// <summary>
        /// Deletes User from database via SSO.
        /// </summary>
        /// <param name="ssoID"></param>
        /// <param name="email"></param>
        /// <param name="timestamp"></param>
        /// <param name="signature"></param>
        public void DeleteUserFromSSO(Guid ssoID, string email, long timestamp, string signature)
        {
            //Validate Request
            var signatureService = new SignatureService();
            bool validRequest = signatureService.IsValid(ssoID, email, timestamp, signature);
            if (!validRequest)
            {
                throw new InvalidRequestSignature("Request Signature is not valid.");
            }

            //Check user's existence
            User user = userService.GetSSOUser(ssoID);

            if (user == null)
            {
                throw new UserDoesNotExistException("User does not exist");
            }

            //Remove user
            userService.RemoveUser(user);
        }

    }
}
