namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainPostSystemAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainPostSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SentDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PostExpirationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SendedBy = c.String(),
                        HasPost = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        PostSystemId = c.Int(nullable: false),
                        SocialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostSystems", t => t.PostSystemId, cascadeDelete: true)
                .ForeignKey("dbo.SocialWorkers", t => t.SocialId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostSystemId)
                .Index(t => t.SocialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MainPostSystems", "UserId", "dbo.Users");
            DropForeignKey("dbo.MainPostSystems", "SocialId", "dbo.SocialWorkers");
            DropForeignKey("dbo.MainPostSystems", "PostSystemId", "dbo.PostSystems");
            DropIndex("dbo.MainPostSystems", new[] { "SocialId" });
            DropIndex("dbo.MainPostSystems", new[] { "PostSystemId" });
            DropIndex("dbo.MainPostSystems", new[] { "UserId" });
            DropTable("dbo.MainPostSystems");
        }
    }
}
