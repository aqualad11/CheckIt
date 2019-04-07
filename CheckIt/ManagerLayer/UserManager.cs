using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.ServiceLayer;
using CheckIt;
using CheckIt.PasswordValidation;
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

        public void CreateNormalUser()
        {
             
        }
    }
}
