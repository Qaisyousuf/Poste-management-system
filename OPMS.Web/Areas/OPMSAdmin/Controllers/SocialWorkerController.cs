using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Models;
using OPMS.ViewModels;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class SocialWorkerController : Controller
    {
        private readonly IUnitOfWork uow;

        public SocialWorkerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetSocialWorkerData()
        {
            var socialWorker = uow.SocialWorkerRepository.GetAll();
            return Json(new { data = socialWorker }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SocialWorkerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                SocialWorker socialWorker = new SocialWorker
                {
                    Id=viewmodel.Id,
                    FullName=viewmodel.FullName,
                    Position=viewmodel.Position
                };
                uow.SocialWorkerRepository.Add(socialWorker);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var socialWorker = uow.SocialWorkerRepository.GetById(id);

            SocialWorkerViewModel viewmodel = new SocialWorkerViewModel
            {
                Id=socialWorker.Id,
                FullName=socialWorker.FullName,
                Position=socialWorker.Position
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(SocialWorkerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var socialWorker = uow.SocialWorkerRepository.GetById(viewmodel.Id);

                socialWorker.Id = viewmodel.Id;
                socialWorker.FullName = viewmodel.FullName;
                socialWorker.Position = viewmodel.Position;

                uow.SocialWorkerRepository.Update(socialWorker);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var socialWorker = uow.SocialWorkerRepository.GetById(id);

            SocialWorkerViewModel viewmodel = new SocialWorkerViewModel
            {
                Id=socialWorker.Id,
                FullName=socialWorker.FullName,
                Position=socialWorker.Position
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            var socialWorker = uow.SocialWorkerRepository.GetById(id);

            SocialWorkerViewModel viewmodel = new SocialWorkerViewModel
            {
                Id=socialWorker.Id,
                FullName=socialWorker.FullName,
                Position=socialWorker.Position
            };
            uow.SocialWorkerRepository.Remove(socialWorker);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var socialWorker = uow.SocialWorkerRepository.GetById(id);

            SocialWorkerViewModel viewmodel = new SocialWorkerViewModel
            {
                Id = socialWorker.Id,
                FullName = socialWorker.FullName,
                Position = socialWorker.Position
            };
            return View(viewmodel);
        }
    }
}