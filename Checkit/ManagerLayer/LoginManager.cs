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
        private UserManager userManager;
        private TokenManager tokenManager;

        public LoginManager(DataBaseContext db)
        {
            userManager = new UserManager(db);
            tokenManager = new TokenManager(db);
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

            string token;
            //Checks if SSOUser exists, if so create a token for user, else create the user and give them a token
            if(userManager.SSOUserExists(ssoID))
            {
                User user = userManager.GetSSOUser(ssoID);
                token = tokenManager.CreateToken(user);

            }
            else
            {
                User user = userManager.CreateSSOUser(ssoID, email);
                token = tokenManager.CreateToken(user);
                //TelLog with description: "FirstLogin"
            }

            return token;
        }
    }
}
