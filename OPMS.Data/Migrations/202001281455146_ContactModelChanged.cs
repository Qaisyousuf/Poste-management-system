namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactMainPages", "IsContactMetaDataOn", c => c.Boolean(nullable: false));
            DropColumn("dbo.ContactMainPages", "IsAboutMetaDataOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactMainPages", "IsAboutMetaDataOn", c => c.Boolean(nullable: false));
            DropColumn("dbo.ContactMainPages", "IsContactMetaDataOn");
        }
    }
}
