using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        readonly ICurrentWeatherService _currentWeatherService;
        IFavoritesRepository _favoritesRepository;

        public FavoritesController(ICurrentWeatherService currentWeatherService, IFavoritesRepository favoritesRepository)
        {
            _currentWeatherService = currentWeatherService;
            _favoritesRepository = favoritesRepository;
        }

        [HttpGet("cities")]
        public async Task<CurrentWeather[]> GetFavoritesAsync()
        {
            var favorites = (IList<CurrentWeather>)new List<CurrentWeather>();
            foreach (var city in _favoritesRepository.GetFavorites())
            {
                var currentWeather = await _currentWeatherService.GetCurrentWeatherAsync(city);
                favorites.Add(currentWeather);
            }

            return favorites.ToArray();
        }

        [HttpPost("{city}")]
        public void AddFavorite(string city)
        {
            _favoritesRepository.AddFavorite(city);
        }

        [HttpDelete("{city}")]
        public void DeleteFavorite(string city)
        {
            _favoritesRepository.DeleteFavorite(city);
        }
    }
}
