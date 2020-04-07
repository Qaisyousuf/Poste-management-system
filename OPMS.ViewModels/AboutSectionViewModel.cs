using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class AboutSectionViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Button Url")]
        public string ButtonUrl { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Image Url")]
        public string UrlImages { get; set; }

        [Display(Name = "Publish date")]
        public DateTime PublishDateTime { get; set; }
    }
}
