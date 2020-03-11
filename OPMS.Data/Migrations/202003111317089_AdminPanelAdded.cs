namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminPanelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminstratorPanels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        AuthenticatedUser = c.String(),
                        AuthenticatedIP = c.String(),
                        LastLoginDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastLoginTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminstratorPanels");
        }
    }
}
