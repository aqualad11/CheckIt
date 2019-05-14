namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deployed_db_edit2_tokenlength : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tokens");
            AlterColumn("dbo.Tokens", "jwt", c => c.String(nullable: false, maxLength: 450));
            AddPrimaryKey("dbo.Tokens", new[] { "jwt", "userID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Tokens");
            AlterColumn("dbo.Tokens", "jwt", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Tokens", new[] { "jwt", "userID" });
        }
    }
}
