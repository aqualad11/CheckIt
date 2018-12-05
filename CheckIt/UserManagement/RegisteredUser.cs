using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.UserManagement
{
    public class RegisteredUser
    {

        public String email { set; get; }
        public string password { set; get; }
        public List<QA> securityQA { set; get; }

        public RegisteredUser()
        {

        }

        public RegisteredUser(String email, string password, List<QA> qa)
        {
            this.email = email;
            this.password = password;
            this.securityQA = qa;
        }
    }

}
