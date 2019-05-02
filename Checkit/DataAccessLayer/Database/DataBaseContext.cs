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
        public DbSet<Token> Tokens { get; set; }

        //
        
        public DataBaseContext()
        {
            
            //TODO: remove password before submitting to github
            string uName = "SpyderzAdmin";
            string password = "";
            string hostname = "checkitdbinstance.ck6ojdbpsmcj.us-west-1.rds.amazonaws.com";

            //string port = "1433";
            string dbname = "CheckitDBInstance";

            this.Database.Connection.ConnectionString = "Data Source="+hostname+";Initial Catalog=" + dbname+";User ID=" + uName+ ";Password="+password+";";
            
        }

    }
}
