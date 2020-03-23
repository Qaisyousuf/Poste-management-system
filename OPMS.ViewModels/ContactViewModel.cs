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

        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Enter correct email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Display(Name = "Mobile")]
        
        public string MobileNumber { get; set; }

        public string IpAddres { get; set; }

        [Display(Name ="Contacted Date")]
        public DateTime ContactedDate { get; set; }

        [Display(Name = "Write more")]
        public string MessageText { get; set; }

        [Display(Name ="Location")]
        public string ContactedLocation { get; set; }
    }
}
