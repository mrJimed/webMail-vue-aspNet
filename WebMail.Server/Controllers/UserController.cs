using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using WebMail.Server.DbContexts;
using WebMail.Server.Models;

namespace WebMail.Server.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController([FromServices] ILogger<UserController> logger, WebMailDbContext dbContext) : ControllerBase
    {
        private readonly ILogger<UserController> logger = logger;
        private readonly WebMailDbContext dbContext = dbContext;

        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync([FromBody] User user)
        {
            if (dbContext.Users.FirstOrDefault(u => u.Email.Equals(user.Email)) != null)
            {
                return Conflict(new
                {
                    Message = "Пользователь с таким email уже существует"
                });
            }

            CreateNewUser(user);
            await SignInAsync(user.Email);
            return Ok(user);
        }

        private async Task SignInAsync(string email)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, email) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        private void CreateNewUser(User user)
        {
            var salt = RandomNumberGenerator.GetBytes(16);
            var hashPassword = CreateHashPassword(user.Password, salt);

            user.Password = hashPassword;
            user.Salt = Convert.ToBase64String(salt);

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        private string CreateHashPassword(string password, byte[] salt)
        {
            var hashedPassword = Convert.ToBase64String(
            KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 32));
            return hashedPassword;
        }
    }
}
