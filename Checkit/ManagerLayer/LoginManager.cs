using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.ServiceLayer;

namespace CheckIt.ManagerLayer
{
    public class LoginManager
    {
        private DataBaseContext db;
        public LoginManager(DataBaseContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Valides the request from SSO, then if the SSO user exists a token is created and return. If the User
        /// does not exist, the user is created then given a token. Logging in is just getting a token.
        /// </summary>
        /// <param name="ssoID"></param>
        /// <param name="email"></param>
        /// <param name="timestamp"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public string SSOLogin(Guid ssoID, string email, long timestamp, string signature)
        {
            //Validate Request
            var ss = new SignatureService();
            bool validRequest = ss.IsValid(ssoID, email, timestamp, signature);
            if(!validRequest)
            {
                throw new InvalidRequestSignature("Request Signature is not valid.");
            }

            //Create Manager
            UserManager um = new UserManager(db);
            TokenManager tm = new TokenManager(db);

            string token;
            //Checks if SSOUser exists, if so create a token for user, else create the user and give them a token
            if(um.SSOUserExists(ssoID))
            {
                User user = um.GetSSOUser(ssoID);
                token = tm.CreateToken(user);

            }
            else
            {
                User user = um.CreateSSOUser(ssoID, email);
                token = tm.CreateToken(user);
            }

            return token;
        }
    }
}
