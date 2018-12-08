using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace CheckIt.DataAccessLayer
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAction> UserActions { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataBaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        
        /*
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<QA> QAs { get; set; }
        public DbSet<itemList> ItemLists { get; set; }
        public DbSet<Item> Items { get; set; }
        */
        //public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        /*
        public void addUser(RegisteredUser regUser)
        {
            using( var context = new DataBaseContext())
            {
                context.RegisteredUsers.Add(regUser);
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
        */
    }
}