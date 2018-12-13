<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Text;
/*
namespace CheckIt.UserManagement
{
    class CreateAdmin
    {
        public bool checkUser(User email)
        {
            //make call to DAL to check if user already exists
            //LLD note: DAL sends response
            return result;
        }




        public String interpret(DAL message){

            //interpret DAL response
        }

        public String generatePassword(User user){

            //interpret DAL response
        }

        public array[] questions (User user){

            //interpret DAL response
        }

        public bool firstLogin(User user){
            
            CreateUser newUswer = createUser();
            //if first log in true, call create user

        }

    }
}
*/
=======
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIt.UserManagement
{
    class CreateAdmin
    {

        public User adminMadeUser(String email, String first, String last, DateTime dob, String atype, String city, String state, String country)
        {
            bool cEmail = CreateUser.checkEmail(email);
            if(cEmail && CreateUser.checkAge(dob))
            {
                List<String> actions = CreateUser.createUserActions();
                long userID = CreateUser.generateID();
                String client = "Basic";
                int height = 2;
                long parentID = userID - 1;//TODO: Wtih DAL, get a user where height is 1 less
                User user = new User(email, first, last, dob, atype, city, state, country, actions, client, height, userID, parentID);
                user.firstLogin = true;

                //DAL request to add to DB

                return user;
            }
            else if (cEmail == false)
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

        public RegisteredUser adminMadeRegisteredUser(String email, String q1, String q2, String q3)
        {
            if (CreateUser.checkEmail(email))
            {
                RegisteredUser regUser = new RegisteredUser();
                regUser.email = email;
                regUser.password = CreateUser.CreatePasswordHash(generateRandomPassword());
                regUser.securityQA = GenerateQuestions(q1, q2, q3);
                return regUser;
            }
            else
            {
                Console.Write("Email is already used in the system!");
                return new RegisteredUser();
            }

        }

        public QA GenerateQuestions(string q1, string q2, string q3){
            QA qa = new QA(q1, "", q2, "", q3, "");
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
>>>>>>> master
