namespace WeatherApp.WebSite.Models
{
    public class CurrentWeather : Weather
    {
        public long CityId { get; set; }
        public string City { get; set; }
    }
}
