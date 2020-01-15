using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class SiteSettingsController : Controller
    {
        private readonly IUnitOfWork uow;

        public SiteSettingsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var siteSetting = uow.SiteSettingsRepository.GetAll();

            List<SiteSettingsViewModel> viewmodel = new List<SiteSettingsViewModel>();

            foreach (var site in siteSetting)
            {
                viewmodel.Add(new SiteSettingsViewModel
                {
                    Id=site.Id,
                    SiteName=site.SiteName,
                    IsRegister=site.IsRegister,
                    SiteFooter=site.SiteFooter,
                    FavIconURL=site.FavIconURL,
                    SiteOwner=site.SiteOwner,
                    GoogleSiteVerification=site.GoogleSiteVerification,
                    GoogleAds=site.GoogleAds,
                    GoogleAnalytics=site.GoogleAnalytics,
                    CustomCSS=site.CustomCSS,
                    CustomJS=site.CustomJS,
                    IsCustomCSSOn=site.IsCustomCSSOn,
                    IsCustomJsOn=site.IsCustomJsOn,
                    SiteLastUpdated=site.SiteLastUpdated,
                    UpdateBy=site.UpdateBy
                    
                });
            }

            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var username = uow.UserRepository.GetAll("UserModel");
            return View();
        }
        [HttpPost]
        public ActionResult Create(SiteSettingsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
               // string username = uow.Context.Users.Where(x => x.UserName ==User.Identity.Name).FirstOrDefault().ToString();
                SiteSettings siteSettings = new SiteSettings
                {
                    Id = viewmodel.Id,
                    SiteName = viewmodel.SiteName,
                    IsRegister = viewmodel.IsRegister,
                    SiteFooter = viewmodel.SiteFooter,
                    FavIconURL = viewmodel.FavIconURL,
                    SiteOwner = viewmodel.SiteOwner,
                    GoogleSiteVerification = viewmodel.GoogleSiteVerification,
                    GoogleAds = viewmodel.GoogleAds,
                    GoogleAnalytics = viewmodel.GoogleAnalytics,
                    CustomCSS = viewmodel.CustomCSS,
                    CustomJS = viewmodel.CustomJS,
                    IsCustomCSSOn = viewmodel.IsCustomCSSOn,
                    IsCustomJsOn = viewmodel.IsCustomJsOn,
                    SiteLastUpdated = DateTime.Now,
                    UpdateBy =viewmodel.UpdateBy
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
                SiteName=siteSetting.SiteName,
                IsRegister=siteSetting.IsRegister,
                SiteFooter=siteSetting.SiteFooter,
                FavIconURL=siteSetting.FavIconURL,
                SiteOwner=siteSetting.SiteOwner,
                GoogleSiteVerification=siteSetting.GoogleSiteVerification,
                GoogleAds=siteSetting.GoogleAds,
                GoogleAnalytics=siteSetting.GoogleAnalytics,
                CustomCSS=siteSetting.CustomCSS,
                CustomJS=siteSetting.CustomJS,
                IsCustomCSSOn=siteSetting.IsCustomCSSOn,
                IsCustomJsOn=siteSetting.IsCustomJsOn,
                SiteLastUpdated=DateTime.Now,
                UpdateBy=siteSetting.UpdateBy
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(SiteSettingsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var siteSetting = uow.SiteSettingsRepository.GetById(viewmodel.Id);

                siteSetting.Id = viewmodel.Id;
                siteSetting.SiteName = viewmodel.SiteName;
                siteSetting.IsRegister = viewmodel.IsRegister;
                siteSetting.SiteFooter = viewmodel.SiteFooter;
                siteSetting.FavIconURL = viewmodel.FavIconURL;
                siteSetting.SiteOwner = viewmodel.SiteOwner;
                siteSetting.GoogleAds = viewmodel.GoogleAds;
                siteSetting.GoogleAnalytics = viewmodel.GoogleAnalytics;
                siteSetting.GoogleSiteVerification = viewmodel.GoogleSiteVerification;
                siteSetting.CustomCSS = viewmodel.CustomCSS;
                siteSetting.CustomJS = viewmodel.CustomJS;
                siteSetting.IsCustomCSSOn = viewmodel.IsCustomCSSOn;
                siteSetting.IsCustomJsOn = viewmodel.IsCustomJsOn;
                siteSetting.SiteLastUpdated = DateTime.Now;
                siteSetting.UpdateBy = viewmodel.UpdateBy;

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
                GoogleSiteVerification = siteSetting.GoogleSiteVerification,
                GoogleAds = siteSetting.GoogleAds,
                GoogleAnalytics = siteSetting.GoogleAnalytics,
                CustomCSS = siteSetting.CustomCSS,
                CustomJS = siteSetting.CustomJS,
                IsCustomCSSOn = siteSetting.IsCustomCSSOn,
                IsCustomJsOn = siteSetting.IsCustomJsOn,
                SiteLastUpdated = DateTime.Now,
                UpdateBy = siteSetting.UpdateBy
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
                Id=siteFromdb.Id,
                SiteName=siteFromdb.SiteName,
                IsRegister=siteFromdb.IsRegister,
                SiteFooter=siteFromdb.SiteFooter,
                FavIconURL=siteFromdb.FavIconURL,
                SiteOwner=siteFromdb.SiteOwner,
                GoogleAds=siteFromdb.GoogleAds,
                GoogleAnalytics=siteFromdb.GoogleAnalytics,
                GoogleSiteVerification=siteFromdb.GoogleSiteVerification,
                CustomCSS=siteFromdb.CustomCSS,
                CustomJS=siteFromdb.CustomJS,
                IsCustomCSSOn=siteFromdb.IsCustomCSSOn,
                IsCustomJsOn=siteFromdb.IsCustomJsOn,
                SiteLastUpdated=siteFromdb.SiteLastUpdated,
                UpdateBy=siteFromdb.UpdateBy
            };

            uow.SiteSettingsRepository.Remove(siteFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));

        }
    }
}