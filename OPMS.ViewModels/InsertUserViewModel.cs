using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class InsertUserViewModel:BaseViewModel
    {
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

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mot de passe requis")]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirmer que le mot de passe ne correspond pas")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmez le mot de passe")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Rôles requis")]
        public List<CheckBoxViewModel> Roles { get; set; }

    }
}
