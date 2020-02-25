using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using OPMS.Services;
using OPMS.Models;
using OPMS.Data.Context;
using OPMS.Web.Infrastructure;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ExceptionFilter]
    public class AdminUserController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IAuthenticationService authService;
        private readonly ContextDb _context;

        public AdminUserController(IUnitOfWork uow,IAuthenticationService authService,ContextDb context)
        {
            this.uow = uow;
            this.authService = authService;
            _context = context;
        }
        public ActionResult Index()
        {
            //var userFromdb = uow.UserRepository.GetUserWithRoles();

            //return View(userFromdb);
            return View();
        }
        public JsonResult GetUserData()
        {

            var userFromdb = uow.UserRepository.GetAll();
            //var userdb = uow.UserRepository.GetAll("Roles");
            return Json(new { data = userFromdb },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            InsertUserViewModel viewmodel = new InsertUserViewModel();

            List<CheckBoxViewModel> checkBox = new List<CheckBoxViewModel>();

            var roles = uow.UserRepository.GetRoles();

            foreach (var role in roles)
            {
                checkBox.Add(new CheckBoxViewModel
                {
                    Id=role.Id,Text=role.Name,Checked=false
                });
               
            }
            viewmodel.Roles = checkBox;
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include ="UserName,Password,ConfirmPassword,PhoneNumber,Email")]
        InsertUserViewModel viewmodel,int[] Roles)
        {
            if(ModelState.IsValid)
            {
               
                bool registerSuccess = authService.Register
                    (viewmodel.Email, viewmodel.UserName, viewmodel.Password, viewmodel.PhoneNumber, out int? userId);
                if(registerSuccess)
                {
                    if(userId !=null)
                    {
                        if(Roles !=null)
                        {
                            authService.AddUserToRoles(userId, Roles);
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "L'utilisateur portant ce nom existe déjà");
                    return View(viewmodel);
                }
            }
            List<CheckBoxViewModel> checkBoxs = new List<CheckBoxViewModel>();
            var roles = uow.UserRepository.GetRoles();

            foreach (var role in roles)
            {
                checkBoxs.Add(new CheckBoxViewModel { Id = role.Id, Text = role.Name, Checked = false });
            }
            viewmodel.Roles = checkBoxs;
            return View(viewmodel);
        }
        public ActionResult Edit(int id)
        {

            var GetEdit = GetEditUser(id);
            return View(GetEdit);
           
        }     
        private EditUserViewModel GetEditUser(int id)
        {
            // var user = uow.UserRepository.GetById(id);
            var userFromdb =_context.Users.Include("Roles").Where(x => x.Id == id).FirstOrDefault();
            var Currentrole = uow.UserRepository.GetUserWithRoles(userFromdb.UserName);
            var currentRoleFromdb = userFromdb.Roles.Select(x => x.Users.Select(u => u.Roles)).ToList();
            var RoleFromdb = uow.UserRepository.GetRoles();
            //var roleByid = _context.Roles.Find(id);

            EditUserViewModel viewmodel = new EditUserViewModel
            {
                UserName = userFromdb.UserName,
                Email=userFromdb.Email,
                PhoneNumber=userFromdb.PhoneNumber,
                
            };

            foreach (var role in RoleFromdb)
            {
                if(RoleFromdb !=null)
                {
                    viewmodel.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = true
                    });
                }
                else
                {
                    viewmodel.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = false
                    });
                }
            }
            return viewmodel;

        }
        //[HttpGet]
        //public ActionResult SendSMS()
        //{
            
        //}
    }
}