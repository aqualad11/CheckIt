using CheckIt.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using CheckIt.DataAccessLayer;


namespace CheckIt.UserManagement{

    class CreateUser { 
        private const int saltByteLength = 24;
        private const int derivedKeyLength = 24;

        public static bool checkEmail(string email)
        {
            bool result = true;
            //make call to DAL to check if user already exists
            return result;
        }

        public static bool checkAge(DateTime dob)
        {
            DateTime now = new DateTime();
            TimeSpan age = now - dob;
            int ageInDays = age.Days;
            int ageInYears = ageInDays / 365;
            if (ageInYears >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public User createUser(String email, String first, String last, DateTime dob, String atype, String city, String state, String country)
        {
            bool emailCheck = checkEmail(email);
            if (emailCheck && checkAge(dob))
            {
                List<String> actions = createUserActions();
                long userID = generateID();
                String client = "Basic";
                int height = 2;
                long parentID = userID - 1;//TODO: Wtih DAL, get a user where height is 1 less

                User user = new User();//(email, first, last, dob, atype, city, state, country, client, height, parentID);

                //DAL request to add to DB

                return user;


            }
            else if (emailCheck == false)
            {
                Console.Write("Email Is already used in the system!");
                return new User();
            }
            else
            {
                Console.Write("You are not of age to access this website!");
                return new User();
            }

        }
        /*
            public RegisteredUser createRegisteredUser(String email, String password, String q1, String a1, String q2, String a2, String q3, String a3)
            {
                bool emailCheck = CreateUser.checkEmail(email);
                if (validatePassword(password) && checkEmail(email)){
                    RegisteredUser regUser = new RegisteredUser();
                    regUser.email = email;
                    regUser.password = CreatePasswordHash(password);
                    regUser.securityQA = new QA(q1, a1, q2, a2, q3, a3);

                    return regUser;
                }
                else if ( emailCheck == false)
                {
                    Console.Write("Email Is already used in the system!");
                    return new RegisteredUser();
                }
                else
                {
                    Console.Write("Password is not valid");
                    return new RegisteredUser();
                }


            }
            */
        public static long generateID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        public static List<String> createUserActions()
        {
            List<String> actions = new List<string>();
            actions.Add("Update_Profile");
            actions.Add("Update_Password");
            actions.Add("Add_Item_To_Watchlist");
            actions.Add("Edit_Price_Threshold");
            actions.Add("View_Watchlist");
            actions.Add("Delete_Self");

            return actions;
        }

        public static string CreatePasswordHash(string password)
        {
            var salt = GenerateRandomSalt();
            var iterationCount = 1000;
            var hashValue = GenerateHashValue(password, salt, iterationCount);
            var iterationCountBtyeArr = BitConverter.GetBytes(iterationCount);
            var valueToSave = new byte[saltByteLength + derivedKeyLength + iterationCountBtyeArr.Length];
            Buffer.BlockCopy(salt, 0, valueToSave, 0, saltByteLength);
            Buffer.BlockCopy(hashValue, 0, valueToSave, saltByteLength, derivedKeyLength);
            Buffer.BlockCopy(iterationCountBtyeArr, 0, valueToSave, salt.Length + hashValue.Length, iterationCountBtyeArr.Length);
            return Convert.ToBase64String(valueToSave);
        }

        private static byte[] GenerateRandomSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[saltByteLength];
            csprng.GetBytes(salt);
            return salt;
        }

        private static byte[] GenerateHashValue(string password, byte[] salt, int iterationCount)
        {
            byte[] hashValue;
            var valueToHash = string.IsNullOrEmpty(password) ? string.Empty : password;
            using (var pbkdf2 = new Rfc2898DeriveBytes(valueToHash, salt, iterationCount))
            {
                hashValue = pbkdf2.GetBytes(derivedKeyLength);
            }
            return hashValue;
        }

        public Boolean validatePassword(string password)
        {
            if (password.Length > 11 && password.Length < 2001)
            {
                return true;
            }
            return false;
        }
    }
    
}
/*
 * TODO Feb-2019
 * Match Create user to SSO
 * Create a Finish User method for First time login
 */



/*
 * TODO:
 * done......................Do the main create user method
 * Add configurations for the rest of a user POCO(Location, Name, Security QA)
 * Edit configuration for actions, 
 * add actual Config method
 * done......................CreateAdmin: Password generator, main create that calls createUser once temporary info is in
 * Deletion: DAL things only
 * done......................go over registered user usage and IUser
 * */

