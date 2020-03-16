using System;

namespace OPMS.Models
{
    public class AdminActivity:EntityBase
    {
        public string Ip { get; set; }
        public string UserAgint { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string LoginUser { get; set; }
        public string UserBrowser { get; set; }
        public DateTime DateTime { get; set; }
        public string DeviceName { get; set; }
        public string AuthenticationActivity { get; set; }



    }
}
