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


            Console.WriteLine("Hello World");
            Console.ReadLine();
            
            
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

            
            //using (var dc = new DataBaseContext())
            //{
                
            //    //dc.Users.Add(usr1);
            //    //dc.Users.Add(usr2);
            //    //dc.Users.Add(usr3);
            //    //dc.Users.Add(usr4);
            //    //dc.Users.Add(usr5);
            //    //dc.Users.Add(usr6);
              
            //    //dc.SaveChanges();

            //    var user = dc.Users.Where(u => u.userEmail == "example1@gmail.com").Select(u => u).SingleOrDefault();
            //    var userID = user.userID;

            //    Console.WriteLine("UserID = "+userID);
               

            //    UserAction ua1 = new UserAction(userID, "Login");
            //    UserAction ua2 = new UserAction(userID, "Update");

            //    //dc.UserActions.Add(ua1);
            //    //dc.UserActions.Add(ua2);
            //    //dc.SaveChanges();

            //    var act = dc.UserActions.Where(a => a.action == "Login").Select(a => a).SingleOrDefault();

            //    Console.WriteLine("actionID = " + act.actionID);
            //    //Console.WriteLine("UserId type: " + user.userID.GetType());

            //    var userActions = user.userActions;
            //    foreach(UserAction ua in userActions )
            //    {
            //        Console.WriteLine("actionID = " + ua.actionID + " action: " + ua.action);
            //    }

            //    Console.ReadLine();


            //}
            
        }
    }
}
