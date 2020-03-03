using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class ContactInfoVM:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        [AllowHtml]
        [Required]
        public string Content { get; set; }


        [Required]
        [Display(Name ="Place Name")]
        public string PlaceName { get; set; }


        [Required]
        [Display(Name = "Place address")]
        public string PlaceAddress { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string PlaceContactNumber { get; set; }


        [AllowHtml]
        [Required]
        [Display(Name = "Website")]
        public string WebSite { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }


        [AllowHtml]
        public string GoogleMap { get; set; }
    }
}
