namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SocialProfileAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SWorkerProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FullName = c.String(),
                        JobTitle = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SWorkerProfiles");
        }
    }
}
