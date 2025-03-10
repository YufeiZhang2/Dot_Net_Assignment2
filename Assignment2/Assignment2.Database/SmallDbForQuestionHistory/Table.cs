namespace Assignment2.Database.SmallDbForQuestionHistory
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
