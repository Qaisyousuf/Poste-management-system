using System;

namespace OPMS.Models
{
    public class Contact:EntityBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string IpAddres { get; set; }
        public DateTime ContactedDate { get; set; }
        public string MessageText { get; set; }
        public string ContactedLocation { get; set; }


    }
}
