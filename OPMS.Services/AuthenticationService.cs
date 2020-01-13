using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork uow;

        public AuthenticationService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public string GenerateHash(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public UserModel Login(string username, string password)
        {
            var user = uow.UserRepository.GetUserWithRoles(username);
            if (user == null)
                return null;
            bool hashValidated = VerifyHash(user.UserName, password);
            if(hashValidated)
            {
                return user;
            }
            return null;
        }

        public bool Register(string email, string username, string password)
        {
            var userExists = uow.UserRepository.UserExists(username);
            if(!userExists)
            {
                string hashedPassword = GenerateHash(password);
                UserModel user = new UserModel
                {
                    Email = email,
                    UserName=username,
                    HashPassword=hashedPassword
                };
                uow.UserRepository.Add(user);
                uow.Commit();
                return true;

            }
            return false;
        }

        public bool VerifyHash(string username, string password)
        {
            var hashedPassword = uow.UserRepository.GetPassword(username);
            bool hashMatched = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return hashMatched;
        }
    }
}
