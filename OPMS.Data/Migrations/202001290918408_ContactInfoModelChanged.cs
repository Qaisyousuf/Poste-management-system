namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactInfoModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoes", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactInfoes", "PostalCode");
        }
    }
}
