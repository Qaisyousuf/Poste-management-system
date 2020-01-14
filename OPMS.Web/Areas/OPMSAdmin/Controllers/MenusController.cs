using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

    }
}