using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OPMS.Models;
using System.Web.Mvc;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Controllers
{
    [ExceptionFilter]
    public class HomeController :BaseController
    {
        //[Route("{slug}")]
      
        public ActionResult Index(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                slug = "Home";
            if(!_uow.PageRepository.SlugExists(slug))
            {
                TempData["PageNotFound"] = "Page not found";
                return RedirectToAction(nameof(Index), new { slug = "" });
            }
            PageViewModel viewmodel;
            Page pageFromDb;

            pageFromDb = _uow.PageRepository.GetPageBySlug(slug);

            ViewBag.PageTitle = pageFromDb.Title;
            TempData["SidebarId"] = pageFromDb.SidebarId;
            TempData["HomeBanner"] = pageFromDb.BannerId;
            TempData["HomeContent"] = pageFromDb.HomeContentId;

            viewmodel = new PageViewModel
            {
                Id = pageFromDb.Id,
                Title = pageFromDb.Title,
                Content=pageFromDb.Content,
                IsVisibleToSearchEngine=pageFromDb.IsVisibleToSearchEngine,
                IsMetaDataOn=pageFromDb.IsPageMetaDataOn,
                MetaKeywords=pageFromDb.MetaKeywordse,
                MetaDescritpion=pageFromDb.MetaDescription,
                //IsPageMetaDataOn=pageFromDb.IsPageMetaDataOn,
                
            };

            return View(viewmodel);
        }
        [ChildActionOnly]
        public ActionResult PagesMenuPartial()
        {
            var context = _uow.Context;
            var menus = context.Menus;

            foreach (var menu in menus)
            {
                context.Entry(menu).Collection(s => s.SubMenus).Query().Where(x => x.ParentId == menu.Id);
            }

            var menuSubmenus = menus.AsNoTracking().ToList();

            context.Dispose();

            return PartialView(menuSubmenus);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult SidbarPartial()
        {
            int id = (int)TempData["SidebarId"];
            var sidebar = _uow.SidebarRepository.GetById(id);

            SidebarViewModel viewmodel = new SidebarViewModel
            {
                Id=sidebar.Id,
                Name=sidebar.Name,
                Content=sidebar.Content
            };
            return PartialView(viewmodel);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult HomeBanner()
        {
            int id = (int)TempData["HomeBanner"];

            var homebanner = _uow.HomeBannerRepository.GetById(id);

            HomeBannerVM viewmodel = new HomeBannerVM
            {
                Id= homebanner.Id,
                Title= homebanner.Title,
                SubTitle= homebanner.SubTitle,
                ImageUrl= homebanner.ImageUrl,
                ButtonText= homebanner.ButtonText,
                ButtonUrl= homebanner.ButtonUrl,
                Content= homebanner.Content,
            };
            return PartialView(viewmodel);
        }
        [HttpGet]
        [ChildActionOnly]
        public ActionResult HomeContentData()
        {
            int id = (int)TempData["HomeContent"];
            var homeContetnFromdb = _uow.HomeContentRepository.GetById(id);

            HomeContentVM viewmodel = new HomeContentVM
            {
                Id=homeContetnFromdb.Id,
                Title=homeContetnFromdb.Title,
                SubTitle=homeContetnFromdb.SubTitle,
                Content=homeContetnFromdb.Content,
                SubContent=homeContetnFromdb.SubContent,
                ButtonText=homeContetnFromdb.ButtonText,
                ButtonUrl=homeContetnFromdb.ButtonUrl,
                ImageUrl=homeContetnFromdb.ImageUrl
            };
            return PartialView(viewmodel);
        }
        [HttpGet]
        [ChildActionOnly]
        public ActionResult HomeRRData()
        {
            var homeRr = _uow.HomeRRepository.GetAll();

            List<HomeRRViewModel> viewmodel = new List<HomeRRViewModel>();

            foreach (var item in homeRr)
            {
                viewmodel.Add(new HomeRRViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    IconUrl=item.IconUrl
                });
            }
            SocialWorkerProfileList HomeDataList = new SocialWorkerProfileList
            {
                HomeRRVMs = viewmodel
            };
            return PartialView(HomeDataList);

        }
    }
}