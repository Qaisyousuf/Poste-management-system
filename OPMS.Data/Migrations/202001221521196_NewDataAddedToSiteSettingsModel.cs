namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDataAddedToSiteSettingsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "MetaKeywordsPage", c => c.String());
            AddColumn("dbo.Pages", "MetaDescriptionPage", c => c.String());
            AddColumn("dbo.Pages", "IsVisibleToSearchEnginePage", c => c.Boolean(nullable: false));
            DropColumn("dbo.Pages", "MetaKeywords");
            DropColumn("dbo.Pages", "MetaDescription");
            DropColumn("dbo.Pages", "IsVisibleToSearchEngine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "MetaDescription", c => c.String());
            AddColumn("dbo.Pages", "MetaKeywords", c => c.String());
            DropColumn("dbo.Pages", "IsVisibleToSearchEnginePage");
            DropColumn("dbo.Pages", "MetaDescriptionPage");
            DropColumn("dbo.Pages", "MetaKeywordsPage");
        }
    }
}
