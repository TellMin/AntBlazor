using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using AntBlazor.Client.Interfaces.Fetchers;
using AntBlazor.Client.Providers;
using AntBlazor.Shared.DTO;

namespace AntBlazor.Client.Fetchers
{
    public class CurrentUserFetcher : ICurrentUserFetcher
    {
        private readonly HttpClient _httpClient;

        public CurrentUserFetcher(HttpClientProvider httpClientProvider)
        {
            _httpClient = httpClientProvider.Client;
        }

        public async Task<bool> Login(LoginDto login)
        {
            var response = await _httpClient.PostAsJsonAsync<LoginDto>("Api/auth/Login", login);
            return response.IsSuccessStatusCode;
        }

        public async Task<CurrentUser> CurrentUserInfo()
            => await _httpClient.GetFromJsonAsync<CurrentUser>("Api/auth/CurentUserInfo") ?? new CurrentUser();
    }
}
