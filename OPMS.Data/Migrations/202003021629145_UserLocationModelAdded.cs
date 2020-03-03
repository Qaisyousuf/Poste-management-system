namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLocationModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ip = c.String(),
                        UserAgint = c.String(),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        LoginUser = c.String(),
                        UserBrowser = c.String(),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserLocationInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLocations");
        }
    }
}
