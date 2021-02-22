using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        readonly string _apiKey;
        readonly string _baseUrl;

        public HttpClient Client { get; set; }

        public CurrentWeatherService(IConfiguration configuration, HttpClient client)
        {
            _apiKey = configuration.GetValue<string>("ApiKeys:WeatherForecast");
            _baseUrl = configuration.GetValue<string>("ApiBaseUrls:CurrentWeather");

            client.BaseAddress = new Uri(_baseUrl);
            Client = client;
        }

        public async Task<CurrentWeather> GetCurrentWeather(string city)
        {
            var urlParameters = $"?appid={_apiKey}&q={city}&units=metric";

            var response = await Client.GetAsync(urlParameters);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(responseString);

            var currentWeather = new CurrentWeather()
            {
                CityId = (long)json.GetValue("id"),
                City = (string)json.GetValue("name"),
                Description = (string)json["weather"][0]["description"],
                Icon = (string)json["weather"][0]["icon"],
                Humidity = (int)json.GetValue("main")["humidity"],
                Temp = (int)json.GetValue("main")["temp"],
                Pressure = (int)json.GetValue("main")["pressure"],
                Wind = (double)json.GetValue("wind")["speed"]
            };

            return currentWeather;
        }
    }
}
