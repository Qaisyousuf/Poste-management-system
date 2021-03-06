using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class HomeRRViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        [AllowHtml]
        public string Content { get; set; }


        [Required]
        [AllowHtml]
        [Display(Name ="Icon Url")]
        public string IconUrl { get; set; }
    }
}
