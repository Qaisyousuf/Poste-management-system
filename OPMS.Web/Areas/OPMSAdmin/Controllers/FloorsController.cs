using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Models;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class FloorsController : Controller
    {
        private readonly IUnitOfWork uow;

        public FloorsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetFloorsData()
        {
            var floors = uow.FloorsRepository.GetAll();

            return Json(new { data = floors }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FloorsAddressViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                FloorsAddress floors = new FloorsAddress
                {
                    Id=viewmodel.Id,
                    FloorsNumber=viewmodel.FloorsNumber
                };
                uow.FloorsRepository.Add(floors);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var floors = uow.FloorsRepository.GetById(id);

            FloorsAddressViewModel viewmodel = new FloorsAddressViewModel
            {
                Id=floors.Id,
                FloorsNumber=floors.FloorsNumber
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(FloorsAddressViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var floors = uow.FloorsRepository.GetById(viewmodel.Id);

                floors.Id = viewmodel.Id;
                floors.FloorsNumber = viewmodel.FloorsNumber;

                uow.FloorsRepository.Update(floors);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var floors = uow.FloorsRepository.GetById(id);

            FloorsAddressViewModel viewmodel = new FloorsAddressViewModel
            {
                Id=floors.Id,
                FloorsNumber=floors.FloorsNumber
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var floors = uow.FloorsRepository.GetById(id);
            FloorsAddressViewModel viewmodel = new FloorsAddressViewModel
            {
                Id=floors.Id,
                FloorsNumber=floors.FloorsNumber,
            };
            uow.FloorsRepository.Remove(floors);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var floors = uow.FloorsRepository.GetById(Id);

            FloorsAddressViewModel viewmodel = new FloorsAddressViewModel
            {
                Id = floors.Id,
                FloorsNumber = floors.FloorsNumber
            };
            return View(viewmodel);
        }
    }
}