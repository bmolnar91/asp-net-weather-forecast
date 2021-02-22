using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        readonly string _apiKey;
        readonly string _baseUrl;

        public HttpClient Client { get; set; }

        public WeatherForecastService(IConfiguration configuration, HttpClient client)
        {
            _apiKey = configuration.GetValue<string>("ApiKeys:WeatherForecast");
            _baseUrl = configuration.GetValue<string>("ApiBaseUrls:WeatherForecast");

            client.BaseAddress = new Uri(_baseUrl);
            Client = client;
        }

        public async Task<IList<WeatherForecast>> GetForecasts(string city)
        {
            string urlParameters = $"?appid={_apiKey}&q={city}&units=metric";

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
