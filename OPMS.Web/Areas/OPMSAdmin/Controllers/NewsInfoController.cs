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
    public class NewsInfoController : Controller
    {
        private readonly IUnitOfWork uow;

        public NewsInfoController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetNewsInfoData()
        {
            var newsFromdb = uow.NewInfoRepository.GetAll("NewsBanners");

            return Json(new { data = newsFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.NewsBannersList = uow.NewsBannerRepoistory.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewsInfoVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                NewsInfo newsInfo = new NewsInfo
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ButtonText=viewmodel.ButtonText,
                    SubContent=viewmodel.SubContent,
                    PublishDate=DateTime.Now,
                    ImageUrl=viewmodel.ImageUrl,
                    GoogleMapAPIUrl=viewmodel.GoogleMapAPIUrl,
                    IsNewsInfotMetaDataOn=viewmodel.IsNewInfotMetaDataOn,
                    MetaKeywordse=viewmodel.MetaKeywordseNewsInfo,
                    MetaDescription=viewmodel.MetaDescriptionNewsInfo,
                    IsVisibleToSearchEngine=viewmodel.IsVisibleToSearchNewsInfo,
                    NewsBanners=viewmodel.NewsBanners,
                    NewsBannerId=viewmodel.NewsBannerId
                };
                uow.NewInfoRepository.Add(newsInfo);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.NewsBannersList = uow.NewsBannerRepoistory.GetAll();

            var newsInfo = uow.NewInfoRepository.GetById(id);

            NewsInfoVM viewmodel = new NewsInfoVM
            {
                Id=newsInfo.Id,
                Title=newsInfo.Title,
                Content=newsInfo.Content,
                ButtonUrl=newsInfo.ButtonUrl,
                ButtonText=newsInfo.ButtonText,
                SubContent=newsInfo.SubContent,
                PublishDate=newsInfo.PublishDate,
                ImageUrl=newsInfo.ImageUrl,
                GoogleMapAPIUrl=newsInfo.GoogleMapAPIUrl,
                IsNewInfotMetaDataOn=newsInfo.IsNewsInfotMetaDataOn,
                MetaKeywordseNewsInfo=newsInfo.MetaKeywordse,
                MetaDescriptionNewsInfo=newsInfo.MetaDescription,
                IsVisibleToSearchNewsInfo=newsInfo.IsVisibleToSearchEngine,
                NewsBannerId=newsInfo.NewsBannerId,
                NewsBanners=newsInfo.NewsBanners,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(NewsInfoVM viewmodel)
        {
           if(ModelState.IsValid)
            {
                var newsInfo = uow.NewInfoRepository.GetById(viewmodel.Id);

                newsInfo.Id = viewmodel.Id;
                newsInfo.Title = viewmodel.Title;
                newsInfo.Content = viewmodel.Content;
                newsInfo.ButtonUrl = viewmodel.ButtonUrl;
                newsInfo.ButtonText = viewmodel.ButtonText;
                newsInfo.SubContent = viewmodel.SubContent;
                newsInfo.PublishDate = DateTime.Now;
                newsInfo.ImageUrl = viewmodel.ImageUrl;
                newsInfo.GoogleMapAPIUrl = viewmodel.GoogleMapAPIUrl;
                newsInfo.IsNewsInfotMetaDataOn = viewmodel.IsNewInfotMetaDataOn;
                newsInfo.MetaKeywordse = viewmodel.MetaKeywordseNewsInfo;
                newsInfo.MetaDescription = viewmodel.MetaDescriptionNewsInfo;
                newsInfo.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchNewsInfo;
                newsInfo.NewsBannerId = viewmodel.NewsBannerId;
                newsInfo.NewsBanners = viewmodel.NewsBanners;

                uow.NewInfoRepository.Update(newsInfo);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ViewBag.NewsBannersList = uow.NewsBannerRepoistory.GetAll();

            var newsInfo = uow.NewInfoRepository.GetById(id);

            NewsInfoVM viewmodel = new NewsInfoVM
            {
                Id = newsInfo.Id,
                Title = newsInfo.Title,
                Content = newsInfo.Content,
                ButtonUrl = newsInfo.ButtonUrl,
                ButtonText = newsInfo.ButtonText,
                SubContent = newsInfo.SubContent,
                PublishDate = newsInfo.PublishDate,
                ImageUrl = newsInfo.ImageUrl,
                GoogleMapAPIUrl = newsInfo.GoogleMapAPIUrl,
                IsNewInfotMetaDataOn = newsInfo.IsNewsInfotMetaDataOn,
                MetaKeywordseNewsInfo = newsInfo.MetaKeywordse,
                MetaDescriptionNewsInfo = newsInfo.MetaDescription,
                IsVisibleToSearchNewsInfo = newsInfo.IsVisibleToSearchEngine,
                NewsBannerId = newsInfo.NewsBannerId,
                NewsBanners = newsInfo.NewsBanners,
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            ViewBag.NewsBannersList = uow.NewsBannerRepoistory.GetAll();

            var newsInfo = uow.NewInfoRepository.GetById(id);

            NewsInfoVM viewmodel = new NewsInfoVM
            {
                Id = newsInfo.Id,
                Title = newsInfo.Title,
                Content = newsInfo.Content,
                ButtonUrl = newsInfo.ButtonUrl,
                ButtonText = newsInfo.ButtonText,
                SubContent = newsInfo.SubContent,
                PublishDate = newsInfo.PublishDate,
                ImageUrl = newsInfo.ImageUrl,
                GoogleMapAPIUrl = newsInfo.GoogleMapAPIUrl,
                IsNewInfotMetaDataOn = newsInfo.IsNewsInfotMetaDataOn,
                MetaKeywordseNewsInfo = newsInfo.MetaKeywordse,
                MetaDescriptionNewsInfo = newsInfo.MetaDescription,
                IsVisibleToSearchNewsInfo = newsInfo.IsVisibleToSearchEngine,
                NewsBannerId = newsInfo.NewsBannerId,
                NewsBanners = newsInfo.NewsBanners,

            };

            uow.NewInfoRepository.Remove(newsInfo);
            uow.Commit();

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            ViewBag.NewsBannersList = uow.NewsBannerRepoistory.GetAll();

            var newsInfo = uow.NewInfoRepository.GetById(id);

            NewsInfoVM viewmodel = new NewsInfoVM
            {
                Id = newsInfo.Id,
                Title = newsInfo.Title,
                Content = newsInfo.Content,
                ButtonUrl = newsInfo.ButtonUrl,
                ButtonText = newsInfo.ButtonText,
                SubContent = newsInfo.SubContent,
                PublishDate = newsInfo.PublishDate,
                ImageUrl = newsInfo.ImageUrl,
                GoogleMapAPIUrl = newsInfo.GoogleMapAPIUrl,
                IsNewInfotMetaDataOn = newsInfo.IsNewsInfotMetaDataOn,
                MetaKeywordseNewsInfo = newsInfo.MetaKeywordse,
                MetaDescriptionNewsInfo = newsInfo.MetaDescription,
                IsVisibleToSearchNewsInfo = newsInfo.IsVisibleToSearchEngine,
                NewsBannerId = newsInfo.NewsBannerId,
                NewsBanners = newsInfo.NewsBanners,
            };
            return View(viewmodel);
        }
        

    }
}