using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class AdminstratorPanelVM:BaseViewModel
    {
        public int Id { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Sub Content")]
        public string SubContent { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Display(Name = "Authenticated User")]
        public string AuthenticatedUser { get; set; }


        [Required]
        [Display(Name = "Image Url")]
        [AllowHtml]
        public string ImageUrl { get; set; }
    }
}
