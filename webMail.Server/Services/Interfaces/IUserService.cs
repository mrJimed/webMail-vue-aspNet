using webMail.Server.Models;
using webMail.Server.Schemas;

namespace webMail.Server.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUserExists(string email);
        bool IsUserExists(string email, string password);
        void CreateUser(UserRegData userRegData);
        User? GetUser(string email);
    }
}
