namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAddedToSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "MetaKeywords", c => c.String());
            AddColumn("dbo.Pages", "MetaDescription", c => c.String());
            AddColumn("dbo.Pages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
            DropColumn("dbo.Pages", "PageMetaKeywords");
            DropColumn("dbo.Pages", "PageMetaDescription");
            DropColumn("dbo.Pages", "IsVisibleToSearchEnginePage");
            DropColumn("dbo.Pages", "PageGoogleSiteVerification");
            DropColumn("dbo.Pages", "PageGoogleAds");
            DropColumn("dbo.Pages", "PageGoogleAnalytics");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "PageGoogleAnalytics", c => c.String());
            AddColumn("dbo.Pages", "PageGoogleAds", c => c.String());
            AddColumn("dbo.Pages", "PageGoogleSiteVerification", c => c.String());
            AddColumn("dbo.Pages", "IsVisibleToSearchEnginePage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "PageMetaDescription", c => c.String());
            AddColumn("dbo.Pages", "PageMetaKeywords", c => c.String());
            DropColumn("dbo.Pages", "IsVisibleToSearchEngine");
            DropColumn("dbo.Pages", "MetaDescription");
            DropColumn("dbo.Pages", "MetaKeywords");
        }
    }
}
