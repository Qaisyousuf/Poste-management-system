namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeChangedToDateTime2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoleModels", newName: "Roles");
            RenameTable(name: "dbo.UserModels", newName: "Users");
            AlterColumn("dbo.Contacts", "ContactedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Sidebars", "PublishDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.SiteSettings", "site Last Updated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SiteSettings", "site Last Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sidebars", "PublishDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "ContactedDate", c => c.DateTime(nullable: false));
            RenameTable(name: "dbo.Users", newName: "UserModels");
            RenameTable(name: "dbo.Roles", newName: "RoleModels");
        }
    }
}
