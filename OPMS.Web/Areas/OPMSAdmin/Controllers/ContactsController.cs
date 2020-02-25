using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;
using System;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class ContactsController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            //var contactfromdb = uow.ContactRepository.GetAll();
            //List<ContactViewModel> viewmodel = new List<ContactViewModel>();

            //foreach (var Contact in contactfromdb)
            //{
            //    viewmodel.Add(new ContactViewModel
            //    {
            //        Id=Contact.Id,
            //        FullName=Contact.FullName,
            //        Email=Contact.Email,
            //        Address=Contact.Address,
            //        MobileNumber=Contact.MobileNumber,
            //        IpAddres=Contact.IpAddres,
            //        MessageText=Contact.MessageText,
            //        ContactedDate=Contact.ContactedDate,
            //        ContactedLocation=Contact.ContactedLocation
            //    });
            //}

            //return View(viewmodel);
            return View();
        }

        public JsonResult GetContactData()
        {


            var contactFromDb = uow.ContactRepository.GetAll();

            return Json(new { data = contactFromDb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactViewModel viewmodel)
        {
           
           
            if (ModelState.IsValid)
            {
                Contact contact = new Contact
                {
                    Id = viewmodel.Id,
                    FullName = viewmodel.FullName,
                    Email = viewmodel.Email,
                    Address = viewmodel.Address,
                    MobileNumber = viewmodel.MobileNumber,
                    IpAddres = GetIpAddres(HttpContext.Request),
                    ContactedDate=DateTime.Now,
                    MessageText=viewmodel.MessageText,
                    ContactedLocation=viewmodel.ContactedLocation
                };
                uow.ContactRepository.Add(contact);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [NonAction]
        private string GetIpAddres(HttpRequestBase request)
        {
            string ipaddres;
            ipaddres = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddres == "" || ipaddres==null)
            {
                ipaddres = request.ServerVariables["REMOTE_ADDR"];
            }
            return ipaddres;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contactfromdb = uow.ContactRepository.GetById(id);

            ContactViewModel viewmodel = new ContactViewModel
            {
                Id=contactfromdb.Id,
                Email=contactfromdb.Email,
                FullName=contactfromdb.FullName,
                MobileNumber=contactfromdb.MobileNumber,
                Address=contactfromdb.Address,
                IpAddres=contactfromdb.IpAddres,
                ContactedDate=contactfromdb.ContactedDate,
                ContactedLocation=contactfromdb.ContactedLocation,
                MessageText=contactfromdb.MessageText
            };
            return View(viewmodel);

        }
        [HttpPost]
        public ActionResult Edit(ContactViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var contactFromdb = uow.ContactRepository.GetById(viewmodel.Id);

                contactFromdb.Id = viewmodel.Id;
                contactFromdb.FullName = viewmodel.FullName;
                contactFromdb.Email = viewmodel.Email;
                contactFromdb.MobileNumber = viewmodel.MobileNumber;
                contactFromdb.Address = viewmodel.Address;
                contactFromdb.IpAddres = GetIpAddres(HttpContext.Request);
                contactFromdb.ContactedDate = DateTime.Now;
                contactFromdb.ContactedLocation = viewmodel.ContactedLocation;
                contactFromdb.MessageText = viewmodel.MessageText;

                uow.ContactRepository.Update(contactFromdb);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet] 
        public ActionResult Delete(int id)
        {
            var contactfromdb = uow.ContactRepository.GetById(id);

            ContactViewModel viewmodel = new ContactViewModel
            {
                Id = contactfromdb.Id,
                Email = contactfromdb.Email,
                FullName = contactfromdb.FullName,
                Address = contactfromdb.Address,
                MobileNumber=contactfromdb.MobileNumber,
                IpAddres = contactfromdb.IpAddres,
                ContactedDate = contactfromdb.ContactedDate,
                ContactedLocation = contactfromdb.ContactedLocation,
                MessageText = contactfromdb.MessageText
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var contactfromd = uow.ContactRepository.GetById(id);

            ContactViewModel viewmodel = new ContactViewModel
            {
                Id=contactfromd.Id,
                FullName=contactfromd.FullName,
                Email=contactfromd.Email,
                Address=contactfromd.Address,
                IpAddres=contactfromd.IpAddres,
                ContactedDate=contactfromd.ContactedDate,
                ContactedLocation=contactfromd.ContactedLocation,
                MessageText=contactfromd.MessageText
            };
            uow.ContactRepository.Remove(contactfromd);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactfromdb = uow.ContactRepository.GetById(id);

            ContactViewModel viewmodel = new ContactViewModel
            {
                Id = contactfromdb.Id,
                Email = contactfromdb.Email,
                FullName = contactfromdb.FullName,
                MobileNumber=contactfromdb.MobileNumber,
                Address = contactfromdb.Address,
                IpAddres = contactfromdb.IpAddres,
                ContactedDate = contactfromdb.ContactedDate,
                ContactedLocation = contactfromdb.ContactedLocation,
                MessageText = contactfromdb.MessageText
            };
            return View(viewmodel);
        }
    }
}