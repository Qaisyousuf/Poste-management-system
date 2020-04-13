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
   // [ExceptionFilter]
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
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var GetEdit = GetEditUser(id);
            return View(GetEdit);
           
        }     

        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserName,PhoneNumber,Email")] EditUserViewModel viewmodel,int[] Roles)
        {
           if(ModelState.IsValid)
            {
                var dbUser = uow.UserRepository.GetById(viewmodel.Id);

                if(dbUser !=null)
                {
                    int[] currentUserRoles = dbUser.Roles.Select(x => x.Id).ToArray();
                    string[] roleName = uow.Context.Roles.Where(x => currentUserRoles.Contains(x.Id)).Select(x => x.Name).ToArray();

                    uow.RolesRepository.RemoveById(currentUserRoles);
                    uow.UserRepository.RemoveById(dbUser.Id);

                    dbUser.Email = viewmodel.Email;
                    dbUser.UserName = viewmodel.UserName;
                    dbUser.PhoneNumber = viewmodel.PhoneNumber;

                    uow.UserRepository.Update(dbUser);

                    if(Roles !=null)
                    {
                        int[] RoleId = dbUser.Roles.Select(x => x.Id).ToArray();
                       // string[] RolesName = uow.Context.Roles.Where(x => currentUserRoles.Contains(x.Id)).Select(x => x.Name).ToString();

                        //uow.UserRepository.AddUserToRoles(dbUser.Id,RolesName,uow.Context);
                        uow.Commit();
                        
                    }
                }
            } 
            return RedirectToAction(nameof(Index));
           
        }
        private EditUserViewModel GetEditUser(int id)
        {

            var userFromdb = uow.Context.Users.Include("Roles").Where(x => x.Id == id).FirstOrDefault();
            var Currentrole = userFromdb.Roles.Select(x => x.Id).ToList();
            
            var RoleFromdb = uow.UserRepository.GetRoles();
            var roleByid =uow.Context.Roles.Find(id);

            EditUserViewModel viewmodel = new EditUserViewModel
            {
                UserName = userFromdb.UserName,
                Email=userFromdb.Email,
                PhoneNumber=userFromdb.PhoneNumber,
                
            };

            foreach (var role in RoleFromdb)
            {
                if(Currentrole.Contains(role.Id))
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
        private DeleteUserViewModel DeleteUser(int id)
        {
            var userFromdb = uow.Context.Users.Include("Roles").Where(x => x.Id == id).FirstOrDefault();
            var Currentrole = userFromdb.Roles.Select(x => x.Id).ToList();

          
            var RoleFromdb = uow.UserRepository.GetRoles();
            var roleByid = _context.Roles.Find(id);

            DeleteUserViewModel viewmodelDelete = new DeleteUserViewModel
            {
                UserName = userFromdb.UserName,
                Email = userFromdb.Email,
                PhoneNumber = userFromdb.PhoneNumber,
                Password=userFromdb.HashPassword,
                ConfirmPassword=userFromdb.HashPassword,

            };

            foreach (var role in RoleFromdb)
            {
                if (Currentrole.Contains(role.Id))
                {
                    viewmodelDelete.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = true
                    });
                }
                else
                {
                    viewmodelDelete.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = false
                    });
                }
            }
            return viewmodelDelete;

        }
        private DetailsUserViewModel DetailsUser(int id)
        {
            var userFromdb = uow.Context.Users.Include("Roles").Where(x => x.Id == id).FirstOrDefault();
            var Currentrole = userFromdb.Roles.Select(x => x.Id).ToList();


            var RoleFromdb = uow.UserRepository.GetRoles();
            var roleByid = _context.Roles.Find(id);

            DetailsUserViewModel viewmodelDelete = new DetailsUserViewModel
            {
                UserName = userFromdb.UserName,
                Email = userFromdb.Email,
                PhoneNumber = userFromdb.PhoneNumber,
                Password = userFromdb.HashPassword,
                

            };

            foreach (var role in RoleFromdb)
            {
                if (Currentrole.Contains(role.Id))
                {
                    viewmodelDelete.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = true
                    });
                }
                else
                {
                    viewmodelDelete.Roles.Add(new CheckBoxViewModel
                    {
                        Id = role.Id,
                        Text = role.Name,
                        Checked = false
                    });
                }
            }
            return viewmodelDelete;

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var GetEdit = DeleteUser(id);


            return View(GetEdit);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var userFromdb = uow.UserRepository.GetById(id);

            uow.UserRepository.Remove(userFromdb);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var GetEdit = DetailsUser(id);


            return View(GetEdit);
        }

    }
}