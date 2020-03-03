using System;

namespace OPMS.ViewModels
{
    public class UserLocationVM
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string UserAgint { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string LoginUser { get; set; }
        public string UserBrowser { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string UserLocationInfo { get; set; }
    }
}
