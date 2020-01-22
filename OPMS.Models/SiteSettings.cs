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

        public string CustomCSS { get; set; }

        public string GoogleSiteVerification { get; set; }
        public string GoogelAds { get; set; }


        public bool IsCustomCSSOn { get; set; }

        public string CustomJS { get; set; }

        public bool IsCustomJsOn { get; set; }

        public DateTime SiteLastUpdated { get; set; }

       
        public string UpdateBy { get; set; }

        //Navigation for Footer
        public string HomeFooter { get; set; }
        public string HomeUrl { get; set; }

        public string AboutFooter { get; set; }
        public string AboutUrl { get; set; }

        public string ContactFooter { get; set; }
        public string ContactUrl { get; set; }

        public string RolesFooter { get; set; }
        public string RolesUrl { get; set; }

        public string ContactNumberFooter { get; set; }
        public string EmailFooter { get; set; }
        public string AddresFooter { get; set; }
        public string ContentFooter { get; set; }
        public string CopyrightFooter { get; set; }

        public string LoginFooter { get; set; }

        public string LoginUrl { get; set; }




    }
}
