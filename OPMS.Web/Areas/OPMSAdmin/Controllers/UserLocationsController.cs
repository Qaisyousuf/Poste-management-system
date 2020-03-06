using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [ExceptionFilter]
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
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var locationFromdb = uow.UserLocationRepository.GetById(id);
            var datatime = locationFromdb.DateTime;
            var time = Convert.ToDateTime(datatime.ToShortTimeString());
            var date = Convert.ToDateTime(datatime.ToShortDateString());
            UserLocationVM viewmodel = new UserLocationVM
            {
                Id=locationFromdb.Id,
                Ip=locationFromdb.Ip,
                UserAgint=locationFromdb.UserAgint,
                ActionName=locationFromdb.ActionName,
                ControllerName=locationFromdb.ControllerName,
                LoginUser=locationFromdb.LoginUser,
                UserBrowser=locationFromdb.UserBrowser,
                Date=date,
                Time=time,
                UserLocationInfo=locationFromdb.UserLocationInfo,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            var locationfromdb = uow.UserLocationRepository.GetById(id);

            UserLocationVM viewmodel = new UserLocationVM
            {
                Id=locationfromdb.Id,
                Ip=locationfromdb.Ip,
                UserAgint=locationfromdb.UserAgint,
                ActionName=locationfromdb.ActionName,
                ControllerName=locationfromdb.ControllerName,
                LoginUser=locationfromdb.LoginUser,
                UserBrowser=locationfromdb.UserBrowser,
                Date=locationfromdb.DateTime,
                UserLocationInfo=locationfromdb.UserLocationInfo,
            };

            uow.UserLocationRepository.Remove(locationfromdb);
            uow.Commit();

            return RedirectToAction(nameof(Index));
        }
    }
}