namespace Assignment2.Bussiness
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
        [StringLength(20)]
        public string Day { get; set; }

        [Required]
        public string Weather { get; set; }

        [Required]
        [StringLength(50)]
        public string Outfit { get; set; }

        public int Temperature { get; set; }

        [Required]
        [StringLength(50)]
        public string LastMaintainerID { get; set; }
    }
}
