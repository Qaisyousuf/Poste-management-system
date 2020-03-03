using OPMS.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Models;

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
                string userLocation = filterContext.HttpContext.Server.MachineName;


                var UserLocationinfo = new UserLocation
                {
                    Ip = IPaddress,
                    UserAgint = UserAgint,
                    ActionName = ActionName,
                    ControllerName = ControllerName,
                    LoginUser = UserName,
                    UserBrowser = BrowserName,
                    DateTime = LoginDate,
                    UserLocationInfo = userLocation,
                };

                _Context.UserLocations.Add(UserLocationinfo);
                _Context.SaveChanges();
            }
           

        }
    }
}