using System;

namespace OPMS.ViewModels
{
    public class BaseViewModel
    {
        public string SiteName { get; set; }
         public string SiteFooter { get; set; }

        public bool?  IsRegister { get; set; }

        public string FavIcon { get; set; }

        public string SiteOwner { get; set; }

        public bool? IsCustomCSSOn { get; set; }

        public string CustomCSS { get; set; }

        public bool? IsCustomJSOn { get; set; }

        public string CustomJs { get; set; }
        public DateTime SiteLastUpdate { get; set; }

        public string GoogleSiteVerification { get; set; }
        public string GoogelAds { get; set; }

        public string LayoutTitle { get; set; }
        public bool? IsMetaDataOn { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescritpion { get; set; }

        public string MetaOgImage { get; set; }
        public bool? IsVisibleToSearchEngine { get; set; }

        public string HomeFooter { get; set; }
        public string HomeUrlBase { get; set; }

        public string AboutFooter { get; set; }
        public string AboutUrl { get; set; }

        public string ContactFooterBase { get; set; }
        public string ContactUrlBase { get; set; }

        public string RolesFooterBase { get; set; }
        public string RolesUrlBase { get; set; }

        public string ContactNumberFooterBase { get; set; }
        public string EmailFooterBase { get; set; }
        public string AddresFooterBase { get; set; }
        public string ContentFooterBase { get; set; }
        public string CopyrightFooterBase { get; set; }
        public string LoginUrlBase { get; set; }
        public string LoginFooter { get; set; }
    }
}
