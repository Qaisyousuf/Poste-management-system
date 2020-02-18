using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class AboutSectionViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string MainTitle { get; set; }

        [Required]
        public string SubTitle { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }

        [Required]
        public string ButtonUrl { get; set; }

        [AllowHtml]
        [Required]
        public string UrlImages { get; set; }
   
        public DateTime PublishDateTime { get; set; }
    }
}
