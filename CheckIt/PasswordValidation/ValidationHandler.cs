using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace CheckIt.PasswordValidation
{
    public class ValidationHandler
    {


        public static async Task<int> ValidatePassword(string password)
        {
            if (password.Length < 5) { return 3; }
            //Create a hash of the password. This is the full hash of the password.
            var passwordHash = Hash(password);
            //Split the hash password into the prefix to be sent. 0 is the starting position, to index 5 of the string.
            var prefix = passwordHash.Substring(0, 5);
            //The suffix will be used to test the result of the API call. 
            var suffix = passwordHash.Substring(5);
            //Create a var to hold the results of the Check method. A String[] will be returned.
            var resultsArray = await PCheck.Check(prefix);
            //Test each string in the returned array to the suffix made earlier.
            foreach (var resultPassword in resultsArray)
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
        //This method will be used to hash the password using SHA1
        //We create a SHA1 object from a library in C#
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
