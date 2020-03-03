using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Models;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class MainPostSystemController : Controller
    {
        private readonly IUnitOfWork uow;

        public MainPostSystemController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var mainPostFromdb = uow.UserRepository.GetAll();

            List<MainPostSystemVM> viewmodel = new List<MainPostSystemVM>();

            foreach (var item in mainPostFromdb)
            {
                viewmodel.Add(new MainPostSystemVM
                {
                   Id=item.Id,
                    UserName=item.UserName,
                    
                });
            }

            return View(viewmodel);
        }

        public JsonResult PostMainData()
        {
            var postFromdb = uow.UserRepository.GetAll();

            return Json(new { data = postFromdb }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.postSystem = uow.PostSystemRepository.GetAll();
            ViewBag.SocialWorker = uow.SocialWorkerRepository.GetAll();
            ViewBag.UserId = uow.UserRepository.GetAll();

            var userFromdb = uow.UserRepository.GetById(id);

            MainPostSystemVM viewmodel = new MainPostSystemVM
            {
                UserId=userFromdb.
                Id=userFromdb.Id,
                UserName=userFromdb.UserName
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(MainPostSystemVM viewmodel)
        {
            var user = User.Identity.IsAuthenticated.ToString();
            var role = User.IsInRole("Admin").ToString();
            var username = User.Identity.Name;

            var EXTime = Convert.ToDateTime(viewmodel.PostExpirationTime);
            var EXDate = Convert.ToDateTime(viewmodel.PostExpirationDate);
            var dtCOMPLTDTTM = new DateTime(EXDate.Year, EXDate.Month, EXDate.Day, EXTime.Hour, EXTime.Minute, EXTime.Second);
            if (ModelState.IsValid && User.IsInRole("Admin") && User.Identity.IsAuthenticated)
            {
               
                var userName = uow.Context.Users.Where(x => x.UserName == viewmodel.UserName).FirstOrDefault();

                if(username != null && role != null && user != null)
                {
                    ViewBag.postSystem = uow.PostSystemRepository.GetAll();
                    ViewBag.SocialWorker = uow.SocialWorkerRepository.GetAll();
                    var socialId = uow.SocialWorkerRepository.GetById(viewmodel.SocialId);
                    var postsystem = uow.PostSystemRepository.GetById(viewmodel.PostSystemId);
                    int usersId = uow.UserRepository.GetById(viewmodel.Id).ToString().FirstOrDefault();
                    MainPostSystem postFromdb = new MainPostSystem
                    {
                        Id = viewmodel.Id,
                        Title = viewmodel.Title,
                        SentDateTime = DateTime.Now,
                        PostExpirationDate =dtCOMPLTDTTM,
                        SendedBy = User.Identity.Name,
                        HasPost = viewmodel.HasPost,
                        UserId=viewmodel.UserId,
                        Users=viewmodel.Users,
                        Name=viewmodel.UserName,
                        PostSystemId=viewmodel.PostSystemId,
                        PostSystems=viewmodel.PostSystems,
                        SocialId=viewmodel.SocialId,
                        SocialWorker=viewmodel.SocialWorker

                    };

                    uow.MainPostSystemRepository.Add(postFromdb);
                    uow.Commit();
                    TempData["Message"] = $"{viewmodel.UserName}";
                    return RedirectToAction(nameof(ThankYou));
                }
             
            }
            return View(viewmodel);

        }

        [HttpGet]
        public ActionResult ThankYou()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPostRecrods()
        {

            var userFromdb = uow.MainPostSystemRepository.GetAll("Users", "SocialWorker", "PostSystems");

            List<MainPostSystemVM> viewmodel = new List<MainPostSystemVM>();

            
            
            foreach (var item in userFromdb)
            {
                var datatime = item.PostExpirationDate;
                var time =Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());
                viewmodel.Add(new MainPostSystemVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    SentDateTime = item.SentDateTime,
                    PostExpirationDate = date,
                    PostExpirationTime = time,
                    SendedBy=item.SendedBy,
                    HasPost=item.HasPost,
                    UserId=item.UserId,
                    Users=item.Users,
                    PostSystemId=item.PostSystemId,
                    PostSystems=item.PostSystems,
                    SocialId=item.SocialId,
                    SocialWorker=item.SocialWorker,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PostData()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ViewBag.postSystem = uow.PostSystemRepository.GetAll();
            ViewBag.SocialWorker = uow.SocialWorkerRepository.GetAll();
            ViewBag.UserId = uow.UserRepository.GetAll();
            var userFromdDb = uow.MainPostSystemRepository.GetById(id);

            MainPostSystemVM viewmodel = new MainPostSystemVM
            {
                Id = userFromdDb.Id,
                Title=userFromdDb.Title,
                SentDateTime=userFromdDb.SentDateTime,
                PostExpirationDate=userFromdDb.PostExpirationDate,
                SendedBy=userFromdDb.SendedBy,
                HasPost=userFromdDb.HasPost,  
                UserId=userFromdDb.UserId,
                Users=userFromdDb.Users,
                UserName=userFromdDb.Name,
                PostSystemId=userFromdDb.PostSystemId,
                PostSystems=userFromdDb.PostSystems,
                SocialId=userFromdDb.SocialId,
                SocialWorker=userFromdDb.SocialWorker,
                
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            ViewBag.postSystem = uow.PostSystemRepository.GetAll();
            ViewBag.SocialWorker = uow.SocialWorkerRepository.GetAll();
            var postFromdb = uow.MainPostSystemRepository.GetById(id);

            MainPostSystemVM viewmodel = new MainPostSystemVM
            {
                Id = postFromdb.Id,
                Title = postFromdb.Title,
                SentDateTime = postFromdb.SentDateTime,
                PostExpirationDate = postFromdb.PostExpirationDate,
                SendedBy = postFromdb.SendedBy,
                HasPost = postFromdb.HasPost,
                UserId = postFromdb.UserId,
                Users = postFromdb.Users,
                PostSystemId = postFromdb.PostSystemId,
                PostSystems = postFromdb.PostSystems,
                SocialId = postFromdb.SocialId,
                SocialWorker = postFromdb.SocialWorker,

            };

            uow.MainPostSystemRepository.Remove(postFromdb);
            uow.Commit();
            return RedirectToAction(nameof(PostData));
        }

        [HttpGet]
        public ActionResult UpdatePost(int? id)
        {

           
            ViewBag.postSystem = uow.PostSystemRepository.GetAll();
            ViewBag.SocialWorker = uow.SocialWorkerRepository.GetAll();
            ViewBag.UserId = uow.UserRepository.GetAll();
            var userFromdDb = uow.MainPostSystemRepository.GetById(id);

            var datatime = userFromdDb.PostExpirationDate;
            var time = Convert.ToDateTime(datatime.ToShortTimeString());
            var date = Convert.ToDateTime(datatime.ToShortDateString());

            MainPostSystemVM viewmodel = new MainPostSystemVM
            {
                Id = userFromdDb.Id,
                Title = userFromdDb.Title,
                SentDateTime =DateTime.Now,
                PostExpirationDate =date,
                PostExpirationTime=time,
                SendedBy = userFromdDb.SendedBy,
                HasPost = userFromdDb.HasPost,
                UserId = userFromdDb.UserId,
                Users = userFromdDb.Users,
                UserName=userFromdDb.Name,
                PostSystemId = userFromdDb.PostSystemId,
                PostSystems = userFromdDb.PostSystems,
                SocialId = userFromdDb.SocialId,
                SocialWorker = userFromdDb.SocialWorker,

            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult UpdatePost(MainPostSystemVM viewmodel)
        {

            var user = User.Identity.IsAuthenticated.ToString();
            var role = User.IsInRole("Admin").ToString();
            var username = User.Identity.Name;
            if (ModelState.IsValid && User.IsInRole("Admin") && User.Identity.IsAuthenticated)
            {

               // var userName = uow.Context.Users.Where(x => x.UserName == viewmodel.UserName).FirstOrDefault();

                if (username != null && role != null && user != null)
                {

                    var EXTime = Convert.ToDateTime(viewmodel.PostExpirationTime);
                    var EXDate = Convert.ToDateTime(viewmodel.PostExpirationDate);
                    var dtCOMPLTDTTM = new DateTime(EXDate.Year, EXDate.Month, EXDate.Day, EXTime.Hour, EXTime.Minute, EXTime.Second);
                    var userFromdb = uow.MainPostSystemRepository.GetById(viewmodel.Id);
                    var usersFromdb = uow.UserRepository.GetById(viewmodel.Id);

                    userFromdb.Id = viewmodel.Id;
                    userFromdb.Title = viewmodel.Title;
                    userFromdb.SentDateTime = DateTime.Now;
                    userFromdb.PostExpirationDate = dtCOMPLTDTTM;
                    userFromdb.SendedBy = User.Identity.Name;
                    userFromdb.HasPost = viewmodel.HasPost;
                    userFromdb.UserId = viewmodel.UserId;
                    userFromdb.Users = viewmodel.Users;
                    userFromdb.PostSystemId = viewmodel.PostSystemId;
                    userFromdb.PostSystems = viewmodel.PostSystems;
                    userFromdb.SocialId = viewmodel.SocialId;
                    userFromdb.SocialWorker = viewmodel.SocialWorker;

                    uow.MainPostSystemRepository.Update(userFromdb);
                    uow.Commit();
                    TempData["UpdateMessage"] = $"{viewmodel.UserName}";

                    return RedirectToAction(nameof(UpdateThankYou));
                }
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult UpdateThankYou()
        {
            return View();
        }
    }
}