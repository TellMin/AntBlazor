using System.Net.Http.Json;
using AntBlazor.Shared.DTO;
using AntBlazor.Client.Interfaces.Services;
using AntBlazor.Client.Providers;

namespace AntBlazor.Client.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClientProvider httpClientProvider)
        {
            _httpClient = httpClientProvider.Client;
        }

        public async Task<ItemDto[]> GetItems()
            => await _httpClient.GetFromJsonAsync<ItemDto[]>("Api/Item/GetItem") ?? Array.Empty<ItemDto>();
    }
}
