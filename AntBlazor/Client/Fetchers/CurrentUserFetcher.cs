using System.Net.Http.Json;
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

        public async Task<CurrentUser> CurrentUserInfo()
            => await _httpClient.GetFromJsonAsync<CurrentUser>("api/auth/CurentUserInfo") ?? new CurrentUser();
    }
}
