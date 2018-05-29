using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Assignment2.Database;

namespace Assignment2.WebApplication.Models
{
    public class MaintainerViewModel
    {
        public List<WeatherInfo> WeatherInfos { get; set; }

        [Key]
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
        public int Temperature { get; set; }

        public string LastMaintainerId { get; set; }
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<MaintainerViewModel> Maintainer { get; set; }
    }
}