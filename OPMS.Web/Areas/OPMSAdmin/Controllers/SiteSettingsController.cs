using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class SiteSettingsController : Controller
    {
        private readonly IUnitOfWork uow;

        public SiteSettingsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult GetSiteSettingData()
        {
            var siteSettingFromdb = uow.SiteSettingsRepository.GetAll();

            return Json(new { data = siteSettingFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(SiteSettingsViewModel viewmodel)
        {
          if(ModelState.IsValid && User.IsInRole("Admin"))
            {
                SiteSettings siteSettings = new SiteSettings
                {
                    Id=viewmodel.Id,
                    SiteName=viewmodel.SiteName,
                    IsRegister=viewmodel.IsRegister,
                    SiteFooter=viewmodel.SiteFooter,
                    FavIconURL=viewmodel.FavIconURL,
                    SiteOwner=viewmodel.SiteOwner,
                    GoogleSiteVerification=viewmodel.GoogleSiteVerification,
                    GoogelAds=viewmodel.GoogleAds,
                    CustomCSS=viewmodel.CustomCSS,
                    IsCustomCSSOn=viewmodel.IsCustomCSSOn,
                    CustomJS=viewmodel.CustomJS,
                    IsCustomJsOn=viewmodel.IsCustomJsOn,
                    SiteLastUpdated=DateTime.Now,
                    UpdateBy=User.Identity.Name,
                    HomeFooter=viewmodel.HomeFooter,
                    HomeUrl=viewmodel.HomeUrl,
                    AboutFooter=viewmodel.AboutFooter,
                    AboutUrl=viewmodel.AboutUrl,
                    ContactFooter=viewmodel.ContactFooter,
                    ContactUrl=viewmodel.ContactUrl,
                    RolesFooter=viewmodel.RolesFooter,
                    RolesUrl=viewmodel.RolesUrl,
                    ContactNumberFooter=viewmodel.ContactNumberFooter,
                    EmailFooter=viewmodel.EmailFooter,
                    AddresFooter=viewmodel.AddresFooter,
                    ContentFooter=viewmodel.ContentFooter,
                    CopyrightFooter=viewmodel.CopyrightFooter,
                    LoginFooter=viewmodel.LoginFooter,
                    LoginUrl=viewmodel.LoginUrl,
                };
                uow.SiteSettingsRepository.Add(siteSettings);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var siteSetting = uow.SiteSettingsRepository.GetById(id);

            SiteSettingsViewModel viewmodel = new SiteSettingsViewModel
            {
                Id = siteSetting.Id,
                SiteName = siteSetting.SiteName,
                IsRegister = siteSetting.IsRegister,
                SiteFooter = siteSetting.SiteFooter,
                FavIconURL = siteSetting.FavIconURL,
                SiteOwner = siteSetting.SiteOwner,
                CustomCSS = siteSetting.CustomCSS,
                CustomJS = siteSetting.CustomJS,
                IsCustomCSSOn = siteSetting.IsCustomCSSOn,
                IsCustomJsOn = siteSetting.IsCustomJsOn,
                SiteLastUpdated = DateTime.Now,
                GoogleAds = siteSetting.GoogelAds,
                GoogleSiteVerification = siteSetting.GoogleSiteVerification,
                UpdateBy = siteSetting.UpdateBy,
                HomeFooter = siteSetting.HomeFooter,
                HomeUrl = siteSetting.HomeUrl,
                AboutFooter = siteSetting.AboutFooter,
                AboutUrl = siteSetting.AboutUrl,
                ContactFooter = siteSetting.ContactFooter,
                ContactUrl = siteSetting.ContactUrl,
                RolesFooter = siteSetting.RolesFooter,
                RolesUrl = siteSetting.RolesUrl,
                ContactNumberFooter = siteSetting.ContactNumberFooter,
                EmailFooter = siteSetting.EmailFooter,
                AddresFooter = siteSetting.AddresFooter,
                ContentFooter = siteSetting.ContentFooter,
                CopyrightFooter = siteSetting.CopyrightFooter,
                LoginFooter = siteSetting.LoginFooter,
                LoginUrl = siteSetting.LoginFooter,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(SiteSettingsViewModel viewmodel)
        {
            if(ModelState.IsValid && User.IsInRole("Admin"))
            {
                var siteSetting = uow.SiteSettingsRepository.GetById(viewmodel.Id);

                siteSetting.Id = viewmodel.Id;
                siteSetting.SiteName = viewmodel.SiteName;
                siteSetting.IsRegister = viewmodel.IsRegister;
                siteSetting.SiteFooter = viewmodel.SiteFooter;
                siteSetting.FavIconURL = viewmodel.FavIconURL;
                siteSetting.SiteOwner = viewmodel.SiteOwner;
                siteSetting.CustomCSS = viewmodel.CustomCSS;
                siteSetting.CustomJS = viewmodel.CustomJS;
                siteSetting.IsCustomCSSOn = viewmodel.IsCustomCSSOn;
                siteSetting.IsCustomJsOn = viewmodel.IsCustomJsOn;
                siteSetting.SiteLastUpdated = DateTime.Now;
                siteSetting.GoogelAds = viewmodel.GoogleAds;
                siteSetting.GoogleSiteVerification = viewmodel.GoogleSiteVerification;
                siteSetting.UpdateBy = User.Identity.Name;
                siteSetting.HomeFooter = viewmodel.HomeFooter;
                siteSetting.HomeUrl = viewmodel.HomeUrl;
                siteSetting.AboutFooter = viewmodel.AboutFooter;
                siteSetting.AboutUrl = viewmodel.AboutUrl;
                siteSetting.ContentFooter = viewmodel.ContentFooter;
                siteSetting.ContactUrl = viewmodel.ContactUrl;
                siteSetting.RolesFooter = viewmodel.RolesFooter;
                siteSetting.RolesUrl = viewmodel.RolesUrl;
                siteSetting.ContactNumberFooter = viewmodel.ContactNumberFooter;
                siteSetting.EmailFooter = viewmodel.EmailFooter;
                siteSetting.AddresFooter = viewmodel.AddresFooter;
                siteSetting.ContentFooter = viewmodel.ContentFooter;
                siteSetting.CopyrightFooter = viewmodel.CopyrightFooter;
                siteSetting.LoginFooter = viewmodel.LoginFooter;
                siteSetting.LoginUrl = viewmodel.LoginUrl;


                uow.SiteSettingsRepository.Update(siteSetting);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var siteSetting = uow.SiteSettingsRepository.GetById(id);

            SiteSettingsViewModel viewmodel = new SiteSettingsViewModel
            {
                Id = siteSetting.Id,
                SiteName = siteSetting.SiteName,
                IsRegister = siteSetting.IsRegister,
                SiteFooter = siteSetting.SiteFooter,
                FavIconURL = siteSetting.FavIconURL,
                SiteOwner = siteSetting.SiteOwner,
                CustomCSS = siteSetting.CustomCSS,
                CustomJS = siteSetting.CustomJS,
                IsCustomCSSOn = siteSetting.IsCustomCSSOn,
                IsCustomJsOn = siteSetting.IsCustomJsOn,
                SiteLastUpdated = DateTime.Now,
                GoogleSiteVerification = siteSetting.GoogleSiteVerification,
                GoogleAds = siteSetting.GoogelAds,
                UpdateBy = siteSetting.UpdateBy,
                HomeFooter = siteSetting.HomeFooter,
                HomeUrl = siteSetting.HomeUrl,
                AboutFooter = siteSetting.AboutFooter,
                AboutUrl = siteSetting.AboutUrl,
                ContactFooter = siteSetting.ContactFooter,
                ContactUrl = siteSetting.ContactUrl,
                RolesFooter = siteSetting.RolesFooter,
                RolesUrl = siteSetting.RolesUrl,
                ContactNumberFooter = siteSetting.ContactNumberFooter,
                EmailFooter = siteSetting.EmailFooter,
                AddresFooter = siteSetting.AddresFooter,
                ContentFooter = siteSetting.ContentFooter,
                CopyrightFooter = siteSetting.CopyrightFooter,
                LoginFooter = siteSetting.LoginFooter,
                LoginUrl = siteSetting.LoginFooter,
            };
            
                
            
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var siteFromdb = uow.SiteSettingsRepository.GetById(id);

            SiteSettingsViewModel viewmodel = new SiteSettingsViewModel
            {
                Id = siteFromdb.Id,
                SiteName = siteFromdb.SiteName,
                IsRegister = siteFromdb.IsRegister,
                SiteFooter = siteFromdb.SiteFooter,
                FavIconURL = siteFromdb.FavIconURL,
                SiteOwner = siteFromdb.SiteOwner,
                CustomCSS = siteFromdb.CustomCSS,
                CustomJS = siteFromdb.CustomJS,
                IsCustomCSSOn = siteFromdb.IsCustomCSSOn,
                IsCustomJsOn = siteFromdb.IsCustomJsOn,
                SiteLastUpdated = siteFromdb.SiteLastUpdated,
                UpdateBy = siteFromdb.UpdateBy,
                GoogleSiteVerification = siteFromdb.GoogleSiteVerification,
                GoogleAds = siteFromdb.GoogelAds,
                HomeFooter = siteFromdb.HomeFooter,
                HomeUrl = siteFromdb.HomeUrl,
                AboutFooter = siteFromdb.AboutFooter,
                AboutUrl = siteFromdb.AboutUrl,
                ContactFooter = siteFromdb.ContactFooter,
                ContactUrl = siteFromdb.ContactUrl,
                RolesFooter = siteFromdb.RolesFooter,
                RolesUrl = siteFromdb.RolesUrl,
                ContactNumberFooter = siteFromdb.ContactNumberFooter,
                EmailFooter = siteFromdb.EmailFooter,
                AddresFooter = siteFromdb.AddresFooter,
                ContentFooter = siteFromdb.ContentFooter,
                CopyrightFooter = siteFromdb.CopyrightFooter,
                LoginFooter = siteFromdb.LoginFooter,
                LoginUrl = siteFromdb.LoginFooter,
            };

            uow.SiteSettingsRepository.Remove(siteFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var siteSetting = uow.SiteSettingsRepository.GetById(id);

            SiteSettingsViewModel viewmodel = new SiteSettingsViewModel
            {
                Id = siteSetting.Id,
                SiteName = siteSetting.SiteName,
                IsRegister = siteSetting.IsRegister,
                SiteFooter = siteSetting.SiteFooter,
                FavIconURL = siteSetting.FavIconURL,
                SiteOwner = siteSetting.SiteOwner,
                CustomCSS = siteSetting.CustomCSS,
                CustomJS = siteSetting.CustomJS,
                IsCustomCSSOn = siteSetting.IsCustomCSSOn,
                IsCustomJsOn = siteSetting.IsCustomJsOn,
                SiteLastUpdated = DateTime.Now,
                UpdateBy = siteSetting.UpdateBy,
                GoogleSiteVerification = siteSetting.GoogleSiteVerification,
                GoogleAds = siteSetting.GoogelAds,
                HomeFooter = siteSetting.HomeFooter,
                HomeUrl = siteSetting.HomeUrl,
                AboutFooter = siteSetting.AboutFooter,
                AboutUrl = siteSetting.AboutUrl,
                ContactFooter = siteSetting.ContactFooter,
                ContactUrl = siteSetting.ContactUrl,
                RolesFooter = siteSetting.RolesFooter,
                RolesUrl = siteSetting.RolesUrl,
                ContactNumberFooter = siteSetting.ContactNumberFooter,
                EmailFooter = siteSetting.EmailFooter,
                AddresFooter = siteSetting.AddresFooter,
                ContentFooter = siteSetting.ContentFooter,
                CopyrightFooter = siteSetting.CopyrightFooter,
                LoginFooter = siteSetting.LoginFooter,
                LoginUrl = siteSetting.LoginFooter,
            };
            return View(viewmodel);
        }
    }
}