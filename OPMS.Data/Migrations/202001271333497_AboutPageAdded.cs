namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutPageAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MainTitle = c.String(),
                        BannerImage = c.String(),
                        SubTitle = c.String(),
                        ButtonUrl = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        IsPageMetaDataOn = c.Boolean(nullable: false),
                        MetaKeywordse = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.Boolean(nullable: false),
                        SectoinId = c.Int(nullable: false),
                        ShortSectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AboutSections", t => t.SectoinId, cascadeDelete: true)
                .ForeignKey("dbo.AboutShortSections", t => t.ShortSectionId, cascadeDelete: true)
                .Index(t => t.SectoinId)
                .Index(t => t.ShortSectionId);
            
            CreateTable(
                "dbo.AboutSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        ButtonUrl = c.String(),
                        UrlImages = c.String(),
                        PulbishDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AboutShortSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        MainTitle = c.String(),
                        Content = c.String(),
                        SubContent = c.String(),
                        PublishDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AboutPages", "ShortSectionId", "dbo.AboutShortSections");
            DropForeignKey("dbo.AboutPages", "SectoinId", "dbo.AboutSections");
            DropIndex("dbo.AboutPages", new[] { "ShortSectionId" });
            DropIndex("dbo.AboutPages", new[] { "SectoinId" });
            DropTable("dbo.AboutShortSections");
            DropTable("dbo.AboutSections");
            DropTable("dbo.AboutPages");
        }
    }
}
