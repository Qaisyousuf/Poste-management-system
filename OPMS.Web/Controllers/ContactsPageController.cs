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
       // [Route("ContactUs")]
        public ActionResult Index( string slug)
        {
            if (string.IsNullOrEmpty(slug))
                slug = "Home";
            if(!_uow.ContactPageRepository.SlugExists(slug))
            {
                TempData["PageNotFound"] = "Page not found";
                return RedirectToAction(nameof(Index), new { slug = "" });
            }
            ContactPageViewModel viewmodel;
            ContactMainPage contactPage;

            contactPage = _uow.ContactPageRepository.GetContactPageBySlug(slug);

            ViewBag.ContactPageTitle = contactPage.Title;
            TempData["ContactDetials"] = contactPage.ContactDetailsId;
            TempData["ContactInfo"] = contactPage.ContactInfoId;
            TempData["ContactForms"] = contactPage.ContactFormId;

            viewmodel = new ContactPageViewModel
            {
                Id=contactPage.Id,
                Title=contactPage.Title,
                Content=contactPage.Content,
                SubContent=contactPage.SubContent,
                Description=contactPage.Description,
                ImageUrl=contactPage.ImageUrl,
                GoogleMapAPIUrl=contactPage.GoogleMapAPIUrl,
                IsMetaDataOn=contactPage.IsContactMetaDataOn,
                MetaKeywords=contactPage.MetaKeywordse,
                MetaDescritpion=contactPage.MetaDescription,
                IsVisibleToSearchEngine=contactPage.IsVisibleToSearchEngine,

            };

            return View(new ContactPageViewModel());
        }

        //[HttpPost]
        //[Route("ContactUs")]
        //public ActionResult Index(ContactViewModel viewmodel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Contact contact = new Contact
        //        {

        //            FullName = viewmodel.FullName,
        //            Email = viewmodel.Email,
        //            Address = viewmodel.Address,
        //            MessageText = viewmodel.MessageText,
        //            IpAddres = GetIpAddres(HttpContext.Request),
        //            MobileNumber = viewmodel.MobileNumber,
        //            ContactedDate = DateTime.Now,
        //            ContactedLocation=viewmodel.ContactedLocation
        //        };
        //        _uow.ContactRepository.Add(contact);
        //        _uow.Commit();
        //        TempData["Message"] = $"{contact.FullName}";
        //        return RedirectToAction(nameof(ThankYou));


        //    }
        //    return View(viewmodel);
        //}
        [HttpGet]
        [Route("Thanks")]
        public ActionResult ThankYou()
        {
            return View(new ContactViewModel());
        }

        public ActionResult ContactDetails()
        {
            int id = (int)TempData["ContactDetials"];

            var contactDetails = _uow.ContactDetailsRepoistory.GetById(id);
            ViewBag.ContactDetails = _uow.ContactDetailsRepoistory.GetAll();

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
            return PartialView(viewmodel);
        }

        public ActionResult ContactInfo()
        {
            int id = (int)TempData["ContactInfo"];

            var contactInfo = _uow.ContactInfoRepository.GetById(id);

            ViewBag.ContactInfo = _uow.ContactInfoRepository.GetAll();


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
            return PartialView(viewmodel);
        }

        public ActionResult ContactForms()
        {
            int id = (int)TempData["ContactForms"];
            var contactFrom = _uow.ContactRepository.GetById(id);
            ViewBag.ContactForm = _uow.ContactRepository.GetAll();

            ContactViewModel viewmodel = new ContactViewModel
            {
                Id = contactFrom.Id,
                FullName = contactFrom.FullName,
                Email = contactFrom.Email,
                AddresFooterBase = contactFrom.Email,
                MobileNumber = contactFrom.MobileNumber,
                IpAddres = GetIpAddres(HttpContext.Request),
                ContactedDate=contactFrom.ContactedDate,
                MessageText=contactFrom.MessageText,
                ContactedLocation=contactFrom.ContactedLocation,
            };
            return RedirectToAction(nameof(ThankYou));
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