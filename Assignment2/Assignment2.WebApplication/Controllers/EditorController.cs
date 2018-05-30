using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Bussiness;
using Assignment2.Database;
using Assignment2.WebApplication.Models;

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
        public int RejectedRulesCount { get; set; }
        public int ApprovedRulesCount { get; set; }
        public string SuccessRate { get; set; }
    }

    [Authorize(Roles = RoleName.Editor)]
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

        public ActionResult UpdateDataDrivenRule()
        {
            return View();
        }


        public ActionResult AddFixedRule()
        {
            return View();
        }

        public ActionResult UpdateFixedRule()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add()
        {

            return RedirectToAction("Index");
        }
        


        public ActionResult EditorReport()
        {
            AllLists allLists = new AllLists();
            allLists.ApprovedDataDrivenRules = rulesEditor.GetYourDataDrivenRulesByStatus("Approved", User.Identity.Name);
            allLists.ApprovedFixedRules = rulesEditor.GetYourFixedRulesByStatus("Approved", User.Identity.Name);
            allLists.RejectedRulesCount = rulesEditor.CountRejectedRules(User.Identity.Name);
            allLists.ApprovedRulesCount = rulesEditor.CountApprovedRules(User.Identity.Name);
            allLists.SuccessRate = String.Format("{0:P}", rulesEditor.SuccessRate(User.Identity.Name));

            return View(allLists);
        }
    }
}