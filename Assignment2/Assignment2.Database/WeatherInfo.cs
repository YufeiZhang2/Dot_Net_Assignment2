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
        public int Id { get; set; }

        [StringLength(10)]
        public string Day { get; set; }

        [Required]
        [StringLength(20)]
        public string Weather { get; set; }

        [Required]
        [StringLength(30)]
        public string Outfit { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Temperature must be numeric")]
        public int Temperature { get; set; }

        [StringLength(30)]
        public string LastMaintainerId { get; set; }
    }
}
