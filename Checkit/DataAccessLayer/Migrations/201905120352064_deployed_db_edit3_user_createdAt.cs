namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deployed_db_edit3_user_createdAt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "createdAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "createdAt");
        }
    }
}
