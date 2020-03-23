using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Models;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Controllers
{
    [ExceptionFilter]
    [NoCacheFilter]
    public class ContactFormsController : BaseController
    {
        [Route("Contact")]
        public ActionResult Index()
        {
            var contactDetailsFromdb = _uow.ContactDetailsRepoistory.GetAll();

            List<ContactDetailsVM> viewmodel = new List<ContactDetailsVM>();

            foreach (var item in contactDetailsFromdb)
            {
                viewmodel.Add(new ContactDetailsVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    CityName = item.CityName,
                    AreaName = item.AreaName,
                    StreetName = item.StreetName,
                    GoogleAPIMap = item.GoogleAPIMap,
                    CenterName = item.CenterName,
                    CenterEmail = item.CenterEmail,
                    MobileNumber = item.MobileNumber,
                });
            }

            var contactInfo = _uow.ContactInfoRepository.GetAll();

            List<ContactInfoVM> ContactInfoviewmodel = new List<ContactInfoVM>();

            foreach (var item in contactInfo)
            {
                ContactInfoviewmodel.Add(new ContactInfoVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    PlaceName = item.PlaceName,
                    PlaceAddress = item.PlaceAddress,
                    PlaceContactNumber = item.PlaceContactNumber,
                    WebSite = item.WebSite,
                    PostalCode = item.PostalCode,
                    GoogleMap = item.GoogleMap,
                });
            }

            var contactPage = _uow.ContactPageRepository.GetAll();

            List<ContactPageViewModel> pageViewmodel = new List<ContactPageViewModel>();

            foreach (var item in contactPage)
            {
                pageViewmodel.Add(new ContactPageViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    SubContent = item.SubContent,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,
                    GoogleMapAPIUrl = item.GoogleMapAPIUrl,
                    IsMetaDataOn = item.IsContactMetaDataOn,
                    MetaKeywords = item.MetaKeywordse,
                    MetaDescritpion = item.MetaDescription,
                    IsVisibleToSearchEngine = item.IsVisibleToSearchEngine,
                    ContactDetailsId = item.ContactDetailsId,
                    ContactDetails = item.ContactDetails,
                    ContactFormId = item.ContactFormId,
                    ContactForms = item.ContactForms,
                    ContactInfoId = item.ContactInfoId,
                    ContactInfo = item.ContactInfo,
                });
            }
            ContactMultiVM ContactData = new ContactMultiVM
            {
                ContactDetailsViewModel = viewmodel,
                ContactInfoViewModel = ContactInfoviewmodel,
                ContactPageViewModel = pageViewmodel
            };

            return PartialView(ContactData);
        }
        [Route("Contact")]
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ContactViewModel());
        }

        [HttpPost]
        [Route("Contact")]
        public ActionResult Create(ContactViewModel viewmodel)
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
                    ContactedLocation = viewmodel.ContactedLocation
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