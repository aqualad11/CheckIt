using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.ServiceLayer;
using CheckIt;
using CheckIt.DataAccessLayer;

namespace CheckIt.ManagerLayer
{
    public class UserManager
    {
        private UserService userService;
    
        public UserManager(DataBaseContext db)
        {
            userService = new UserService(db);
        }

        public async Task CreateNormalUser(string email, string first, string last, DateTime dob, string atype, string city, string state,
            string country, Guid? clientID, Guid? parentID, string password, string q1, string a1, string q2, string a2, string q3, string a3)
        {
            //check if user exists
            if(userService.userExists(email))
            {
                throw new UserExistsException("Email is already registered in our system");
            }

            //check if user is older than 18
            DateTime now = DateTime.Today;
            TimeSpan age = now - dob;
            int ageInYears = age.Days / 365;

            if(ageInYears < 18)
            {
                throw new TooYoungException("Invalid Date of Birth");
            }

            //checks if password is vulnerable
            int pwnd = await PasswordService.ValidatePassword(password);
            if(pwnd == 1)
            {
                throw new PasswordHackedException("Password is too Vulnerable");
            }

            //get salt and hashed password
            byte[] saltBytes = PasswordService.CreateSalt();
            string passwordHash = PasswordService.GetPasswordHash(password, saltBytes);
            
            //convert salt byte array to string
            string salt = Convert.ToBase64String(saltBytes);

            //check client and parentID

            //create user
            User user = new User(email, first, last, dob, atype, city, state, country, clientID, parentID,
                passwordHash, salt, q1, a1, q2, a2, q3, a3);

            //add User to db
            userService.addUser(user);

        }

    }
}
