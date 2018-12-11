using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;

namespace CheckIt.Authorizations
{
    public class Authorization
    {
       


        /// <summary>
        /// authorizes IP addresses to make sure its in user scope
        /// </summary>
        /// <param name="token"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        private static bool authorizeIP(Token token, string IP)
        {

            return false;
        }

        /// <summary>
        /// checks if user is old enough to use system based off birthdate
        /// </summary>
        /// <param name="token"></param>
        /// <param name="birthday"> user's birthdate</param>
        /// <returns></returns>
        private static bool authorizeAge(DateTime birthday)
        {
            DateTime now = new DateTime();
            TimeSpan age = now - birthday;
            int ageInDays = age.Days;
            int ageInYears = ageInDays / 365;

            if(ageInYears >= 18)
            {
                return true;
            }

            return false;
        }

        public static bool CheckClientActions(IToken token, string action)
        {
            
            string client = token.GetClient();

            /*
             * TODO: call DAL to get client actions
             * once we have actions compare to actions in token
             * DAL.GetActions(client))
             */
            if(client == "null")
            {
                return true;
            }else
            {
                DataAccessManager dm = new DataAccessManager();
                List<string> clientActions = dm.getActions(client);
                if (clientActions.Contains(action))
                {
                    return true;
                }
                
            }
            return false;
        }

        //TODO: Once DAL is done we can do this
        //DAL.GetUserHeight(user2)
        public static bool UserToUserPermission(IToken token, string user2)
        {
            DataAccessManager dm = new DataAccessManager();
            Console.WriteLine("token height = " + token.GetHeight());
            int user2height = dm.getHeight(user2);
            if(user2height == -1)
            {
                return false;
            }else if(token.GetHeight() < user2height)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        

        public static bool AuthorizeAction(IToken token, string action)
        {
            List<string> userActions = token.GetActions();
            bool hasAction = userActions.Contains(action);
            return hasAction;
        }
    }
}
