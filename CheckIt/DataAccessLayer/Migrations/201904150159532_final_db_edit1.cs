namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final_db_edit1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tokens");
            AddPrimaryKey("dbo.Tokens", new[] { "jwt", "userID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Tokens");
            AddPrimaryKey("dbo.Tokens", "jwt");
        }
    }
}
