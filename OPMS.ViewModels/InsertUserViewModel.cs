using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class InsertUserViewModel:BaseViewModel
    {
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
