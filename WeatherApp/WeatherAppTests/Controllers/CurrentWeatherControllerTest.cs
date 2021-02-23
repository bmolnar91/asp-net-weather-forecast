using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using WeatherApp.WebSite.Controllers;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite
{
    [TestFixture]
    public class CurrentWeatherControllerTest
    {
        private CurrentWeatherController _currentWeatherController;
        private ICurrentWeatherService _currentWeatherService;

        [SetUp]
        public void Setup()
        {
            _currentWeatherService = Substitute.For<ICurrentWeatherService>();
            _currentWeatherController = new CurrentWeatherController(_currentWeatherService);
        }

        [Test]
        public async Task GetCurrentWeatherAsync_ExistingLocation_ReturnsLocation()
        {
            var city = "Budapest";

            _currentWeatherService.GetCurrentWeatherAsync(city).Returns(new CurrentWeather { City = city });

            var expected = city;
            var currentWeather = await _currentWeatherController.GetCurrentWeatherAsync(city);
            var actual = currentWeather.City;

            Assert.AreEqual(expected, actual);
        }
    }
}
