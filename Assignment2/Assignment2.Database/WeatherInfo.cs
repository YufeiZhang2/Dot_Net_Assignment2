namespace Assignment2.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeatherInfo")]
    public partial class WeatherInfo
    { 
        public int Id { get; set; }

        [Key]
        [Required(ErrorMessage = "Please select a day")]
        public string Day { get; set; }

        
        [MaxLength(20)]
        [Required(ErrorMessage = "The weather field is required")]
        public string Weather { get; set; }

        
        [MaxLength(30)]
        [Required(ErrorMessage = "The outfit field is required")]
        public string Outfit { get; set; }

        [Required(ErrorMessage = "The temperature field is required, and it should be number.")]
        public int Temperature { get; set; }

        [StringLength(30)]
        public string LastMaintainerId { get; set; }
    }

    public enum DaySelection
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
