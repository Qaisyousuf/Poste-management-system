using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{

    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class RolesController : Controller
    {
        private readonly IUnitOfWork uow;

        public RolesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            //var roleFromdb = uow.RolesRepository.GetAll();

            //List<RoleViewModel> viewmodel = new List<RoleViewModel>();

            //foreach (var role in roleFromdb)
            //{
            //    viewmodel.Add(new RoleViewModel
            //    {
            //        Id = role.Id,
            //        Name = role.Name,
            //        Users = role.Users,
            //    });
            //}

            return View();
        }
        public JsonResult GetRolesData()
        {
            var roles = uow.RolesRepository.GetAll();
            return Json(new { data = roles }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoleViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                RoleModel roles = new RoleModel
                {
                    Id = viewmodel.Id,
                    Name = viewmodel.Name,
                    Users = viewmodel.Users
                };
                uow.RolesRepository.Add(roles);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
       [HttpGet]
       public ActionResult Edit(int id)
        {
            var rolesfromdb = uow.RolesRepository.GetById(id);

            RoleViewModel viewmodel = new RoleViewModel
            {
                Id = rolesfromdb.Id,
                Name=rolesfromdb.Name,
                Users=rolesfromdb.Users
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(RoleViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var rolesfrodb = uow.RolesRepository.GetById(viewmodel.Id);

                rolesfrodb.Id = viewmodel.Id;
                rolesfrodb.Name = viewmodel.Name;
                uow.RolesRepository.Update(rolesfrodb);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            TempData["Wrong"] = "update is not working";
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var rolesfromdb = uow.RolesRepository.GetById(id);

            RoleViewModel viewmodel = new RoleViewModel
            {
                Id=rolesfromdb.Id,
                Name=rolesfromdb.Name
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var rolesfromdb = uow.RolesRepository.GetById(id);
            uow.RolesRepository.Remove(rolesfromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var role = uow.RolesRepository.GetById(id);

            RoleViewModel viewmodel = new RoleViewModel
            {
                Id=role.Id,
                Name=role.Name,
            };
            return View(viewmodel);
        }

    }
}