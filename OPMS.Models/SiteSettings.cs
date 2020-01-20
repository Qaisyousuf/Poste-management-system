using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.Models
{
    public class SiteSettings:EntityBase
    {
        public string SiteName { get; set; }

        public bool IsRegister { get; set; }

        public string SiteFooter { get; set; }

        public string FavIconURL { get; set; }

        public string SiteOwner { get; set; }

        public string GoogleSiteVerification { get; set; }

        public string GoogleAds { get; set; }

        public string GoogleAnalytics { get; set; }

        public string CustomCSS { get; set; }

        public bool IsCustomCSSOn { get; set; }

        public string CustomJS { get; set; }

        public bool IsCustomJsOn { get; set; }

        public DateTime SiteLastUpdated { get; set; }

       
        public string UpdateBy { get; set; }

        
       
    }
}
