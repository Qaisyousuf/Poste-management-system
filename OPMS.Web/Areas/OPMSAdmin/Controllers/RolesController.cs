using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class RolesController : Controller
    {
        private readonly IUnitOfWork uow;

        public RolesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var roleFromdb = uow.RolesRepository.GetAll();

            List<RoleViewModel> viewmodel = new List<RoleViewModel>();

            foreach (var role in roleFromdb)
            {
                viewmodel.Add(new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    Users = role.Users,
                });
            }

            return View(viewmodel);
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
    }
}