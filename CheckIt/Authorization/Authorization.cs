using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;

namespace CheckIt.Authorization
{
    public class Authorization
    {



        /// <summary>
        /// authorizes IP addresses to make sure its in user scope
        /// </summary>
        /// <param name="token"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static bool authorizeIP(Token token, string IP)
        {
            return true;
        }

        /// <summary>
        /// checks if user is old enough to use system based off birthdate
        /// </summary>
        /// <param name="token"></param>
        /// <param name="birthday"> user's birthdate</param>
        /// <returns></returns>
        public static bool authorizeAge(DateTime birthday)
        {
            DateTime now = DateTime.Now;
            TimeSpan age = now - birthday;
            int ageInDays = age.Days;
            int ageInYears = ageInDays / 365;

            if (ageInYears >= 18)
            {
                return true;
            }

            return false;
        }

        //TODO: Once Repository is done, Re-implement
        public static bool CheckClientActions(IToken token, string action)
        {
            /*
            string client = token.GetClient();

            if (client == null)
            {
                return true;
            }
            else
            {
                AuthorizationData dm = new AuthorizationData();
                List<string> clientActions = dm.getClientActions(client);
                if (clientActions.Contains(action))
                {
                    return true;
                }

            }
            return false;
            */
            return true;
        }

        //TODO: Once Repository is complete, RE-Implement
        //DAL.GetUserHeight(user2)
        public static bool UserToUserPermission(IToken token, string user2)
        {
            /*AuthorizationData dm = new AuthorizationData();
            Console.WriteLine("token height = " + token.GetHeight());
            int user2height = dm.getHeight(user2);
            if (user2height == -1)
            {
                return false;
            }
            else if (token.GetHeight() < user2height)
            {
                return true;
            }
            else
            {
                return false;
            }
            */
            return true;
        }
        


        public static bool AuthorizeAction(IToken token, string action)
        {
            List<string> userActions = token.GetActions();
            bool hasAction = userActions.Contains(action);
            return hasAction;
        }
    }
}
