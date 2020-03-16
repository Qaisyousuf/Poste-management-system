namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminFilterUpated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminActivities", "AuthenticationActivity", c => c.String());
            AddColumn("dbo.UserLocations", "AuthenticationActivity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserLocations", "AuthenticationActivity");
            DropColumn("dbo.AdminActivities", "AuthenticationActivity");
        }
    }
}
