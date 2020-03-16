using System;
using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class UserLocationVM
    {
        public int Id { get; set; }

        [Display(Name ="User IP")]
        public string Ip { get; set; }


        [Display(Name = "User Agent")]
        public string UserAgint { get; set; }


        [Display(Name = "Link Nmae")]
        public string ActionName { get; set; }


        [Display(Name = "Page Name")]
        public string ControllerName { get; set; }

        [Display(Name = "User")]
        public string LoginUser { get; set; }

        [Display(Name = "User Browser")]
        public string UserBrowser { get; set; }

        [Display(Name = "Login time Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Login time")]
        public DateTime Time { get; set; }

        [Display(Name = "Device Name")]
        public string DeviceName { get; set; }

        [Display(Name = "Authentcation Activity")]
        public string AuthenticationActivity { get; set; }
    }
}
