using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer
{
    public class AuthorizationData
    {
        private DataBaseContext dbc;

        public AuthorizationData()
        {
            dbc = new DataBaseContext();
        }



        public int getHeight(string email)
        {
            try
            {
                User user = dbc.Users.Where(u => u.userEmail == email).Select(u => u).SingleOrDefault();
                
                return user.height;
            }catch (Exception e)
            {
                Console.WriteLine("Exception in AuthorizationData.getHeight " + e.ToString());
                return -1;
            }


        }

        public List<string> getUserActions(string email)
        {
            try
            {
                List<string> actions = new List<string>();
                User usr = dbc.Users.Where(u => u.userEmail == email).Select(u => u).SingleOrDefault();
                var userActions = usr.userActions;
                
                foreach (var act in userActions)
                {
                    actions.Add(act.action);
                }
                return actions;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in AuthorizationData.getUserActions "+e.ToString());
                return new List<string>();
            }
        }

        public List<string> getClientActions(string name)
        {
            try
            {
                List<string> actions = new List<string>();
                Client clt = dbc.Clients.Where(u => u.name == name).Select(u => u).SingleOrDefault();
                var clientActions = clt.actions;

                foreach (var act in clientActions)
                {
                    actions.Add(act.action);
                }
                return actions;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in AuthorizationData.getClientActions " + e.ToString());
                return new List<string>();
            }
        }
    }
}
