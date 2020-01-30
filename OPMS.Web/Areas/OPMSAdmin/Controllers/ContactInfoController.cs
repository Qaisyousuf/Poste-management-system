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
    public class ContactInfoController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactInfoController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public JsonResult GetContactInfoData()
        {
            var contactInfoFromDb = uow.ContactInfoRepository.GetAll();
            return Json(new { data = contactInfoFromDb }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ContactInfoVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                ContactInfo conactInfo = new ContactInfo
                {
                    Id = viewmodel.Id,
                    Title=viewmodel.Title,
                    Content = viewmodel.Content,
                    PlaceName = viewmodel.PlaceName,
                    PlaceAddress = viewmodel.PlaceAddress,
                    PlaceContactNumber = viewmodel.PlaceContactNumber,
                    WebSite = viewmodel.WebSite,
                    PostalCode = viewmodel.PostalCode,
                    GoogleMap = viewmodel.GoogleMap,
                };
                uow.ContactInfoRepository.Add(conactInfo);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contactInf = uow.ContactInfoRepository.GetById(id);

            ContactInfoVM viewmodel = new ContactInfoVM
            {
                Id=contactInf.Id,
                Title=contactInf.Title,
                Content=contactInf.Content,
                PlaceName=contactInf.PlaceName,
                PlaceAddress=contactInf.PlaceAddress,
                PlaceContactNumber=contactInf.PlaceContactNumber,
                WebSite=contactInf.WebSite,
                PostalCode=contactInf.PostalCode,
                GoogleMap=contactInf.GoogleMap,

            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(ContactInfoVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var contactInfo = uow.ContactInfoRepository.GetById(viewmodel.Id);
                contactInfo.Id = viewmodel.Id;
                contactInfo.Title = viewmodel.Title;
                contactInfo.Content = viewmodel.Content;
                contactInfo.PlaceName = viewmodel.PlaceName;
                contactInfo.PlaceAddress = viewmodel.PlaceAddress;
                contactInfo.PlaceContactNumber = viewmodel.PlaceContactNumber;
                contactInfo.WebSite = viewmodel.WebSite;
                contactInfo.PostalCode = viewmodel.PostalCode;
                contactInfo.GoogleMap = viewmodel.GoogleMap;

                uow.ContactInfoRepository.Update(contactInfo);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel); 
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var contactInf = uow.ContactInfoRepository.GetById(id);

            ContactInfoVM viewmodel = new ContactInfoVM
            {
                Id = contactInf.Id,
                Title = contactInf.Title,
                Content = contactInf.Content,
                PlaceName = contactInf.PlaceName,
                PlaceAddress = contactInf.PlaceAddress,
                PlaceContactNumber = contactInf.PlaceContactNumber,
                WebSite = contactInf.WebSite,
                PostalCode = contactInf.PostalCode,
                GoogleMap = contactInf.GoogleMap,

            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var contactInfo = uow.ContactInfoRepository.GetById(id);

            ContactInfoVM viewmodel = new ContactInfoVM
            {
                Id=contactInfo.Id,
                Title=contactInfo.Title,
                Content=contactInfo.Content,
                PlaceName=contactInfo.PlaceName,
                PlaceAddress=contactInfo.PlaceAddress,
                PlaceContactNumber=contactInfo.PlaceContactNumber,
                WebSite=contactInfo.WebSite,
                PostalCode=contactInfo.PostalCode,
                GoogleMap=contactInfo.GoogleMap,
            };
            uow.ContactInfoRepository.Remove(contactInfo);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactInf = uow.ContactInfoRepository.GetById(id);

            ContactInfoVM viewmodel = new ContactInfoVM
            {
                Id = contactInf.Id,
                Title = contactInf.Title,
                Content = contactInf.Content,
                PlaceName = contactInf.PlaceName,
                PlaceAddress = contactInf.PlaceAddress,
                PlaceContactNumber = contactInf.PlaceContactNumber,
                WebSite = contactInf.WebSite,
                PostalCode = contactInf.PostalCode,
                GoogleMap = contactInf.GoogleMap,

            };
            return View(viewmodel);
        }
    }
}