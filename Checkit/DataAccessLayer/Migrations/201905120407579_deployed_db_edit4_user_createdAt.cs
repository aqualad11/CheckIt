namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deployed_db_edit4_user_createdAt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "createdAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "createdAt", c => c.DateTime());
        }
    }
}
