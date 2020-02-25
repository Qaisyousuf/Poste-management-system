﻿using OPMS.Data.Interfaces;
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
using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;
using OPMS.Web.Infrastructure;

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
            ViewBag.Building = uow.BuildingRepository.GetAll();
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
            ViewBag.Address = uow.BuildingRepository.GetAll();

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
                var time = Convert.ToDateTime(viewmodel.AppointmentOrTime.ToShortTimeString());
                var date = Convert.ToDateTime(viewmodel.AppointmentOrTaskDateTime.ToLongDateString());
                var dtCOMPLTDTTM = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

                var addres = uow.BuildingRepository.GetById(viewmodel.BuildingId);
                var addresMsg =("Work Place: " + addres.BuildingName).ToUpper();

                var socialWorker = uow.SocialWorkerRepository.GetById(viewmodel.SocialId);

                var socialName = ("Sended By: " + socialWorker.FullName).ToUpper();

                var messbody ="Work Time:" + dtCOMPLTDTTM +"\n"+ mess.Title + mess.Content + "\n" + addresMsg+"\n"+socialName;


                var userName = ("Bonjour Mr : " + viewmodel.UserName).ToUpper();

                var accountsid = ConfigurationManager.AppSettings["TwilioAccountSid"];
                var authKey = ConfigurationManager.AppSettings["TwilioAuthToken"];
                TwilioClient.Init(accountsid, authKey);

                var to = new PhoneNumber(viewmodel.PhoneNumber);
                var from = new PhoneNumber(ConfigurationManager.AppSettings["TwilioPhoneNumber"]);


                var message = MessageResource.Create(to: to, from: from, body: userName + "\n" + messbody);

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
                        BuildingId = viewmodel.BuildingId,
                        Building = viewmodel.Building,
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
            var messFromdb = uow.MessagesSendingRepository.GetAll("Users", "MessageContainer", "Building", "SocialWorker");


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
                    AppointmentOrTaskDateTime=date,
                    AppointmentOrTime=time,
                    SendedBy=item.SendedBy,
                    MessageContainer=item.MessageContainer,
                    MessageContainerId=item.MessageContainerId,
                    Building=item.Building,
                    BuildingId=item.BuildingId,
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

       
    }
}