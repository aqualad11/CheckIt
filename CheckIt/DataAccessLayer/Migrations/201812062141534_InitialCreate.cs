namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        actionEmail = c.String(nullable: false, maxLength: 128),
                        action = c.String(),
                    })
                .PrimaryKey(t => t.actionEmail);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userEmail = c.String(nullable: false, maxLength: 128),
                        userID = c.Long(nullable: false),
                        clientName = c.String(),
                        parentEmail = c.String(maxLength: 128),
                        height = c.Int(nullable: false),
                        fName = c.String(),
                        lName = c.String(),
                        accountType = c.String(),
                        firstLogin = c.Boolean(nullable: false),
                        active = c.Boolean(nullable: false),
                        DoB = c.DateTime(nullable: false),
                        locCity = c.String(),
                        locState = c.String(),
                        locCountry = c.String(),
                    })
                .PrimaryKey(t => t.userEmail)
                .ForeignKey("dbo.Users", t => t.parentEmail)
                .Index(t => t.parentEmail);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "parentEmail", "dbo.Users");
            DropIndex("dbo.Users", new[] { "parentEmail" });
            DropTable("dbo.Users");
            DropTable("dbo.UserActions");
        }
    }
}
