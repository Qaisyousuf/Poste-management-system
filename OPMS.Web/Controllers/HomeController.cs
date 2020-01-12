using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var sidebarfromdb = uow.SidebarRepository.GetAll();
            return View(sidebarfromdb);
        }
    }
}