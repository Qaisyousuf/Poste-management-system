using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class UserLocationsController : Controller
    {
        private readonly IUnitOfWork uow;

        public UserLocationsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUserLocation()
        {
            var locationFromdb = uow.UserLocationRepository.GetAll();

            List<UserLocationVM> viewmodel = new List<UserLocationVM>();

            foreach (var item in locationFromdb)
            {
                var datatime = item.DateTime;
                var time = Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());
                viewmodel.Add(new UserLocationVM
                {
                    Id=item.Id,
                    Ip=item.Ip,
                    UserAgint=item.UserAgint,
                    ActionName=item.ActionName,
                    ControllerName=item.ControllerName,
                    LoginUser=item.LoginUser,
                    UserBrowser=item.UserBrowser,
                    Date=date,
                    Time=time,
                    UserLocationInfo=item.UserLocationInfo,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
    }
}