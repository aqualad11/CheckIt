using System;
using System.Collections.Generic;
using System.Text;
using CheckIt.Authorization;

namespace UserManagement
{
    class Configuration
    {
        private bool authorized;
        public List<string> actions;

        public void Configure(IToken token, string action, string email1, string email2)
        {
            authorized = AuthorizationManager.AuthorizeUserToUser(token, email1, email2, action); //We may need to change this due to instantiation of AuthorizationManager class
            if (authorized)
            {
                actions = retrieveActions(email2);
                updateActions(actions);

                //Call new Token Creation(email, list<strings>)

                storeActions();

            }
            else
            {
                //Error say authorization not granted
            }
        }

        public List<string> retrieveActions(string email2){
            List<string> retrieve = new List<string>();
            //call DAL to query db for email2 dictionary of actions
            return retrieve;
        }

        public void updateActions(List<string> actions){

            //TODO: Store boolean with actions as a Dictionary to toggle each action
            //DAL will have 2 getActions calls. one will return list of just enabled strings, other will return dictionary for this configuration
        
        }

        public void storeActions(){

            //Send to DAL to update user with updated actions
        
        }


    }
}


/*
 * removeAction(string action) //check if action even there
 * addAction(string action) //check if there
 * updateName(string name) // optional split if there's 2 names (lastname)
 * updateLocation(string city,state,country) //
 * updatePassword(newpass, a1,a2,a3)
 * */