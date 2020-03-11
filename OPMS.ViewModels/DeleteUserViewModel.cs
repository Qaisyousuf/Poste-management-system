using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
   public class DeleteUserViewModel:BaseViewModel
    {
        public DeleteUserViewModel()
        {
            Roles = new List<CheckBoxViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Resident Name")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Enter correct email")]
        [Display(Name = "E-mail(Optional)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password does not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }


        public List<CheckBoxViewModel> Roles { get; set; }
    }
}
