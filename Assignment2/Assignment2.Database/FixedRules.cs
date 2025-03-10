namespace Assignment2.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FixedRules
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field should not be empty.")]
        public string Question { get; set; }

        [Required(ErrorMessage = "This field should not be empty.")]
        public string Answer { get; set; }

        [StringLength(10)]
        public string CurrentStatus { get; set; }

        [StringLength(50)]
        public string LastEditorID { get; set; }
    }
}
