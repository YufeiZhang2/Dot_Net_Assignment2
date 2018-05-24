using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.WebApplication.Models
{
    public class WeatherInfo
    {
        [Required]
        [StringLength(10)]
        public string Day { get; set; }

        [Required]
        [StringLength(20)]
        public string Weather { get; set; }

        [Required]
        [StringLength(20)]
        public string Outfit { get; set; }

        [Required]
        [StringLength(3)]
        public int Temperature { get; set; }

        public string LastMaintainerId { get; set; }
    }
}