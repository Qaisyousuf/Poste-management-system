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
                    baseviewmodel.IsRegister = siteSettings.IsRegister;
                    baseviewmodel.SiteOwner = siteSettings.SiteOwner;
                    baseviewmodel.SiteFooter = siteSettings.SiteFooter;
                    baseviewmodel.FavIcon = siteSettings.FavIconURL;
                    baseviewmodel.GoogleAds = siteSettings.GoogleAds;
                    baseviewmodel.GoogleAnalytics = siteSettings.GoogleAnalytics;
                    baseviewmodel.GoogleSiteVerification = siteSettings.GoogleSiteVerification;
                    baseviewmodel.CustomCSS = siteSettings.CustomCSS;
                    baseviewmodel.IsCustomCSSOn = siteSettings.IsCustomCSSOn;
                    baseviewmodel.CustomJs = siteSettings.CustomJS;
                    baseviewmodel.IsCustomJSOn = siteSettings.IsCustomJsOn;
                    baseviewmodel.SiteLastUpdate = siteSettings.SiteLastUpdated;
                    


                }
            }
        }
    }
}