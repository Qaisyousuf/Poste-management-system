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
    public class HelpController : Controller
    {
        private readonly IUnitOfWork uow;

        public HelpController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        public ActionResult Index()
        {
            var helpFromdb = uow.HelpSupportRepository.GetAll();

            List<HelpSupportVM> viewmodel = new List<HelpSupportVM>();

            foreach (var item in helpFromdb)
            {
                viewmodel.Add(new HelpSupportVM
                {
                    Id=item.Id,
                    Title=item.Title,
                    CompanyName=item.CompanyName,
                    Content=item.Content,
                    DeveloperName=item.DeveloperName,
                    SoftwareDownload=item.SoftwareDownload,
                    ProiflePic=item.ProiflePic,
                    DesignedBy=item.DesignedBy,
                    CreatedDate=item.CreatedDate,
                    Email=item.Email,
                    Skype=item.Skype

                });
            }

            return View(viewmodel);
        }
    }
}