using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CheckIt.DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthorizationData ad = new AuthorizationData();
            List<string> actions = ad.getUserActions("example1@gmail.com");
            foreach(var a in actions)
            {
                Console.WriteLine(a);
            }

            var userHeight = ad.getHeight("example1@gmail.com");
            Console.WriteLine("User example1@gmail.com Height = " + userHeight);

            Console.WriteLine("Client Finance actions:");
            List<string> clientActions = ad.getClientActions("Finance");
            foreach(var c in clientActions)
            {
                Console.WriteLine(c);
            }

            Console.ReadLine();
        /*
            
            Client c1 = new Client("Finance");
            Client c2 = new Client("IT");
            Client c3 = new Client("Marketing");
            Client c4 = new Client("HR");





            //DateTime DOB = new DateTime(2000, 5, 1);
            //User usr1 = new User() { userEmail = "example1@gmail.com", clientName = "Finance", height=1, DoB = DOB};
            //User usr2 = new User() { userEmail = "example2@gmail.com", clientName = "IT", height = 2, DoB = DOB };
            //User usr3 = new User() { userEmail = "example3@gmail.com", clientName = "Finance", height = 2, DoB = DOB };
            //User usr4 = new User() { userEmail = "example4@gmail.com", clientName = "IT", height = 2, DoB = DOB };
            //User usr5 = new User() { userEmail = "example5@gmail.com", clientName = "Finance", height = 2, DoB = DOB };
            //User usr6 = new User() { userEmail = "example6@gmail.com", clientName = "IT", height = 2, DoB = DOB };
            //UserAction login = new UserAction("example@gmail.com", "Login");
            //UserAction search = new UserAction("example@gmail.com", "Search");
            //UserAction loginFinance = new UserAction("Finance", "Login");
            //UserAction updateFinance = new UserAction("Finance", "Update");
            // Client c1 = new Client() { name = "Finance"}


            using (var dc = new DataBaseContext())
            {
                /*
                dc.Clients.Add(c1);
                dc.Clients.Add(c2);
                dc.Clients.Add(c3);
                dc.Clients.Add(c4);
                dc.SaveChanges();
                */

            /*
            var financeID = dc.Clients.Where(c => c.name == "Finance").Select(c => c.clientID).SingleOrDefault();
            Console.WriteLine("financeID: " + financeID);
            var ITID = dc.Clients.Where(c => c.name == "IT").Select(c => c.clientID).SingleOrDefault();
            Console.WriteLine("ITID: " + ITID);
            var markID = dc.Clients.Where(c => c.name == "Marketing").Select(c => c.clientID).SingleOrDefault();
            Console.WriteLine("marketng ID: " + markID);
            var HRID = dc.Clients.Where(c => c.name == "HR").Select(c => c.clientID).SingleOrDefault();
            Console.WriteLine("HR ID: " + HRID);

            ClientAction HRaction1 = new ClientAction(HRID, "Login");
            ClientAction HRaction2 = new ClientAction(HRID, "Update");
            ClientAction HRaction3 = new ClientAction(HRID, "View_Watchlist");
            ClientAction financeAction1 = new ClientAction(financeID, "Login");
            ClientAction financeAction2 = new ClientAction(financeID, "Update");
            ClientAction ITaction1 = new ClientAction(ITID, "Login");
            ClientAction markAction1 = new ClientAction(markID, "Update");
            ClientAction markAction2 = new ClientAction(markID, "View_Watchlist");
            ClientAction markAction3 = new ClientAction(markID, "Search");

            dc.ClientActions.Add(HRaction1);
            dc.ClientActions.Add(HRaction2);
            dc.ClientActions.Add(HRaction3);
            dc.ClientActions.Add(financeAction1);
            dc.ClientActions.Add(financeAction2);
            dc.ClientActions.Add(ITaction1);
            dc.ClientActions.Add(markAction1);
            dc.ClientActions.Add(markAction2);
            dc.ClientActions.Add(markAction3);
            dc.SaveChanges();

            var markactions = dc.ClientActions.Where(m => m.clientID == markID).Select(m=>m);
            foreach(var ma in markactions)
            {
                Console.WriteLine("Marketing ActionL " + ma.action);
            }

            /*
            //dc.Users.Add(usr1);
            //dc.Users.Add(usr2);
            //dc.Users.Add(usr3);
            //dc.Users.Add(usr4);
            //dc.Users.Add(usr5);
            //dc.Users.Add(usr6);

            //dc.SaveChanges();

            var user = dc.Users.Where(u => u.userEmail == "example1@gmail.com").Select(u => u).SingleOrDefault();
            var userID = user.userID;

            Console.WriteLine("UserID = " + userID);


            UserAction ua1 = new UserAction(userID, "Login");
            UserAction ua2 = new UserAction(userID, "Update");

            //dc.UserActions.Add(ua1);
            //dc.UserActions.Add(ua2);
            //dc.SaveChanges();

            var act = dc.UserActions.Where(a => a.action == "Login").Select(a => a).SingleOrDefault();

            Console.WriteLine("actionID = " + act.actionID);
            //Console.WriteLine("UserId type: " + user.userID.GetType());

            var userActions = user.userActions;
            foreach (UserAction ua in userActions)
            {
                Console.WriteLine("actionID = " + ua.actionID + " action: " + ua.action);
            }

            Console.ReadLine();


        }*/

        }
    }
}
