using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Models;
using OPMS.Services;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class PagesController : Controller
    {
        private readonly IUnitOfWork uow;

        public PagesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void GetSidebar()
        {
            ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
        }
        public ActionResult Index()
        {
            var pagFromDb = uow.PageRepository.GetAll("Sidebars");
            List<PageViewModel> viewmodel = new List<PageViewModel>();

            foreach (var item in pagFromDb)
            {
                viewmodel.Add(new PageViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Slug = item.Slug,
                    Content = item.Slug,
                    MetaKeywords = item.MetaKeywords,
                    MetaDescription = item.MetaDescription,
                    IsPageMetaDataOn = item.IsPageMetaDataOn,
                    IsVisibleToSearchEngine = item.IsVisibleToSearchEngine,
                    SidebarId = item.SidebarId,
                    Sidebars = item.Sidebars
                });
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetSidebar();
            return View();
        }
        [HttpPost]
        public ActionResult Create(PageViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
                // GetSidebar();
                return View(viewmodel);
            }
            string slug;
            Page page = new Page();
            page.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))

                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.PageRepository.SlugExists(slug))
            {
                ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
                //GetSidebar();
                ModelState.AddModelError("", "Le titre ou le slug existe déjà");
                return View(viewmodel);
            }
            page.Slug = slug;
            page.Content = viewmodel.Content;
            page.MetaKeywords = viewmodel.MetaKeywords;
            page.MetaDescription = viewmodel.MetaDescription;
            page.IsPageMetaDataOn = viewmodel.IsPageMetaDataOn;
            page.SidebarId = viewmodel.SidebarId;
            page.Sidebars = viewmodel.Sidebars;
            page.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;

            uow.PageRepository.Add(page);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var page = uow.PageRepository.GetById(id);

            PageViewModel viewmodel = new PageViewModel
            {
                Id = page.Id,
                Title = page.Title,
                Slug = page.Slug,
                Content = page.Content,
                MetaKeywords = page.MetaKeywords,
                MetaDescription = page.MetaDescription,
                IsPageMetaDataOn = page.IsPageMetaDataOn,
                IsVisibleToSearchEngine = page.IsVisibleToSearchEngine,
                SidebarId = page.SidebarId,
                Sidebars = page.Sidebars

            };
            ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
            //GetSidebar();
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(PageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
                return View(viewmodel);
            }

            var page = uow.PageRepository.GetById(viewmodel.Id);

            page.Title = viewmodel.Title;

            string slug;
            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Slug);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.PageRepository.SlugExists(viewmodel.Id,slug))
            {
                ModelState.AddModelError("", "Le titre ou le slug existe déjà");
                ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
                return View(viewmodel);
            }
            page.Slug = slug;
            page.Content = viewmodel.Content;
            page.MetaKeywords = viewmodel.MetaKeywords;
            page.MetaDescription = viewmodel.MetaDescription;
            page.IsPageMetaDataOn = viewmodel.IsPageMetaDataOn;
            page.IsPageMetaDataOn = viewmodel.IsPageMetaDataOn;
            page.SidebarId = viewmodel.SidebarId;
            page.Sidebars = viewmodel.Sidebars;

            uow.PageRepository.Update(page);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var pageDelete = uow.PageRepository.GetById(id);
            ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
            PageViewModel viewmodel = new PageViewModel
            {
                Id=pageDelete.Id,
                Title=pageDelete.Title,
                Slug=pageDelete.Slug,
                Content=pageDelete.Content,
                MetaKeywords=pageDelete.MetaKeywords,
                MetaDescription=pageDelete.MetaDescription,
                IsPageMetaDataOn=pageDelete.IsPageMetaDataOn,
                IsVisibleToSearchEngine=pageDelete.IsVisibleToSearchEngine,
                SidebarId=pageDelete.SidebarId,
                Sidebars=pageDelete.Sidebars
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var page = uow.PageRepository.GetById(id);
            PageViewModel viewmodel = new PageViewModel
            {
                Id=page.Id,
                Title=page.Title,
                Slug=page.Slug,
                Content=page.Content,
                IsPageMetaDataOn=page.IsPageMetaDataOn,
                IsVisibleToSearchEngine=page.IsVisibleToSearchEngine,
                MetaDescription=page.MetaDescription,
                MetaKeywords=page.MetaKeywords,
                SidebarId=page.SidebarId,
                Sidebars=page.Sidebars
            };
            uow.PageRepository.Remove(page);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var pageDelete = uow.PageRepository.GetById(id);
            ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
            PageViewModel viewmodel = new PageViewModel
            {
                Id = pageDelete.Id,
                Title = pageDelete.Title,
                Slug = pageDelete.Slug,
                Content = pageDelete.Content,
                MetaKeywords = pageDelete.MetaKeywords,
                MetaDescription = pageDelete.MetaDescription,
                IsPageMetaDataOn = pageDelete.IsPageMetaDataOn,
                IsVisibleToSearchEngine = pageDelete.IsVisibleToSearchEngine,
                SidebarId = pageDelete.SidebarId,
                Sidebars = pageDelete.Sidebars
            };
            return View(viewmodel);
        }
    }

    
}