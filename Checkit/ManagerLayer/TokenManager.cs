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
        private UserService userService;
        //TODO: store this key elsewhere. put in a Environment variable
        private string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b372742" +
          "9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        public TokenManager(DataBaseContext db)
        {
            tokenService = new TokenService(db);
            userService = new UserService(db);
        }

        /// <summary>
        /// Creates a JWT and adds it to the database
        /// </summary>
        /// <param name="user">UserObject</param>
        /// <returns>The JWT created as a string</returns>
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
                new Claim("userID", user.userID.ToString()),
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

            string jwt = handler.WriteToken(securityToken);

            //add to db
            tokenService.AddToken(jwt, user.userID);

            return jwt;
        }


        /// <summary>
        /// Validates token by checking if expired and if still valid in the Database
        /// </summary>
        /// <param name="jwt"></param>
        /// <returns>Same Token if it is still valid, if it is about to expire then it creates another Token. If it is invalid
        /// it return null</returns>
        public string ValidateToken(string jwt)
        {
            //Paramets which the token will be tested against
            var validationParameters = new TokenValidationParameters()
            {
                RequireSignedTokens = true,
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidIssuer = "CheckIt.gq",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                //Exception caused by line below
                var principal = new JwtSecurityTokenHandler().ValidateToken(jwt, validationParameters, out var rawValidatedToken);

                //Get extract userID from jwt
                Guid userID = ExtractUserID(jwt);

                //checks if token in DB is valid
                if(!tokenService.IsValid(jwt, userID))
                {
                    return null;
                }else if(UnderFiveMin(jwt))//checks if expiration is in the next five minutes if so refresh token
                {
                    return RefreshToken(jwt);
                }
                //return old token
                return jwt;
            }
            catch (SecurityTokenValidationException e)
            {
                //invalid token 
                Console.WriteLine("Security Exception caught. Message = " + e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
            

        }

        /// <summary>
        /// Checks whether the token's expiration time is under five minutes from now
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool UnderFiveMin(string jwt)
        {
            DateTime beginning = new DateTime(1970, 1, 1);

            //time five minutes from now in UTC
            var plusFive = DateTime.UtcNow.AddMinutes(-5);
            //time five minutes from now in seconds
            var nowPlus5 = (Int32)(plusFive.Subtract(beginning)).TotalSeconds;

            JwtSecurityToken token = new JwtSecurityToken(jwt);

            var expTime = (Int32)token.Payload.Exp;

            return expTime < nowPlus5 ? true : false;
        }

        /// <summary>
        /// Gets user from database and gives it a new token
        /// </summary>
        /// <param name="jwt"></param>
        /// <returns></returns>
        private string RefreshToken(string jwt)
        {
            User user = ExtractUser(jwt);

            if (user == null)
            {
                return null;
            }
            
            //TODO: TokenService.Invalidate now returns bool, do something with it.
            //makes current token invalid in the database
            tokenService.Invalidate(jwt, user.userID);
            //return new Token
            return CreateToken(user); 
        }

        /// <summary>
        /// Extracts userEmail from jwt and calls UserService to get and return User
        /// </summary>
        /// <param name="jwt"></param>
        /// <returns></returns>
        public User ExtractUser(string jwt)
        {
            JwtSecurityToken token = new JwtSecurityToken(jwt);
            var claims = token.Payload.Claims as List<Claim>;
            string userID = "";

            //finds email in claims
            foreach(Claim c in claims)
            {
                if(c.Type == "userID")
                {
                    userID = c.Value;
                    break;
                }
            }

            return userService.GetUser(new Guid(userID));
        }

        /// <summary>
        /// Extract user's ID from jwt.
        /// </summary>
        /// <param name="jwt"></param>
        /// <returns></returns>
        private Guid ExtractUserID(string jwt)
        {
            JwtSecurityToken token = new JwtSecurityToken(jwt);
            var claims = token.Payload.Claims as List<Claim>;
            string userID = "";

            //finds email in claims
            foreach (Claim c in claims)
            {
                if (c.Type == "userID")
                {
                    userID = c.Value;
                    break;
                }
            }

            return new Guid(userID);
        }
    }
}
