using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherForecastService;

        public WeatherForecastController(IWeatherService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("{city}")]
        public async Task<IList<WeatherForecast>> GetForecastsAsync(string city)
        {
            return await _weatherForecastService.GetForecastsAsync(city);
        }
    }
}
