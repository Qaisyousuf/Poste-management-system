using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.Services;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;
using System.Web.Mvc;


namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class AboutPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public AboutPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {

            return View();
        }

        private void AboutPageRelatedData()
        {
           ViewBag.shortSection = uow.AboutShortSectionRepository.GetAll();
          ViewBag.aboutSetcon = uow.AboutSectionRepository.GetAll();
        }

        public JsonResult GetAboutPageData()
        {
            AboutPageRelatedData();
            var pageFromdb = uow.AboutPageRepository.GetAll("AboutSection", "AboutShortSection");
            return Json(new { data = pageFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            AboutPageRelatedData();
            return View();
        }
        [HttpPost]
        public ActionResult Create(AboutPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                AboutPageRelatedData();
                return View(viewmodel);
            }
            string slug;
            AboutPage aboutPage = new AboutPage();

            aboutPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.AboutPageRepository.SlugExists(slug))
            {
                ModelState.AddModelError("", "Title or slug already exists");
                AboutPageRelatedData();
                return View(viewmodel);
            }
            aboutPage.Slug = slug;
            aboutPage.MainTitle = viewmodel.MainTitle;
            aboutPage.BannerImage = viewmodel.BannerImage;
            aboutPage.SubTitle = viewmodel.SubTitle;
            aboutPage.ButtonUrl = viewmodel.ButtonUrl;
            aboutPage.Content = viewmodel.Content;
            aboutPage.IsAboutMetaDataOn = viewmodel.IsAboutMetaDataOn;
            aboutPage.MetaKeywordse = viewmodel.MetaKeywordseAbout;
            aboutPage.MetaDescription = viewmodel.MetaDescriptionAbout;
            aboutPage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngineAbout;
            aboutPage.AboutSection = viewmodel.AboutSection;
            aboutPage.SectoinId = viewmodel.SectoinId;
            aboutPage.ShortSectionId = viewmodel.ShortSectionId;

            uow.AboutPageRepository.Add(aboutPage);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aboutPageFromdb = uow.AboutPageRepository.GetById(id);
            AboutPageRelatedData();

            AboutPageViewModel viewmodel = new AboutPageViewModel
            {
                Id=aboutPageFromdb.Id,
                Title=aboutPageFromdb.Title,
                Slug=aboutPageFromdb.Slug,
                MainTitle=aboutPageFromdb.MainTitle,
                BannerImage=aboutPageFromdb.BannerImage,
                SubTitle=aboutPageFromdb.SubTitle,
                ButtonUrl=aboutPageFromdb.ButtonUrl,
                Content=aboutPageFromdb.Content,
                IsAboutMetaDataOn=aboutPageFromdb.IsAboutMetaDataOn,
               MetaKeywordseAbout=aboutPageFromdb.MetaDescription,
               MetaDescriptionAbout=aboutPageFromdb.MetaDescription,
               IsVisibleToSearchEngineAbout=aboutPageFromdb.IsVisibleToSearchEngine,
               SectoinId=aboutPageFromdb.SectoinId,
               AboutSection=aboutPageFromdb.AboutSection,
               AboutShortSection=aboutPageFromdb.AboutShortSection,
               ShortSectionId=aboutPageFromdb.ShortSectionId,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(AboutPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                AboutPageRelatedData();
                return View(viewmodel);
            }

            string slug;
            var aboutPage = uow.AboutPageRepository.GetById(viewmodel.Id);

            aboutPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.AboutPageRepository.SlugExists(viewmodel.Id,slug))
            {
                ModelState.AddModelError("", "Title or slug already exists try again");
                AboutPageRelatedData();
                return View(viewmodel);
            }
            aboutPage.Slug = slug;
            aboutPage.MainTitle = viewmodel.MainTitle;
            aboutPage.BannerImage = viewmodel.BannerImage;
            aboutPage.SubTitle = viewmodel.SubTitle;
            aboutPage.ButtonUrl = viewmodel.ButtonUrl;
            aboutPage.Content = viewmodel.Content;
            aboutPage.IsAboutMetaDataOn = viewmodel.IsAboutMetaDataOn;
            aboutPage.MetaDescription = viewmodel.MetaDescriptionAbout;
            aboutPage.MetaKeywordse = viewmodel.MetaKeywordseAbout;
            aboutPage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngineAbout;
            aboutPage.SectoinId = viewmodel.SectoinId;
            aboutPage.ShortSectionId = viewmodel.ShortSectionId;
            aboutPage.AboutShortSection = viewmodel.AboutShortSection;
            aboutPage.AboutSection = viewmodel.AboutSection;

            uow.AboutPageRepository.Update(aboutPage);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var aboutPage = uow.AboutPageRepository.GetById(id);

            AboutPageRelatedData();

            AboutPageViewModel viewmodel = new AboutPageViewModel
            {
                Id = aboutPage.Id,
                Title = aboutPage.Title,
                Slug = aboutPage.Slug,
                MainTitle = aboutPage.MainTitle,
                BannerImage = aboutPage.BannerImage,
                SubTitle = aboutPage.SubTitle,
                ButtonUrl = aboutPage.ButtonUrl,
                Content = aboutPage.Content,
                IsAboutMetaDataOn = aboutPage.IsAboutMetaDataOn,
                MetaKeywordseAbout = aboutPage.MetaKeywordse,
                MetaDescriptionAbout = aboutPage.MetaDescription,
                IsVisibleToSearchEngineAbout = aboutPage.IsVisibleToSearchEngine,
                SectoinId = aboutPage.SectoinId,
                AboutSection = aboutPage.AboutSection,
                AboutShortSection = aboutPage.AboutShortSection
            };

            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var aboutfromdb = uow.AboutPageRepository.GetById(id);

            AboutPageViewModel viewmodel = new AboutPageViewModel
            {
                Id=aboutfromdb.Id,
                Title=aboutfromdb.Title,
                Slug=aboutfromdb.Slug,
                MainTitle=aboutfromdb.MainTitle,
                BannerImage=aboutfromdb.BannerImage,
                SubTitle=aboutfromdb.SubTitle,
                ButtonUrl=aboutfromdb.ButtonUrl,
                Content=aboutfromdb.Content,
                IsAboutMetaDataOn=aboutfromdb.IsAboutMetaDataOn,
                MetaKeywordseAbout=aboutfromdb.MetaKeywordse,
                MetaDescriptionAbout=aboutfromdb.MetaDescription,
                IsVisibleToSearchEngineAbout=aboutfromdb.IsVisibleToSearchEngine,
                AboutSection=aboutfromdb.AboutSection,
                SectoinId=aboutfromdb.SectoinId,
                AboutShortSection=aboutfromdb.AboutShortSection,
                ShortSectionId=aboutfromdb.ShortSectionId
            };

            uow.AboutPageRepository.Remove(aboutfromdb);
            uow.Commit();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var aboutPage = uow.AboutPageRepository.GetById(id);

            AboutPageRelatedData();

            AboutPageViewModel viewmodel = new AboutPageViewModel
            {
                Id = aboutPage.Id,
                Title = aboutPage.Title,
                Slug = aboutPage.Slug,
                MainTitle = aboutPage.MainTitle,
                BannerImage = aboutPage.BannerImage,
                SubTitle = aboutPage.SubTitle,
                ButtonUrl = aboutPage.ButtonUrl,
                Content = aboutPage.Content,
                IsAboutMetaDataOn = aboutPage.IsAboutMetaDataOn,
                MetaKeywordseAbout = aboutPage.MetaKeywordse,
                MetaDescriptionAbout = aboutPage.MetaDescription,
                IsVisibleToSearchEngineAbout = aboutPage.IsVisibleToSearchEngine,
                SectoinId = aboutPage.SectoinId,
                AboutSection = aboutPage.AboutSection,
                AboutShortSection = aboutPage.AboutShortSection
            };

            return View(viewmodel);
        }
    }
}