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
    public class BuildingAddresController : Controller
    {
        private readonly IUnitOfWork uow;

        public BuildingAddresController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult GetBuildingaddres()
        {
            var building = uow.BuildingRepository.GetAll();
            return Json(new { data = building }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BuildingAddressViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                BuildingAddress address = new BuildingAddress
                {
                    Id=viewmodel.Id,
                    BuildingName=viewmodel.BuildingName
                };
                uow.BuildingRepository.Add(address);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var building = uow.BuildingRepository.GetById(id);

            BuildingAddressViewModel viewmodel = new BuildingAddressViewModel
            {
                Id=building.Id,
                BuildingName=building.BuildingName
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(BuildingAddressViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var building = uow.BuildingRepository.GetById(viewmodel.Id);

                building.Id = viewmodel.Id;
                building.BuildingName = viewmodel.BuildingName;

                uow.BuildingRepository.Update(building);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var building = uow.BuildingRepository.GetById(id);

            BuildingAddressViewModel viewmodel = new BuildingAddressViewModel
            {
                Id=building.Id,
                BuildingName=building.BuildingName
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfimrDelete(int? id)
        {
            var building = uow.BuildingRepository.GetById(id);

            BuildingAddressViewModel viewmodel = new BuildingAddressViewModel
            {
                Id=building.Id,
                BuildingName=building.BuildingName,
            };
            uow.BuildingRepository.Remove(building);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var building = uow.BuildingRepository.GetById(id);

            BuildingAddressViewModel viewmodel = new BuildingAddressViewModel
            {
                Id = building.Id,
                BuildingName = building.BuildingName
            };
            return View(viewmodel);
        }
    }
}