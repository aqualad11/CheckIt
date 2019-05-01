using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer.Repositories;
using CheckIt.DataAccessLayer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;

namespace CheckIt.ServiceLayer
{
    public class TokenService
    {
        private ITokenRepository tokenRepo;
        //TODO: store this key elsewhere. put in a gitIgnore
        private string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b372742" +
          "9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        //private JwtSecurityTokenHandler handler;

        public TokenService(DataBaseContext db)
        {
            tokenRepo = new TokenRepository(db);
        }

        
        public bool IsValid(string jwt, Guid userID)
        {
            Token token = tokenRepo.GetToken(jwt, userID);
            if(token.valid)
            {
                return true;
            }

            return false;
        }


        public bool Invalidate(string jwt, Guid userID)
        {
            try
            {
                Token token = tokenRepo.GetToken(jwt, userID);
                token.valid = false;
                tokenRepo.UpdateToken(token);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public bool AddToken(string jwt, Guid userID)
        {
            try
            {
                Token token = new Token(jwt, userID);
                tokenRepo.AddToken(token);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public bool RemoveToken(string jwt, Guid userID)
        {
            try
            {
                Token token = new Token(jwt, userID);
                tokenRepo.RemoveToken(token);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }



    }
}
