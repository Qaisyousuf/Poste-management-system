using OPMS.Data.Interfaces;
using System.Web.Mvc;
using OPMS.ViewModels;
using OPMS.Models;
using System;
using System.Collections.Generic;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class MessageContainerController : Controller
    {
        private readonly IUnitOfWork uow;

        public MessageContainerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            var userFromdb = uow.UserRepository.GetAll();

            List<EditUserViewModel> viewmodel = new List<EditUserViewModel>();

            foreach (var item in userFromdb)
            {
                viewmodel.Add(new EditUserViewModel
                {
                    Id=item.Id,
                    PhoneNumber=item.PhoneNumber,
                });
            }

            return View(viewmodel);
        }

        //Code for Get data by Jquery Datatable

        public JsonResult GetMessageContainerData()
        {
            var messageFromDb = uow.MessageRepository.GetAll();
            return Json(new { data = messageFromDb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MessageContainerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                MessageContainer messageContainer = new MessageContainer
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    SubTitle = viewmodel.SubTitle,
                    Content = viewmodel.Content,
                    CreatedBy = User.Identity.Name,
                    

                };
                uow.MessageRepository.Add(messageContainer);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var messageFromDb = uow.MessageRepository.GetById(id);

            MessageContainerViewModel viewmodel = new MessageContainerViewModel
            {
                Id = messageFromDb.Id,
                Title = messageFromDb.Title,
                SubTitle = messageFromDb.SubTitle,
                Content = messageFromDb.Content,
                CreatedBy = messageFromDb.CreatedBy,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(MessageContainerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var messageFromDb = uow.MessageRepository.GetById(viewmodel.Id);

                messageFromDb.Id = viewmodel.Id;
                messageFromDb.Title = viewmodel.Title;
                messageFromDb.SubTitle = viewmodel.SubTitle;
                messageFromDb.Content = viewmodel.Content;
                messageFromDb.CreatedBy = User.Identity.Name;

                uow.MessageRepository.Update(messageFromDb);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var messageFromdb = uow.MessageRepository.GetById(id);

            MessageContainerViewModel viewmodel = new MessageContainerViewModel
            {
                Id=messageFromdb.Id,
                Title=messageFromdb.Title,
                SubTitle=messageFromdb.SubTitle,
                Content=messageFromdb.Content,
                CreatedBy=messageFromdb.CreatedBy,
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfimrDelete(int id)
        {
                var messageFromdb = uow.MessageRepository.GetById(id);

                MessageContainerViewModel viewmodel = new MessageContainerViewModel
                {
                    Id=messageFromdb.Id,
                    Title=messageFromdb.Title,
                    SubTitle=messageFromdb.SubTitle,
                    Content=messageFromdb.Content,
                    CreatedBy=messageFromdb.CreatedBy,
                };
            uow.MessageRepository.Remove(messageFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            var messageFromdb = uow.MessageRepository.GetById(id);

            MessageContainerViewModel viewmodel = new MessageContainerViewModel
            {
                Id = messageFromdb.Id,
                Title = messageFromdb.Title,
                SubTitle = messageFromdb.SubTitle,
                Content = messageFromdb.Content,
                CreatedBy=messageFromdb.CreatedBy,
            };
            return View(viewmodel);
        }
    }
}