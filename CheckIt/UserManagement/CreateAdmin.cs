using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIt.UserManagement
{
    class CreateAdmin
    {
        public bool checkEmail(string email)
        {
            bool result = true;
            //make call to DAL to check if user already exists
            return result;
        }

        public String GeneratePassword(User user){

            return "test";
            //interpret DAL response
        }

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

        public List<QA> GenerateQuestions(User user){
            List<QA> questions = new List<QA>();
            return questions;
            //interpret DAL response
        }

        public void setFirstLogin(User user){

            user.firstLogin= false;

        }

    }
}
