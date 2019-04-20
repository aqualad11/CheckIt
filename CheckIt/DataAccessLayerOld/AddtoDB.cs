using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer
{
    class AddToDB
    {
        public AddToDB()
        {
            Client c1 = new Client("Finance");
            Client c2 = new Client("IT");
            Client c3 = new Client("Marketing");
            Client c4 = new Client("HR");

            using (var dc = new DataBaseContext())
            {
                //dc.Clients.Add(c1);
                //dc.Clients.Add(c2);
                //dc.Clients.Add(c3);
                //dc.Clients.Add(c4);
                //dc.SaveChanges();

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

                //dc.ClientActions.Add(HRaction1);
                //dc.ClientActions.Add(HRaction2);
                //dc.ClientActions.Add(HRaction3);
                //dc.ClientActions.Add(financeAction1);
                //dc.ClientActions.Add(financeAction2);
                //dc.ClientActions.Add(ITaction1);
                //dc.ClientActions.Add(markAction1);
                //dc.ClientActions.Add(markAction2);
                //dc.ClientActions.Add(markAction3);
                //dc.SaveChanges();

                var markactions = dc.ClientActions.Where(m => m.clientID == markID).Select(m => m);
                foreach (var ma in markactions)
                {
                    Console.WriteLine("Marketing ActionL " + ma.action);
                }

                DateTime DOB = new DateTime(2000, 5, 1);
                User usr1 = new User() { fName = "Admin", userEmail = "example1@gmail.com", clientID = HRID, height = 1, DoB = DOB };
                User usr2 = new User() { userEmail = "example2@gmail.com", clientID = HRID, height = 2, DoB = DOB };
                User usr3 = new User() { userEmail = "example3@gmail.com", clientID = financeID, height = 2, DoB = DOB };
                User usr4 = new User() { userEmail = "example4@gmail.com", clientID = ITID, height = 2, DoB = DOB };
                User usr5 = new User() { userEmail = "example5@gmail.com", clientID = financeID, height = 2, DoB = DOB };
                User usr6 = new User() { userEmail = "example6@gmail.com", clientID = ITID, height = 2, DoB = DOB };

                var usr1ID = dc.Users.Where(u => u.userEmail == "example1@gmail.com").Select(u => u.userID).SingleOrDefault();
                Console.WriteLine("User1's ID: " + usr1ID);
                var usr2ID = dc.Users.Where(u => u.userEmail == "example2@gmail.com").Select(u => u.userID).SingleOrDefault();
                Console.WriteLine("User2's ID: " + usr2ID);

                UserAction usr1login = new UserAction(usr1ID, "Login");
                UserAction usr1search = new UserAction(usr1ID, "Search");
                UserAction usr2login = new UserAction(usr2ID, "Login");
                UserAction usr2update = new UserAction(usr2ID, "Update");


                //dc.Users.Add(usr1);
                //dc.Users.Add(usr2);
                //dc.Users.Add(usr3);
                //dc.Users.Add(usr4);
                //dc.Users.Add(usr5);
                //dc.Users.Add(usr6);

                //dc.SaveChanges();

                //dc.UserActions.Add(usr1login);
                //dc.UserActions.Add(usr1search);
                //dc.UserActions.Add(usr2login);
                //dc.UserActions.Add(usr2update);

                //dc.SaveChanges();
            }
            Console.ReadKey();
        }
    }
}
