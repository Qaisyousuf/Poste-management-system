using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class PostSystemVM:BaseViewModel
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

        [Display(Name ="Created By")]
        public string PostCreatedBy { get; set; }
    }
}
