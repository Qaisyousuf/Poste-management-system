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
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewResult result = filterContext.Result as ViewResult;
            if(result !=null)
            {
                BaseViewModel baseviewmodel = ViewData.Model as BaseViewModel;
                if(baseviewmodel !=null)
                {
                    var site = _uow.Context.SiteSettings.FirstOrDefault();

                    var siteSettings = _uow.Context.SiteSettings.FirstOrDefault(x => x.Id == site.Id);

                    baseviewmodel.SiteName = siteSettings.SiteName;

                    baseviewmodel.IsRegister = siteSettings.IsRegister;

                    baseviewmodel.SiteFooter = siteSettings.SiteFooter;
                  
                    baseviewmodel.FavIcon = siteSettings.FavIconURL;
                    
                    baseviewmodel.SiteOwner = siteSettings.SiteOwner;
                    
                    baseviewmodel.GoogleSiteVerification = siteSettings.GoogleSiteVerification;
                    
                    baseviewmodel.GoogleAds = siteSettings.GoogleAds;
                    
                    baseviewmodel.GoogleAnalytics = siteSettings.GoogleAnalytics;

                    baseviewmodel.IsCustomCSSOn = siteSettings.IsCustomCSSOn;
                    
                    baseviewmodel.IsCustomJSOn = siteSettings.IsCustomJsOn;

                    baseviewmodel.CustomCSS = siteSettings.CustomCSS;

                    baseviewmodel.CustomJs = siteSettings.CustomJS;
                    baseviewmodel.SiteLastUpdate = siteSettings.SiteLastUpdated;

                }
            }
           
        }
    }
}