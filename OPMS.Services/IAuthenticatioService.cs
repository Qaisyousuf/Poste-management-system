using OPMS.Models;

namespace OPMS.Services
{
    public interface IAuthenticatioService
    {
        bool Register(string username, string email, string password, string phonenumber,out int? userId);
        UserModel Login(string username, string password);
        bool VerifyHash(string username, string password);
        string GenerateHash(string password);

    }
}
