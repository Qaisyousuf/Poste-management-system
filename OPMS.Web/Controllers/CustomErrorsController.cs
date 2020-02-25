using OPMS.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Controllers
{
    [ExceptionFilter]
    public class CustomErrorsController : Controller
    {
        // GET: CustomErrors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
        public ActionResult Unauthorized()
        {
            Response.StatusCode = 401;
            return View();
        }
    }
}