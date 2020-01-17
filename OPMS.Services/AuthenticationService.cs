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

        public void AddUserToRoles(int? userId, int[] roleIds)
        {
            uow.UserRepository.AddUserToRoles(userId, roleIds,uow.Context);
            uow.Commit();
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
            bool hashValidate = VerifyHash(user.UserName, password);

            if(hashValidate)
            {
                return user;
            }
            return null;
        }

        public bool Register(string email, string username, string password, string phonenumber,out int? userId)
        {
            var userExists = uow.UserRepository.UserExists(username);
            if(!userExists)
            {
                string hashedPassword = GenerateHash(password);

                UserModel user = new UserModel
                {
                    Email = email,
                    UserName = username,
                    HashPassword=hashedPassword,
                    PhoneNumber=phonenumber
                };
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
