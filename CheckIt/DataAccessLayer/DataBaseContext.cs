using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Checkit
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public void addUser(string firstName,string lastName, string email, int height)
        {
            User usr = new User(firstName, lastName, email, height);
            using( var context = new DataBaseContext())
            {
                context.Users.Add(usr);
                context.SaveChanges();
            }

        }
        public void addUser(User usr)
        {
            using (var context = new DataBaseContext())
            {
                context.Users.Add(usr);
                context.SaveChanges();
            }

        }

    }
}