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
                        FullName = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        MobileNumber = c.String(nullable: false),
                        IpAddres = c.String(),
                        ContactedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MessageText = c.String(nullable: false),
                        ContactedLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
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
                        Title = c.String(nullable: false),
                        Slug = c.String(),
                        Content = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        IsPageMetaDataOn = c.Boolean(nullable: false),
                        IsVisibleToSearchEngine = c.Boolean(nullable: false),
                        SidebarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sidebars", t => t.SidebarId, cascadeDelete: true)
                .Index(t => t.SidebarId);
            
            CreateTable(
                "dbo.Sidebars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                        SiteName = c.String(nullable: false),
                        IsRegister = c.Boolean(nullable: false),
                        SiteFooter = c.String(),
                        FavIconURL = c.String(),
                        SiteOwner = c.String(nullable: false),
                        GoogleSiteVerification = c.String(),
                        GoogleAds = c.String(),
                        GoogleAnalytics = c.String(),
                        CustomCSS = c.String(),
                        IsCustomCSSOn = c.Boolean(nullable: false),
                        CustomJS = c.String(),
                        IsCustomJsOn = c.Boolean(nullable: false),
                        SiteLastUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateBy = c.String(),
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
            DropForeignKey("dbo.Pages", "SidebarId", "dbo.Sidebars");
            DropForeignKey("dbo.Menus", "ParentId", "dbo.Menus");
            DropForeignKey("dbo.BlogPostTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.BlogPostTag", "BlogPostId", "dbo.BlogPosts");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.BlogPostTag", new[] { "TagId" });
            DropIndex("dbo.BlogPostTag", new[] { "BlogPostId" });
            DropIndex("dbo.Pages", new[] { "SidebarId" });
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
