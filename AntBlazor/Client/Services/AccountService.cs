using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using AntBlazor.Client.Interfaces.Services;
using AntBlazor.Client.Providers;
using AntBlazor.Shared.DTO;

namespace AntBlazor.Client.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClientProvider httpClientProvider)
        {
            _httpClient = httpClientProvider.Client;
        }

        public async Task<bool> Login(LoginDto login)
        {
            var response = await _httpClient.PostAsJsonAsync("Api/auth/Login", login);
            return response.IsSuccessStatusCode;
        }

        public async Task<CurrentUser> CurrentUserInfo()
            => await _httpClient.GetFromJsonAsync<CurrentUser>("Api/auth/CurentUserInfo") ?? new CurrentUser();
    }
}
