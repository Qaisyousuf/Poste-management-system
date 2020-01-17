using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OPMS.Data.Concrete
{
    public class UserRepository:Repository<UserModel>,IUserRepository
    {
        public UserRepository(ContextDb context):base(context)
        {

        }

        public void AddUserToRoles(int? userId, int[] roleIds,ContextDb context)
        {
            var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            var rolesFromdb = GetRolesById(roleIds);
            foreach (var role in rolesFromdb)
            {
                user.Roles.Add(role);
            }
        }

        public string GetPassword(string username)
        {
            return _context.Users.Where(x => x.UserName == username).Select(x => x.HashPassword).FirstOrDefault();
        }

        public IEnumerable<RoleModel> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public IEnumerable<RoleModel> GetRolesById(int[] ids)
        {
            return _context.Roles.Where(x => ids.Contains(x.Id)).ToList();
        }

        public UserModel GetUserWithRoles(string username)
        {
            UserModel user = _context.Users.Include("Roles").Where(x=>x.UserName==username).SingleOrDefault();
            UserModel currentUser = new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles=user.Roles
            };
            return currentUser;
        }

        public IEnumerable<UserModel> GetUserWithRoles()
        {
            var users = _context.Users.Include(u => u.Roles);

            List<UserModel> userWithRoles = new List<UserModel>();
            foreach (var user in users)
            {
                userWithRoles.Add(new UserModel
                {
                    Id=user.Id,
                    Email=user.Email,
                    UserName=user.UserName,
                    PhoneNumber=user.PhoneNumber,
                    Roles=user.Roles
                    
                });
            }
            return userWithRoles;
        }

        public bool UserExists(string username)
        {
            return _context.Users.Any(x => x.UserName == username);
        }
    }
}
