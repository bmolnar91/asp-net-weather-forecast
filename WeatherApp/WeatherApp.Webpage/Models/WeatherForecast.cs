namespace WeatherApp.WebSite.Models
{
    public class WeatherForecast : Weather
    {
        public long ExactDate { get; set; }
        public string Date { get; set; }
    }
}
