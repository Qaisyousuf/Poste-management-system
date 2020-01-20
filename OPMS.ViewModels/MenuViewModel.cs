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
        
        [Display(Name = "titre du menu")]
        [Required(ErrorMessage = "Le titre du menu est obligatoire")]
        public string Title { get; set; }

        [Display(Name = "Description du menu")]
        public string Description { get; set; }

        [Display(Name = "URL du menu")]
        public string Url { get; set; }

        [InverseProperty("SubMenus")]
        [Display(Name = "Sous-menu")]
        public int? ParentId { get; set; }
        public Menu Parent { get; set; }

        [ForeignKey("ParentId")]
        public List<Menu> SubMenus { get; set; }
    }
}
