using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    class RegisteredUser
    {
        public class QA
        {
            public String question { set; get; }
            public String answer { set; get; }
            public QA(String q, String a)
            {
                question = q;
                answer = a;
            }
        }

        public int userID { set; get; }
        public int clientID { set; get; }
        public int parentID { set; get; }
        public int height { set; get; }
        public String email { set; get; }
        public String fName { set; get; }
        public String lName { set; get; }
        public DateTime DoB { set; get; }
        public String accountType { set; get; }
        public Boolean firstLogin { set; get; }
        public Boolean active { set; get; }
        public String locCity { set; get; }
        public String locState { set; get; }
        public String locCountry { set; get; }
        public List<String> actions;
        private string password;
        private List<QA> securityQA;
    }
}
