using OPMS.Services.Security;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace OPMS.Web.Controllers
{
    [ExceptionFilter]
    [NoCacheFilter]
    [LoginInfoFilter]
    [AdminActivityFilter]
    public class AccountsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [LoginInfoFilter]
        [AdminActivityFilter]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Route("Authorization")]
        [LoginInfoFilter]
        [AdminActivityFilter]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [Route("Authorization")]
        
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
               
                return View(viewmodel);
            }
            var user = _authSerivce.Login(viewmodel.UserName, viewmodel.Password);
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

            HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket)
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMinutes(30)
            };

            Response.Cookies.Add(myCookie);
           

            return RedirectToAction("Index", "CheckPost");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        [Authorize]
        public ActionResult Register(RegisterViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewmodel);
            }
            bool registerSuccess = _authSerivce.Register(viewmodel.Email, viewmodel.UserName, viewmodel.Password, viewmodel.PhoneNumber, out int? userId);

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