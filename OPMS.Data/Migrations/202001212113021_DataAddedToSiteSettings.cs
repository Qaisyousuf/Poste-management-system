namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAddedToSiteSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteSettings", "HomeFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "HomeUrl", c => c.String());
            AddColumn("dbo.SiteSettings", "AboutFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "AboutUrl", c => c.String());
            AddColumn("dbo.SiteSettings", "ContactFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "ContactUrl", c => c.String());
            AddColumn("dbo.SiteSettings", "RolesFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "RolesUrl", c => c.String());
            AddColumn("dbo.SiteSettings", "ContactNumberFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "EmailFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "AddresFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "ContentFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "CopyrightFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "LoginFooter", c => c.String());
            AddColumn("dbo.SiteSettings", "LoginUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SiteSettings", "LoginUrl");
            DropColumn("dbo.SiteSettings", "LoginFooter");
            DropColumn("dbo.SiteSettings", "CopyrightFooter");
            DropColumn("dbo.SiteSettings", "ContentFooter");
            DropColumn("dbo.SiteSettings", "AddresFooter");
            DropColumn("dbo.SiteSettings", "EmailFooter");
            DropColumn("dbo.SiteSettings", "ContactNumberFooter");
            DropColumn("dbo.SiteSettings", "RolesUrl");
            DropColumn("dbo.SiteSettings", "RolesFooter");
            DropColumn("dbo.SiteSettings", "ContactUrl");
            DropColumn("dbo.SiteSettings", "ContactFooter");
            DropColumn("dbo.SiteSettings", "AboutUrl");
            DropColumn("dbo.SiteSettings", "AboutFooter");
            DropColumn("dbo.SiteSettings", "HomeUrl");
            DropColumn("dbo.SiteSettings", "HomeFooter");
        }
    }
}
