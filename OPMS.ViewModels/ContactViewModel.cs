using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class ContactViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nom complet")]
        [Required(ErrorMessage ="Le nom est requis")]
        public string FullName { get; set; }

        [Display(Name = "Adresse e-mail facultative")]
        [EmailAddress(ErrorMessage = "adresse e-mail complète")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Display(Name = "Numéro de mobile Facultatif")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        public string IpAddres { get; set; }

        public DateTime ContactedDate { get; set; }

        [Display(Name = "Votre texte ici")]
        public string MessageText { get; set; }

        public string ContactedLocation { get; set; }
    }
}
