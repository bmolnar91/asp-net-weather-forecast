using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public interface IFavoritesRepository
    {
        void AddFavorite(string city);
        ICollection<string> GetFavorites();
        void DeleteFavorite(string city);
    }
}
