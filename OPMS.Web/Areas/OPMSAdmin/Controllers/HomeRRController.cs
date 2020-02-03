using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.ViewModels;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class HomeRRController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeRRController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetHomeRRData()
        {
            var homeRR = uow.HomeRRepository.GetAll();

            return Json(new { data = homeRR }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HomeRRViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                HomeRR homrRR = new HomeRR
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    IconUrl=viewmodel.IconUrl,
                };
                uow.HomeRRepository.Add(homrRR);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var homeRR = uow.HomeRRepository.GetById(id);

            HomeRRViewModel viewmodel = new HomeRRViewModel
            {
                Id=homeRR.Id,
                Title=homeRR.Title,
                Content=homeRR.Content,
                IconUrl=homeRR.IconUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(HomeRRViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var homrrFromdb = uow.HomeRRepository.GetById(viewmodel.Id);
                homrrFromdb.Id = viewmodel.Id;
                homrrFromdb.Title = viewmodel.Title;
                homrrFromdb.Content = viewmodel.Content;
                homrrFromdb.IconUrl = viewmodel.IconUrl;

                uow.HomeRRepository.Update(homrrFromdb);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var homeRR = uow.HomeRRepository.GetById(id);

            HomeRRViewModel viewmodel = new HomeRRViewModel
            {
                Id = homeRR.Id,
                Title = homeRR.Title,
                Content = homeRR.Content,
                IconUrl = homeRR.IconUrl,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var homeRRFromdb = uow.HomeRRepository.GetById(id);

            HomeRRViewModel viewmodle = new HomeRRViewModel
            {
                Id=homeRRFromdb.Id,
                Title=homeRRFromdb.Title,
                Content=homeRRFromdb.Content,
                IconUrl=homeRRFromdb.IconUrl
            };
            uow.HomeRRepository.Remove(homeRRFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var homeRR = uow.HomeRRepository.GetById(id);

            HomeRRViewModel viewmodel = new HomeRRViewModel
            {
                Id = homeRR.Id,
                Title = homeRR.Title,
                Content = homeRR.Content,
                IconUrl = homeRR.IconUrl,
            };
            return View(viewmodel);
        }
    }
}