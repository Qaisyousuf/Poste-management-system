using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Models;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class MenusController : Controller
    {
        private readonly IUnitOfWork uow;

        public MenusController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var menu = uow.MenuRepository.GetAll();

            List<MenuViewModel> viewmodel = new List<MenuViewModel>();
            foreach (var item in menu)
            {
                viewmodel.Add(new MenuViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Description=item.Description,
                    Url=item.Url,
                    Parent=item.Parent,
                    ParentId=item.ParentId
                });

            }

            return View(viewmodel);
        }

        public void GetMenus()
        {
            ViewBag.MenusDropDownList = uow.MenuRepository.GetAll();
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetMenus();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                Menu menus = new Menu
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Description=viewmodel.Description,
                    Url=viewmodel.Url,
                    ParentId=viewmodel.ParentId,
                    SubMenus=viewmodel.SubMenus
                };
                uow.MenuRepository.Add(menus);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var menus = uow.MenuRepository.GetById(id);

            uow.Context.Entry(menus).Reference(x => x.Parent).Load();
            GetMenus();
            MenuViewModel viewmodel = new MenuViewModel
            {
                Id=menus.Id,
                Title=menus.Title,
                Description=menus.Description,
                Url=menus.Url,
                SubMenus=menus.SubMenus,
                Parent=menus.Parent,
                ParentId=menus.ParentId
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(MenuViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var menus = uow.MenuRepository.GetById(viewmodel.Id);
                menus.Id = viewmodel.Id;
                menus.Title = viewmodel.Title;
                menus.Description = viewmodel.Description;
                menus.Url = viewmodel.Url;
                menus.ParentId = viewmodel.ParentId;
                menus.Parent = viewmodel.Parent;

                uow.MenuRepository.Update(menus);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var menus = uow.MenuRepository.GetById(id);
            GetMenus();
            MenuViewModel viewmodel = new MenuViewModel
            {
                Id=menus.Id,
                Title=menus.Title,
                Description=menus.Description,
                Url=menus.Url,
                Parent=menus.Parent,
                ParentId=menus.ParentId
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            if(ModelState.IsValid)
            {
                var menus = uow.MenuRepository.GetById(id);
                MenuViewModel viewmodel = new MenuViewModel
                {
                    Id=menus.Id,
                    Title=menus.Title,
                    Description=menus.Description,
                    Url=menus.Url,
                    ParentId=menus.ParentId
                };
                uow.MenuRepository.Remove(menus);
                uow.Commit();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var menus = uow.MenuRepository.GetById(id);
            GetMenus();
            MenuViewModel viewmodel = new MenuViewModel
            {
                Id = menus.Id,
                Title = menus.Title,
                Description = menus.Description,
                Url = menus.Url,
                Parent = menus.Parent,
                ParentId = menus.ParentId
            };
            return View(viewmodel);
        }


    }
}