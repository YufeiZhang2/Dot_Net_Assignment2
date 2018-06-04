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

        [Required(ErrorMessage = "Please select a day")]
        public string Day { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "Please enter characters only")]
        public string Weather { get; set; }

        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "Please enter characters only")]
        public string Outfit { get; set; }

        [Required]
      //  [RegularExpression(@"^[+-]?[0-9]{0,6})?**$", ErrorMessage = "Temperature must be numeric & 2 digits only ")]
        public int Temperature { get; set; }

        [StringLength(30)]
        public string LastMaintainerId { get; set; }
    }

    public enum DaySelection
    {
        Sunday,
        Monday,
        Tueday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
