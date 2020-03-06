using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Models;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Controllers
{
    [ExceptionFilter]
    [LoginInfoFilter]
    [AdminActivityFilter]
    public class CheckPostController : BaseController
    {
        [Route("CheckPost")]
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
          
        }
       
    }
}