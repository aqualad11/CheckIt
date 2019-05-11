using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;

namespace CheckIt.ManagerLayer
{
    public class AuthorizationManager
    {
        private TokenManager tokenManager;
        private UserManager userManager;

        public AuthorizationManager(DataBaseContext db)
        {
            tokenManager = new TokenManager(db);
            userManager = new UserManager(db);
        }

        /// <summary>
        /// Authorize's action using a JWT string, which is used to extract user to see the user's
        /// actions and client's actions
        /// </summary>
        /// <param name="jwt"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool AuthorizeAction(string jwt, string action)
        {
            //get user from token
            User user = tokenManager.ExtractUser(jwt);
            bool authorized = false;
            
            //check if action is unders user's actions
            foreach (UserAction ua in user.userActions)
            {
                if(ua.action == action)
                {
                    authorized = true;
                    break;
                }
            }

            //if user has a client and action they have action, check client
            if (user.client != null && authorized)
            {
                Client client = user.client;
                foreach (ClientAction ca in client.actions)
                {
                    if(ca.action == action)
                    {
                        authorized = true;
                        break;
                    }
                }
            }

            return authorized;
        }

        /// <summary>
        /// Overloaded method which skips accessing the DAL
        /// </summary>
        /// <param name="user"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public bool AuthorizeAction(User user, string action)
        {
            bool authorized = false;

            //check if action is unders user's actions
            foreach (UserAction ua in user.userActions)
            {
                if (ua.action == action)
                {
                    authorized = true;
                    break;
                }
            }

            //if user has a client and action they have action, check client
            if (user.client != null && authorized)
            {
                Client client = user.client;
                foreach (ClientAction ca in client.actions)
                {
                    if (ca.action == action)
                    {
                        authorized = true;
                        break;
                    }
                }
            }

            return authorized;
        }

        
        public bool AuthorizeUserToUser(string jwt, Guid user2ID, string action)
        {
            User user1 = tokenManager.ExtractUser(jwt);
            User user2 = userManager.GetUser(user2ID);

            if(user1.height < user2.height)
            {
                return AuthorizeAction(user1, action);
            }
            return false;
        }
    }
}
