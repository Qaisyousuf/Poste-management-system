namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsVisibleToSearchEngineAddedToPageModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "IsVisibleToSearchEngine");
        }
    }
}
