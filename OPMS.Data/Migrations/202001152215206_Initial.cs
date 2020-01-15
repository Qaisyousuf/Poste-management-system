namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        BlogPostMetaDataOn = c.Boolean(nullable: false),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        MetaOgImage = c.String(),
                        IsVisibleToSearchEngine = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(name: "Tag Name", nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullNamme = c.String(name: "Full Namme", nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        MobileNumber = c.String(name: "Mobile Number", nullable: false),
                        IpAddres = c.String(),
                        ContactedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Message = c.String(nullable: false),
                        ContactedLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuTitle = c.String(name: "Menu Title"),
                        Description = c.String(),
                        Url = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageTitle = c.String(name: "Page Title", nullable: false),
                        Slug = c.String(),
                        Content = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        IsPageMetaDataOn = c.Boolean(nullable: false),
                        IsVisibleToSearchEngine = c.Boolean(nullable: false),
                        SidebarId = c.Int(name: "Sidebar Id", nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sidebars", t => t.SidebarId, cascadeDelete: true)
                .Index(t => t.SidebarId);
            
            CreateTable(
                "dbo.Sidebars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SidebarName = c.String(name: "Sidebar Name", nullable: false),
                        ContentName = c.String(name: "Content Name", nullable: false),
                        PublishDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(name: "Role Name", nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(),
                        HashPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteName = c.String(name: "Site Name", nullable: false),
                        IsSiteRegister = c.Boolean(name: "Is Site Register", nullable: false),
                        SiteFooter = c.String(name: "Site Footer"),
                        FavIconURL = c.String(),
                        SiteOwner = c.String(name: "Site Owner", nullable: false),
                        GoogleSiteVerification = c.String(name: "Google Site Verification"),
                        GoogleAds = c.String(name: "Google Ads"),
                        GoogleAnalytics = c.String(name: "Google Analytics"),
                        CustomCSS = c.String(),
                        IsCustomCSSOn = c.Boolean(nullable: false),
                        CustomJS = c.String(),
                        IsCustomJsOn = c.Boolean(nullable: false),
                        siteLastUpdated = c.DateTime(name: "site Last Updated", nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(name: "Updated By"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogPostTag",
                c => new
                    {
                        BlogPostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogPostId, t.TagId })
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.BlogPostId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Pages", "Sidebar Id", "dbo.Sidebars");
            DropForeignKey("dbo.Menus", "ParentId", "dbo.Menus");
            DropForeignKey("dbo.BlogPostTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.BlogPostTag", "BlogPostId", "dbo.BlogPosts");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.BlogPostTag", new[] { "TagId" });
            DropIndex("dbo.BlogPostTag", new[] { "BlogPostId" });
            DropIndex("dbo.Pages", new[] { "Sidebar Id" });
            DropIndex("dbo.Menus", new[] { "ParentId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.BlogPostTag");
            DropTable("dbo.SiteSettings");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Sidebars");
            DropTable("dbo.Pages");
            DropTable("dbo.Menus");
            DropTable("dbo.Contacts");
            DropTable("dbo.Tags");
            DropTable("dbo.BlogPosts");
        }
    }
}
