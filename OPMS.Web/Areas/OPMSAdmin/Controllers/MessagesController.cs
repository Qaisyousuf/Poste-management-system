using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class MessagesController : Controller
    {
        private readonly IUnitOfWork uow;

        public object HtmlUtilities { get; private set; }

        public MessagesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        private void RelatedData()
        {
            var usermodel = uow.Context.Users.Select(x => x.PhoneNumber);

            ViewBag.Messag = uow.MessageRepository.GetAll();
            ViewBag.Social = uow.SocialWorkerRepository.GetAll();

        }

        public ActionResult Index()
        {
            var userFromdb = uow.UserRepository.GetAll();
            ViewBag.MessageContainer = uow.MessageRepository.GetAll();
            List<UserSMSViewModel> viewmodel = new List<UserSMSViewModel>();

            foreach (var item in userFromdb)
            {
                viewmodel.Add(new UserSMSViewModel
                {
                    Id = item.Id,
                    PhoneNumber = item.PhoneNumber,
                    UserName=item.UserName,
          
                });
            }
            return View(viewmodel);
        }

        public JsonResult GetUserSMSData()
        {
            var userFromdb = uow.UserRepository.GetAll();

            return Json(new { data = userFromdb }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.MessageContainer = uow.MessageRepository.GetAll();
            ViewBag.SocialWorker = uow.SocialWorkerRepository.GetAll();
            

            var userfromdb = uow.UserRepository.GetById(id);

            UserSMSViewModel viewmodel = new UserSMSViewModel
            {
                Id=userfromdb.Id,
                UserName=userfromdb.UserName,
                PhoneNumber=userfromdb.PhoneNumber,
                
            };

            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(UserSMSViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                
               
                var mess = uow.MessageRepository.GetById(viewmodel.MessageContainerId);
                var time = Convert.ToDateTime(viewmodel.AppointmentTime.ToShortTimeString());
                var date = Convert.ToDateTime(viewmodel.AppointmentDate.ToLongDateString());
                var dtCOMPLTDTTM = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

                //var addres = uow.BuildingRepository.GetById(viewmodel.BuildingId);
                //var addresMsg =("Work Place: " + addres.BuildingName).ToUpper();

                var socialWorker = uow.SocialWorkerRepository.GetById(viewmodel.SocialId);

                var socialName = ("Sended By: " + socialWorker.FullName).ToUpper();

                string messbody ="Time: " + dtCOMPLTDTTM +"\n"+"Title: "+ mess.Title+"\n"+ "SMS:" + mess.Content + "\n"+socialName;


                var userName = ("Hi, Mr : " + viewmodel.UserName).ToUpper();

                var accountsid = ConfigurationManager.AppSettings["TwilioAccountSid"];
                var authKey = ConfigurationManager.AppSettings["TwilioAuthToken"];
                TwilioClient.Init(accountsid, authKey);

                var to = new PhoneNumber(viewmodel.PhoneNumber);
                var from = new PhoneNumber(ConfigurationManager.AppSettings["TwilioPhoneNumber"]);

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                string message = MessageResource.Create(to: to, from: from, body: userName + "\n" + messbody).ToString();

                if (ModelState.IsValid)
                {
                   
                    Messages msgViewModel = new Messages
                    {
                        Id = viewmodel.Id,
                        Title = viewmodel.Title,
                        SentDateTime = DateTime.Now,
                        AppointmentOrTaskDateTime =dtCOMPLTDTTM,
                        SendedBy = User.Identity.Name,
                        UserId = viewmodel.Id,
                        Users = viewmodel.Users,
                        MessageContainer = viewmodel.MessageContainer,
                        MessageContainerId = viewmodel.MessageContainerId,
                        SocialId = viewmodel.SocialId,
                        SocialWorker = viewmodel.SocialWorker,
                    };

                    uow.MessagesSendingRepository.Add(msgViewModel);
                    uow.Commit();
                   // var SS = message.Sid;
                    TempData["Message"] = $"{viewmodel.UserName}";
                    return RedirectToAction("ThankYou");
                }

            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult ThankYou()
        {
            return View();
        }
        
        public JsonResult SentSMSData()
        {
            var messFromdb = uow.MessagesSendingRepository.GetAll("Users", "MessageContainer", "SocialWorker");


            List<UserSMSViewModel> viewmodel = new List<UserSMSViewModel>();

            foreach (var item in messFromdb)
            {
                var datatime = item.AppointmentOrTaskDateTime;
                var time = Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());
                viewmodel.Add(new UserSMSViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    UserId=item.UserId,
                    Users=item.Users,
                    SentDateTime=item.SentDateTime,
                    AppointmentDate=date,
                    AppointmentTime=time,
                    SendedBy=item.SendedBy,
                    MessageContainer=item.MessageContainer,
                    MessageContainerId=item.MessageContainerId,
                    SocialId=item.SocialId,
                    SocialWorker=item.SocialWorker,

                });
            }
 

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SMSRecords()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var smsFromdb = uow.MessagesSendingRepository.GetById(id);
            var datatime = smsFromdb.AppointmentOrTaskDateTime;
            var time = Convert.ToDateTime(datatime.ToShortTimeString());
            var date = Convert.ToDateTime(datatime.ToShortDateString());
            ViewBag.MessageContainer = uow.MessageRepository.GetAll();
            ViewBag.SocialWorker = uow.SocialWorkerRepository.GetAll();

          
            UserSMSViewModel viewmodel = new UserSMSViewModel
            {
                Id = smsFromdb.Id,
                Title = smsFromdb.Title,
                UserId = smsFromdb.UserId,
               
                Users=smsFromdb.Users,
                SentDateTime=smsFromdb.SentDateTime,
                SendedBy=smsFromdb.SendedBy,
                MessageContainer=smsFromdb.MessageContainer,
                MessageContainerId=smsFromdb.MessageContainerId,
                SocialId=smsFromdb.SocialId,
                SocialWorker=smsFromdb.SocialWorker,
                AppointmentTime=time,
                AppointmentDate=date,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
          
            var smsFromdb = uow.MessagesSendingRepository.GetById(id);
            var datatime = smsFromdb.AppointmentOrTaskDateTime;
            var time = Convert.ToDateTime(datatime.ToShortTimeString());
            var date = Convert.ToDateTime(datatime.ToShortDateString());
            UserSMSViewModel viewmodel = new UserSMSViewModel
            {
                Id = smsFromdb.Id,
                Title = smsFromdb.Title,
                UserId = smsFromdb.UserId,

                Users = smsFromdb.Users,
                SentDateTime = smsFromdb.SentDateTime,
                SendedBy = smsFromdb.SendedBy,
                MessageContainer = smsFromdb.MessageContainer,
                MessageContainerId = smsFromdb.MessageContainerId,
                SocialId = smsFromdb.SocialId,
                SocialWorker = smsFromdb.SocialWorker,
                AppointmentTime = time,
                AppointmentDate = date,
            };

            uow.MessagesSendingRepository.Remove(smsFromdb);
            uow.Commit();
            return RedirectToAction(nameof(SMSRecords));

        }

       
    }
}