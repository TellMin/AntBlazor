using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using AntBlazor.Shared.DTO;
using AntBlazor.Client.Interfaces.Services;

namespace AntBlazor.Client.Providers
{
    public class CustomAuthStateProvider: AuthenticationStateProvider
    {
        private readonly IAccountService _AccountService;

        public CustomAuthStateProvider(IAccountService accountService)
        {
            _AccountService = accountService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetCurrentUser();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, userInfo.UserName) }.Concat(userInfo.UserRoles.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private async Task<CurrentUser> GetCurrentUser() => await _AccountService.CurrentUserInfo();
    }
}
