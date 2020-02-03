namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsInfoAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ButtonUrl = c.String(),
                        ButtonText = c.String(),
                        SubContent = c.String(),
                        PublishDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ImageUrl = c.String(),
                        GoogleMapAPIUrl = c.String(),
                        IsNewsInfotMetaDataOn = c.Boolean(nullable: false),
                        MetaKeywordse = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.Boolean(nullable: false),
                        NewsBannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsBanners", t => t.NewsBannerId, cascadeDelete: true)
                .Index(t => t.NewsBannerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsInfoes", "NewsBannerId", "dbo.NewsBanners");
            DropIndex("dbo.NewsInfoes", new[] { "NewsBannerId" });
            DropTable("dbo.NewsInfoes");
            DropTable("dbo.NewsBanners");
        }
    }
}
