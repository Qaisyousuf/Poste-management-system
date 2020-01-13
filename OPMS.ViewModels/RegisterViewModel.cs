using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Nom d'utilisateur")]
        [Required(ErrorMessage = "Nom d'utilisateur est nécessaire")]
        public string UserName { get; set; }

        [Display(Name = "E-mail (facultatif)")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numéro de portable")]
        [Required(ErrorMessage = "le numéro de portable est requis")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Mot de passe requis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmez le mot de passe")]
        [Required(ErrorMessage ="Confirmer le mot de passe est requis")]
        [Compare("Password",ErrorMessage = "confirmer le mot de passe ne correspond pas")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
