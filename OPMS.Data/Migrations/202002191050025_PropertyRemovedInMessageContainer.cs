namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyRemovedInMessageContainer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageContainers", "CreatedBy", c => c.String());
            DropColumn("dbo.MessageContainers", "SendingDateTime");
            DropColumn("dbo.MessageContainers", "AppointmentDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MessageContainers", "AppointmentDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.MessageContainers", "SendingDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.MessageContainers", "CreatedBy");
        }
    }
}
