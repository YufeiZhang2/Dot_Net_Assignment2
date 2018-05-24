using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment2.Database;

namespace Assignment2.WebApplication.Models
{
    public class DataDrivenRuleViewModel
    {
        public List<DataDrivenRules> Rules { get; set; }

        public string Question { get; set; }

        public string QuestionColumn { get; set; }

        public string Answer { get; set; }

        public string AnswerColumn { get; set; }

        public string CurrentStatus { get; set; }

        public string LastEditorID { get; set; }
    }
}