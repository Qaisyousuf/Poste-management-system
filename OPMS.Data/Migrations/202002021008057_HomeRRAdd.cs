namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeRRAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeBanners",
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
                "dbo.HomeRRs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        IconUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        SubContent = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pages", "BannerId", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "HomeContentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pages", "BannerId");
            CreateIndex("dbo.Pages", "HomeContentId");
            AddForeignKey("dbo.Pages", "BannerId", "dbo.HomeBanners", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pages", "HomeContentId", "dbo.HomeContents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "HomeContentId", "dbo.HomeContents");
            DropForeignKey("dbo.Pages", "BannerId", "dbo.HomeBanners");
            DropIndex("dbo.Pages", new[] { "HomeContentId" });
            DropIndex("dbo.Pages", new[] { "BannerId" });
            DropColumn("dbo.Pages", "HomeContentId");
            DropColumn("dbo.Pages", "BannerId");
            DropTable("dbo.HomeContents");
            DropTable("dbo.HomeRRs");
            DropTable("dbo.HomeBanners");
        }
    }
}
