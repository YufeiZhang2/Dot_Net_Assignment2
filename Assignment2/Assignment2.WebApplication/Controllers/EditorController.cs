using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpPost]
        public ActionResult AddDataDrivenRule(DataDrivenRules rule)
        {
            rule.CurrentStatus = "Unchecked";
            rule.LastEditorID = User.Identity.Name;
            rulesEditor.AddDataDrivenRule(rule);

            return RedirectToAction("Index");
        }


        public ActionResult AddFixedRule()
        {
            return View();
        }

        public ActionResult UpdateDataDrivenRule(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rule = rulesEditor.SearchDataDrivenRuleById((int)id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }


        [HttpPost]
        public ActionResult UpdateDataDrivenRule(DataDrivenRules rule)
        {
            rule.LastEditorID = User.Identity.Name;
            rulesEditor.UpdateDataDrivenRule(rule);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateFixedRule()
        {
            return View();
        }
        

        public ActionResult DeleteDataDrivenRule(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rule = rulesEditor.SearchDataDrivenRuleById((int)id);
            if (rule == null)
            {
                return HttpNotFound();
            }

            return View(rule);
        }


        [HttpPost, ActionName("DeleteDataDrivenRule")]
        public ActionResult DeleteDataDrivenRuleConfirmed(int id)
        {
            var rule = rulesEditor.SearchDataDrivenRuleById((int)id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            rulesEditor.DeleteDataDrivenRule(rule);


            
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