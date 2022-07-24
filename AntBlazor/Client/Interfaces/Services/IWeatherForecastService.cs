using AntBlazor.Shared.DTO;
using System.Threading.Tasks;

namespace AntBlazor.Client.Interfaces.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetWeatherForecasts();
    }
}
