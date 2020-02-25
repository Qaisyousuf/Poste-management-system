using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Models;
using OPMS.Data.Interfaces;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class SocialProfilesController : Controller
    {
        private readonly IUnitOfWork uow;

        public SocialProfilesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSocialProfile()
        {
            var ProfileFromddb = uow.SocialProfileRepository.GetAll();

            return Json(new { data = ProfileFromddb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SWorkerProfileVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                SWorkerProfile profile = new SWorkerProfile
                {
                    Id=viewmodel.Id,
                    ImageUrl=viewmodel.ImageUrl,
                    Title=viewmodel.Title,
                    FullName=viewmodel.FullName,
                    JobTitle=viewmodel.JobTitle,
                    Content=viewmodel.Content,
                };
                uow.SocialProfileRepository.Add(profile);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var profilefromdb = uow.SocialProfileRepository.GetById(id);

            SWorkerProfileVM viewmodel = new SWorkerProfileVM
            {
                Id=profilefromdb.Id,
                Title=profilefromdb.Title,
                ImageUrl=profilefromdb.ImageUrl,
                JobTitle=profilefromdb.JobTitle,
                FullName=profilefromdb.FullName,
                Content=profilefromdb.Content,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(SWorkerProfileVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var profile = uow.SocialProfileRepository.GetById(viewmodel.Id);

                profile.Id = viewmodel.Id;
                profile.Title = viewmodel.Title;
                profile.JobTitle = viewmodel.JobTitle;
                profile.FullName = viewmodel.FullName;
                profile.ImageUrl = viewmodel.ImageUrl;
                profile.Content = viewmodel.Content;

                uow.SocialProfileRepository.Update(profile);
                uow.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);

        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var userFromdb = uow.SocialProfileRepository.GetById(id);
            SWorkerProfileVM viewmodel = new SWorkerProfileVM
            {
                Id = userFromdb.Id,
                Title = userFromdb.Title,
                ImageUrl = userFromdb.ImageUrl,
                JobTitle = userFromdb.JobTitle,
                FullName = userFromdb.FullName,
                Content = userFromdb.Content,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            var userFromdb = uow.SocialProfileRepository.GetById(id);
            SWorkerProfileVM viewmodel = new SWorkerProfileVM
            {
                Id = userFromdb.Id,
                Title = userFromdb.Title,
                ImageUrl = userFromdb.ImageUrl,
                JobTitle = userFromdb.JobTitle,
                FullName = userFromdb.FullName,
                Content = userFromdb.Content,
            };

            uow.SocialProfileRepository.Remove(userFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            var userFromdb = uow.SocialProfileRepository.GetById(id);
            SWorkerProfileVM viewmodel = new SWorkerProfileVM
            {
                Id = userFromdb.Id,
                Title = userFromdb.Title,
                ImageUrl = userFromdb.ImageUrl,
                JobTitle = userFromdb.JobTitle,
                FullName = userFromdb.FullName,
                Content = userFromdb.Content,
            };
            return View(viewmodel);
        }

    }
}