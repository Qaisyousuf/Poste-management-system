namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAddedToSocialProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SWorkerProfiles", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SWorkerProfiles", "ImageUrl");
        }
    }
}
