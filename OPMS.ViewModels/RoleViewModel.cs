using OPMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
    public class RoleViewModel:BaseViewModel
    {
        public RoleViewModel()
        {
            Users = new List<UserModel>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name= "Role Name")]
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}
