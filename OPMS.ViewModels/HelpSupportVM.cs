using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class HelpSupportVM
    {
        public int Id { get; set; }

        public string Title { get; set; }


        [Required]
        [Display(Name ="Compay Name")]
        public string CompanyName { get; set; }


        [Required]
        [AllowHtml]
        public string Content { get; set; }


        [Required]
        [Display(Name ="Developer")]
        public string DeveloperName { get; set; }

        [Required]
        [Display(Name ="Project Name")]
        public string SoftwareDownload { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Profile Image")]
        public string ProiflePic { get; set; }

        [Required]
        [Display(Name = "Designed By")]
        public string DesignedBy { get; set; }

        [Display(Name ="Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Skype { get; set; }
    }
}
