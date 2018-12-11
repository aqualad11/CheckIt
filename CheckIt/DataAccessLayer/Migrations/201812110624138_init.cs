namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientActions",
                c => new
                    {
                        clientActionID = c.Guid(nullable: false, identity: true),
                        clientID = c.Guid(nullable: false),
                        action = c.String(),
                    })
                .PrimaryKey(t => new { t.clientActionID, t.clientID })
                .ForeignKey("dbo.Clients", t => t.clientID, cascadeDelete: true)
                .Index(t => t.clientID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        clientID = c.Guid(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.clientID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userID = c.Guid(nullable: false, identity: true),
                        userEmail = c.String(),
                        parentID = c.Guid(),
                        clientID = c.Guid(),
                        height = c.Int(nullable: false),
                        fName = c.String(),
                        lName = c.String(),
                        accountType = c.String(),
                        firstLogin = c.Boolean(nullable: false),
                        active = c.Boolean(nullable: false),
                        DoB = c.DateTime(),
                        locCity = c.String(),
                        locState = c.String(),
                        locCountry = c.String(),
                    })
                .PrimaryKey(t => t.userID)
                .ForeignKey("dbo.Clients", t => t.clientID)
                .ForeignKey("dbo.Users", t => t.parentID)
                .Index(t => t.parentID)
                .Index(t => t.clientID);
            
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        actionID = c.Guid(nullable: false, identity: true),
                        userID = c.Guid(nullable: false),
                        action = c.String(),
                    })
                .PrimaryKey(t => new { t.actionID, t.userID })
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientActions", "clientID", "dbo.Clients");
            DropForeignKey("dbo.UserActions", "userID", "dbo.Users");
            DropForeignKey("dbo.Users", "parentID", "dbo.Users");
            DropForeignKey("dbo.Users", "clientID", "dbo.Clients");
            DropIndex("dbo.UserActions", new[] { "userID" });
            DropIndex("dbo.Users", new[] { "clientID" });
            DropIndex("dbo.Users", new[] { "parentID" });
            DropIndex("dbo.ClientActions", new[] { "clientID" });
            DropTable("dbo.UserActions");
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientActions");
        }
    }
}
