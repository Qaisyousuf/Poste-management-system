using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class ContactViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress(ErrorMessage = "Enter correct email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Adresse")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Mobile")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        public string IpAddres { get; set; }

        [Required]
        [Display(Name ="Contacted Date")]
        public DateTime ContactedDate { get; set; }

        [Required]
        [Display(Name = "Write more")]
        [DataType(DataType.Text)]
        [AllowHtml]
        public string MessageText { get; set; }

        [Display(Name ="Location")]
        [Required]
        public string ContactedLocation { get; set; }
    }
}
