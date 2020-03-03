using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
     public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<CheckBoxViewModel>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Resident Name")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage ="Enter correct email")]
        [Display(Name = "E-mail (Optional)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public List<CheckBoxViewModel> Roles { get; set; }
    }
}
