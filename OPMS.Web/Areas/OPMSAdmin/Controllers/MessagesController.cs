using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Models;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IUnitOfWork uow;

        public MessagesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        private void RelatedData()
        {
            var usermodel = uow.Context.Users.Select(x => x.PhoneNumber);

            ViewBag.User = uow.UserRepository.GetAll();
            ViewBag.Messag = uow.MessageRepository.GetAll();
            ViewBag.Building = uow.BuildingRepository.GetAll();
            ViewBag.Floors = uow.FloorsRepository.GetAll();
            ViewBag.Rooms = uow.RoomRepository.GetAll();
            ViewBag.Social = uow.SocialWorkerRepository.GetAll();

           
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            RelatedData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MessagesViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                string userphone = uow.Context.Users.Select(x => x.PhoneNumber).FirstOrDefault();
                Messages messageFromdb = new Messages
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    SentDateTime = DateTime.Now,
                    UserId = viewmodel.UserId,
                    Users=viewmodel.Users,
                    MessageContainerId=viewmodel.MessageContainerId,
                    MessageContainer=viewmodel.MessageContainer,
                    Building=viewmodel.Building,
                    BuildingId=viewmodel.BuildingId,
                    RoomId=viewmodel.RoomId,
                    FloorId=viewmodel.FloorId,
                    Florrs=viewmodel.Florrs,
                    SocialId=viewmodel.SocialId,
                    SocialWorker=viewmodel.SocialWorker,
                };
                uow.MessagesSendingRepository.Add(messageFromdb);
                uow.Commit();
               
                var accountsid = ConfigurationManager.AppSettings["TwilioAccountSid"];
                var authKey = ConfigurationManager.AppSettings["TwilioAuthToken"];
                TwilioClient.Init(accountsid, authKey);

                var to = new PhoneNumber(userphone);
                var from = new PhoneNumber(ConfigurationManager.AppSettings["TwilioPhoneNumber"]);

                var msgbody = viewmodel.MessageContainer.Content.ToString();



               


                var message = MessageResource.Create(to: to, from: from, body: msgbody);


                //return Content(message.Sid);

                return RedirectToAction(message.Sid,nameof(Index));
            }
            return View(viewmodel);
        }

        public ActionResult Edit(int id)
        {
            RelatedData();
            var msg = uow.MessagesSendingRepository.GetById(id);
            MessagesViewModel viewmdooel = new MessagesViewModel
            {
                Id=msg.Id,
                Title=msg.Title,
                SentDateTime=msg.SentDateTime,
                UserId=msg.UserId,
                Users=msg.Users,
                MessageContainer=msg.MessageContainer,
                MessageContainerId=msg.MessageContainerId,
                Building=msg.Building,
                BuildingId=msg.BuildingId,
                RoomId=msg.RoomId,
                Rooms=msg.Rooms,
                FloorId=msg.FloorId,
                Florrs=msg.Florrs,
                SocialId=msg.SocialId,
                SocialWorker=msg.SocialWorker,


            };
            return View(viewmdooel);
        }
        [HttpPost]
        public ActionResult Edit(MessagesViewModel viewmodel)
        {

            if(ModelState.IsValid)
            {
                var messageFromdb = uow.MessagesSendingRepository.GetById(viewmodel.Id);

                messageFromdb.Id = viewmodel.Id;
                messageFromdb.Title = viewmodel.Title;
                messageFromdb.SentDateTime = viewmodel.SentDateTime;
                messageFromdb.MessageContainerId = viewmodel.MessageContainerId;
                messageFromdb.MessageContainer = viewmodel.MessageContainer;
                messageFromdb.BuildingId = viewmodel.BuildingId;
                messageFromdb.Building = viewmodel.Building;
                messageFromdb.RoomId = viewmodel.RoomId;
                messageFromdb.Rooms = viewmodel.Rooms;
                messageFromdb.FloorId = viewmodel.FloorId;
                messageFromdb.Florrs = viewmodel.Florrs;
                messageFromdb.SocialId = viewmodel.SocialId;
                messageFromdb.SocialWorker = viewmodel.SocialWorker;

                uow.MessagesSendingRepository.Update(messageFromdb);
                uow.Commit();
                var accountsid = ConfigurationManager.AppSettings["TwilioAccountSid"];
                var authKey = ConfigurationManager.AppSettings["TwilioAuthToken"];
                TwilioClient.Init(accountsid, authKey);

                var to = new PhoneNumber(viewmodel.Users.PhoneNumber);
                var from = new PhoneNumber(ConfigurationManager.AppSettings["TwilioPhoneNumber"]);



                var msg = viewmodel.Users.UserName;
                var mesg = viewmodel.MessageContainer.Content;

                var msgbody = mesg + msg;


                var message = MessageResource.Create(to: to, from: from, body: msgbody);


                //return Content(message.Sid);

                return RedirectToAction(message.Sid, nameof(Index));
            }
            return View(viewmodel);

            //var accountsid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            //var authKey = ConfigurationManager.AppSettings["TwilioAuthToken"];
            //TwilioClient.Init(accountsid, authKey);

            //var to = new PhoneNumber(viewmodel.Users.PhoneNumber);
            //var from = new PhoneNumber(ConfigurationManager.AppSettings["TwilioPhoneNumber"]);



            //var msg = viewmodel.Users.UserName;
            //var mesg = viewmodel.MessageContainer.Content;

            //var msgbody = mesg + msg;


            //var message = MessageResource.Create(to: to, from: from, body: msgbody);


            //return Content(message.Sid);
        }
    }
}