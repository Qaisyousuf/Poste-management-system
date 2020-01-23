namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(),
                        FloorId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FloorsAddresses", t => t.FloorId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.FloorId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.FloorsAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FloorsNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageContainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        SendingDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AppointmentDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                        SocialId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuildingAddresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.SocialWorkers", t => t.SocialId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SocialId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.SocialWorkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageContainers", "UserId", "dbo.Users");
            DropForeignKey("dbo.MessageContainers", "SocialId", "dbo.SocialWorkers");
            DropForeignKey("dbo.MessageContainers", "AddressId", "dbo.BuildingAddresses");
            DropForeignKey("dbo.BuildingAddresses", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.BuildingAddresses", "FloorId", "dbo.FloorsAddresses");
            DropIndex("dbo.MessageContainers", new[] { "AddressId" });
            DropIndex("dbo.MessageContainers", new[] { "SocialId" });
            DropIndex("dbo.MessageContainers", new[] { "UserId" });
            DropIndex("dbo.BuildingAddresses", new[] { "RoomId" });
            DropIndex("dbo.BuildingAddresses", new[] { "FloorId" });
            DropTable("dbo.SocialWorkers");
            DropTable("dbo.MessageContainers");
            DropTable("dbo.Rooms");
            DropTable("dbo.FloorsAddresses");
            DropTable("dbo.BuildingAddresses");
        }
    }
}
