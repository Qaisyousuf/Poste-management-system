namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SworkerModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SWorkerPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ButtonUrl = c.String(),
                        ButtonText = c.String(),
                        SubContent = c.String(),
                        GoogleMapAPIUrl = c.String(),
                        IsSWorkertMetaDataOn = c.Boolean(nullable: false),
                        MetaKeywordse = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SWorkerPages");
        }
    }
}
