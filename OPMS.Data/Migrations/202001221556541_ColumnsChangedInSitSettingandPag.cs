namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnsChangedInSitSettingandPag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "MetaKeywordse", c => c.String());
            AddColumn("dbo.Pages", "MetaDescription", c => c.String());
            AddColumn("dbo.Pages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
            AddColumn("dbo.SiteSettings", "GoogleSiteVerification", c => c.String());
            AddColumn("dbo.SiteSettings", "GoogelAds", c => c.String());
            DropColumn("dbo.Pages", "MetaKeywordsPage");
            DropColumn("dbo.Pages", "MetaDescriptionPage");
            DropColumn("dbo.Pages", "IsVisibleToSearchEnginePage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "IsVisibleToSearchEnginePage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "MetaDescriptionPage", c => c.String());
            AddColumn("dbo.Pages", "MetaKeywordsPage", c => c.String());
            DropColumn("dbo.SiteSettings", "GoogelAds");
            DropColumn("dbo.SiteSettings", "GoogleSiteVerification");
            DropColumn("dbo.Pages", "IsVisibleToSearchEngine");
            DropColumn("dbo.Pages", "MetaDescription");
            DropColumn("dbo.Pages", "MetaKeywordse");
        }
    }
}
