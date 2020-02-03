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
        public string SubTitle { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }
        [Required]
        public string SubContent { get; set; }
        [Required]
        public string ButtonText { get; set; }
        [Required]
        public string ButtonUrl { get; set; }
        [Required]
        [AllowHtml]
        public string ImageUrl { get; set; }

    }
}
