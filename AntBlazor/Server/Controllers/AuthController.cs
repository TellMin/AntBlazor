using Microsoft.AspNetCore.Mvc;
using AntBlazor.Shared.DTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace AntBlazor.Server.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {

        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            // TODO: add DbContext and use it
            var dummy = Task.Run(() => Console.WriteLine("dummy"));

            if(login == null || !login.UserId.Equals("tellmin"))
            {
                return BadRequest();
            }

            var claims = new List<Claim>
            {
                // TODO: Add other claims
                new Claim("UserId", login.UserId),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties());

            return Ok(login);
        }

        [HttpGet]
        public CurrentUser CurentUserInfo()
        {
            return new CurrentUser
            {
                IsAuthenticated = User.Identity?.IsAuthenticated ?? false,
                UserName = User.Identity?.Name ?? String.Empty,
                UserRoles = User.Claims.ToDictionary(c => c.Type, c => c.Value)
            };
        }
    }
}
