using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer.Repositories;
using CheckIt.DataAccessLayer;
using CheckIt.ServiceLayer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;

namespace CheckIt.ManagerLayer
{
    public class TokenManager
    {
        
        private TokenService tokenService;
        //TODO: store this key elsewhere. put in a Environment variable
        private string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b372742" +
          "9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        public TokenManager(DataBaseContext db)
        {
            tokenService = new TokenService(db);
        }

        public string CreateToken(User user)
        {
            //var hmac = new HMACSHA256();
            //string key = Convert.ToBase64String(hmac.Key);
            var now = DateTime.UtcNow;
            var handler = new JwtSecurityTokenHandler();
            //using key basically says we are the only ones that can create key
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //user info which will go in the payload
            //add userID
            List<Claim> userInfo = new List<Claim>()
            {
                new Claim("email", user.userEmail),
                new Claim("client", user.clientID.ToString()),
                new Claim("height", user.height.ToString()),
            };


            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(
                issuer: "CheckIt.gq",//may change depending on our sites name
                audience: null,
                claims: userInfo,
                notBefore: null,
                expires: now.AddMinutes(15)//sets expiration at 15 minutes from now
                );

            

            var securityToken = new JwtSecurityToken(header, payload);

            string token = handler.WriteToken(securityToken);

            //add to db


            return token;
        }

        public string ValidateToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters()
            {
                RequireSignedTokens = true,
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidIssuer = "CheckIt.gq",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero//.FromMinutes(Convert.ToInt32(2))
            };

            try
            {
                var principal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out var rawValidatedToken);
                JwtSecurityToken jwt = new JwtSecurityToken(token);


                JwtSecurityToken securityToken = (JwtSecurityToken)rawValidatedToken;
                return handler.WriteToken(securityToken);//converts JwtSecurityToken to a string
            }
            catch (SecurityTokenValidationException e)
            {

                Console.WriteLine("Security Exception caught. Message = " + e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught. Message = " + e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }

        }
    }
}
