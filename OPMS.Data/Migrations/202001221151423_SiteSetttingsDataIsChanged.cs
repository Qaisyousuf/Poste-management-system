namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteSetttingsDataIsChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "PageMetaKeywords", c => c.String());
            AddColumn("dbo.Pages", "PageMetaDescription", c => c.String());
            AddColumn("dbo.Pages", "IsVisibleToSearchEnginePage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "PageGoogleSiteVerification", c => c.String());
            AddColumn("dbo.Pages", "PageGoogleAds", c => c.String());
            AddColumn("dbo.Pages", "PageGoogleAnalytics", c => c.String());
            DropColumn("dbo.Pages", "MetaKeywords");
            DropColumn("dbo.Pages", "MetaDescription");
            DropColumn("dbo.Pages", "IsVisibleToSearchEngine");
            DropColumn("dbo.SiteSettings", "GoogleSiteVerification");
            DropColumn("dbo.SiteSettings", "GoogleAds");
            DropColumn("dbo.SiteSettings", "GoogleAnalytics");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SiteSettings", "GoogleAnalytics", c => c.String());
            AddColumn("dbo.SiteSettings", "GoogleAds", c => c.String());
            AddColumn("dbo.SiteSettings", "GoogleSiteVerification", c => c.String());
            AddColumn("dbo.Pages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "MetaDescription", c => c.String());
            AddColumn("dbo.Pages", "MetaKeywords", c => c.String());
            DropColumn("dbo.Pages", "PageGoogleAnalytics");
            DropColumn("dbo.Pages", "PageGoogleAds");
            DropColumn("dbo.Pages", "PageGoogleSiteVerification");
            DropColumn("dbo.Pages", "IsVisibleToSearchEnginePage");
            DropColumn("dbo.Pages", "PageMetaDescription");
            DropColumn("dbo.Pages", "PageMetaKeywords");
        }
    }
}
