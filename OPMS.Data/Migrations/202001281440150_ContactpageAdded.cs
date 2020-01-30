namespace OPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactpageAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CityName = c.String(),
                        AreaName = c.String(),
                        StreetName = c.String(),
                        GoogleAPIMap = c.String(),
                        CenterName = c.String(),
                        CenterEmail = c.String(),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Contact = c.String(),
                        PlaceName = c.String(),
                        PlaceAddress = c.String(),
                        PlaceContactNumber = c.String(),
                        webSite = c.String(),
                        GoogleMap = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactMainPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        SubContent = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        GoogleMapAPIUrl = c.String(),
                        IsAboutMetaDataOn = c.Boolean(nullable: false),
                        MetaKeywordse = c.String(),
                        MetaDescription = c.String(),
                        IsVisibleToSearchEngine = c.Boolean(nullable: false),
                        ContactDetailsId = c.Int(nullable: false),
                        ContactInfoId = c.Int(nullable: false),
                        ContactFormId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactDetails", t => t.ContactDetailsId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.ContactFormId, cascadeDelete: true)
                .ForeignKey("dbo.ContactInfoes", t => t.ContactInfoId, cascadeDelete: true)
                .Index(t => t.ContactDetailsId)
                .Index(t => t.ContactInfoId)
                .Index(t => t.ContactFormId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactMainPages", "ContactInfoId", "dbo.ContactInfoes");
            DropForeignKey("dbo.ContactMainPages", "ContactFormId", "dbo.Contacts");
            DropForeignKey("dbo.ContactMainPages", "ContactDetailsId", "dbo.ContactDetails");
            DropIndex("dbo.ContactMainPages", new[] { "ContactFormId" });
            DropIndex("dbo.ContactMainPages", new[] { "ContactInfoId" });
            DropIndex("dbo.ContactMainPages", new[] { "ContactDetailsId" });
            DropTable("dbo.ContactMainPages");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.ContactDetails");
        }
    }
}
