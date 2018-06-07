using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

    // Redirecting to the error page when an exception occurs.
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    // Authorizing the role of editor
    [Authorize(Roles = RoleName.Editor)]
    public class EditorController : Controller
    {
        private RulesEditor rulesEditor = new RulesEditor();

        // Control the view of the editor main page
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



        // Control the view when adding new data-driven rule
        public ActionResult AddDataDrivenRule()
        {
            return View();
        }



        // Control the view and action after submitting the new data-driven rule
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddDataDrivenRule([Bind(Include = "Question,QuestionColumn,Answer,AnswerColumn")] DataDrivenRules rule)
        {
 
            if (ModelState.IsValid)
            {
                rule.CurrentStatus = "Unchecked";
                rule.LastEditorID = User.Identity.Name;
                rulesEditor.AddDataDrivenRule(rule);
                return RedirectToAction("Index");
            }
            else
            {
                return View(rule);
            }
        }



        // Control the view when adding new fixed rule
        public ActionResult AddFixedRule()
        {
            return View();
        }



        // Control the view and action after submitting the new fixed rule
        [HttpPost]
        public ActionResult AddFixedRule([Bind(Include = "Question,Answer")] FixedRules rule)
        {
            if (ModelState.IsValid)
            {
                rule.CurrentStatus = "Unchecked";
                rule.LastEditorID = User.Identity.Name;
                rulesEditor.AddFixedRule(rule);

                return RedirectToAction("Index");
            }
            else
            {
                return View(rule);
            }

        }



        // Control the view when editing a data-driven rule
        public ActionResult UpdateDataDrivenRule(int? id)
        {
            if (id == null)
            {
                throw new Exception("This is a bad request. You should select the rule to edit first.");
            }

            var rule = rulesEditor.SearchDataDrivenRuleById((int)id);
            if (rule == null)
            {
                throw new Exception("Sorry, there is an error finding the rule to edit. Please try again later.");
            }
            return View(rule);
        }



        // Control the view and action after submitting the update of a data-driven rule
        [HttpPost]
        public ActionResult UpdateDataDrivenRule(DataDrivenRules rule)
        {
            if (ModelState.IsValid)
            {
                rule.LastEditorID = User.Identity.Name;
                rulesEditor.UpdateDataDrivenRule(rule);
                return RedirectToAction("Index");
            }
            else
            {
                return View(rule);
            }

        }


        // Control the view when editing a fixed rule
        public ActionResult UpdateFixedRule(int? id)
        {
            if (id == null)
            {
                throw new Exception("This is a bad request. You should select the rule to edit first.");
            }

            var rule = rulesEditor.SearchFixedRuleById((int)id);
            if (rule == null)
            {
                throw new Exception("Sorry, there is an error finding the rule to edit. Please try again later.");
            }
            return View(rule);
        }



        // Control the view and action after submitting the update of a fixed rule
        [HttpPost]
        public ActionResult UpdateFixedRule(FixedRules rule)
        {
            if (ModelState.IsValid)
            {
                rule.LastEditorID = User.Identity.Name;
                rulesEditor.UpdateFixedRule(rule);
                return RedirectToAction("Index");
            }
            else
            {
                return View(rule);
            }

        }



        // Control the view when deleting a data-driven rule
        public ActionResult DeleteDataDrivenRule(int? id)
        {
            if (id == null)
            {
                throw new Exception("This is a bad request. You should select the rule to delete first.");
            }

            var rule = rulesEditor.SearchDataDrivenRuleById((int)id);
            if (rule == null)
            {
                throw new Exception("Sorry, there is an error finding the rule to delete. Please try again later.");
            }

            return View(rule);
        }



        // Control the view and action after confirming the deletion of a data-driven rule
        [HttpPost, ActionName("DeleteDataDrivenRule")]
        public ActionResult DeleteDataDrivenRuleConfirmed(int id)
        {
            var rule = rulesEditor.SearchDataDrivenRuleById((int)id);
            if (rule == null)
            {
                throw new Exception("Sorry, there is an error deleting this rule. Please try again later.");
            }
            rulesEditor.DeleteDataDrivenRule(rule);

            return RedirectToAction("Index");
        }



        // Control the view when deleting a data-driven rule
        public ActionResult DeleteFixedRule(int? id)
        {
            if (id == null)
            {
                throw new Exception("This is a bad request. You should select the rule to delete first.");
            }

            var rule = rulesEditor.SearchFixedRuleById((int)id);
            if (rule == null)
            {
                throw new Exception("Sorry, there is an error finding the rule to delete. Please try again later.");
            }

            return View(rule);
        }



        // Control the view and action after confirming the deletion of a fixed rule
        [HttpPost, ActionName("DeleteFixedRule")]
        public ActionResult DeleteFixedRuleConfirmed(int id)
        {
            var rule = rulesEditor.SearchFixedRuleById((int)id);
            if (rule == null)
            {
                throw new Exception("Sorry, there is an error deleting this rule. Please try again later.");
            }
            rulesEditor.DeleteFixedRule(rule);

            return RedirectToAction("Index");
        }



        // Control the view of the editor report
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