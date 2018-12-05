using System;
using System.Collections.Generic;
using System.Text;
using CheckIt.Authorization;

namespace UserManagement
{
    class Configuration
    {
        private bool authorized;
        public Dictionary<string, bool> actions;

        public Configure(IToken token, string action, string email1, string email2)
        {
            authorized = AuthorizationManager.AuthorizeUserToUser(token, email2, action); //We may need to change this due to instantiation of AuthorizationManager class
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

        public Dictionary<string, bool> retrieveActions(string email2){

            //call DAL to query db for email2 dictionary of actions
            
        }

        public void updateActions(Dictionary<string, bool> actions){

            //TODO: Store boolean with actions as a Dictionary to toggle each action
            //DAL will have 2 getActions calls. one will return list of just enabled strings, other will return dictionary for this configuration
        
        }

        public void storeActions(){

            //Send to DAL to update user with updated actions
        
        }


    }
}