using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class SWBannerVM:BaseViewModel
    {
        public int Id { get; set; }


        [Required]
        [Display(Name ="Title")]
        public string BTitle { get; set; }


        [Required]
        [Display(Name = "Sub Title")]
        public string BSubTitle { get; set; }


        [Required]
        [AllowHtml]
        [Display(Name = "Content")]
        public string BContent { get; set; }


        [Required]
        [AllowHtml]
        [Display(Name = "Image Url")]
        public string BImage { get; set; }


        [Required]
        [Display(Name = "Button Text")]
        public string BButton { get; set; }


        [Required]
        [Display(Name = "Button Url")]
        public string BButtonUrl { get; set; }
    }
}
