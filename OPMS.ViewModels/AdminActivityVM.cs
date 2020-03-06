using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
    public class AdminActivityVM
    {
        public int Id { get; set; }

        [Display(Name = "User IP")]
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
        public string DeviceName { get; set; }
    }
}
