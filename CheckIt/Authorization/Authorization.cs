using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.Authorization
{
    class Authorization
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

        //TODO: Once DAL is done we can do this
        public static bool UserToUserPermission(string user1, string user2)
        {

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
