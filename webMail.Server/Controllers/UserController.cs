using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webMail.Server.Schemas;
using webMail.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace webMail.Server.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync(UserRegData userRegData)
        {
            if (userService.IsUserExists(userRegData.Email))
                return Conflict("Пользователь с таким email уже был зарегистрирован.");

            userService.CreateUser(userRegData);
            await SignInAsync(userRegData.Email);
            return Ok(userRegData.Username);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginData userLoginData)
        {
            if (!userService.IsUserExists(userLoginData.Email, userLoginData.Password))
                return Unauthorized("Неправильный email или пароль.");

            var user = userService.GetUser(userLoginData.Email);
            await SignInAsync(user.Email);
            return Ok(user.Username);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task LogoutAsync()
        {
            await HttpContext.SignOutAsync();
        }

        private async Task SignInAsync(string email)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, email) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
