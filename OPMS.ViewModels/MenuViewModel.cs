using OPMS.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.ViewModels
{
    public class MenuViewModel:BaseViewModel
    {
        public MenuViewModel()
        {
            SubMenus = new List<Menu>();
        }
        public int Id { get; set; }
        
        [Display(Name = "Menu title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Menu Url")]
        public string Url { get; set; }

        [InverseProperty("SubMenus")]
        [Display(Name = "Sub Menu")]
        public int? ParentId { get; set; }
        public Menu Parent { get; set; }

        [ForeignKey("ParentId")]
        public List<Menu> SubMenus { get; set; }
    }
}
