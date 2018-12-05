using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using CheckIt;
namespace Checkit
{
    public class ValidationHandler
    {
        

        public static int ValidatePassword(string password)
        {
            //Create a hash of the password. This is the full hash of the password.
            var passwordHash = Hash(password);
            var prefix = passwordHash.Substring(0, 5);
            var suffix = passwordHash.Substring(5);
            //PCheck p = new PCheck();
            //p = PCheck.Check(prefix);
            // Create results variable and set it to the results of the response from the API.
            // Note - the Split methods splits the results with "\r\n" - this is used as a new line character in Window.
            // Note - the next call is part of the method param - it states to not keep empty array elemenets of the substring.
            var resultsArray = PCheck.Check(passwordHash);
            //var results = resultsArray.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach ( var resultPassword in resultsArray)
            {
                //Because the result of quary to the API is in the form of the hashed password followed by a column and the 
                //number of times that password is seen,  we split the result by the ':'
                //This makes values into an array, with the hashed password at the 0 index, and the number of times that password is seen
                //at the 1 index.  
                var values = resultPassword.Split(':');
                //Once split, we comapre the hashed password suffix to our own determined suffix. 
                if (suffix == values[0])
                {

                    return 1; //Means that password is a match an insecure
                }
            }
            return 0;
        }
        public static string Hash(string input)
        {
            using (var SHA1 = new SHA1Managed())
            {
                var hash = SHA1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
