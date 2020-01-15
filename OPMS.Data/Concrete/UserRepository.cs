using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OPMS.Data.Concrete
{
    public class UserRepository : Repository<UserModel>, IUserRepository
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
            //var user = _context.Users.Include(u => u.Roles).SingleOrDefault();
            UserModel user = _context.Users.Include("Roles").Where(x => x.UserName == username).FirstOrDefault();
            UserModel currentUser = new UserModel();

            currentUser.Id = user.Id;
            currentUser.UserName = user.UserName;
            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.Email = user.Email;
            currentUser.Roles = user.Roles;
            return currentUser; 


        }

        public IEnumerable<UserModel> GetUserWithRoles()
        {
            var users = _context.Users.Include(u => u.Roles);
            List<UserModel> userWithRoles = new List<UserModel>();
            foreach (UserModel user in users)
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
