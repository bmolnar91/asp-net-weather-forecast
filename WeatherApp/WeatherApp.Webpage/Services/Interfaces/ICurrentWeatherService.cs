﻿using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services.Interfaces
{
    public interface ICurrentWeatherService
    {
        Task<CurrentWeather> GetCurrentWeatherAsync(string city);
    }
}
