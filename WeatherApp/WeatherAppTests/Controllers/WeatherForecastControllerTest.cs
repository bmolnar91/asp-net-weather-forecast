using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Controllers;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;

namespace WeatherApp.Tests.Controllers
{
    [TestFixture]
    class WeatherForecastControllerTest
    {
        private IWeatherForecastService _weatherForecastService;
        private WeatherForecastController _weatherForecastController;

        [SetUp]
        public void Setup()
        {
            _weatherForecastService = Substitute.For<IWeatherForecastService>();
            _weatherForecastController = new WeatherForecastController(_weatherForecastService);
        }

        [Test]
        public async Task GetForecastsAsync_ExistingLocation_ReturnsForecast()
        {
            string city = "Budapest";

            var forecast = (IList<WeatherForecast>)new List<WeatherForecast>();

            forecast.Add(new WeatherForecast
            {
                ExactDate =   default,
                Date =        default,
                Description = default,
                Temp =        default,
                Pressure =    default,
                Humidity =    default,
                Wind =        default,
                Icon =        default,
            });

            _weatherForecastService.GetForecastsAsync(city).Returns(forecast);

            var result = await _weatherForecastController.GetForecastsAsync(city);

            Assert.AreEqual(result, forecast);
        }
    }
}
