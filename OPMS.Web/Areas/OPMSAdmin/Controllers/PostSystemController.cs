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
    public class PostSystemController : Controller
    {
        private readonly IUnitOfWork uow;

        public PostSystemController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult PostData()
        {
            var postFromdb = uow.PostSystemRepository.GetAll();

            return Json(new { data = postFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PostSystemVM viewmodel)
        {
            var user = User.Identity.IsAuthenticated.ToString();
            var role = User.IsInRole("Admin").ToString();
            var username = User.Identity.Name;
            if(ModelState.IsValid && User.IsInRole("Admin") && User.Identity.IsAuthenticated)
            {
                if(username !=null && role !=null && user !=null)
                {
                    PostSystem postSystem = new PostSystem
                    {
                        Id = viewmodel.Id,
                        Title = viewmodel.Title,
                        SubTitle = viewmodel.SubTitle,
                        Content = viewmodel.Content,
                        //PostCreatedBy = User.IsInRole("Admin").ToString(),
                        PostCreatedBy = User.Identity.Name
                    };
                    uow.PostSystemRepository.Add(postSystem);
                    uow.Commit();
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var postFromdb = uow.PostSystemRepository.GetById(id);

            PostSystemVM viewmodel = new PostSystemVM
            {
                Id=postFromdb.Id,
                Title=postFromdb.Title,
                SubTitle=postFromdb.SubTitle,
                Content=postFromdb.Content,
                PostCreatedBy=postFromdb.PostCreatedBy,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(PostSystemVM viewmodel)
        {
            var user = User.Identity.IsAuthenticated.ToString();
            var role = User.IsInRole("Admin").ToString();
            var username = User.Identity.Name;
            if (ModelState.IsValid && User.IsInRole("Admin") && User.Identity.IsAuthenticated)
            {
                if (username != null && role != null && user != null)
                {
                    var postFromdb = uow.PostSystemRepository.GetById(viewmodel.Id);

                    postFromdb.Id = viewmodel.Id;
                    postFromdb.Title = viewmodel.Title;
                    postFromdb.SubTitle = viewmodel.SubTitle;
                    postFromdb.Content = viewmodel.Content;
                    postFromdb.PostCreatedBy = User.Identity.Name;
                    uow.PostSystemRepository.Update(postFromdb);
                    uow.Commit();
                    return RedirectToAction(nameof(Index));
                }
              
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var postFromdb = uow.PostSystemRepository.GetById(id);

            PostSystemVM viewmodel = new PostSystemVM
            {
                Id = postFromdb.Id,
                Title = postFromdb.Title,
                SubTitle = postFromdb.SubTitle,
                Content = postFromdb.Content,
                PostCreatedBy = postFromdb.PostCreatedBy,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            var postFromDb = uow.PostSystemRepository.GetById(id);

            PostSystemVM viewmodel = new PostSystemVM
            {
                Id=postFromDb.Id,
                Title=postFromDb.Title,
                SubTitle=postFromDb.SubTitle,
                Content=postFromDb.Content,
                PostCreatedBy=postFromDb.PostCreatedBy
            };
            uow.PostSystemRepository.Remove(postFromDb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var postFromdb = uow.PostSystemRepository.GetById(id);

            PostSystemVM viewmodel = new PostSystemVM
            {
                Id = postFromdb.Id,
                Title = postFromdb.Title,
                SubTitle = postFromdb.SubTitle,
                Content = postFromdb.Content,
                PostCreatedBy = postFromdb.PostCreatedBy,
            };
            return View(viewmodel);
        }

    }
}