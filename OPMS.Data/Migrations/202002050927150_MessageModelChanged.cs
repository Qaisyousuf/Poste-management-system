namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageModelChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "FloorId", "dbo.FloorsAddresses");
            DropForeignKey("dbo.Messages", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Messages", new[] { "RoomId" });
            DropIndex("dbo.Messages", new[] { "FloorId" });
            AddColumn("dbo.Messages", "AppointmentOrTaskDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Messages", "SendedBy", c => c.String());
            DropColumn("dbo.Messages", "RoomId");
            DropColumn("dbo.Messages", "FloorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FloorId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "RoomId", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "SendedBy");
            DropColumn("dbo.Messages", "AppointmentOrTaskDateTime");
            CreateIndex("dbo.Messages", "FloorId");
            CreateIndex("dbo.Messages", "RoomId");
            AddForeignKey("dbo.Messages", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "FloorId", "dbo.FloorsAddresses", "Id", cascadeDelete: true);
        }
    }
}
