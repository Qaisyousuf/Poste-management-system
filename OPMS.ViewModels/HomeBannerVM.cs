using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class HomeBannerVM:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        [AllowHtml]
        public string ImageUrl { get; set; }
        [Required]
        public string ButtonText { get; set; }
        [Required]
        public string ButtonUrl { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }

    }
}
