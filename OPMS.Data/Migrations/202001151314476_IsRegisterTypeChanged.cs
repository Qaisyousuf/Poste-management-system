namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsRegisterTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SiteSettings", "Is Site Register", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SiteSettings", "Is Site Register", c => c.String(nullable: false));
        }
    }
}
