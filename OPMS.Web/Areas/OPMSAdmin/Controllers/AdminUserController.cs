using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPMS.Data.Interfaces;
using OPMS.ViewModels;
using OPMS.Services;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    
    public class AdminUserController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IAuthenticationService authService;

        public AdminUserController(IUnitOfWork uow,IAuthenticationService authService)
        {
            this.uow = uow;
            this.authService = authService;
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
    }
}