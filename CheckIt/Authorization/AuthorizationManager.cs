using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.Authorization
{
    public class AuthorizationManager
    {
        /// <summary>
        /// This method is to authorize a specific action 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="actionRole"></param>
        /// <returns></returns>
        public static bool AuthorizeAction(IToken token, string action)
        {
            string client = token.GetClient();
            if (client == null)
            {
                return Authorization.AuthorizeAction(token, action);
            }
            else
            {
                if(Authorization.CheckClientActions(token, action))
                {
                    return Authorization.AuthorizeAction(token, action);
                }
                return false;
            }     
            
        }

        public static bool AuthorizeUserToUser(IToken token, string email2, string action)
        {
            //checks if user can edit second user
            if(!Authorization.UserToUserPermission(token,email2))
            {
                return false;
            }

            //checks if user has action
            if(!Authorization.AuthorizeAction(token,action))
            {
                return false;
            }

            return true;
        }
    }
}
