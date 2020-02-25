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
    [ExceptionFilter]
    public class HelpSupportController : Controller
    {
        private readonly IUnitOfWork uow;

        public HelpSupportController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSupport()
        {
            var supportFromdb = uow.HelpSupportRepository.GetAll();

            return Json(new { data = supportFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HelpSupportVM viewmodel)
        {
           if(ModelState.IsValid)
            {
                HelpSupport support = new HelpSupport
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    CompanyName = viewmodel.CompanyName,
                    Content = viewmodel.Content,
                    DeveloperName = viewmodel.DeveloperName,
                    SoftwareDownload = viewmodel.SoftwareDownload,
                    ProiflePic = viewmodel.ProiflePic,
                    DesignedBy = viewmodel.DesignedBy,
                    CreatedDate = viewmodel.CreatedDate,
                    Email = viewmodel.Email,
                    Skype = viewmodel.Skype,

                };
                uow.HelpSupportRepository.Add(support);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var supportFromdb = uow.HelpSupportRepository.GetById(id);

            HelpSupportVM viewmodel = new HelpSupportVM
            {
                Id=supportFromdb.Id,
                Title=supportFromdb.Title,
                CompanyName=supportFromdb.CompanyName,
                Content=supportFromdb.Content,
                DeveloperName=supportFromdb.DeveloperName,
                SoftwareDownload=supportFromdb.SoftwareDownload,
                ProiflePic=supportFromdb.ProiflePic,
                DesignedBy=supportFromdb.DesignedBy,
                CreatedDate=supportFromdb.CreatedDate,
                Email=supportFromdb.Email,
                Skype=supportFromdb.Skype,

            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(HelpSupportVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var support = uow.HelpSupportRepository.GetById(viewmodel.Id);

                support.Id = viewmodel.Id;
                support.Title = viewmodel.Title;
                support.CompanyName = viewmodel.CompanyName;
                support.Content = viewmodel.Content;
                support.DeveloperName = viewmodel.DeveloperName;
                support.SoftwareDownload = viewmodel.SoftwareDownload;
                support.ProiflePic = viewmodel.ProiflePic;
                support.DesignedBy = viewmodel.DesignedBy;
                support.CreatedDate = viewmodel.CreatedDate;
                support.Email = viewmodel.Email;
                support.Skype = viewmodel.Skype;

                uow.HelpSupportRepository.Update(support);
                uow.Commit();
                return RedirectToAction(nameof(Index));
                
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var supportFromdb = uow.HelpSupportRepository.GetById(id);

            HelpSupportVM viewmodel = new HelpSupportVM
            {
                Id = supportFromdb.Id,
                Title = supportFromdb.Title,
                CompanyName = supportFromdb.CompanyName,
                Content = supportFromdb.Content,
                DeveloperName = supportFromdb.DeveloperName,
                SoftwareDownload = supportFromdb.SoftwareDownload,
                ProiflePic = supportFromdb.ProiflePic,
                DesignedBy = supportFromdb.DesignedBy,
                CreatedDate = supportFromdb.CreatedDate,
                Email = supportFromdb.Email,
                Skype = supportFromdb.Skype,

            };
            return View(viewmodel);
        }
    }
}