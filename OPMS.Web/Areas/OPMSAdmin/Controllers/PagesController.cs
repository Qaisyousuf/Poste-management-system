using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.Services;
using OPMS.ViewModels;
using System.Web.Mvc;
using OPMS.Web.Infrastructure;


namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class PagesController : Controller
    {
        private readonly IUnitOfWork uow;

        public PagesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void GetSidebar()
        {
            
            ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
            ViewBag.HomeBanner = uow.HomeBannerRepository.GetAll();
            ViewBag.HomeContent = uow.HomeContentRepository.GetAll();
            
        }
        public JsonResult GetPagesData()
        {
           
            //var pageFromdb = uow.Context.Pages.Include("Sidebars").ToList();
            var pageFromdb = uow.PageRepository.GetAll("Sidebars", "HomeBanner","HomeContent");
            return Json(new { data = pageFromdb }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            //var pagFromDb = uow.PageRepository.GetAll("Sidebars");
            //List<PageViewModel> viewmodel = new List<PageViewModel>();

            //foreach (var item in pagFromDb)
            //{
            //    viewmodel.Add(new PageViewModel
            //    {
            //        Id = item.Id,
            //        Title = item.Title,
            //        Slug = item.Slug,
            //        Content = item.Slug,
            //        MetaKeywords = item.MetaKeywords,
            //        MetaDescription = item.MetaDescription,
            //        IsPageMetaDataOn = item.IsPageMetaDataOn,
            //        IsVisibleToSearchEngine = item.IsVisibleToSearchEngine,
            //        SidebarId = item.SidebarId,
            //        Sidebars = item.Sidebars
            //    });
            //}
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetSidebar();
            return View();
        }
        [HttpPost]
        public ActionResult Create(PageViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                GetSidebar();
                ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
                // GetSidebar();
                return View(viewmodel);
            }
            string slug;
            Page page = new Page();
            page.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))

                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.PageRepository.SlugExists(slug))
            {
                GetSidebar();
                ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
                //GetSidebar();
                ModelState.AddModelError("", "Le titre ou le slug existe déjà");
                return View(viewmodel);
            }
            page.Slug = slug;
            page.Content = viewmodel.Content;
            page.MetaKeywordse = viewmodel.MetaKeywordsPage;
            page.MetaDescription = viewmodel.MetaDescriptionPage;
            page.IsPageMetaDataOn = viewmodel.IsPageMetaDataOn;
            page.SidebarId = viewmodel.SidebarId;
            page.Sidebars = viewmodel.Sidebars;
            page.BannerId = viewmodel.BannerId;
            page.HomeBanner = viewmodel.HomeBanner;
            page.HomeContentId = viewmodel.HomeContentId;
            page.HomeContent = viewmodel.HomeContent;
            page.IsVisibleToSearchEngine =( bool)viewmodel.IsVisibleToSearchEnginePage;

            uow.PageRepository.Add(page);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var page = uow.PageRepository.GetById(id);

            PageViewModel viewmodel = new PageViewModel
            {
                Id = page.Id,
                Title = page.Title,
                Slug = page.Slug,
                Content = page.Content,
                MetaKeywordsPage = page.MetaKeywordse,
                MetaDescriptionPage = page.MetaDescription,
                IsPageMetaDataOn = page.IsPageMetaDataOn,
                IsVisibleToSearchEnginePage = page.IsVisibleToSearchEngine,
                SidebarId = page.SidebarId,
                Sidebars = page.Sidebars,
                BannerId=page.BannerId,
                HomeBanner=page.HomeBanner,
                HomeContentId=page.HomeContentId,
                HomeContent=page.HomeContent,

            };
            GetSidebar();
            ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
            //GetSidebar();
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(PageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetSidebar();
                ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
                return View(viewmodel);
            }

            var page = uow.PageRepository.GetById(viewmodel.Id);

            page.Title = viewmodel.Title;

            string slug;
            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Slug);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.PageRepository.SlugExists(viewmodel.Id,slug))
            {
                ModelState.AddModelError("", "Le titre ou le slug existe déjà");
                ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
                return View(viewmodel);
            }
            page.Slug = slug;
            page.Content = viewmodel.Content;
            page.MetaKeywordse = viewmodel.MetaKeywordsPage;
            page.MetaDescription = viewmodel.MetaKeywordsPage;
            page.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEnginePage;
            page.IsPageMetaDataOn = viewmodel.IsPageMetaDataOn;
            page.SidebarId = viewmodel.SidebarId;
            page.Sidebars = viewmodel.Sidebars;
            page.BannerId = viewmodel.BannerId;
            page.HomeBanner = viewmodel.HomeBanner;
            page.HomeContentId = viewmodel.HomeContentId;
            page.HomeContent = viewmodel.HomeContent;
            uow.PageRepository.Update(page);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var pageDelete = uow.PageRepository.GetById(id);
            ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
            PageViewModel viewmodel = new PageViewModel
            {
                Id=pageDelete.Id,
                Title=pageDelete.Title,
                Slug=pageDelete.Slug,
                Content=pageDelete.Content,
                MetaKeywordsPage=pageDelete.MetaKeywordse,
                MetaDescriptionPage=pageDelete.MetaDescription,
                IsPageMetaDataOn=pageDelete.IsPageMetaDataOn,
                IsVisibleToSearchEnginePage=pageDelete.IsVisibleToSearchEngine,
                SidebarId=pageDelete.SidebarId,
                Sidebars=pageDelete.Sidebars,
                BannerId=pageDelete.BannerId,
                HomeBanner=pageDelete.HomeBanner,
                HomeContentId=pageDelete.HomeContentId,
                HomeContent=pageDelete.HomeContent,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var page = uow.PageRepository.GetById(id);
            PageViewModel viewmodel = new PageViewModel
            {
                Id=page.Id,
                Title=page.Title,
                Slug=page.Slug,
                Content=page.Content,
                IsPageMetaDataOn=page.IsPageMetaDataOn,
                IsVisibleToSearchEnginePage=page.IsVisibleToSearchEngine,
                MetaKeywordsPage=page.MetaKeywordse,
                MetaDescriptionPage=page.MetaKeywordse,
                SidebarId=page.SidebarId,
                Sidebars=page.Sidebars,
                BannerId=page.BannerId,
                HomeBanner=page.HomeBanner,
                HomeContentId=page.HomeContentId,
                HomeContent=page.HomeContent,
            };
            uow.PageRepository.Remove(page);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var pageDelete = uow.PageRepository.GetById(id);
            ViewBag.SidebarDropDownList = uow.SidebarRepository.GetAll();
            PageViewModel viewmodel = new PageViewModel
            {
                Id = pageDelete.Id,
                Title = pageDelete.Title,
                Slug = pageDelete.Slug,
                Content = pageDelete.Content,
                MetaKeywordsPage = pageDelete.MetaKeywordse,
                MetaDescriptionPage = pageDelete.MetaDescription,
                IsPageMetaDataOn = pageDelete.IsPageMetaDataOn,
                IsVisibleToSearchEnginePage = pageDelete.IsVisibleToSearchEngine,
                SidebarId = pageDelete.SidebarId,
                Sidebars = pageDelete.Sidebars,
                BannerId=pageDelete.BannerId,
                HomeBanner=pageDelete.HomeBanner,
                HomeContentId=pageDelete.HomeContentId,
                HomeContent=pageDelete.HomeContent,
            };
            return View(viewmodel);
        }
       
    }

    
}