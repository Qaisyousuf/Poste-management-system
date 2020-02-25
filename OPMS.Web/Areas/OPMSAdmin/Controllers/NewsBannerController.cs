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
    public class NewsBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public NewsBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetNewsBanner()
        {
            var newsBanner = uow.NewsBannerRepoistory.GetAll();

            return Json(new { data = newsBanner }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsBannerVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                NewsBanner newsBanner = new NewsBanner
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ButtonText=viewmodel.ButtonText,
                    Content=viewmodel.Content,
                };
                uow.NewsBannerRepoistory.Add(newsBanner);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var newsBanner = uow.NewsBannerRepoistory.GetById(id);

            NewsBannerVM viewmodel = new NewsBannerVM
            {
                Id=newsBanner.Id,
                Title=newsBanner.Title,
                SubTitle=newsBanner.SubTitle,
                ImageUrl=newsBanner.ImageUrl,
                ButtonText=newsBanner.ButtonText,
                ButtonUrl=newsBanner.ButtonUrl,
                Content=newsBanner.Content,
            };
            return View(viewmodel);

        }

        [HttpPost]
        public ActionResult Edit(NewsBannerVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var newsBanner = uow.NewsBannerRepoistory.GetById(viewmodel.Id);

                newsBanner.Id = viewmodel.Id;
                newsBanner.Title = viewmodel.Title;
                newsBanner.SubTitle = viewmodel.SubTitle;
                newsBanner.ImageUrl = viewmodel.ImageUrl;
                newsBanner.ButtonText = viewmodel.ButtonText;
                newsBanner.ButtonUrl = viewmodel.ButtonUrl;
                newsBanner.Content = viewmodel.Content;

                uow.NewsBannerRepoistory.Update(newsBanner);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var newsBanner = uow.NewsBannerRepoistory.GetById(id);

            NewsBannerVM viewmodel = new NewsBannerVM
            {
                Id = newsBanner.Id,
                Title = newsBanner.Title,
                SubTitle = newsBanner.SubTitle,
                ImageUrl = newsBanner.ImageUrl,
                ButtonText = newsBanner.ButtonText,
                ButtonUrl = newsBanner.ButtonUrl,
                Content = newsBanner.Content,
            };
            return View(viewmodel);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var newsBanner = uow.NewsBannerRepoistory.GetById(id);

            NewsBannerVM viewmodel = new NewsBannerVM
            {
                Id = newsBanner.Id,
                Title = newsBanner.Title,
                SubTitle = newsBanner.SubTitle,
                ImageUrl = newsBanner.ImageUrl,
                ButtonText = newsBanner.ButtonText,
                ButtonUrl = newsBanner.ButtonUrl,
                Content = newsBanner.Content,
            };

            uow.NewsBannerRepoistory.Remove(newsBanner);
            uow.Commit();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var newsBanner = uow.NewsBannerRepoistory.GetById(id);

            NewsBannerVM viewmodel = new NewsBannerVM
            {
                Id = newsBanner.Id,
                Title = newsBanner.Title,
                SubTitle = newsBanner.SubTitle,
                ImageUrl = newsBanner.ImageUrl,
                ButtonText = newsBanner.ButtonText,
                ButtonUrl = newsBanner.ButtonUrl,
                Content = newsBanner.Content,
            };
            return View(viewmodel);
        }
    }
}