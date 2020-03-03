using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class SWorkerProfileVM
    {

        public int Id { get; set; }

        [Display(Name ="Image Url")]
        public string ImageUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }


    }
}
