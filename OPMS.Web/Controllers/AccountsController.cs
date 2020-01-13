using OPMS.Data.Interfaces;
using OPMS.Services;
using OPMS.Services.Security;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace OPMS.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IAuthenticationService authService;

        public AccountsController(IUnitOfWork uow,IAuthenticationService authService)
        {
            this.uow = uow;
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
            return RedirectToAction("Index","Home");
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
                TempData["WronLogin"] = "veuillez vérifier votre nom d'utilisateur et votre mot de passe";
               // ModelState.AddModelError("", "Tentative de connexion non valide");
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
            bool registerSuccessful = authService.Register(viewmodel.Email, viewmodel.UserName,viewmodel.PhoneNumber, viewmodel.Password, out int? userId);
            if(!registerSuccessful)
            {
                ModelState.AddModelError("", "Ce nom d'utilisateur existe déjà");
                return View(viewmodel);
            }
            TempData["Success"] = "Inscription terminée avec succès";
            return RedirectToAction(nameof(Register));

        }
    }
}