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
    public class SWBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public SWBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SWBannerData()
        {
            var SWbanner = uow.SWBaneerRepository.GetAll();

            return Json(new { data = SWbanner }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SWBannerVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                SWBanner sWbanner = new SWBanner
                {
                    Id=viewmodel.Id,
                    BTitle=viewmodel.BTitle,
                    BSubTitle=viewmodel.BSubTitle,
                    BContent=viewmodel.BContent,
                    BImage=viewmodel.BImage,
                    BButton=viewmodel.BButton,
                    BButtonUrl=viewmodel.BButtonUrl,
                };
                uow.SWBaneerRepository.Add(sWbanner);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sWBanner = uow.SWBaneerRepository.GetById(id);

            SWBannerVM viewmodel = new SWBannerVM
            {
                Id=sWBanner.Id,
                BTitle=sWBanner.BTitle,
                BSubTitle = sWBanner.BSubTitle,
                BContent = sWBanner.BContent,
                BImage = sWBanner.BImage,
                BButton = sWBanner.BButton,
                BButtonUrl = sWBanner.BButtonUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(SWBannerVM viewmodel)
        {
           if(ModelState.IsValid)
            {
                var swbanner = uow.SWBaneerRepository.GetById(viewmodel.Id);

                swbanner.Id = viewmodel.Id;
                swbanner.BTitle = viewmodel.BTitle;
                swbanner.BSubTitle = viewmodel.BSubTitle;
                swbanner.BContent = viewmodel.BContent;
                swbanner.BImage = viewmodel.BImage;
                swbanner.BButton = viewmodel.BButton;
                swbanner.BButtonUrl = viewmodel.BButtonUrl;

                uow.SWBaneerRepository.Update(swbanner);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var sWBanner = uow.SWBaneerRepository.GetById(id);

            SWBannerVM viewmodel = new SWBannerVM
            {
                Id = sWBanner.Id,
                BTitle = sWBanner.BTitle,
                BSubTitle = sWBanner.BSubTitle,
                BContent = sWBanner.BContent,
                BImage = sWBanner.BImage,
                BButton = sWBanner.BButton,
                BButtonUrl = sWBanner.BButtonUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var swbannerfromdb = uow.SWBaneerRepository.GetById(id);

            SWBannerVM viewmodel = new SWBannerVM
            {
                Id=swbannerfromdb.Id,
                BTitle=swbannerfromdb.BTitle,
                BSubTitle=swbannerfromdb.BSubTitle,
                BContent=swbannerfromdb.BContent,
                BImage=swbannerfromdb.BImage,
                BButton=swbannerfromdb.BButton,
                BButtonUrl=swbannerfromdb.BButtonUrl,
            };

            uow.SWBaneerRepository.Remove(swbannerfromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var sWBanner = uow.SWBaneerRepository.GetById(id);

            SWBannerVM viewmodel = new SWBannerVM
            {
                Id = sWBanner.Id,
                BTitle = sWBanner.BTitle,
                BSubTitle = sWBanner.BSubTitle,
                BContent = sWBanner.BContent,
                BImage = sWBanner.BImage,
                BButton = sWBanner.BButton,
                BButtonUrl = sWBanner.BButtonUrl,
            };
            return View(viewmodel);
        }
       
    }
}