using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.ServiceLayer;

namespace CheckIt.ManagerLayer
{
    public class LogoutManager
    {
        private UserManager userManager;
        private TokenManager tokenManager;

        public LogoutManager(DataBaseContext db)
        {
            userManager = new UserManager(db);
            tokenManager = new TokenManager(db);
        }

        public void SSOLogout(Guid ssoID, string email, long timestamp, string signature)
        {
            //Validate Request
            var signatureService = new SignatureService();
            bool validRequest = signatureService.IsValid(ssoID, email, timestamp, signature);
            if (!validRequest)
            {
                throw new InvalidRequestSignature("Request Signature is not valid.");
            }

            //Check user's existence
            if(!userManager.SSOUserExists(ssoID))
            {
                throw new UserDoesNotExistException("User does not exist");
            }

            //invalide all tokens
            User user = userManager.GetSSOUser(ssoID);
            tokenManager.InvalideAllTokens(user.userID);

        }

        public void CheckItLogout(string jwt)
        {
            Guid userID = tokenManager.ExtractUserID(jwt);
            tokenManager.InvalidateToken(jwt, userID);
        }
    }
}
