using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services
{
    public interface IAutocompleteService
    {
        Task<IEnumerable<Location>> GetSuggestionsAsync(string query);
    }
}
