﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public abstract class Weather
    {
        public string Description { get; set; }
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }
        public string Icon { get; set; }
    }
}
