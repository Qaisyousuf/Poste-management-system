using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Nom d'utilisateur est nécessaire")]
        [Display(Name = "Nom d'utilisateur")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Mot de passe requis")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
