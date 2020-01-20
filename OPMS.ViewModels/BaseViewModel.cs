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

        public string GoogleSiteVerification { get; set; }

        public string GoogleAds { get; set; }

        public string GoogleAnalytics { get; set; }
        public bool? IsCustomCSSOn { get; set; }

        public string CustomCSS { get; set; }

        public bool? IsCustomJSOn { get; set; }

        public string CustomJs { get; set; }
        public DateTime SiteLastUpdate { get; set; }

        public string LayoutTitle { get; set; }
        public bool? IsMetaDataOn { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescritpion { get; set; }

        public string MetaOgImage { get; set; }
        public bool? IsVisibleToSearchEngine { get; set; }
    }
}
