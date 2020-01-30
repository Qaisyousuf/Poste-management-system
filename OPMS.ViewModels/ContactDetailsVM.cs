using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
    public class ContactDetailsVM:BaseViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string AreaName { get; set; }

        [Required]
        public string StreetName { get; set; }

        public string GoogleAPIMap { get; set; }

        [Required]
        public string CenterName { get; set; }

        [Required]
        public string CenterEmail { get; set; }

        [Required]
        public string MobileNumber { get; set; }
    }
}
