using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Services
{
    public class WeatherService : IWeatherService
    {
        readonly string _apiKey;
        readonly string _baseUrl;

        public HttpClient Client { get; set; }

        public WeatherService(IConfiguration configuration, HttpClient client)
        {
            _apiKey = configuration["WeatherApp:ServiceApiKeys:Openweathermap"];
            _baseUrl = configuration["ApiBaseUrls:Weather"];

            client.BaseAddress = new Uri(_baseUrl);
            Client = client;
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(string city)
        {
            var urlParameters = $"weather?appid={_apiKey}&q={city}&units=metric";

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

        public async Task<IList<WeatherForecast>> GetForecastsAsync(string city)
        {
            string urlParameters = $"forecast?appid={_apiKey}&q={city}&units=metric";

            var response = await Client.GetAsync(urlParameters);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(responseString).GetValue("list");

            var forecasts = (IList<WeatherForecast>)new List<WeatherForecast>();
            foreach (var token in json)
            {
                var weatherForecast = new WeatherForecast
                {
                    ExactDate =   (int)token["dt"],
                    Date =        (string)token["dt_txt"],
                    Description = (string)token["weather"][0]["description"],
                    Temp =        (double)token["main"]["temp"],
                    Pressure =    (int)token["main"]["pressure"],
                    Humidity =    (int)token["main"]["humidity"],
                    Wind =        (double)token["wind"]["speed"],
                    Icon =        (string)token["weather"][0]["icon"],
                };
                forecasts.Add(weatherForecast);
            }

            return forecasts;
        }
    }
}
