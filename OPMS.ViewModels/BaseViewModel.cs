using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
    public class BaseViewModel
    {
        public string SiteName { get; set; }
         public string SiteFooter { get; set; }

        public bool  IsRegister { get; set; }

        public string FavIcon { get; set; }

        public string SiteOwner { get; set; }

        public string GoogleSiteVerification { get; set; }

        public bool IsCustomCSSOn { get; set; }

        public string CustomCSS { get; set; }

        public bool IsCustomJSOn { get; set; }

        public string CustomJs { get; set; }
        public DateTime SiteLastUpdate { get; set; }
        
    }
}
