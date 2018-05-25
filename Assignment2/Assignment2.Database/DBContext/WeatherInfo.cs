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
        [Key]
        [StringLength(10)]
        public string Day { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Weather { get; set; }

        [Required]
        [StringLength(30)]
        public string Outfit { get; set; }

        [Required]
        public int Temperature { get; set; }

        [StringLength(30)]
        public string LastMaintainerId { get; set; }
    }
}
