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
            //var siteSetting = uow.SiteSettingsRepository.GetAll();

            //List<SiteSettingsViewModel> viewmodel = new List<SiteSettingsViewModel>();

            //foreach (var site in siteSetting)
            //{
            //    viewmodel.Add(new SiteSettingsViewModel
            //    {
            //        Id=site.Id,
            //        SiteName=site.SiteName,
            //        IsRegister=site.IsRegister,
            //        SiteFooter=site.SiteFooter,
            //        FavIconURL=site.FavIconURL,
            //        SiteOwner=site.SiteOwner,
            //        GoogleSiteVerification=site.GoogleSiteVerification,
            //        GoogleAds=site.GoogleAds,
            //        GoogleAnalytics=site.GoogleAnalytics,
            //        CustomCSS=site.CustomCSS,
            //        CustomJS=site.CustomJS,
            //        IsCustomCSSOn=site.IsCustomCSSOn,
            //        IsCustomJsOn=site.IsCustomJsOn,
            //        SiteLastUpdated=site.SiteLastUpdated,
            //        UpdateBy=site.UpdateBy

            //    });
            //}

            //return View(viewmodel);
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
        public ActionResult Create(SiteSettings model)
        {
            if(ModelState.IsValid)
            {
                model.SiteLastUpdated = DateTime.Now;
                uow.SiteSettingsRepository.Add(model);
                uow.Commit();
                return RedirectToAction(nameof(Index));
              // string username = uow.Context.Users.Where(x => x.UserName ==User.Identity.Name).FirstOrDefault().ToString();
            //    SiteSettings siteSettings = new SiteSettings
            //    {
            //        //Id = viewmodel.Id,
            //        //SiteName = viewmodel.SiteName,
            //        //IsRegister = viewmodel.IsRegister,
            //        //SiteFooter = viewmodel.SiteFooter,
            //        //FavIconURL = viewmodel.FavIconURL,
            //        //SiteOwner = viewmodel.SiteOwner,
            //        //CustomCSS = viewmodel.CustomCSS,
            //        //CustomJS = viewmodel.CustomJS,
            //        //IsCustomCSSOn = viewmodel.IsCustomCSSOn,
            //        //IsCustomJsOn = viewmodel.IsCustomJsOn,
            //        //SiteLastUpdated = DateTime.Now,
            //        //GoogleSiteVerification=viewmodel.GoogleSiteVerification,
            //        //GoogelAds=viewmodel.GoogleAds,
            //        //UpdateBy = viewmodel.UpdateBy,
            //        //HomeFooter=viewmodel.HomeFooter,
            //        //HomeUrl=viewmodel.HomeUrl,
            //        //AboutFooter=viewmodel.AboutFooter,
            //        //AboutUrl=viewmodel.AboutUrl,
            //        //ContactFooter=viewmodel.ContactFooter,
            //        //ContactUrl=viewmodel.ContactUrl,
            //        //RolesFooter=viewmodel.RolesFooter,
            //        //RolesUrl=viewmodel.RolesUrl,
            //        //ContactNumberFooter=viewmodel.ContactNumberFooter,
            //        //EmailFooter=viewmodel.EmailFooter,
            //        //AddresFooter=viewmodel.AddresFooter,
            //        //ContentFooter=viewmodel.ContentFooter,
            //        //CopyrightFooter=viewmodel.CopyrightFooter,
            //        //LoginFooter=viewmodel.CopyrightFooter,
            //        //LoginUrl=viewmodel.LoginUrl,

                    

            //    };
            //    uow.SiteSettingsRepository.Add(siteSettings);
            //    uow.Commit();
            //    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var siteSetting = uow.SiteSettingsRepository.GetById(id);

            //SiteSettingsViewModel viewmodel = new SiteSettingsViewModel
            //{
            //    Id = siteSetting.Id,
            //    SiteName=siteSetting.SiteName,
            //    IsRegister=siteSetting.IsRegister,
            //    SiteFooter=siteSetting.SiteFooter,
            //    FavIconURL=siteSetting.FavIconURL,
            //    SiteOwner=siteSetting.SiteOwner,
            //    CustomCSS=siteSetting.CustomCSS,
            //    CustomJS=siteSetting.CustomJS,
            //    IsCustomCSSOn=siteSetting.IsCustomCSSOn,
            //    IsCustomJsOn=siteSetting.IsCustomJsOn,
            //    SiteLastUpdated=DateTime.Now,
            //    GoogleAds=siteSetting.GoogelAds,
            //    GoogleSiteVerification=siteSetting.GoogleSiteVerification,
            //    UpdateBy=siteSetting.UpdateBy,
            //    HomeFooter=siteSetting.HomeFooter,
            //    HomeUrl = siteSetting.HomeUrl,
            //    AboutFooter = siteSetting.AboutFooter,
            //    AboutUrl = siteSetting.AboutUrl,
            //    ContactFooter = siteSetting.ContactFooter,
            //    ContactUrl = siteSetting.ContactUrl,
            //    RolesFooter = siteSetting.RolesFooter,
            //    RolesUrl = siteSetting.RolesUrl,
            //    ContactNumberFooter = siteSetting.ContactNumberFooter,
            //    EmailFooter = siteSetting.EmailFooter,
            //    AddresFooter = siteSetting.AddresFooter,
            //    ContentFooter = siteSetting.ContentFooter,
            //    CopyrightFooter = siteSetting.CopyrightFooter,
            //    LoginFooter = siteSetting.LoginFooter,
            //    LoginUrl = siteSetting.LoginFooter,
            //};
            return View(siteSetting);
        }
        [HttpPost]
        public ActionResult Edit(SiteSettings Settings)
        {
            if(ModelState.IsValid)
            {
                var siteSetting = uow.SiteSettingsRepository.GetById(Settings.Id);

                siteSetting.Id = Settings.Id;
                siteSetting.SiteName = Settings.SiteName;
                siteSetting.IsRegister = Settings.IsRegister;
                siteSetting.SiteFooter = Settings.SiteFooter;
                siteSetting.FavIconURL = Settings.FavIconURL;
                siteSetting.SiteOwner = Settings.SiteOwner;
                siteSetting.CustomCSS = Settings.CustomCSS;
                siteSetting.CustomJS = Settings.CustomJS;
                siteSetting.IsCustomCSSOn = Settings.IsCustomCSSOn;
                siteSetting.IsCustomJsOn = Settings.IsCustomJsOn;
                siteSetting.SiteLastUpdated = DateTime.Now;
                siteSetting.GoogelAds = Settings.GoogelAds;
                siteSetting.GoogleSiteVerification = Settings.GoogleSiteVerification;
                siteSetting.UpdateBy = Settings.UpdateBy;
                siteSetting.HomeFooter = Settings.HomeFooter;
                siteSetting.HomeUrl = Settings.HomeUrl;
                siteSetting.AboutFooter = Settings.AboutFooter;
                siteSetting.AboutUrl = Settings.AboutUrl;
                siteSetting.ContentFooter = Settings.ContentFooter;
                siteSetting.ContactUrl = Settings.ContactUrl;
                siteSetting.RolesFooter = Settings.RolesFooter;
                siteSetting.RolesUrl = Settings.RolesUrl;
                siteSetting.ContactNumberFooter = Settings.ContactNumberFooter;
                siteSetting.EmailFooter = Settings.EmailFooter;
                siteSetting.AddresFooter = Settings.AddresFooter;
                siteSetting.ContentFooter = Settings.ContentFooter;
                siteSetting.CopyrightFooter = Settings.CopyrightFooter;
                siteSetting.LoginFooter = Settings.LoginFooter;
                siteSetting.LoginUrl = Settings.LoginUrl;


                uow.SiteSettingsRepository.Update(siteSetting);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(Settings);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var siteSetting = uow.SiteSettingsRepository.GetById(id);

           
           // {
            //    Id = siteSetting.Id,
            //    SiteName = siteSetting.SiteName,
            //    IsRegister = siteSetting.IsRegister,
            //    SiteFooter = siteSetting.SiteFooter,
            //    FavIconURL = siteSetting.FavIconURL,
            //    SiteOwner = siteSetting.SiteOwner,
            //    CustomCSS = siteSetting.CustomCSS,
            //    CustomJS = siteSetting.CustomJS,
            //    IsCustomCSSOn = siteSetting.IsCustomCSSOn,
            //    IsCustomJsOn = siteSetting.IsCustomJsOn,
            //    SiteLastUpdated = DateTime.Now,
            //    GoogleSiteVerification=siteSetting.GoogleSiteVerification,
            //    GoogleAds=siteSetting.GoogelAds,
            //    UpdateBy = siteSetting.UpdateBy,
            //     HomeFooter = siteSetting.HomeFooter,
            //    HomeUrl = siteSetting.HomeUrl,
            //    AboutFooter = siteSetting.AboutFooter,
            //    AboutUrl = siteSetting.AboutUrl,
            //    ContactFooter = siteSetting.ContactFooter,
            //    ContactUrl = siteSetting.ContactUrl,
            //    RolesFooter = siteSetting.RolesFooter,
            //    RolesUrl = siteSetting.RolesUrl,
            //    ContactNumberFooter = siteSetting.ContactNumberFooter,
            //    EmailFooter = siteSetting.EmailFooter,
            //    AddresFooter = siteSetting.AddresFooter,
            //    ContentFooter = siteSetting.ContentFooter,
            //    CopyrightFooter = siteSetting.CopyrightFooter,
            //    LoginFooter = siteSetting.LoginFooter,
            //    LoginUrl = siteSetting.LoginFooter,
            //};
            return View(siteSetting);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var siteFromdb = uow.SiteSettingsRepository.GetById(id);

            //SiteSettingsViewModel viewmodel = new SiteSettingsViewModel
            //{
            //    Id=siteFromdb.Id,
            //    SiteName=siteFromdb.SiteName,
            //    IsRegister=siteFromdb.IsRegister,
            //    SiteFooter=siteFromdb.SiteFooter,
            //    FavIconURL=siteFromdb.FavIconURL,
            //    SiteOwner=siteFromdb.SiteOwner,
            //    CustomCSS=siteFromdb.CustomCSS,
            //    CustomJS=siteFromdb.CustomJS,
            //    IsCustomCSSOn=siteFromdb.IsCustomCSSOn,
            //    IsCustomJsOn=siteFromdb.IsCustomJsOn,
            //    SiteLastUpdated=siteFromdb.SiteLastUpdated,
            //    UpdateBy=siteFromdb.UpdateBy,
            //       GoogleSiteVerification = siteFromdb.GoogleSiteVerification,
            //    GoogleAds = siteFromdb.GoogelAds,
              
            //    HomeFooter = siteFromdb.HomeFooter,
            //    HomeUrl = siteFromdb.HomeUrl,
            //    AboutFooter = siteFromdb.AboutFooter,
            //    AboutUrl = siteFromdb.AboutUrl,
            //    ContactFooter = siteFromdb.ContactFooter,
            //    ContactUrl = siteFromdb.ContactUrl,
            //    RolesFooter = siteFromdb.RolesFooter,
            //    RolesUrl = siteFromdb.RolesUrl,
            //    ContactNumberFooter = siteFromdb.ContactNumberFooter,
            //    EmailFooter = siteFromdb.EmailFooter,
            //    AddresFooter = siteFromdb.AddresFooter,
            //    ContentFooter = siteFromdb.ContentFooter,
            //    CopyrightFooter = siteFromdb.CopyrightFooter,
            //    LoginFooter = siteFromdb.LoginFooter,
            //    LoginUrl = siteFromdb.LoginFooter,
            //};

            uow.SiteSettingsRepository.Remove(siteFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var siteSetting = uow.SiteSettingsRepository.GetById(id);

            //SiteSettingsViewModel viewmodel = new SiteSettingsViewModel
            //{
            //    Id = siteSetting.Id,
            //    SiteName = siteSetting.SiteName,
            //    IsRegister = siteSetting.IsRegister,
            //    SiteFooter = siteSetting.SiteFooter,
            //    FavIconURL = siteSetting.FavIconURL,
            //    SiteOwner = siteSetting.SiteOwner,
            //    CustomCSS = siteSetting.CustomCSS,
            //    CustomJS = siteSetting.CustomJS,
            //    IsCustomCSSOn = siteSetting.IsCustomCSSOn,
            //    IsCustomJsOn = siteSetting.IsCustomJsOn,
            //    SiteLastUpdated = DateTime.Now,
            //    UpdateBy = siteSetting.UpdateBy,
            //    GoogleSiteVerification = siteSetting.GoogleSiteVerification,
            //    GoogleAds = siteSetting.GoogelAds,
              
            //    HomeFooter = siteSetting.HomeFooter,
            //    HomeUrl = siteSetting.HomeUrl,
            //    AboutFooter = siteSetting.AboutFooter,
            //    AboutUrl = siteSetting.AboutUrl,
            //    ContactFooter = siteSetting.ContactFooter,
            //    ContactUrl = siteSetting.ContactUrl,
            //    RolesFooter = siteSetting.RolesFooter,
            //    RolesUrl = siteSetting.RolesUrl,
            //    ContactNumberFooter = siteSetting.ContactNumberFooter,
            //    EmailFooter = siteSetting.EmailFooter,
            //    AddresFooter = siteSetting.AddresFooter,
            //    ContentFooter = siteSetting.ContentFooter,
            //    CopyrightFooter = siteSetting.CopyrightFooter,
            //    LoginFooter = siteSetting.LoginFooter,
            //    LoginUrl = siteSetting.LoginFooter,
            //};
            return View(siteSetting);
        }
    }
}