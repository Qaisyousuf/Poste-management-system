using System;

namespace OPMS.Models
{
    public class HelpSupport:EntityBase
    {
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Content { get; set; }
        public string DeveloperName { get; set; }
        public string SoftwareDownload { get; set; }
        public string ProiflePic { get; set; }
        public string DesignedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Email { get; set; }
        public string Skype { get; set; }




    }
}
