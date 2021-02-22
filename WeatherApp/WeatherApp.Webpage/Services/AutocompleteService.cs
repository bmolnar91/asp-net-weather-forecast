using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public class AutocompleteService : IAutocompleteService
    {
        readonly string _apiKey;
        readonly string _baseUrl;

        public HttpClient Client { get; set; }

        public AutocompleteService(IConfiguration configuration, HttpClient client)
        {
            _apiKey = configuration.GetValue<string>("ApiKeys:Autocomplete");
            _baseUrl = configuration.GetValue<string>("ApiBaseUrls:Autocomplete");

            client.BaseAddress = new Uri(_baseUrl);
            Client = client;
        }

        public async Task<IEnumerable<Location>> GetSuggestionsAsync(string query)
        {
            var urlParameters = $"?apikey={_apiKey}&query={query}&maxresults=5&resultType=city&language=en";

            var response = await Client.GetAsync(urlParameters);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(responseString);
            var jsonSuggestions = json.GetValue("suggestions");

            var locations = (ISet<Location>)new HashSet<Location>();
            foreach (var suggestion in jsonSuggestions)
            {
                var location = new Location()
                {
                    City =        (string)suggestion["address"]["city"],
                    State =       (string)suggestion["address"]["state"],
                    Country =     (string)suggestion["address"]["country"],
                    CountryCode = (string)suggestion["countryCode"]
                };
                locations.Add(location);
            }

            return locations;
        }
    }
}
