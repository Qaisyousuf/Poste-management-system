namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddresModelRemoved : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BuildingAddresses");
            DropTable("dbo.FloorsAddresses");
            DropTable("dbo.Rooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FloorsAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FloorsNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BuildingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
