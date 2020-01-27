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
    public class AboutShortSectionController : Controller
    {
        private readonly IUnitOfWork uow;

        public AboutShortSectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetShortSectionData()
        {
            var shortSection = uow.AboutShortSectionRepository.GetAll();

            return Json(new { data = shortSection }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AboutShortSectionVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                AboutShortSection shortSection = new AboutShortSection
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    SubTitle=viewmodel.SubTitle,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    SubContent=viewmodel.SubContent,
                    PublishDateTime=DateTime.Now,
                };
                uow.AboutShortSectionRepository.Add(shortSection);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var shortSectionFromdb = uow.AboutShortSectionRepository.GetById(id);

            AboutShortSectionVM viewmodel = new AboutShortSectionVM
            {
                Id = shortSectionFromdb.Id,
                Title = shortSectionFromdb.Title,
                SubContent = shortSectionFromdb.SubContent,
                MainTitle = shortSectionFromdb.MainTitle,
                Content = shortSectionFromdb.Content,
                SubTitle = shortSectionFromdb.SubTitle,
                PublishDateTime = shortSectionFromdb.PublishDateTime,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(AboutShortSectionVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var shortSection = uow.AboutShortSectionRepository.GetById(viewmodel.Id);

                shortSection.Id = viewmodel.Id;
                shortSection.Title = viewmodel.Title;
                shortSection.MainTitle = viewmodel.MainTitle;
                shortSection.SubContent = viewmodel.SubContent;
                shortSection.SubTitle = viewmodel.SubTitle;
                shortSection.Content = viewmodel.Content;
                shortSection.PublishDateTime = DateTime.Now;

                uow.AboutShortSectionRepository.Update(shortSection);
                uow.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var shortSectionFromdb = uow.AboutShortSectionRepository.GetById(id);

            AboutShortSectionVM viewmodel = new AboutShortSectionVM
            {
                Id = shortSectionFromdb.Id,
                Title = shortSectionFromdb.Title,
                SubContent = shortSectionFromdb.SubContent,
                MainTitle = shortSectionFromdb.MainTitle,
                Content = shortSectionFromdb.Content,
                SubTitle = shortSectionFromdb.SubTitle,
                PublishDateTime = shortSectionFromdb.PublishDateTime,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var shortSectoin = uow.AboutShortSectionRepository.GetById(id);

            AboutShortSectionVM viewmodel = new AboutShortSectionVM
            {
                Id=shortSectoin.Id,
                Title=shortSectoin.Title,
                SubTitle=shortSectoin.SubTitle,
                MainTitle=shortSectoin.MainTitle,
                Content=shortSectoin.Content,
                SubContent=shortSectoin.SubContent,
                PublishDateTime=shortSectoin.PublishDateTime,
            };
            uow.AboutShortSectionRepository.Remove(shortSectoin);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var shortSectionFromdb = uow.AboutShortSectionRepository.GetById(id);

            AboutShortSectionVM viewmodel = new AboutShortSectionVM
            {
                Id = shortSectionFromdb.Id,
                Title = shortSectionFromdb.Title,
                SubContent = shortSectionFromdb.SubContent,
                MainTitle = shortSectionFromdb.MainTitle,
                Content = shortSectionFromdb.Content,
                SubTitle = shortSectionFromdb.SubTitle,
                PublishDateTime = shortSectionFromdb.PublishDateTime,
            };
            return View(viewmodel);
        }
    }
}