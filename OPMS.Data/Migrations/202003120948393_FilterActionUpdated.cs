namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilterActionUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLocations", "DeviceName", c => c.String());
            DropColumn("dbo.UserLocations", "UserLocationInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserLocations", "UserLocationInfo", c => c.String());
            DropColumn("dbo.UserLocations", "DeviceName");
        }
    }
}
