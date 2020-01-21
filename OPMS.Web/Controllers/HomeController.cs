using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OPMS.Models;
using System.Web.Mvc;

namespace OPMS.Web.Controllers
{
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

            viewmodel = new PageViewModel
            {
                Id = pageFromDb.Id,
                Title = pageFromDb.Title,
                Content=pageFromDb.Content,
                IsVisibleToSearchEngine=pageFromDb.IsVisibleToSearchEngine,
                IsMetaDataOn=pageFromDb.IsPageMetaDataOn,
                MetaKeywords=pageFromDb.MetaKeywords,
                MetaDescription=pageFromDb.MetaDescription,
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
    }
}