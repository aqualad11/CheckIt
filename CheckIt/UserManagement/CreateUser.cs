using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


namespace CheckIt.UserManagement
{
    class CreateUser
    {

        private const int saltByteLength = 24;
        private const int derivedKeyLength = 24;

        public bool checkEmail(string email)
        {
            bool result = true; 
            //make call to DAL to check if user already exists
            return result;
        }

        public bool checkAge(DateTime dob){
            DateTime now = new DateTime();
            TimeSpan age = now - dob;
            int ageInDays = age.Days;
            int ageInYears = ageInDays / 365;
            if (ageInYears >= 18){
                return true;
            }else{
                return false;
            }
        }

        public string CreatePasswordHash(string password)
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

        public void storeUser(User user){

                //call DAL to store user

        }

    }
}



/*
 * TODO:
 * Do the main create user method
 * Add configurations for the rest of a user POCO(Location, Name, Security QA)
 * Edit configuration for actions, 
 * add actual Config method
 * CreateAdmin: Password generator, main create that calls createUser once temporary info is in
 * Deletion: DAL things only
 * Go over registered user usage and IUser
 * */