using System.Collections.Generic;


namespace WeatherApp.WebSite.Models
{
    public class InMemoryFavoritesRepository : IFavoritesRepository
    {
        IList<string> _favorites = new List<string>() { "Vienna", "Vancouver" };

        public void AddFavorite(string city)
        {
            if (!_favorites.Contains(city))
            {
                _favorites.Add(city);
            }
        }

        ICollection<string> IFavoritesRepository.GetFavorites()
        {
            return _favorites;
        }

        public void DeleteFavorite(string city)
        {
            if (_favorites.Contains(city))
            {
                _favorites.Remove(city);
            }
        }
    }
}
