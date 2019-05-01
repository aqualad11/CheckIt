using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer.Repositories;

namespace CheckIt.DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //add users with SSO IDs
            using(var dc = new DataBaseContext())
            {
                User usr7 = new User()
                {
                    userEmail = "example7@gmail.com",
                    height = 2,
                    ssoID = Guid.NewGuid(),
                    trackTelData = true
                };

                User usr8 = new User()
                {
                    userEmail = "example8@gmail.com",
                    height = 2,
                    ssoID = Guid.NewGuid(),
                    trackTelData = true
                };

                User usr9 = new User()
                {
                    userEmail = "example9@gmail.com", 
                    height = 2,
                    ssoID = Guid.NewGuid(),
                    trackTelData = true
                };


                //adding users to db
                dc.Users.Add(usr7);
                dc.Users.Add(usr8);
                dc.Users.Add(usr9);

                dc.SaveChanges();
            }
            
            /*--------------------------Data Seeding---------------------------------------------
            using (var dc = new DataBaseContext())
            {
                
                //Creating Clients
                Client c1 = new Client("Finance");
                Client c2 = new Client("IT");
                Client c3 = new Client("Marketing");
                Client c4 = new Client("HR");

                //adding Clients to DB and saving DB
                dc.Clients.Add(c1);
                dc.Clients.Add(c2);
                dc.Clients.Add(c3);
                dc.Clients.Add(c4);
                dc.SaveChanges();


                //seeing their GUIDs
                var financeID = dc.Clients.Where(c => c.name == "Finance").Select(c => c.clientID).SingleOrDefault();
                Console.WriteLine("financeID: " + financeID);
                var ITID = dc.Clients.Where(c => c.name == "IT").Select(c => c.clientID).SingleOrDefault();
                Console.WriteLine("ITID: " + ITID);
                var markID = dc.Clients.Where(c => c.name == "Marketing").Select(c => c.clientID).SingleOrDefault();
                Console.WriteLine("marketng ID: " + markID);
                var HRID = dc.Clients.Where(c => c.name == "HR").Select(c => c.clientID).SingleOrDefault();
                Console.WriteLine("HR ID: " + HRID);

                //creating ClientActions
                ClientAction HRaction1 = new ClientAction(HRID, "Login");
                ClientAction HRaction2 = new ClientAction(HRID, "Update");
                ClientAction HRaction3 = new ClientAction(HRID, "View_Watchlist");
                ClientAction financeAction1 = new ClientAction(financeID, "Login");
                ClientAction financeAction2 = new ClientAction(financeID, "Update");
                ClientAction ITaction1 = new ClientAction(ITID, "Login");
                ClientAction markAction1 = new ClientAction(markID, "Update");
                ClientAction markAction2 = new ClientAction(markID, "View_Watchlist");
                ClientAction markAction3 = new ClientAction(markID, "Search");

                //adding clientactions to db
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
                
                
                //create users
                DateTime DOB = new DateTime(2000, 5, 1);
                User usr1 = new User()
                {
                    userEmail = "example1@gmail.com",
                    clientID = HRID,
                    height = 1,
                    trackTelData = true
                };

                User usr2 = new User()
                {
                    userEmail = "example2@gmail.com",
                    accountType = "user",
                    active = true,
                    clientID = HRID,
                    height = 2,
                    trackTelData = true
                };

                User usr3 = new User()
                {
                    userEmail = "example3@gmail.com",
                    clientID = financeID,
                    height = 2,
                    trackTelData = true
                };

                User usr4 = new User()
                {
                    userEmail = "example4@gmail.com",
                    clientID = ITID,
                    height = 2,
                    trackTelData = true
                };

                User usr5 = new User()
                {
                    userEmail = "example5@gmail.com",
                    clientID = financeID,
                    height = 2,
                    trackTelData = true
                };

                User usr6 = new User()
                {
                    userEmail = "example6@gmail.com",
                    clientID = ITID,
                    height = 2,
                    trackTelData = true
                };
                
                
                //adding users to db
                dc.Users.Add(usr1);
                dc.Users.Add(usr2);
                dc.Users.Add(usr3);
                dc.Users.Add(usr4);
                dc.Users.Add(usr5);
                dc.Users.Add(usr6);

                dc.SaveChanges();

                //getting user IDs
                var usr1ID = dc.Users.Where(u => u.userEmail == "example1@gmail.com").Select(u => u.userID).SingleOrDefault();
                Console.WriteLine("User1's ID: " + usr1ID);
                var usr2ID = dc.Users.Where(u => u.userEmail == "example2@gmail.com").Select(u => u.userID).SingleOrDefault();
                Console.WriteLine("User2's ID: " + usr2ID);
                var usr3ID = dc.Users.Where(u => u.userEmail == "example3@gmail.com").Select(u => u.userID).SingleOrDefault();
                Console.WriteLine("User3's ID: " + usr3ID);
                var usr4ID = dc.Users.Where(u => u.userEmail == "example4@gmail.com").Select(u => u.userID).SingleOrDefault();
                Console.WriteLine("User4's ID: " + usr4ID);
                var usr5ID = dc.Users.Where(u => u.userEmail == "example5@gmail.com").Select(u => u.userID).SingleOrDefault();
                Console.WriteLine("User5's ID: " + usr5ID);
                var usr6ID = dc.Users.Where(u => u.userEmail == "example6@gmail.com").Select(u => u.userID).SingleOrDefault();
                Console.WriteLine("User6's ID: " + usr6ID);


                //Creating Tokens
                Token token1 = new Token("SampleJWT1", usr1ID);
                Token token2 = new Token("SampleJWT2", usr2ID);
                Token token3 = new Token("SampleJWT3", usr3ID);
                Token token4 = new Token("SampleJWT4", usr4ID);
                Token token5 = new Token("SampleJWT5", usr5ID);
                Token token6 = new Token("SampleJWT6", usr6ID);
                
                //Adding tokens to db
                dc.Tokens.Add(token1);
                dc.Tokens.Add(token2);
                dc.Tokens.Add(token3);
                dc.Tokens.Add(token4);
                dc.Tokens.Add(token5);
                dc.Tokens.Add(token6);
                   
                //save db
                dc.SaveChanges();

                
                //creating userActions
                UserAction usr1login = new UserAction(usr1ID, "Login");
                UserAction usr1search = new UserAction(usr1ID, "Search");
                UserAction usr2login = new UserAction(usr2ID, "Login");
                UserAction usr2update = new UserAction(usr2ID, "Update");

                //adding userActions to db
                dc.UserActions.Add(usr1login);
                dc.UserActions.Add(usr1search);
                dc.UserActions.Add(usr2login);
                dc.UserActions.Add(usr2update);

                dc.SaveChanges();

                //creating items
                Item shadesRay = new Item("rayban wayfarer", 123.99, "amazon.com/wayfarer", "raybanwayfarer");
                Item shadesOak = new Item("Oakley", 199.99, "amazon.com/Oakley", "oakley");
                Item monitor = new Item("LG ultrawide", 220.12, "amazon.com/ultrawide", "lgultrawide");

                //adding items to db
                dc.Items.Add(shadesRay);
                dc.Items.Add(shadesOak);
                dc.Items.Add(monitor);

                dc.SaveChanges();

                //getting Item IDs
                var shadesRayID = dc.Items.Where(i => i.ItemName == "rayban wayfarer").Select(i => i.itemID).SingleOrDefault();
                var shadesOakID = dc.Items.Where(i => i.ItemName == "Oakley").Select(i => i.itemID).SingleOrDefault();
                var monitorID = dc.Items.Where(i => i.ItemName == "LG ultrawide").Select(i => i.itemID).SingleOrDefault();

                

                //creating ItemLists
                ItemList usr1List = new ItemList(usr1ID, shadesRayID);
                ItemList usr2List = new ItemList(usr2ID, shadesRayID);
                ItemList usr3List = new ItemList(usr3ID, monitorID);
                ItemList usr3List2 = new ItemList(usr3ID, shadesOakID);


                //adding itemLists to DB
                dc.ItemLists.Add(usr1List);
                dc.ItemLists.Add(usr2List);
                dc.ItemLists.Add(usr3List);
                dc.ItemLists.Add(usr3List2);

                dc.SaveChanges();
                
                

            }*/
            Console.ReadKey();
        }
    }
}
