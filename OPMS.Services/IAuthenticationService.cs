using OPMS.Models;

namespace OPMS.Services
{
    public interface IAuthenticationService
    {
        bool Register(string email, string username, string password, string phonenumber,out int? userId);
        UserModel Login(string username, string password);

        bool VerifyHash(string username, string password);
        string GenerateHash(string password);

        void AddUserToRoles(int? userId, int[] roleIds);
    }
}
