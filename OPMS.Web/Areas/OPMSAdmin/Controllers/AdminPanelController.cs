using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Models;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class AdminPanelController : Controller
    {
        private readonly IUnitOfWork uow;

        public AdminPanelController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAdminPanelData()
        {
            var adminFromdb = uow.AdminPanelInfo.GetAll();

            return Json(new { data = adminFromdb }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdminstratorPanelVM viewmodel)
        {
           if(ModelState.IsValid)
            {
                AdminstratorPanel adminPanel = new AdminstratorPanel
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    SubContent = viewmodel.SubContent,
                    AuthenticatedUser = User.Identity.Name,
                    Content = viewmodel.Content,
                    ImageUrl = viewmodel.ImageUrl,
                };
                uow.AdminPanelInfo.Add(adminPanel);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var adminFromdb = uow.AdminPanelInfo.GetById(id);

            AdminstratorPanelVM viewmodel = new AdminstratorPanelVM
            {
                Id=adminFromdb.Id,
                Title=adminFromdb.Title,
                SubContent=adminFromdb.SubContent,
                Content=adminFromdb.Content,
                ImageUrl=adminFromdb.ImageUrl,
                AuthenticatedUser=adminFromdb.AuthenticatedUser,
            };


            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(AdminstratorPanelVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var admainFromdb = uow.AdminPanelInfo.GetById(viewmodel.Id);

                admainFromdb.Id = viewmodel.Id;
                admainFromdb.Title = viewmodel.Title;
                admainFromdb.SubContent = viewmodel.SubContent;
                admainFromdb.Content = viewmodel.Content;
                admainFromdb.ImageUrl = viewmodel.ImageUrl;
                admainFromdb.AuthenticatedUser = User.Identity.Name;

                uow.AdminPanelInfo.Update(admainFromdb);
                uow.Commit();
                return RedirectToAction(nameof(Index));

            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var adminFromdb = uow.AdminPanelInfo.GetById(id);

            AdminstratorPanelVM viewmodel = new AdminstratorPanelVM
            {
                Id = adminFromdb.Id,
                Title = adminFromdb.Title,
                SubContent = adminFromdb.SubContent,
                Content = adminFromdb.Content,
                AuthenticatedUser=adminFromdb.AuthenticatedUser,
                ImageUrl = adminFromdb.ImageUrl,

            };

            return View(viewmodel);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var adminfromdb = uow.AdminPanelInfo.GetById(id);

            AdminstratorPanelVM viewmodel = new AdminstratorPanelVM
            {
                Id=adminfromdb.Id,
                Title=adminfromdb.Title,
                SubContent=adminfromdb.SubContent,
                Content=adminfromdb.Content,
                AuthenticatedUser=adminfromdb.AuthenticatedUser,
                ImageUrl=adminfromdb.ImageUrl,
            };

            uow.AdminPanelInfo.Remove(adminfromdb);
            uow.Commit();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var adminFromdb = uow.AdminPanelInfo.GetById(id);

            AdminstratorPanelVM viewmodel = new AdminstratorPanelVM
            {
                Id = adminFromdb.Id,
                Title = adminFromdb.Title,
                SubContent = adminFromdb.SubContent,
                Content = adminFromdb.Content,
                AuthenticatedUser = adminFromdb.AuthenticatedUser,
                ImageUrl = adminFromdb.ImageUrl,

            };

            return View(viewmodel);
        }
      
    }
}