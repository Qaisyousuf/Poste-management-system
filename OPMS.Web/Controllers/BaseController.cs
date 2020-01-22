using OPMS.Data.Interfaces;
using OPMS.Services;
using OPMS.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Unity;
namespace OPMS.Web.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public IUnitOfWork _uow { get; set; }
        [Dependency]
        public IAuthenticationService _authSerivce { get; set; }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ViewResult result = filterContext.Result as ViewResult;

            if(result !=null)
            {
               BaseViewModel baseviewmodel= ViewData.Model as BaseViewModel;
                
               if(baseviewmodel !=null)
                {
                    var site = _uow.Context.SiteSettings.FirstOrDefault();

                    var siteSettings = _uow.Context.SiteSettings.Where(x => x.Id == site.Id).FirstOrDefault();

                    baseviewmodel.SiteName = siteSettings.SiteName;
                    baseviewmodel.SiteFooter = siteSettings.SiteFooter;
                    baseviewmodel.IsRegister = siteSettings.IsRegister;
                    baseviewmodel.FavIcon = siteSettings.FavIconURL;
                    baseviewmodel.SiteOwner = siteSettings.SiteOwner;
                    baseviewmodel.IsCustomCSSOn = siteSettings.IsCustomCSSOn;
                    baseviewmodel.IsCustomJSOn = siteSettings.IsCustomJsOn;
                    baseviewmodel.CustomCSS = siteSettings.CustomCSS;
                    baseviewmodel.CustomJs = siteSettings.CustomJS;
                    baseviewmodel.SiteLastUpdate = siteSettings.SiteLastUpdated;
                    baseviewmodel.HomeFooter = siteSettings.HomeFooter;
                    baseviewmodel.HomeUrlBase = siteSettings.HomeUrl;
                    baseviewmodel.AboutFooter = siteSettings.AboutFooter;
                    baseviewmodel.AboutUrl = siteSettings.AboutUrl;
                    baseviewmodel.ContactFooterBase = siteSettings.ContactFooter;
                    baseviewmodel.ContactUrlBase = siteSettings.ContactUrl;
                    baseviewmodel.RolesFooterBase = siteSettings.RolesFooter;
                    baseviewmodel.RolesUrlBase = siteSettings.RolesUrl;
                    baseviewmodel.ContactNumberFooterBase = siteSettings.ContactNumberFooter;
                    baseviewmodel.EmailFooterBase = siteSettings.EmailFooter;
                    baseviewmodel.AddresFooterBase = siteSettings.AddresFooter;
                    baseviewmodel.ContentFooterBase = siteSettings.ContentFooter;
                    baseviewmodel.CopyrightFooterBase = siteSettings.CopyrightFooter;
                    baseviewmodel.LoginFooter = siteSettings.LoginFooter;
                    baseviewmodel.LoginUrlBase = siteSettings.LoginUrl;
                    baseviewmodel.GoogleSiteVerification = siteSettings.GoogleSiteVerification;
                    baseviewmodel.GoogelAds = siteSettings.GoogelAds;

                    

                    
                    


                }
            }
        }
    }
}