using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class ContactDetailsVM:BaseViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="City Name")]
        public string CityName { get; set; }

        [Required]
        [Display(Name = "Area Name")]
        public string AreaName { get; set; }

        [Required]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name ="Google API")]
        [AllowHtml]
        public string GoogleAPIMap { get; set; }

        [Required]
        [Display(Name = "Center Name")]
        public string CenterName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string CenterEmail { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
    }
}
