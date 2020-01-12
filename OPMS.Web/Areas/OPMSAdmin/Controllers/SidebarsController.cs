using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var data = uow.SidebarRepository.GetAll();
            return View(data);
        }
    }
}