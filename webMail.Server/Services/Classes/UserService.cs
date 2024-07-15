using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using webMail.Server.DbContexts;
using webMail.Server.Models;
using webMail.Server.Schemas;
using webMail.Server.Services.Interfaces;

namespace webMail.Server.Services.Classes
{
    public class UserService(WebMailDbContext dbContext) : IUserService
    {
        public bool IsUserExists(string email)
        {
            return dbContext.Users.FirstOrDefault(user => user.Email.Equals(email)) != null;
        }

        public bool IsUserExists(string email, string password)
        {
            var user = dbContext.Users.FirstOrDefault(user => user.Email.Equals(email));
            if (user != null)
            {
                var hashedPassword = CreateHashPassword(password, Convert.FromBase64String(user.Salt));
                return user.Password.Equals(hashedPassword);
            }
            return false;
        }

        public User? GetUser(string email)
        {
            return dbContext.Users.FirstOrDefault(user => user.Email.Equals(email));
        }

        public void CreateUser(UserRegData userRegData)
        {
            var hashData = CreateHashPassword(userRegData.Password);
            dbContext.Add(new User()
            {
                Username = userRegData.Username,
                Email = userRegData.Email,
                Password = hashData.HashedPassword,
                Salt = Convert.ToBase64String(hashData.Salt)
            });
            dbContext.SaveChanges();
        }

        private (string HashedPassword, byte[] Salt) CreateHashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(16);
            var hashedPassword = CreateHashPassword(password, salt);
            return (hashedPassword, salt);
        }

        private string CreateHashPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 10000,
                    numBytesRequested: 32

                ));
        }
    }
}
