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
                "dbo.BuildingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(),
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
                "dbo.FloorsAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FloorsNumber = c.String(),
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
                "dbo.MessageContainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        SendingDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AppointmentDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SentDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                        MessageContainerId = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        FloorId = c.Int(nullable: false),
                        SocialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuildingAddresses", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("dbo.FloorsAddresses", t => t.FloorId, cascadeDelete: true)
                .ForeignKey("dbo.MessageContainers", t => t.MessageContainerId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.SocialWorkers", t => t.SocialId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MessageContainerId)
                .Index(t => t.BuildingId)
                .Index(t => t.RoomId)
                .Index(t => t.FloorId)
                .Index(t => t.SocialId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialWorkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Position = c.String(),
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
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Slug = c.String(),
                        Content = c.String(),
                        IsPageMetaDataOn = c.Boolean(nullable: false),
                        MetaKeywordse = c.String(),
                        MetaDescription = c.String(),
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
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteName = c.String(nullable: false),
                        IsRegister = c.Boolean(nullable: false),
                        SiteFooter = c.String(),
                        FavIconURL = c.String(),
                        SiteOwner = c.String(nullable: false),
                        CustomCSS = c.String(),
                        GoogleSiteVerification = c.String(),
                        GoogelAds = c.String(),
                        IsCustomCSSOn = c.Boolean(nullable: false),
                        CustomJS = c.String(),
                        IsCustomJsOn = c.Boolean(nullable: false),
                        SiteLastUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateBy = c.String(),
                        HomeFooter = c.String(),
                        HomeUrl = c.String(),
                        AboutFooter = c.String(),
                        AboutUrl = c.String(),
                        ContactFooter = c.String(),
                        ContactUrl = c.String(),
                        RolesFooter = c.String(),
                        RolesUrl = c.String(),
                        ContactNumberFooter = c.String(),
                        EmailFooter = c.String(),
                        AddresFooter = c.String(),
                        ContentFooter = c.String(),
                        CopyrightFooter = c.String(),
                        LoginFooter = c.String(),
                        LoginUrl = c.String(),
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
            DropForeignKey("dbo.Pages", "SidebarId", "dbo.Sidebars");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "SocialId", "dbo.SocialWorkers");
            DropForeignKey("dbo.Messages", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Messages", "MessageContainerId", "dbo.MessageContainers");
            DropForeignKey("dbo.Messages", "FloorId", "dbo.FloorsAddresses");
            DropForeignKey("dbo.Messages", "BuildingId", "dbo.BuildingAddresses");
            DropForeignKey("dbo.Menus", "ParentId", "dbo.Menus");
            DropForeignKey("dbo.BlogPostTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.BlogPostTag", "BlogPostId", "dbo.BlogPosts");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.BlogPostTag", new[] { "TagId" });
            DropIndex("dbo.BlogPostTag", new[] { "BlogPostId" });
            DropIndex("dbo.Pages", new[] { "SidebarId" });
            DropIndex("dbo.Messages", new[] { "SocialId" });
            DropIndex("dbo.Messages", new[] { "FloorId" });
            DropIndex("dbo.Messages", new[] { "RoomId" });
            DropIndex("dbo.Messages", new[] { "BuildingId" });
            DropIndex("dbo.Messages", new[] { "MessageContainerId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.Menus", new[] { "ParentId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.BlogPostTag");
            DropTable("dbo.SiteSettings");
            DropTable("dbo.Sidebars");
            DropTable("dbo.Pages");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.SocialWorkers");
            DropTable("dbo.Rooms");
            DropTable("dbo.Messages");
            DropTable("dbo.MessageContainers");
            DropTable("dbo.Menus");
            DropTable("dbo.FloorsAddresses");
            DropTable("dbo.Contacts");
            DropTable("dbo.BuildingAddresses");
            DropTable("dbo.Tags");
            DropTable("dbo.BlogPosts");
        }
    }
}
