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
    public class AboutSectionsController : Controller
    {
        private readonly IUnitOfWork uow;

        public AboutSectionsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            int value = int.Parse("ddddd");
            return View();
        }

        public JsonResult GetAboutSectionData()
        {
            var aboutSection = uow.AboutSectionRepository.GetAll();

            return Json(new { data = aboutSection }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            int value = int.Parse("ddddd");
            return View();
        }

        [HttpPost]
        public ActionResult Create(AboutSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                AboutSection section = new AboutSection
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    MainTitle = viewmodel.MainTitle,
                    SubTitle = viewmodel.SubTitle,
                    Content = viewmodel.Content,
                    ButtonUrl = viewmodel.ButtonUrl,
                    UrlImages = viewmodel.UrlImages,
                    PublishDateTime = DateTime.Now
                };
                uow.AboutSectionRepository.Add(section);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aboutSection = uow.AboutSectionRepository.GetById(id);

            AboutSectionViewModel viewmodel = new AboutSectionViewModel
            {
                Id=aboutSection.Id,
                Title=aboutSection.Title,
                MainTitle=aboutSection.MainTitle,
                SubTitle=aboutSection.SubTitle,
                Content=aboutSection.Content,
                ButtonUrl=aboutSection.ButtonUrl,
                UrlImages=aboutSection.UrlImages,
                PublishDateTime=aboutSection.PublishDateTime
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(AboutSectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var sectionFromDb = uow.AboutSectionRepository.GetById(viewmodel.Id);

                sectionFromDb.Id = viewmodel.Id;
                sectionFromDb.Title = viewmodel.Title;
                sectionFromDb.MainTitle = viewmodel.MainTitle;
                sectionFromDb.SubTitle = viewmodel.SubTitle;
                sectionFromDb.Content = viewmodel.Content;
                sectionFromDb.ButtonUrl = viewmodel.ButtonUrl;
                sectionFromDb.UrlImages = viewmodel.UrlImages;
                sectionFromDb.PublishDateTime = DateTime.Now;

                uow.AboutSectionRepository.Update(sectionFromDb);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var sectionfromdb = uow.AboutSectionRepository.GetById(id);

            AboutSectionViewModel viewmodel = new AboutSectionViewModel
            {
                Id=sectionfromdb.Id,
                Title=sectionfromdb.Title,
                MainTitle=sectionfromdb.MainTitle,
                SubTitle=sectionfromdb.SubTitle,
                Content=sectionfromdb.Content,
                ButtonUrl=sectionfromdb.ButtonUrl,
                UrlImages=sectionfromdb.UrlImages,
                PublishDateTime=sectionfromdb.PublishDateTime,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDalete(int id)
        {
            var aboutSection = uow.AboutSectionRepository.GetById(id);

            AboutSectionViewModel viewmodel = new AboutSectionViewModel
            {
                Id=aboutSection.Id,
                Title=aboutSection.Title,
                MainTitle=aboutSection.MainTitle,
                SubTitle=aboutSection.SubTitle,
                Content=aboutSection.Content,
                ButtonUrl=aboutSection.ButtonUrl,
                UrlImages=aboutSection.UrlImages,
                PublishDateTime=aboutSection.PublishDateTime,
            };
            uow.AboutSectionRepository.Remove(aboutSection);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var sectionfromdb = uow.AboutSectionRepository.GetById(id);

            AboutSectionViewModel viewmodel = new AboutSectionViewModel
            {
                Id = sectionfromdb.Id,
                Title = sectionfromdb.Title,
                MainTitle = sectionfromdb.MainTitle,
                SubTitle = sectionfromdb.SubTitle,
                Content = sectionfromdb.Content,
                ButtonUrl = sectionfromdb.ButtonUrl,
                UrlImages = sectionfromdb.UrlImages,
                PublishDateTime = sectionfromdb.PublishDateTime,
            };
            return View(viewmodel);
        }
        
    }
}