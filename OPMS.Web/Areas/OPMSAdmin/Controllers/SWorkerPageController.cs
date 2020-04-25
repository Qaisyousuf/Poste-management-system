using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class SWorkerPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public SWorkerPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        private void BannerData()
        {
            ViewBag.Banner = uow.SWBaneerRepository.GetAll();
        }
        public JsonResult DetSWorkerData()
        {
            var sWorkerFromdb = uow.SWorkerPageRepository.GetAll("SWbanners");

            return Json(new { data = sWorkerFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            BannerData();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SWorkerPageVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                SWorkerPage sWorker = new SWorkerPage
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ButtonText=viewmodel.ButtonText,
                    SubContent=viewmodel.SubContent,
                    GoogleMapAPIUrl=viewmodel.GoogleMapAPIUrl,
                    IsSWorkertMetaDataOn=viewmodel.IsSWorkertMetaDataOn,
                    MetaKeywordse=viewmodel.MetaKeywordseSworker,
                    MetaDescription=viewmodel.MetaDescriptionSworker,
                    IsVisibleToSearchEngine=viewmodel.IsVisibleToSearchEngineSworker,
                    BannerId=viewmodel.BannerId,
                };
                uow.SWorkerPageRepository.Add(sWorker);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            BannerData();
            var sWorker = uow.SWorkerPageRepository.GetById(id);

            SWorkerPageVM viewmodel = new SWorkerPageVM
            {
                Id=sWorker.Id,
                Title=sWorker.Title,
                Content=sWorker.Content,
                ButtonUrl=sWorker.ButtonUrl,
                ButtonText=sWorker.ButtonText,
                SubContent=sWorker.SubContent,
                GoogleMapAPIUrl=sWorker.GoogleMapAPIUrl,
                IsSWorkertMetaDataOn=sWorker.IsSWorkertMetaDataOn,
                MetaKeywordseSworker=sWorker.MetaKeywordse,
                MetaDescriptionSworker=sWorker.MetaKeywordse,
                IsVisibleToSearchEngineSworker=sWorker.IsVisibleToSearchEngine,
                BannerId=sWorker.BannerId,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(SWorkerPageVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                var sworkerFromdb = uow.SWorkerPageRepository.GetById(viewmodel.Id);
                sworkerFromdb.Id = viewmodel.Id;
                sworkerFromdb.Title = viewmodel.Title;
                sworkerFromdb.Content = viewmodel.Content;
                sworkerFromdb.ButtonUrl = viewmodel.ButtonUrl;
                sworkerFromdb.ButtonText = viewmodel.ButtonText;
                sworkerFromdb.SubContent = viewmodel.SubContent;
                sworkerFromdb.GoogleMapAPIUrl = viewmodel.GoogleMapAPIUrl;
                sworkerFromdb.IsSWorkertMetaDataOn = viewmodel.IsSWorkertMetaDataOn;
                sworkerFromdb.MetaKeywordse = viewmodel.MetaKeywordseSworker;
                sworkerFromdb.MetaDescription = viewmodel.MetaDescriptionSworker;
                sworkerFromdb.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngineSworker;
                sworkerFromdb.BannerId = viewmodel.BannerId;

                uow.SWorkerPageRepository.Update(sworkerFromdb);
                uow.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            BannerData();
            var sWorker = uow.SWorkerPageRepository.GetById(id);

            SWorkerPageVM viewmodel = new SWorkerPageVM
            {
                Id = sWorker.Id,
                Title = sWorker.Title,
                Content = sWorker.Content,
                ButtonUrl = sWorker.ButtonUrl,
                ButtonText = sWorker.ButtonText,
                SubContent = sWorker.SubContent,
                GoogleMapAPIUrl = sWorker.GoogleMapAPIUrl,
                IsSWorkertMetaDataOn = sWorker.IsSWorkertMetaDataOn,
                MetaKeywordseSworker = sWorker.MetaKeywordse,
                MetaDescriptionSworker = sWorker.MetaKeywordse,
                IsVisibleToSearchEngineSworker = sWorker.IsVisibleToSearchEngine,
                BannerId=sWorker.BannerId,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            var sWorker = uow.SWorkerPageRepository.GetById(id);

            SWorkerPageVM viewmodel = new SWorkerPageVM
            {
                Id = sWorker.Id,
                Title = sWorker.Title,
                Content = sWorker.Content,
                ButtonUrl = sWorker.ButtonUrl,
                ButtonText = sWorker.ButtonText,
                SubContent = sWorker.SubContent,
                GoogleMapAPIUrl = sWorker.GoogleMapAPIUrl,
                IsSWorkertMetaDataOn = sWorker.IsSWorkertMetaDataOn,
                MetaKeywordseSworker = sWorker.MetaKeywordse,
                MetaDescriptionSworker = sWorker.MetaKeywordse,
                IsVisibleToSearchEngineSworker = sWorker.IsVisibleToSearchEngine,
                BannerId=sWorker.BannerId,
            };
            uow.SWorkerPageRepository.Remove(sWorker);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            BannerData();
            var sWorker = uow.SWorkerPageRepository.GetById(id);

            SWorkerPageVM viewmodel = new SWorkerPageVM
            {
                Id = sWorker.Id,
                Title = sWorker.Title,
                Content = sWorker.Content,
                ButtonUrl = sWorker.ButtonUrl,
                ButtonText = sWorker.ButtonText,
                SubContent = sWorker.SubContent,
                GoogleMapAPIUrl = sWorker.GoogleMapAPIUrl,
                IsSWorkertMetaDataOn = sWorker.IsSWorkertMetaDataOn,
                MetaKeywordseSworker = sWorker.MetaKeywordse,
                MetaDescriptionSworker = sWorker.MetaKeywordse,
                IsVisibleToSearchEngineSworker = sWorker.IsVisibleToSearchEngine,
                BannerId=sWorker.BannerId,
            };
            return View(viewmodel);
        }
    }
}