using OPMS.Data.Context;
using OPMS.Models;
using System;
using System.Web.Mvc;

namespace OPMS.Web.Infrastructure
{
    public class AdminActivityFilter:FilterAttribute,IActionFilter
    {
        private readonly ContextDb _context;
        public AdminActivityFilter()
        {
            _context = new ContextDb();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated && filterContext.HttpContext.User.IsInRole("Admin"))
            {

                string ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string ActionName = filterContext.ActionDescriptor.ActionName;
                string UserAgint = filterContext.HttpContext.Request.UserAgent;
                string IPaddress = filterContext.HttpContext.Request.UserHostAddress;
                string UserName = filterContext.HttpContext.User.Identity.Name;
                DateTime LoginDate = filterContext.HttpContext.Timestamp;
                string BrowserName = filterContext.HttpContext.Request.Browser.Browser;
                // string userLocation = filterContext.ActionDescriptor.ActionName.Replace("Index", "Login");
                string deviceName = filterContext.HttpContext.Server.MachineName;

                var adminActivity = new AdminActivity
                {
                    Ip = IPaddress,
                    UserAgint = UserAgint,
                    ActionName = ActionName,
                    ControllerName = ControllerName,
                    LoginUser = UserName,
                    UserBrowser = BrowserName,
                    DateTime = LoginDate,
                    DeviceName = deviceName,
                };
                _context.AdminActivities.Add(adminActivity);
                _context.SaveChanges();

                
            }
        }
    }
}