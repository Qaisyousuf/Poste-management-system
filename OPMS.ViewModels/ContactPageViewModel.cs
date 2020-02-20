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
        [Display(Name = "Google API")]
        public string GoogleMapAPIUrl { get; set; }

        [Display(Name ="Meta Data On")]
        public bool IsContactMetaDataOn { get; set; }

        [Display(Name = "Meta Keywords")]
        public string MetaKeywordseContact { get; set; }

        [Display(Name = "Meta Description")]
        public string MetaDescriptionContact { get; set; }

        [Display(Name = "Search Engine")]
        public bool IsVisibleToSearchEngineContact { get; set; }



        [Display(Name = "Contact Details")]
        public int ContactDetailsId { get; set; }
        [ForeignKey("ContactDetailsId")]
        public ContactDetails ContactDetails { get; set; }


        [Display(Name = "Contact Info")]
        public int ContactInfoId { get; set; }
        [ForeignKey("ContactInfoId")]
        public ContactInfo ContactInfo { get; set; }


        [Display(Name = "Contact Form")]
        public int ContactFormId { get; set; }
        [ForeignKey("ContactFormId")]
        public Contact ContactForms { get; set; }
    }
}
