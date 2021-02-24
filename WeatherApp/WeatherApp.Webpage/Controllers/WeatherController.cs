using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("current/{city}")]
        public async Task<CurrentWeather> GetCurrentWeatherAsync(string city)
        {
            return await _weatherService.GetCurrentWeatherAsync(city);
        }

        [HttpGet("forecast/{city}")]
        public async Task<IList<WeatherForecast>> GetForecastsAsync(string city)
        {
            return await _weatherService.GetForecastsAsync(city);
        }
    }
}
