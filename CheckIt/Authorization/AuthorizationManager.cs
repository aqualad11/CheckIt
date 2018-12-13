using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.Authorizations
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
            //if user does not have client just authorize based on user's actions
            if (client == null)
            {
                return Authorization.AuthorizeAction(token, action);
            }
            else
            {
                //check if action is in client's action list
                if(Authorization.CheckClientActions(token, action))
                {
                    //if so check if action is in user's action list
                    return Authorization.AuthorizeAction(token, action);
                }
                //client does not have action
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
            return AuthorizeAction(token, action);

        }
    }
}
