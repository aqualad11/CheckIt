using System;
using System.Collections.Generic;
using System.Text;
using CheckIt.Authorizations;
using CheckIt.DataAccessLayer;

namespace CheckIt.UserManagement
{
    class Deletion
    {
        public void DeleteSelf(User self)
        {
            //make call to DAL to delete where "email"
            //LLD note: DAL will respond with pass/fail
        }


        public void DeleteUser(IToken token, string email1, string email2, string action){
            bool authorized = AuthorizationManager.AuthorizeUserToUser(token, email2, action);
            if (authorized)
            {
                //call DAL to delete query database
            }
            else
            {
                //Error say authorization not granted
            } 
        }

        public void confirmDelete(string email2)
        {
            //Call DAL to Search-query email2
        }

    }
}