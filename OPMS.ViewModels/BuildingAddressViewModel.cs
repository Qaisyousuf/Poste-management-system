using OPMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.ViewModels
{
    public class BuildingAddressViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "L'adresse est obligatoire")]
        [Display(Name = "Nom du bâtiment")]
        public string BuildingName { get; set; }
        

    }
}
