using OPMS.Data.Context;
using OPMS.Models;
using System.Collections.Generic;

namespace OPMS.Data.Interfaces
{
    public interface IUserRepository:IRepository<UserModel>
    {
        UserModel GetUserWithRoles(string username);
        bool UserExists(string username);
        string GetPassword(string username);
        IEnumerable<RoleModel> GetRoles();
        IEnumerable<UserModel> GetUserWithRoles();
        IEnumerable<RoleModel> GetRolesById(int[] ids);
        void AddUserToRoles(int? userId, int[] roleIds,ContextDb context);
    }
}
