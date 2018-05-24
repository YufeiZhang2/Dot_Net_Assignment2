using Assignment2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.WebApplication.Models
{
    public class FixedRuleViewModel
    {
        public List<FixedRules> SimpleRules { get; set; }

        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public string CurrentStatus { get; set; }

        public string LastEditorID { get; set; }

    }
}