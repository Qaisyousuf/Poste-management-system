using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace OPMS.ViewModels
{
    public class SidebarViewModel:BaseViewModel
    {
        public int Id { get; set; }

        
        [Required]
        public string Name { get; set; }

        [AllowHtml]
        
        [Required]
        public string Content { get; set; }

        [Display(Name = "Publish date")]
        public DateTime PublishDate { get; set; }
    }
}
