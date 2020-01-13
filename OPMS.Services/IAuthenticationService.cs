using OPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Services
{
    public interface IAuthenticationService
    {
        bool Register(string email,string username, string password);

        UserModel Login(string username, string password);

        bool VerifyHash(string username, string password);

        string GenerateHash(string password);
    }
}
