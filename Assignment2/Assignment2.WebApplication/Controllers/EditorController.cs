using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Bussiness;
using Assignment2.Database;


namespace Assignment2.WebApplication.Controllers
{
    public class AllLists
    {
        public List<FixedRules> ApprovedFixedRules;
        public List<DataDrivenRules> ApprovedDataDrivenRules;
        public List<FixedRules> RejectedFixedRules;
        public List<DataDrivenRules> RejectedDataDrivenRules;
        public List<FixedRules> UncheckedFixedRules;
        public List<DataDrivenRules> UncheckedDataDrivenRules;
    }

    public class EditorController : Controller
    {
        private RulesEditor rulesEditor = new RulesEditor();

        // GET: Editor
        public ActionResult Index()
        {
            AllLists allLists = new AllLists();

            allLists.RejectedDataDrivenRules = rulesEditor.GetDataDrivenRulesByStatus("Rejected");
            allLists.UncheckedDataDrivenRules = rulesEditor.GetDataDrivenRulesByStatus("Unchecked");

            allLists.RejectedFixedRules = rulesEditor.GetFixedRulesByStatus("Rejected");
            allLists.UncheckedFixedRules = rulesEditor.GetFixedRulesByStatus("Unchecked");

            return View(allLists);
        }

        public ActionResult AddDataDrivenRule()
        {
            return View();
        }

        public ActionResult AddFixedRule()
        {
            return View();
        }





        public ActionResult EditorReport()
        {
            AllLists allLists = new AllLists();

            allLists.ApprovedDataDrivenRules = rulesEditor.GetDataDrivenRulesByStatus("Approved");
            allLists.ApprovedFixedRules = rulesEditor.GetFixedRulesByStatus("Approved");

            return View(allLists);
        }
    }
}