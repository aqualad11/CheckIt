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

            DataAccessManager dm = new DataAccessManager();
            int height = dm.getHeight("example@gmail.com");
            Console.WriteLine("user height = " + height);
            List<string> actions = dm.getActions("Finance");
            foreach(var act in actions)
            {
                Console.WriteLine(act);
            }

            Console.ReadLine();
            /*
            DateTime DOB = new DateTime(2000, 5, 1);
            User usr1 = new User() { userEmail = "example1@gmail.com", clientName = "Finance", height=, DoB = DOB};
            User usr2 = new User() { userEmail = "example2@gmail.com", clientName = "IT", height = 2, DoB = DOB };
            User usr3 = new User() { userEmail = "example3@gmail.com", clientName = "Finance", height = 2, DoB = DOB };
            User usr4 = new User() { userEmail = "example4@gmail.com", clientName = "IT", height = 2, DoB = DOB };
            User usr5 = new User() { userEmail = "example5@gmail.com", clientName = "Finance", height = 2, DoB = DOB };
            User usr6 = new User() { userEmail = "example6@gmail.com", clientName = "IT", height = 2, DoB = DOB };
            //UserAction login = new UserAction("example@gmail.com", "Login");
            //UserAction search = new UserAction("example@gmail.com", "Search");
            //UserAction loginFinance = new UserAction("Finance", "Login");
            //UserAction updateFinance = new UserAction("Finance", "Update");
            
            using (var dc = new DataBaseContext())
            {
                
                dc.Users.Add(usr1);
                dc.Users.Add(usr2);
                dc.Users.Add(usr3);
                dc.Users.Add(usr4);
                dc.Users.Add(usr5);
                dc.Users.Add(usr6);
                dc.SaveChanges();


            }
            */
        }
    }
}
