using System;

namespace WeatherApp.WebSite.Models
{
    public class Observation
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
