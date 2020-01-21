using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.Models
{
    public class Menu:EntityBase
    {
        public Menu()
        {
            SubMenus = new List<Menu>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        [InverseProperty("SubMenus")]
        public int? ParentId { get; set; }
        public  Menu Parent { get; set; }

        [ForeignKey("ParentId")]
        public List<Menu> SubMenus { get; set; }

    }
}
