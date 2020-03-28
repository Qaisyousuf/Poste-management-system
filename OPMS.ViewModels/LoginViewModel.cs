using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
