using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<Weather> GetCurrentWeatherAsync(string city);
        Task<IList<Weather>> GetForecastsAsync(string city);
    }
}
