using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIt.UserManagement
{
    class CreateAdmin
    {

        public void adminMadeUser(String email, String first, String last, DateTime dob, String atype, String city, String state, String country, String q1, String q2, String q3)
        {
            if(CreateUser.checkEmail(email) && CreateUser.checkAge(dob))
            {
                User user = new User();
                user.email = email;
                user.fName = first;
                user.lName = last;
                user.DoB = dob;
                user.accountType = atype;
                user.locCity = city;
                user.locState = state;
                user.locCountry = country;
                user.firstLogin = true;
                user.active = true;
                user.height = 2;
                user.actions = CreateUser.createUserActions();
                //UserID, ParentID, ClientID


                RegisteredUser regUser = new RegisteredUser();
                regUser.email = email;
                regUser.password = CreateUser.CreatePasswordHash(generateRandomPassword());
                regUser.securityQA = GenerateQuestions(q1, q2, q3);

                //DAL request to add to DB
            }
        }

        public List<QA> GenerateQuestions(string q1, string q2, string q3){
            List<QA> qa = new List<QA>();
            qa[0].question = q1;
            qa[0].answer = "";
            qa[1].question = q2;
            qa[1].answer = "";
            qa[2].question = q3;
            qa[2].answer = "";
            return qa;
        }

        public string generateRandomPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[15];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            string final = new String(stringChars);
            return final;

        }

    }
}
