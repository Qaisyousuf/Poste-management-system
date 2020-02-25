using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.ViewModels;
using OPMS.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class RoomsController : Controller
    {
        private readonly IUnitOfWork uow;

        public RoomsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetRoomData()
        {
            var roomFromdb = uow.RoomRepository.GetAll();

            return Json(new { data = roomFromdb }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoomViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                Room room = new Room
                {
                    Id=viewmodel.Id,
                    RoomNumber=viewmodel.RoomNumber
                };
                uow.RoomRepository.Add(room);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var room = uow.RoomRepository.GetById(id);

            RoomViewModel viewmodel = new RoomViewModel
            {
                Id=room.Id,
                RoomNumber=room.RoomNumber,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(RoomViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var room = uow.RoomRepository.GetById(viewmodel.Id);
                room.Id = viewmodel.Id;
                room.RoomNumber = viewmodel.RoomNumber;

                uow.RoomRepository.Update(room);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var room = uow.RoomRepository.GetById(id);

            RoomViewModel viewmodel = new RoomViewModel
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            var room = uow.RoomRepository.GetById(id);

            RoomViewModel viewmodel = new RoomViewModel
            {
                Id=room.Id,
                RoomNumber=room.RoomNumber
            };
            uow.RoomRepository.Remove(room);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var room = uow.RoomRepository.GetById(id);

            RoomViewModel viewmodel = new RoomViewModel
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
            };
            return View(viewmodel);
        }
    }
}