using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.Models
{
    public class ContactMainPage:EntityBase
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Content { get; set; }

        public string SubContent { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string GoogleMapAPIUrl { get; set; }

        public bool IsContactMetaDataOn { get; set; }

        public string MetaKeywordse { get; set; }

        public string MetaDescription { get; set; }

        public bool IsVisibleToSearchEngine { get; set; }


        public int ContactDetailsId { get; set; }
        [ForeignKey("ContactDetailsId")]
        public ContactDetails ContactDetails { get; set; }


        public int ContactInfoId { get; set; }
        [ForeignKey("ContactInfoId")]
        public ContactInfo ContactInfo { get; set; }


        public int ContactFormId { get; set; }
        [ForeignKey("ContactFormId")]
        public Contact ContactForms { get; set; }
    }
}
