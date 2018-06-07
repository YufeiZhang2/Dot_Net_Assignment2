namespace Assignment2.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DataDrivenRules
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field should not be empty.")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Please select a column")]
        [StringLength(50)]
        [Display(Name = "Question Column")]
        public string QuestionColumn { get; set; }

        [Required(ErrorMessage = "This field should not be empty.")]
        public string Answer { get; set; }

        [Required(ErrorMessage = "Please select a column")]
        [StringLength(50)]
        [Display(Name = "Answer Column")]
        public string AnswerColumn { get; set; }

        [StringLength(10)]
        public string CurrentStatus { get; set; }

        [StringLength(50)]
        public string LastEditorID { get; set; }
    }
}
