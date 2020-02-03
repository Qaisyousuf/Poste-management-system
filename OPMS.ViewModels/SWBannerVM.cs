using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using OPMS.Models;

namespace OPMS.ViewModels
{
    public class SWBannerVM:BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string BTitle { get; set; }
        [Required]
        public string BSubTitle { get; set; }
        [Required]
        [AllowHtml]
        public string BContent { get; set; }
        [Required]
        [AllowHtml]
        public string BImage { get; set; }
        [Required]
        public string BButton { get; set; }
        [Required]
        public string BButtonUrl { get; set; }
    }
}
