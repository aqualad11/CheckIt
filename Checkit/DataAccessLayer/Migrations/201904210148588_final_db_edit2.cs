namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final_db_edit2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ssoID", c => c.Guid());
            DropColumn("dbo.Users", "DoB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DoB", c => c.DateTime());
            AlterColumn("dbo.Users", "ssoID", c => c.Guid(nullable: false));
        }
    }
}
