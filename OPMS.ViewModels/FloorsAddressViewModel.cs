using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class FloorsAddressViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de l'étage est obligatoire")]
        [Display(Name = "Nom des étages")]
        public string FloorsNumber { get; set; }
    }
}
