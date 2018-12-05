using System;
using System.Collections.Generic;
using System.Text;
using CheckIt.Authorization;

namespace CheckIt.UserManagement
{
    class Activation
    {
        public static bool authorized;
        public User user1;
        public User user2;

        public void Activate(IToken token, string action, string email1, string email2)
        {
            authorized = AuthorizationManager.AuthorizeUserToUser(token, email1, email2, action); //We may need to change this due to instantiation of AuthorizationManager class
            if (authorized)
            {
                user2 = getUser(email2);
                user2 = SetActivation(user2, action);
                storeUser();
            }
            else
            {
                //Error say authorization not granted
            }
        }

        public User getUser(string email)
        {
            User user = null;//DAL getUser(email)
            return user;
        }

        public User SetActivation(User user, string action)
        {
            if (action == "Activate_User")
            {
                if (user.active)
                {
                    //Error say user is already active
                }
                else
                {
                    user.active = true;
                }
            }
            else if (action == "Deactivate_User")
            {
                if (!user.active)
                {
                    //Error say user is already deactivated
                }
                else
                {
                    user.active = false;
                }
            }
            else{
                //Error say action was not activate or deactivate
            }
            return user;
        }
        public void storeUser()
        {

            //Send to DAL to update user with updated activation

        }
    }
}
