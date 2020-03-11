namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminPanelUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminstratorPanels", "SubContent", c => c.String());
            AddColumn("dbo.AdminstratorPanels", "ImageUrl", c => c.String());
            DropColumn("dbo.AdminstratorPanels", "AuthenticatedIP");
            DropColumn("dbo.AdminstratorPanels", "LastLoginDate");
            DropColumn("dbo.AdminstratorPanels", "LastLoginTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdminstratorPanels", "LastLoginTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.AdminstratorPanels", "LastLoginDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.AdminstratorPanels", "AuthenticatedIP", c => c.String());
            DropColumn("dbo.AdminstratorPanels", "ImageUrl");
            DropColumn("dbo.AdminstratorPanels", "SubContent");
        }
    }
}
