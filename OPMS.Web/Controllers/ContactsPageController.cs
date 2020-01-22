using OPMS.Models;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Controllers
{
    
    public class ContactsPageController : BaseController
    {
        [Route("ContactUs")]
        public ActionResult Index()
        {
            return View(new ContactViewModel());
        }

        [HttpPost]
        [Route("ContactUs")]
        public ActionResult Index(ContactViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact
                {

                    FullName = viewmodel.FullName,
                    Email = viewmodel.Email,
                    Address = viewmodel.Address,
                    MessageText = viewmodel.MessageText,
                    IpAddres = GetIpAddres(HttpContext.Request),
                    MobileNumber = viewmodel.MobileNumber,
                    ContactedDate = DateTime.Now,
                    ContactedLocation=viewmodel.ContactedLocation
                };
                _uow.ContactRepository.Add(contact);
                _uow.Commit();
                TempData["Message"] = $"{contact.FullName}";
                return RedirectToAction(nameof(ThankYou));


            }
            return View(viewmodel);
        }
        [HttpGet]
        [Route("Thanks")]
        public ActionResult ThankYou()
        {
            return View(new ContactViewModel());
        }
        [NonAction]
        private string GetIpAddres(HttpRequestBase request)
        {
            string ipaddres;
            ipaddres = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddres == "" || ipaddres == null)
            {
                ipaddres = request.ServerVariables["REMOTE_ADDR"];
            }
            return ipaddres;
        }
    }
}