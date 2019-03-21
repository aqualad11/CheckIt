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
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAction> ClientActions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemList> ItemLists { get; set; }

        //
        
        public DataBaseContext()
        {
            //TODO: remove password before submitting to github
            string uName = "SpyderzAdmin";
            string password = "";
            string hostname = "checkitdbinstance.chfkr5vmkp6a.us-east-1.rds.amazonaws.com";
            string port = "1433";
            string dbname = "checkitdbinstance";

            this.Database.Connection.ConnectionString = "Data Source="+hostname+";Initial Catalog=" + dbname+";User ID=" + uName+ ";Password="+password+";";
        }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataBaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }*/

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
