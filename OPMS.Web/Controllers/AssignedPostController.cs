using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Models;
using OPMS.ViewModels;

namespace OPMS.Web.Controllers
{
    
    public class AssignedPostController : BaseController
    {
        [Route("Post")]
        public ActionResult Index()
        {

            //var currrentuser = _uow.Context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var UserPost = _uow.MainPostSystemRepository.GetAll("Users", "SocialWorker", "PostSystems");
            ViewBag.Social = _uow.SocialWorkerRepository.GetAll();
            ViewBag.userId = _uow.UserRepository.GetAll();
            ViewBag.Post = _uow.PostSystemRepository.GetAll();
            List<MainPostSystemVM> viewmodel = new List<MainPostSystemVM>();

            foreach (var item in UserPost)
            {
                viewmodel.Add(new MainPostSystemVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    SentDateTime = item.SentDateTime,
                    PostExpirationDate = item.PostExpirationDate,
                    SendedBy = item.SendedBy,
                    HasPost = item.HasPost,
                    UserId = item.UserId,
                    Users = item.Users,
                    UserName = item.Users.UserName,
                    PostSystemId = item.PostSystemId,
                    PostSystems = item.PostSystems,
                    SocialId = item.SocialId,
                    SocialWorker = item.SocialWorker,
                });
            }

            return View(viewmodel);
           // return View();
        }
        //[Route("Post/view")]
        //[HttpGet]
        //public ActionResult PostView(int? id)
        //{

        //    ViewBag.userFromdb = _uow.UserRepository.GetById(id);
        //    ViewBag.socialFromdb = _uow.SocialWorkerRepository.GetById(id);
        //    ViewBag.postSystem = _uow.PostSystemRepository.GetById(id);
        //    var postFromdb = _uow.MainPostSystemRepository.GetById(id);

        //    MainPostSystemVM viewmodel = new MainPostSystemVM();
        //    postFromdb.Id = viewmodel.Id;
        //    postFromdb.Title = viewmodel.Title;
        //    postFromdb.SentDateTime = viewmodel.SentDateTime;
        //    postFromdb.PostExpirationDate = viewmodel.PostExpirationDate;
        //    postFromdb.HasPost = viewmodel.HasPost;
        //    postFromdb.UserId = viewmodel.UserId;
        //    postFromdb.Users = viewmodel.Users;
        //    postFromdb.PostSystemId = viewmodel.PostSystemId;
        //    postFromdb.PostSystems = viewmodel.PostSystems;
        //    postFromdb.SocialId = viewmodel.SocialId;
        //    postFromdb.SocialWorker = viewmodel.SocialWorker;
        //    return View(viewmodel);
        //}
    }
}