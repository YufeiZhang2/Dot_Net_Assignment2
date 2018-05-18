namespace Assignment2.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DataDrivenRule
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        [StringLength(50)]
        public string QuestionColumn { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        [StringLength(50)]
        public string AnswerColumn { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrentStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string LastEditorID { get; set; }
    }
}
