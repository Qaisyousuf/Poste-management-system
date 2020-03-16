using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    //[ExceptionFilter]
    public class AdminActivityController : Controller
    {
        private readonly IUnitOfWork uow;

        public AdminActivityController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAdminActivity()
        {
            var adminfromdb = uow.AdminActivityRepository.GetAll();

            List<AdminActivityVM> viewmodel = new List<AdminActivityVM>();

            foreach (var item in adminfromdb)
            {
                var datatime = item.DateTime;
                var time = Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());
                viewmodel.Add(new AdminActivityVM
                {
                    Id = item.Id,
                    Ip = item.Ip,
                    UserAgint = item.UserAgint,
                    ActionName = item.ActionName,
                    ControllerName = item.ControllerName,
                    LoginUser = item.LoginUser,
                    UserBrowser = item.UserBrowser,
                    Date = date,
                    Time = time,
                    DeviceName = item.DeviceName,
                    AuthenticationActivity = item.AuthenticationActivity,
                });
            }

            return Json(new { data = adminfromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var adminactivity = uow.AdminActivityRepository.GetById(id);
            var datatime = adminactivity.DateTime;
            var time = Convert.ToDateTime(datatime.ToShortTimeString());
            var date = Convert.ToDateTime(datatime.ToShortDateString());
            AdminActivityVM viewmodel = new AdminActivityVM
            {
                Id = adminactivity.Id,
                Ip = adminactivity.Ip,
                UserAgint = adminactivity.UserAgint,
                ActionName = adminactivity.ActionName,
                ControllerName = adminactivity.ControllerName,
                LoginUser = adminactivity.LoginUser,
                UserBrowser = adminactivity.UserBrowser,
                Date = date,
                Time = time,
                DeviceName = adminactivity.ToString(),
                AuthenticationActivity = adminactivity.AuthenticationActivity,
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            var adminActivityfromDb = uow.AdminActivityRepository.GetById(id);

            AdminActivityVM viewmodel = new AdminActivityVM
            {
                Id = adminActivityfromDb.Id,
                Ip = adminActivityfromDb.Ip,
                UserAgint = adminActivityfromDb.UserAgint,
                ActionName = adminActivityfromDb.ActionName,
                ControllerName = adminActivityfromDb.ControllerName,
                LoginUser = adminActivityfromDb.LoginUser,
                UserBrowser = adminActivityfromDb.UserBrowser,
                Date = adminActivityfromDb.DateTime,
                DeviceName = adminActivityfromDb.DeviceName,
                AuthenticationActivity = adminActivityfromDb.AuthenticationActivity,
            };

            uow.AdminActivityRepository.Remove(adminActivityfromDb);
            uow.Commit();

            return RedirectToAction(nameof(Index));
        }
    }
}