namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentpropetyAddedToContactInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoes", "Content", c => c.String());
            DropColumn("dbo.ContactInfoes", "Contact");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactInfoes", "Contact", c => c.String());
            DropColumn("dbo.ContactInfoes", "Content");
        }
    }
}
