using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using OPMS.Services;
using OPMS.Services.Security;
using OPMS.ViewModels;

namespace OPMS.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAuthenticatioService authService;

        public AccountsController(IAuthenticatioService authService)
        {
            this.authService = authService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); 
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewmodel);
            }
            var user = authService.Login(viewmodel.UserName, viewmodel.Password);

            if(user==null)
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return View(viewmodel);
            }
            CustomPricipalSerialize serialize = new CustomPricipalSerialize
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber=user.PhoneNumber,
                Roles = user.Roles.Select(x => x.Name).ToArray()
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serialize);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(2, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, userData);

            string encryptTicket = FormsAuthentication.Encrypt(authTicket);

            HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            myCookie.HttpOnly = true;
            myCookie.Expires = DateTime.Now.AddMinutes(20);

            Response.Cookies.Add(myCookie);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            bool registerSucess = authService.Register(viewmodel.UserName, viewmodel.Email, viewmodel.Password, viewmodel.PhoneNumber, out int? userId);
            if(!registerSucess)
            {
                ModelState.AddModelError("", "User Exists Already");
                return View(viewmodel);
            }
            TempData["Registration"] = "Registration successful";
            return RedirectToAction(nameof(Register));
        }
    }
}