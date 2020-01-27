namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutPageCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AboutPages", "IsAboutMetaDataOn", c => c.Boolean(nullable: false));
            DropColumn("dbo.AboutPages", "IsPageMetaDataOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AboutPages", "IsPageMetaDataOn", c => c.Boolean(nullable: false));
            DropColumn("dbo.AboutPages", "IsAboutMetaDataOn");
        }
    }
}
