using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CheckIt.DataAccessLayer;

namespace CheckIt.ServiceLayer
{
    class Program
    {
        static void Main(string[] args)
        {
           /*
            DataBaseContext db = new DataBaseContext();
            TokenService ts = new TokenService(db);
            User user = new User()
            {
                userEmail = "NonexistanEmail@gmail.com",
                clientID = new Guid(),
                height = 2,
                userActions = new List<UserAction>()
            };

            string jwt = ts.CreateToken(user);
            string jwt2 = ts.CreateToken(user);


            string token = ts.ValidateToken(jwt);

            if(token == null)
            {
                Console.WriteLine("Token is null");
            }else
            {
                Console.WriteLine("Token = " + token);
            }

            JwtSecurityToken tempToken = new JwtSecurityToken(jwt);
            var temp = DateTime.UtcNow.AddMinutes(2);//.Subtract(new DateTime(1970, 1, 1));
            var newTemp = (Int32)(temp.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            var currentTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var expTime = (Int32)tempToken.Payload.Exp;

            //Convert unix to datetime
            //TODO integrate this with TokenService and change TokenService to TokenManager
            DateTime dtime = new DateTime(1970, 1, 1);
            DateTime currTime = dtime.AddSeconds(currentTime);
            DateTime exprTime = dtime.AddSeconds(expTime);

            Console.WriteLine("Unix to curr = " + currTime);
            Console.WriteLine("Unix to exp = " + exprTime);


            Console.WriteLine("Expiration = \t" + newTemp);
            Console.WriteLine("DateTime Exp = \t" + expTime);


            List<Claim> claims = tempToken.Claims as List<Claim>;
            //TODO: figure out how to extract claims to generate new token if time is within two minutes
           
            DateTime time = tempToken.ValidTo;

            var nows = DateTime.UtcNow;
            int n = time.CompareTo(nows);
            if(time < nows)
            {
                Console.WriteLine("time is invalid");
            }
            else if(time > nows)
            {
                Console.WriteLine("time is valid");
                Console.WriteLine("time = " + time);
            }

            var now = DateTime.UtcNow;

            Console.WriteLine("Now = " + nows);
            Console.WriteLine("Past Hopefully = " + now.AddMinutes(-2));
            Console.WriteLine("JWT 1 = " + jwt);
            Console.WriteLine("\n\nJWT 2 = " + jwt2);
            Console.ReadKey();
            */
            
        }
    }
}
