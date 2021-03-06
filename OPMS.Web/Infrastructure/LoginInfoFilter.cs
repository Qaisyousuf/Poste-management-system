using OPMS.Data.Context;
using OPMS.Models;
using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OPMS.Web.Infrastructure
{
    public class LoginInfoFilter : FilterAttribute, IActionFilter
    {
        private readonly ContextDb _Context;
        public LoginInfoFilter()
        {
            _Context = new ContextDb();
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.User.Identity.IsAuthenticated && filterContext.HttpContext.User.IsInRole("Resident"))
            {

                string ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string ActionName = filterContext.ActionDescriptor.ActionName;
                string UserAgint = filterContext.HttpContext.Request.UserAgent;
                string IPaddress = filterContext.HttpContext.Request.UserHostAddress;
                string UserName = filterContext.HttpContext.User.Identity.Name;
                DateTime LoginDate = filterContext.HttpContext.Timestamp;
                string BrowserName = filterContext.HttpContext.Request.Browser.Browser;
                string UserAction = filterContext.ActionDescriptor.ActionName.Replace("Index", "Login");
                string deviceName = filterContext.HttpContext.Server.MachineName;

               

                var location = new UserLocation
                {
                    Ip = IPaddress,
                    UserAgint = UserAgint,
                    ActionName = ActionName,
                    ControllerName = ControllerName,
                    LoginUser = UserName,
                    UserBrowser = BrowserName,
                    DateTime = LoginDate,
                    DeviceName = deviceName,
                    AuthenticationActivity=UserAction,
                };

                _Context.UserLocations.Add(location);
                _Context.SaveChanges();
            }
           

        }
    }
}