using OPMS.Data.Interfaces;
using OPMS.Models;
using System;

namespace OPMS.Services
{
    public class AuthenticationService : IAuthenticatioService
    {
        private readonly IUnitOfWork uow;

        public AuthenticationService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public string GenerateHash(string password)
        {
            string HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return HashedPassword;
        }

        public UserModel Login(string username, string password)
        {
            var user = uow.UserRepository.GetUserWithRoles(username);
            if (user == null)
                return null;
            bool hashValideated = VerifyHash(user.UserName, password);
            if(hashValideated)
            {
                return user;
            }
            return null;
        }

        public bool Register(string username, string email, string password, string phonenumber, out int? userId)
        {
            var userExists = uow.UserRepository.UserExists(username);
            if(!userExists)
            {
                string hashedPassword = GenerateHash(password);
                UserModel user = new UserModel();
                user.Email = email;
                user.PhoneNumber = phonenumber;
                user.UserName = username;
                user.HashPassword = hashedPassword;
                uow.UserRepository.Add(user);
                uow.Commit();
                userId = user.Id;
                return true;
            }
            userId = null;
            return false;
        }

        public bool VerifyHash(string username, string password)
        {
            var hashedPassword = uow.UserRepository.GetPassword(username);
            bool hashMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return hashMatch;
        }
    }
}
