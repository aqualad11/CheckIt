namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final_db_edit3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "trackTelData", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "trackTelData");
        }
    }
}
