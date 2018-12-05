using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement
{
    class CreateUser
    {
        
    
        public bool checkUser(User email)
        {
            //make call to DAL to check if user already exists
            return result;
        }

        public bool checkAge(User dob){
            if(dob.year > 17){
                return true;
            }else{
                return false;
            }
            return;
        }

        public void callDALtoStore(User user){

                //call DAL to store user

        }

        public String interpret(DAL message){

            //interpret DAL response
        }


    }
}
