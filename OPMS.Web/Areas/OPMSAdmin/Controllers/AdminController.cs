using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork uow;

        public AdminController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
       
        public ActionResult Index()
        {
            var adminFromdb = uow.AdminPanelInfo.GetAll();

            List<AdminstratorPanelVM> adminviewmodel = new List<AdminstratorPanelVM>();

            foreach (var item in adminFromdb)
            {
                adminviewmodel.Add(new AdminstratorPanelVM
                {
                    Id=item.Id,
                    Title=item.Title,
                    SubContent=item.SubContent,
                    Content=item.Content,
                    AuthenticatedUser=User.Identity.Name,
                    ImageUrl=item.ImageUrl,
                });
            }

            return View(adminviewmodel);
        }
    }
}