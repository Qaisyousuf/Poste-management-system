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
    public class HomebannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomebannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetHomeBanner()
        {
            var homeBannerFromdb = uow.HomeBannerRepository.GetAll();

            return Json(new { data = homeBannerFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HomeBannerVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                HomeBanner homeBanner = new HomeBanner
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    ButtonText=viewmodel.ButtonText,
                    ButtonUrl=viewmodel.ButtonUrl,
                    Content=viewmodel.Content,
                };
                uow.HomeBannerRepository.Add(homeBanner);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var homebanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerVM viewmodel = new HomeBannerVM
            {
                Id=homebanner.Id,
                Title=homebanner.Title,
                SubTitle=homebanner.SubTitle,
                ImageUrl=homebanner.ImageUrl,
                ButtonText=homebanner.ButtonText,
                ButtonUrl=homebanner.ButtonUrl,
                Content=homebanner.Content,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(HomeBannerVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var homebannerFromdb = uow.HomeBannerRepository.GetById(viewmodel.Id);

                homebannerFromdb.Id = viewmodel.Id;
                homebannerFromdb.Title = viewmodel.Title;
                homebannerFromdb.SubTitle = viewmodel.SubTitle;
                homebannerFromdb.ImageUrl = viewmodel.ImageUrl;
                homebannerFromdb.ButtonText = viewmodel.ButtonText;
                homebannerFromdb.ButtonUrl = viewmodel.ButtonUrl;
                homebannerFromdb.Content = viewmodel.Content;

                uow.HomeBannerRepository.Update(homebannerFromdb);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var homebanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerVM viewmodel = new HomeBannerVM
            {
                Id = homebanner.Id,
                Title = homebanner.Title,
                SubTitle = homebanner.SubTitle,
                ImageUrl = homebanner.ImageUrl,
                ButtonText = homebanner.ButtonText,
                ButtonUrl = homebanner.ButtonUrl,
                Content = homebanner.Content,
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var bannerFromdb = uow.HomeBannerRepository.GetById(id);

            HomeBannerVM viewmodel = new HomeBannerVM
            {
                Id=bannerFromdb.Id,
                Title=bannerFromdb.Title,
                SubTitle=bannerFromdb.SubTitle,
                ImageUrl=bannerFromdb.ImageUrl,
                ButtonText=bannerFromdb.ButtonText,
                ButtonUrl=bannerFromdb.ButtonUrl,
                Content=bannerFromdb.Content,
            };

            uow.HomeBannerRepository.Remove(bannerFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var homebanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerVM viewmodel = new HomeBannerVM
            {
                Id = homebanner.Id,
                Title = homebanner.Title,
                SubTitle = homebanner.SubTitle,
                ImageUrl = homebanner.ImageUrl,
                ButtonText = homebanner.ButtonText,
                ButtonUrl = homebanner.ButtonUrl,
                Content = homebanner.Content,
            };
            return View(viewmodel);
        }
    }
}