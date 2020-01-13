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
    public class SidebarsController : Controller
    {
        private readonly IUnitOfWork uow;

        public SidebarsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var sidebarFromDb = uow.SidebarRepository.GetAll();

            List<SidebarViewModel> viewmodel = new List<SidebarViewModel>();

            foreach (var item in sidebarFromDb)
            {
                viewmodel.Add(new SidebarViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Content=item.Content,
                    PublishDate=item.PublishDate
                });
            }

            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SidebarViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                Sidebar sidebar = new Sidebar
                {
                    Id = viewmodel.Id,
                    Name = viewmodel.Name,
                    Content = viewmodel.Content,
                    PublishDate = DateTime.Now,
                };
                uow.SidebarRepository.Add(sidebar);
                uow.Commit();
                
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sidebarFromDb = uow.SidebarRepository.GetById(id);

            SidebarViewModel viewmodel = new SidebarViewModel
            {
                Id=sidebarFromDb.Id,
                Name=sidebarFromDb.Name,
                Content=sidebarFromDb.Content,
                PublishDate=sidebarFromDb.PublishDate
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(SidebarViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var sidebarfromdb = uow.SidebarRepository.GetById(viewmodel.Id);
                sidebarfromdb.Id = viewmodel.Id;
                sidebarfromdb.Name = viewmodel.Name;
                sidebarfromdb.Content = viewmodel.Content;
                sidebarfromdb.PublishDate = DateTime.Now;

                uow.SidebarRepository.Update(sidebarfromdb);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var sidebarFromDb = uow.SidebarRepository.GetById(id);

            SidebarViewModel viewmodel = new SidebarViewModel
            {
                Id=sidebarFromDb.Id,
                Name=sidebarFromDb.Name,
                Content=sidebarFromDb.Content,
                PublishDate=sidebarFromDb.PublishDate
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if(ModelState.IsValid)
            {
                var sidebarfromdb = uow.SidebarRepository.GetById(id);

                SidebarViewModel viewmodel = new SidebarViewModel
                {
                    Id=sidebarfromdb.Id,
                    Name=sidebarfromdb.Name,
                    Content=sidebarfromdb.Content,
                    PublishDate=sidebarfromdb.PublishDate
                };
                uow.SidebarRepository.Remove(sidebarfromdb);
                uow.Commit();
              
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var sidebarFromDb = uow.SidebarRepository.GetById(id);

            SidebarViewModel viewmodel = new SidebarViewModel
            {
                Id = sidebarFromDb.Id,
                Name = sidebarFromDb.Name,
                Content = sidebarFromDb.Content,
                PublishDate = sidebarFromDb.PublishDate,
            };
            return View(viewmodel);
            
        }
    }
}