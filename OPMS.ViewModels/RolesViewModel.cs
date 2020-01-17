using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using OPMS.Models;
using OPMS.ViewModels;

namespace UItoCode.Web.ViewModels
{
    public class RolesViewModel:BaseViewModel
    {
        public RolesViewModel()
        {
            Users = new List<UserModel>();
        }
        public int Id { get; set; }
      
        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Enter your role name*")]
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}