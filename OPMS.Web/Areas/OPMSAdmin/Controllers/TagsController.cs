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
    public class TagsController : Controller
    {
        private readonly IUnitOfWork uow;

        public TagsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var tagFromdb = uow.TagRepository.GetAll();

            List<TagViewModel> viewmodel = new List<TagViewModel>();

            foreach (var item in tagFromdb)
            {
                viewmodel.Add(new TagViewModel
                {
                    Id=item.Id,
                    Name=item.Name
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
        public ActionResult Create(TagViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                Tag tagsfromdb = new Tag
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name
                };
                uow.TagRepository.Add(tagsfromdb);
                uow.Commit();
                TempData["TagCreated"] = "Tag Created Successfuly";
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var TagsFromDataBase = uow.TagRepository.GetById(id);
            TagViewModel viewmodel = new TagViewModel
            {
                Id=TagsFromDataBase.Id,
                Name=TagsFromDataBase.Name
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(TagViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var tagFromdDb = uow.TagRepository.GetById(viewmodel.Id);
                tagFromdDb.Id = viewmodel.Id;
                tagFromdDb.Name = viewmodel.Name;

                uow.TagRepository.Update(tagFromdDb);
                uow.Commit();
                TempData["TagUpdated"] = "Tag Updated Successfuly";
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var TagFromDb = uow.TagRepository.GetById(id);
            TagViewModel viewmodel = new TagViewModel
            {
                Id=TagFromDb.Id,
                Name=TagFromDb.Name
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var TagDeleteFromdb = uow.TagRepository.GetById(id);

            TagViewModel viewmodel = new TagViewModel
            {
                Id=TagDeleteFromdb.Id,
                Name=TagDeleteFromdb.Name
            };
            uow.TagRepository.Remove(TagDeleteFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var TagDetailsFromDb = uow.TagRepository.GetById(id);

            TagViewModel viewmodel = new TagViewModel
            {
                Id=TagDetailsFromDb.Id,
                Name=TagDetailsFromDb.Name
            };
            return View(viewmodel);
        }


    }
}