namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildingRemoveed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "BuildingId", "dbo.BuildingAddresses");
            DropIndex("dbo.Messages", new[] { "BuildingId" });
            DropColumn("dbo.Messages", "BuildingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "BuildingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "BuildingId");
            AddForeignKey("dbo.Messages", "BuildingId", "dbo.BuildingAddresses", "Id", cascadeDelete: true);
        }
    }
}
