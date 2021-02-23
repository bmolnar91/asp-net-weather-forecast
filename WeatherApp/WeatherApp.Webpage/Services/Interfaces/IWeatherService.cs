using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<CurrentWeather> GetCurrentWeatherAsync(string city);
        Task<IList<WeatherForecast>> GetForecastsAsync(string city);
    }
}
