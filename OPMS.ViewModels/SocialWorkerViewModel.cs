using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class SocialWorkerViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Le nom du travailleur social est requis")]
        [Display(Name = "Nom du travailleur social")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Position de travail est requis")]
        [Display(Name = "Position de travail")]
        public string Position { get; set; }
    }
}
