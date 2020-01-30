using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Models;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactDetailsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetContactDetails()
        {
            var contactDetailsFromdb = uow.ContactDetailsRepoistory.GetAll();
            return Json(new { data = contactDetailsFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactDetailsVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                ContactDetails contactDetails = new ContactDetails
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    CityName=viewmodel.CityName,
                    AreaName=viewmodel.AreaName,
                    StreetName=viewmodel.StreetName,
                    GoogleAPIMap=viewmodel.GoogleAPIMap,
                    CenterName = viewmodel.CenterName,
                    CenterEmail =viewmodel.CenterEmail,
                    MobileNumber=viewmodel.MobileNumber
                };
                uow.ContactDetailsRepoistory.Add(contactDetails);
                uow.Commit();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contactDetailsFromdb = uow.ContactDetailsRepoistory.GetById(id);

            ContactDetailsVM viewmodel = new ContactDetailsVM
            {
                Id=contactDetailsFromdb.Id,
                Title=contactDetailsFromdb.Title,
                CityName=contactDetailsFromdb.CityName,
                AreaName=contactDetailsFromdb.AreaName,
                StreetName=contactDetailsFromdb.StreetName,
                GoogleAPIMap=contactDetailsFromdb.GoogleAPIMap,
                CenterName=contactDetailsFromdb.CenterName,
                CenterEmail=contactDetailsFromdb.CenterEmail,
                MobileNumber=contactDetailsFromdb.MobileNumber,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(ContactDetailsVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var contactDetaisl = uow.ContactDetailsRepoistory.GetById(viewmodel.Id);
                contactDetaisl.Id = viewmodel.Id;
                contactDetaisl.Title = viewmodel.Title;
                contactDetaisl.CityName = viewmodel.CityName;
                contactDetaisl.AreaName = viewmodel.AreaName;
                contactDetaisl.StreetName = viewmodel.StreetName;
                contactDetaisl.GoogleAPIMap = viewmodel.GoogleAPIMap;
                contactDetaisl.CenterName = viewmodel.CenterName;
                contactDetaisl.CenterEmail = viewmodel.CenterEmail;
                contactDetaisl.MobileNumber = viewmodel.MobileNumber;

                uow.ContactDetailsRepoistory.Update(contactDetaisl);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var contactDetailsFromdb = uow.ContactDetailsRepoistory.GetById(id);

            ContactDetailsVM viewmodel = new ContactDetailsVM
            {
                Id = contactDetailsFromdb.Id,
                Title = contactDetailsFromdb.Title,
                CityName = contactDetailsFromdb.CityName,
                AreaName = contactDetailsFromdb.AreaName,
                StreetName = contactDetailsFromdb.StreetName,
                GoogleAPIMap = contactDetailsFromdb.GoogleAPIMap,
                CenterName = contactDetailsFromdb.CenterName,
                CenterEmail = contactDetailsFromdb.CenterEmail,
                MobileNumber = contactDetailsFromdb.MobileNumber,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var contactDetails = uow.ContactDetailsRepoistory.GetById(id);

            ContactDetailsVM viewmodel = new ContactDetailsVM
            {
                Id=contactDetails.Id,
                Title=contactDetails.Title,
                CityName=contactDetails.CityName,
                AreaName=contactDetails.AreaName,
                StreetName=contactDetails.StreetName,
                GoogleAPIMap=contactDetails.GoogleAPIMap,
                CenterName=contactDetails.CenterName,
                CenterEmail=contactDetails.CenterEmail,
                MobileNumber=contactDetails.MobileNumber,
          
            };
            uow.ContactDetailsRepoistory.Remove(contactDetails);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactDetailsFromdb = uow.ContactDetailsRepoistory.GetById(id);

            ContactDetailsVM viewmodel = new ContactDetailsVM
            {
                Id = contactDetailsFromdb.Id,
                Title = contactDetailsFromdb.Title,
                CityName = contactDetailsFromdb.CityName,
                AreaName = contactDetailsFromdb.AreaName,
                StreetName = contactDetailsFromdb.StreetName,
                GoogleAPIMap = contactDetailsFromdb.GoogleAPIMap,
                CenterName = contactDetailsFromdb.CenterName,
                CenterEmail = contactDetailsFromdb.CenterEmail,
                MobileNumber = contactDetailsFromdb.MobileNumber,
            };
            return View(viewmodel);
        }
    }
}