<<<<<<< HEAD
﻿using CheckIt.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
namespace Checkit
{
    public class DataAccessManager
    {
        public int getHeight(User usr)
        {
            using (var context = new DataBaseContext())
            {
                var height = context.Users.Select(u => u.height).Where(o => o.email.Contains(usr.email));
                return 0;
            }
        }
       // public void addToDB(User usr)
       // {
            //using(var context = new DataBaseContext())
            //{
               // context.addUser(usr);
           // }
       // }
    }
}
*/
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CheckIt.DataAccessLayer
{
    public class DataAccessManager
    {
        private DataBaseContext dbc;

        public DataAccessManager()
        {
            dbc = new DataBaseContext();
        }

        
        
        public int getHeight(string email)
        {
            //try
            //{
                User user = dbc.Users.Where(u => u.userEmail == email).Select(u => u).Single();
                Console.Write("DAM getheight = " + user.height);
                return user.height;
            //}catch (Exception e)
            //{
            //    return -1;
            //}
            
            
        }
        
        public List<string> getActions(string email)
        {
            try
            {
                List<string> actions = new List<string>();
                //var query = dbc.UserActions.Where(a => a.actionEmail == email).Select(a => a);
                //foreach(var act in query)
                //{
                //    actions.Add(act.action);
                //}
                return actions;
            }catch (Exception e)
            {
                return new List<string>();
            }
        }
    }
}
>>>>>>> master
