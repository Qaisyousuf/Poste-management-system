using System;
using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class UserLocationVM
    {
        public int Id { get; set; }

        [Display(Name ="User IP")]
        public string Ip { get; set; }


        [Display(Name = "User Browser")]
        public string UserAgint { get; set; }


        [Display(Name = "Action Nmae")]
        public string ActionName { get; set; }


        [Display(Name = "Controller Name")]
        public string ControllerName { get; set; }

        [Display(Name = "User")]
        public string LoginUser { get; set; }

        [Display(Name = "User ISP")]
        public string UserBrowser { get; set; }

        [Display(Name = "logged in Date")]
        public DateTime Date { get; set; }

        [Display(Name = "logged in Time")]
        public DateTime Time { get; set; }

        [Display(Name = "Device Name")]
        public string UserLocationInfo { get; set; }
    }
}
