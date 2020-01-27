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
        [Required(ErrorMessage = "Nom d'utilisateur est nécessaire")]
        [Display(Name = "Nom d'utilisateur")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Entrez le bon e-mail")]
        [Display(Name = "E-mail(facultatif)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est requis")]
        [Display(Name = "Numéro de portable")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Rôles requis")]
        public List<CheckBoxViewModel> Roles { get; set; }
    }
}
