using OPMS.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class MessageContainerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        public string CreatedBy { get; set; }

    }
}
