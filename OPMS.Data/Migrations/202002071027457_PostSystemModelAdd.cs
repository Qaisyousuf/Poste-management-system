namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostSystemModelAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        PostCreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostSystems");
        }
    }
}
