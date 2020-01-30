using OPMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class ContactPageViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }

        [AllowHtml]
        [Required]
        public string SubContent { get; set; }

        [Required]
        public string Description { get; set; }

        [AllowHtml]
        [Required]
        public string ImageUrl { get; set; }

        [AllowHtml]
        public string GoogleMapAPIUrl { get; set; }

        public bool IsContactMetaDataOn { get; set; }

        public string MetaKeywordseContact { get; set; }

        public string MetaDescriptionContact { get; set; }

        public bool IsVisibleToSearchEngineContact { get; set; }


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
