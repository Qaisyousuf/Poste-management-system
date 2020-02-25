using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Models;
using OPMS.Services;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class ContactPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }
        private void ContactData()
        {
            ViewBag.ContactFomrs = uow.ContactRepository.GetAll();
            ViewBag.ConactDetails = uow.ContactDetailsRepoistory.GetAll();
            ViewBag.ContactInfo = uow.ContactInfoRepository.GetAll();
        }

        public JsonResult GetContactPageData()
        {
            var ContactFromdb = uow.ContactPageRepository.GetAll("ContactDetails", "ContactInfo", "ContactForms");
            return Json(new { data = ContactFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ContactData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                ContactData();
                return View(viewmodel);
            }

            string slug;
            ContactMainPage contactpage = new ContactMainPage();
            contactpage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.ContactPageRepository.SlugExists(slug))
            {
                ModelState.AddModelError("", "Title or slug already exists");
                ContactData();
                return View(viewmodel);
            }
            contactpage.Slug = slug;
            contactpage.Content = viewmodel.Content;
            contactpage.SubContent = viewmodel.SubContent;
            contactpage.Description = viewmodel.Description;
            contactpage.ImageUrl = viewmodel.ImageUrl;
            contactpage.GoogleMapAPIUrl = viewmodel.GoogleMapAPIUrl;
            contactpage.IsContactMetaDataOn = viewmodel.IsContactMetaDataOn;
            contactpage.MetaKeywordse = viewmodel.MetaKeywordseContact;
            contactpage.MetaDescription = viewmodel.MetaDescriptionContact;
            contactpage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngineContact;
            contactpage.ContactDetailsId = viewmodel.ContactDetailsId;
            contactpage.ContactDetails = viewmodel.ContactDetails;
            contactpage.ContactInfoId = viewmodel.ContactInfoId;
            contactpage.ContactInfo = viewmodel.ContactInfo;
            contactpage.ContactFormId = viewmodel.ContactFormId;
            contactpage.ContactForms = viewmodel.ContactForms;

            uow.ContactPageRepository.Add(contactpage);
            uow.Commit();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ContactData();
            var contactPageFromdb = uow.ContactPageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {
                Id=contactPageFromdb.Id,
                Title=contactPageFromdb.Title,
                Slug=contactPageFromdb.Slug,
                Content=contactPageFromdb.Content,
                SubContent=contactPageFromdb.SubContent,
                Description=contactPageFromdb.Description,
                ImageUrl=contactPageFromdb.ImageUrl,
                GoogleMapAPIUrl=contactPageFromdb.GoogleMapAPIUrl,
                IsContactMetaDataOn=contactPageFromdb.IsContactMetaDataOn,
                MetaKeywordseContact=contactPageFromdb.MetaKeywordse,
                MetaDescriptionContact=contactPageFromdb.MetaDescription,
                IsVisibleToSearchEngineContact=contactPageFromdb.IsVisibleToSearchEngine,
                ContactDetailsId=contactPageFromdb.ContactDetailsId,
                ContactDetails=contactPageFromdb.ContactDetails,
                ContactFormId=contactPageFromdb.ContactFormId,
                ContactForms=contactPageFromdb.ContactForms,
                ContactInfoId=contactPageFromdb.ContactInfoId,
                ContactInfo=contactPageFromdb.ContactInfo
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(ContactPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                ContactData();
                return View(viewmodel);
            }
            string slug;
            var contactPage = uow.ContactPageRepository.GetById(viewmodel.Id);
            contactPage.Id = viewmodel.Id;
            contactPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))

                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.ContactPageRepository.SlugExists(viewmodel.Id,slug))
            {
                ModelState.AddModelError("", "Title or slug already exists");
                ContactData();
                return View(viewmodel);
            }
            contactPage.Slug = slug;
            contactPage.Content = viewmodel.Content;
            contactPage.SubContent = viewmodel.SubContent;
            contactPage.Description = viewmodel.Description;
            contactPage.ImageUrl = viewmodel.ImageUrl;
            contactPage.GoogleMapAPIUrl = viewmodel.GoogleMapAPIUrl;
            contactPage.IsContactMetaDataOn = viewmodel.IsContactMetaDataOn;
            contactPage.MetaDescription = viewmodel.MetaDescriptionContact;
            contactPage.MetaKeywordse = viewmodel.MetaKeywordseContact;
            contactPage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngineContact;
            contactPage.ContactDetailsId = viewmodel.ContactDetailsId;
            contactPage.ContactDetails = viewmodel.ContactDetails;
            contactPage.ContactFormId = viewmodel.ContactFormId;
            contactPage.ContactForms = viewmodel.ContactForms;
            contactPage.ContactInfo = viewmodel.ContactInfo;
            contactPage.ContactInfoId = viewmodel.ContactInfoId;

            uow.ContactPageRepository.Update(contactPage);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var contactPageFromdb = uow.ContactPageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {
                Id = contactPageFromdb.Id,
                Title = contactPageFromdb.Title,
                Slug = contactPageFromdb.Slug,
                Content = contactPageFromdb.Content,
                SubContent = contactPageFromdb.SubContent,
                Description = contactPageFromdb.Description,
                ImageUrl = contactPageFromdb.ImageUrl,
                GoogleMapAPIUrl = contactPageFromdb.GoogleMapAPIUrl,
                IsContactMetaDataOn = contactPageFromdb.IsContactMetaDataOn,
                MetaKeywordseContact = contactPageFromdb.MetaKeywordse,
                MetaDescriptionContact = contactPageFromdb.MetaDescription,
                IsVisibleToSearchEngineContact = contactPageFromdb.IsVisibleToSearchEngine,
                ContactDetailsId = contactPageFromdb.ContactDetailsId,
                ContactDetails = contactPageFromdb.ContactDetails,
                ContactFormId = contactPageFromdb.ContactFormId,
                ContactForms = contactPageFromdb.ContactForms,
                ContactInfoId = contactPageFromdb.ContactInfoId,
                ContactInfo = contactPageFromdb.ContactInfo
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            var contactPageFromdb = uow.ContactPageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {
                Id = contactPageFromdb.Id,
                Title = contactPageFromdb.Title,
                Slug = contactPageFromdb.Slug,
                Content = contactPageFromdb.Content,
                SubContent = contactPageFromdb.SubContent,
                Description = contactPageFromdb.Description,
                ImageUrl = contactPageFromdb.ImageUrl,
                GoogleMapAPIUrl = contactPageFromdb.GoogleMapAPIUrl,
                IsContactMetaDataOn = contactPageFromdb.IsContactMetaDataOn,
                MetaKeywordseContact = contactPageFromdb.MetaKeywordse,
                MetaDescriptionContact = contactPageFromdb.MetaDescription,
                IsVisibleToSearchEngineContact = contactPageFromdb.IsVisibleToSearchEngine,
                ContactDetailsId = contactPageFromdb.ContactDetailsId,
                ContactDetails = contactPageFromdb.ContactDetails,
                ContactFormId = contactPageFromdb.ContactFormId,
                ContactForms = contactPageFromdb.ContactForms,
                ContactInfoId = contactPageFromdb.ContactInfoId,
                ContactInfo = contactPageFromdb.ContactInfo
            };
            uow.ContactPageRepository.Remove(contactPageFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
            
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            var contactPageFromdb = uow.ContactPageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {
                Id = contactPageFromdb.Id,
                Title = contactPageFromdb.Title,
                Slug = contactPageFromdb.Slug,
                Content = contactPageFromdb.Content,
                SubContent = contactPageFromdb.SubContent,
                Description = contactPageFromdb.Description,
                ImageUrl = contactPageFromdb.ImageUrl,
                GoogleMapAPIUrl = contactPageFromdb.GoogleMapAPIUrl,
                IsContactMetaDataOn = contactPageFromdb.IsContactMetaDataOn,
                MetaKeywordseContact = contactPageFromdb.MetaKeywordse,
                MetaDescriptionContact = contactPageFromdb.MetaDescription,
                IsVisibleToSearchEngineContact = contactPageFromdb.IsVisibleToSearchEngine,
                ContactDetailsId = contactPageFromdb.ContactDetailsId,
                ContactDetails = contactPageFromdb.ContactDetails,
                ContactFormId = contactPageFromdb.ContactFormId,
                ContactForms = contactPageFromdb.ContactForms,
                ContactInfoId = contactPageFromdb.ContactInfoId,
                ContactInfo = contactPageFromdb.ContactInfo
            };
            return View(viewmodel);
        }
    }
}