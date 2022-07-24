using System.Net.Http.Json;
using AntBlazor.Client.Interfaces.Services;
using AntBlazor.Client.Providers;
using AntBlazor.Shared.DTO;

namespace AntBlazor.Client.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClientProvider httpClientProvider)
        {
            _httpClient = httpClientProvider.Client;
        }

        public async Task<WeatherForecast[]> GetWeatherForecasts()
            => await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast") ?? Array.Empty<WeatherForecast>();
    }
}
