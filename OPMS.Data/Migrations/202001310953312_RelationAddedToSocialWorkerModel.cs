namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationAddedToSocialWorkerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SWBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BTitle = c.String(),
                        BSubTitle = c.String(),
                        BContent = c.String(),
                        BImage = c.String(),
                        BButton = c.String(),
                        BButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SWorkerPages", "BannerId", c => c.Int(nullable: false));
            CreateIndex("dbo.SWorkerPages", "BannerId");
            AddForeignKey("dbo.SWorkerPages", "BannerId", "dbo.SWBanners", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SWorkerPages", "BannerId", "dbo.SWBanners");
            DropIndex("dbo.SWorkerPages", new[] { "BannerId" });
            DropColumn("dbo.SWorkerPages", "BannerId");
            DropTable("dbo.SWBanners");
        }
    }
}
