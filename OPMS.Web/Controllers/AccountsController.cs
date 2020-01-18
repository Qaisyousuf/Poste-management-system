using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Services;
using OPMS.ViewModels;
using OPMS.Services.Security;
using System.Web.Security;
using System.Web.Script.Serialization;

namespace OPMS.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAuthenticationService authService;

        public AccountsController(IAuthenticationService authService)
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
                ModelState.AddModelError("", "L'utilisateur portant ce nom n'existe pas");
                return View(viewmodel);
            }
            CustomPricipalSerialize serialize = new CustomPricipalSerialize
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber=user.PhoneNumber,
                Email = user.Email,
                Roles = user.Roles.Select(x => x.Name).ToArray()
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serialize);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(2, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, userData);

            string encryptTicket = FormsAuthentication.Encrypt(authTicket);

            HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            myCookie.HttpOnly = true;
            myCookie.Expires = DateTime.Now.AddMinutes(1);

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
            bool registerSuccess = authService.Register(viewmodel.Email, viewmodel.UserName, viewmodel.Password, viewmodel.PhoneNumber, out int? userId);

            if(!registerSuccess)
            {
                ModelState.AddModelError("", "Quelque chose ne va pas");
                return View(viewmodel);
            }
            TempData["Success"] = "Inscription terminée avec succès";
            return RedirectToAction(nameof(Register));

        }
    }
}