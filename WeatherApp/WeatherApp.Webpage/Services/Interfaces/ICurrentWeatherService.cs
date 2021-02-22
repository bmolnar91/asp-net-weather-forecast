using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services.Interfaces
{
    public interface ICurrentWeatherService
    {
        Task<CurrentWeather> GetCurrentWeather(string city);
    }
}
