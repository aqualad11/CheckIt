namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final_db_init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientActions",
                c => new
                    {
                        clientID = c.Guid(nullable: false),
                        action = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.clientID, t.action })
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
                        ssoID = c.Guid(nullable: false),
                        height = c.Int(nullable: false),
                        accountType = c.String(),
                        active = c.Boolean(nullable: false),
                        DoB = c.DateTime(),
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
                        userID = c.Guid(nullable: false),
                        action = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.userID, t.action })
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.ItemLists",
                c => new
                    {
                        userID = c.Guid(nullable: false),
                        itemID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.userID, t.itemID })
                .ForeignKey("dbo.Items", t => t.itemID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID)
                .Index(t => t.itemID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        itemID = c.Guid(nullable: false, identity: true),
                        ItemName = c.String(),
                        price = c.Double(nullable: false),
                        url = c.String(),
                        picKey = c.String(),
                    })
                .PrimaryKey(t => t.itemID);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        jwt = c.String(nullable: false, maxLength: 128),
                        userID = c.Guid(nullable: false),
                        valid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.jwt)
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "userID", "dbo.Users");
            DropForeignKey("dbo.ItemLists", "userID", "dbo.Users");
            DropForeignKey("dbo.ItemLists", "itemID", "dbo.Items");
            DropForeignKey("dbo.ClientActions", "clientID", "dbo.Clients");
            DropForeignKey("dbo.UserActions", "userID", "dbo.Users");
            DropForeignKey("dbo.Users", "parentID", "dbo.Users");
            DropForeignKey("dbo.Users", "clientID", "dbo.Clients");
            DropIndex("dbo.Tokens", new[] { "userID" });
            DropIndex("dbo.ItemLists", new[] { "itemID" });
            DropIndex("dbo.ItemLists", new[] { "userID" });
            DropIndex("dbo.UserActions", new[] { "userID" });
            DropIndex("dbo.Users", new[] { "clientID" });
            DropIndex("dbo.Users", new[] { "parentID" });
            DropIndex("dbo.ClientActions", new[] { "clientID" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Items");
            DropTable("dbo.ItemLists");
            DropTable("dbo.UserActions");
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientActions");
        }
    }
}
