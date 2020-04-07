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
    //[ExceptionFilter]
    public class HomeContentsController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeContentsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetHomeContet()
        {
            var homeContent = uow.HomeContentRepository.GetAll();

            return Json(new { data = homeContent }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HomeContentVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                HomeContent homeContent = new HomeContent
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    SubTitle=viewmodel.SubTitle,
                    Content=viewmodel.Content,
                    SubContent=viewmodel.SubContent,
                    ButtonText=viewmodel.ButtonText,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.HomeContentRepository.Add(homeContent);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var homeContentFromdb = uow.HomeContentRepository.GetById(id);

            HomeContentVM viewmodel = new HomeContentVM
            {
                Id=homeContentFromdb.Id,
                Title=homeContentFromdb.Title,
                SubTitle=homeContentFromdb.SubTitle,
                Content=homeContentFromdb.Content,
                SubContent=homeContentFromdb.SubContent,
                ButtonText=homeContentFromdb.ButtonText,
                ButtonUrl=homeContentFromdb.ButtonUrl,
                ImageUrl=homeContentFromdb.ImageUrl,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(HomeContentVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var homeContent = uow.HomeContentRepository.GetById(viewmodel.Id);

                homeContent.Id = viewmodel.Id;
                homeContent.Title = viewmodel.Title;
                homeContent.SubTitle = viewmodel.SubTitle;
                homeContent.Content = viewmodel.Content;
                homeContent.SubContent = viewmodel.SubContent;
                homeContent.ButtonText = viewmodel.ButtonText;
                homeContent.ButtonUrl = viewmodel.ButtonUrl;
                homeContent.ImageUrl = viewmodel.ImageUrl;

                uow.HomeContentRepository.Update(homeContent);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var homeContentFromdb = uow.HomeContentRepository.GetById(id);

            HomeContentVM viewmodel = new HomeContentVM
            {
                Id = homeContentFromdb.Id,
                Title = homeContentFromdb.Title,
                SubTitle = homeContentFromdb.SubTitle,
                Content = homeContentFromdb.Content,
                SubContent = homeContentFromdb.SubContent,
                ButtonText = homeContentFromdb.ButtonText,
                ButtonUrl = homeContentFromdb.ButtonUrl,
                ImageUrl = homeContentFromdb.ImageUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var homefromDb = uow.HomeContentRepository.GetById(id);

            HomeContentVM viewmodel = new HomeContentVM
            {
                Id=homefromDb.Id,
                Title=homefromDb.Title,
                SubTitle=homefromDb.SubTitle,
                Content=homefromDb.Content,
                SubContent=homefromDb.SubContent,
                ButtonText=homefromDb.ButtonText,
                ButtonUrl=homefromDb.ButtonUrl,
                ImageUrl=homefromDb.ImageUrl
            };

            uow.HomeContentRepository.Remove(homefromDb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var homeContentFromdb = uow.HomeContentRepository.GetById(id);

            HomeContentVM viewmodel = new HomeContentVM
            {
                Id = homeContentFromdb.Id,
                Title = homeContentFromdb.Title,
                SubTitle = homeContentFromdb.SubTitle,
                Content = homeContentFromdb.Content,
                SubContent = homeContentFromdb.SubContent,
                ButtonText = homeContentFromdb.ButtonText,
                ButtonUrl = homeContentFromdb.ButtonUrl,
                ImageUrl = homeContentFromdb.ImageUrl,
            };
            return View(viewmodel);
        }
    }
}