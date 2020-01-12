using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin
{
    public class OPMSAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OPMSAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OPMSAdmin_default",
                "OPMSAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}