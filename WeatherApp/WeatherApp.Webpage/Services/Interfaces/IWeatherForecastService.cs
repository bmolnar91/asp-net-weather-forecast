using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public interface IWeatherForecastService
    {
        Task<IList<WeatherForecast>> GetForecasts(string city);
    }
}
