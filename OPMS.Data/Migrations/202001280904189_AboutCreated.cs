namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AboutSections", "PublishDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.AboutSections", "PulbishDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AboutSections", "PulbishDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.AboutSections", "PublishDateTime");
        }
    }
}
