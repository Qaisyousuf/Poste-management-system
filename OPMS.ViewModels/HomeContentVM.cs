using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class HomeContentVM:BaseViewModel
    {
        public int Id { get; set; }


        [Required]
        public string Title { get; set; }


        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }


        [Required]
        [AllowHtml]
        [Display(Name = "Sub Content")]
        public string SubContent { get; set; }


        [Required]
        [Display(Name ="Button Text")]
        public string ButtonText { get; set; }


        [Required]
        [Display(Name = "Button Url")]
        public string ButtonUrl { get; set; }


        [Required]
        [AllowHtml]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

    }
}
