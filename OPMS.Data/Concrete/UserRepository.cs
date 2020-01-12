using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OPMS.Data.Concrete
{
    public class UserRepository:Repository<UserModel>,IUserRepository
    {
        public UserRepository(ContextDb context):base(context)
        {

        }

        public string GetPassword(string username)
        {
            return _context.Users.Where(x => x.UserName == username).Select(x => x.HashPassword).SingleOrDefault();
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
            var user = _context.Users.Include(u => u.Roles).SingleOrDefault();
            UserModel currentuser = new UserModel
            {
                Id = user.Id,
                UserName=user.UserName,
                PhoneNumber=user.PhoneNumber,
                Email=user.Email,
                Roles=user.Roles
            };
            return currentuser;

        }

        public IEnumerable<UserModel> GetUserWithRoles()
        {
            var user = _context.Users.Include(u => u.Roles);
            List<UserModel> userwithRoles = new List<UserModel>();
            foreach (var item in user)
            {
                userwithRoles.Add(new UserModel { Id = item.Id, UserName = item.UserName, Email = item.Email,PhoneNumber=item.PhoneNumber, Roles = item.Roles });
            }
            return userwithRoles;
        }

        public bool UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
