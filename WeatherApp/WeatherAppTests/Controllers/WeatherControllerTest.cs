using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Controllers;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite
{
    [TestFixture]
    public class WeatherControllerTest
    {
        private WeatherController _weatherController;
        private IWeatherService _weatherService;

        [SetUp]
        public void Setup()
        {
            _weatherService = Substitute.For<IWeatherService>();
            _weatherController = new WeatherController(_weatherService);
        }

        [Test]
        public async Task GetCurrentWeatherAsync_ExistingLocation_ReturnsLocation()
        {
            var city = "Budapest";

            _weatherService.GetCurrentWeatherAsync(city).Returns(new CurrentWeather { City = city });

            var expected = city;
            var currentWeather = await _weatherController.GetCurrentWeatherAsync(city);
            var actual = currentWeather.City;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetForecastsAsync_ExistingLocation_ReturnsForecast()
        {
            string city = "Budapest";

            var forecast = (IList<WeatherForecast>)new List<WeatherForecast>();

            forecast.Add(new WeatherForecast
            {
                ExactDate = default,
                Date = default,
                Description = default,
                Temp = default,
                Pressure = default,
                Humidity = default,
                Wind = default,
                Icon = default,
            });

            _weatherService.GetForecastsAsync(city).Returns(forecast);

            var result = await _weatherController.GetForecastsAsync(city);

            Assert.AreEqual(result, forecast);
        }
    }
}
