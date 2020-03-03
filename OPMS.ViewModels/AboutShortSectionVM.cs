using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class AboutShortSectionVM:BaseViewModel
    {
        public int Id { get; set; }


        [Required]
        public string Title { get; set; }


        [Required]
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }


        [Required]
        [Display(Name = "Main Title")]
        public string MainTitle { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }


        [Required]
        [Display(Name = "Sub Content")]
        public string SubContent { get; set; }


        [Display(Name = "Publish Date")]
        public DateTime PublishDateTime { get; set; }
    }
}
