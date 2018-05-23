using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.WebApplication.Models
{
    public class WeatherInfo
    {
        public string Day { get; set; }
        public string Weather { get; set; }
        public string Outfit { get; set; }
        public int Temperature { get; set; }
        public string LastMaintainerId { get; set; }
    }
}