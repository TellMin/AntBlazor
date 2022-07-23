using Microsoft.AspNetCore.Mvc;
using AntBlazor.Shared.DTO;

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
