using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Business;
using Assignment2.Database;


namespace Assignment2.WebApplication.Controllers
{
    public class AllRuleList
    {
        public List<FixedRules> ApprovedFixedRules;
        public List<DataDrivenRules> ApprovedDataDrivenRules;
        public List<FixedRules> UncheckedFixedRules;
        public List<DataDrivenRules> UncheckedDataDrivenRules;
        public int totalApprovedRules;
        public int totalRejectedRules;
        public double successRate;

        public int totalApprovedRulesAmy;
        public int totalRejectedRulesAmy;
        public int totalUncheckedRulesAmy;
        public double successRateAmy;

        public int totalApprovedRulesCrys;
        public int totalRejectedRulesCrys;
        public int totalUncheckedRulesCrys;
        public double successRateCrys;

        public double averageSuccessRate;
    }

    public class ApproverController : Controller
    {
        RuleApprover rulesApprover = new RuleApprover();

        // GET: Approver
        public ActionResult Index()
        {
            AllRuleList allRuleList = new AllRuleList();

            allRuleList.UncheckedDataDrivenRules = rulesApprover.GetDataDrivenRulesByStatus("Unchecked");

            allRuleList.UncheckedFixedRules = rulesApprover.GetFixedRulesByStatus("Unchecked");


            return View(allRuleList);
        }

        public ActionResult FixedRulesApproved(int? id)
        {
            rulesApprover.ApproveFixedRule((int)id);
            return RedirectToAction("Index");
        }

        public ActionResult DataDrivenRulesApproved(int? id)
        {
            rulesApprover.ApproveDataDrivenRule((int)id);
            return RedirectToAction("Index");
        }

        public ActionResult FixedRulesRejected(int? id)
        {
            rulesApprover.RejectFixedRule((int)id);
            return RedirectToAction("Index");
        }

        public ActionResult DataDrivenRulesRejected(int? id)
        {
            rulesApprover.RejectDataDrivenRule((int)id);
            return RedirectToAction("Index");
        }


        public ActionResult ApproverReportForRule()
        {
            AllRuleList allRuleList = new AllRuleList();
            allRuleList.ApprovedFixedRules = rulesApprover.GetFixedRulesByStatus("Approved");
            allRuleList.ApprovedDataDrivenRules = rulesApprover.GetDataDrivenRulesByStatus("Approved");

            allRuleList.totalApprovedRules = rulesApprover.GetDataDrivenRulesByStatus("Approved").Count + rulesApprover.GetFixedRulesByStatus("Approved").Count;
            allRuleList.totalRejectedRules = rulesApprover.GetFixedRulesByStatus("Rejected").Count + rulesApprover.GetDataDrivenRulesByStatus("Rejected").Count;

            double result = ((double) allRuleList.totalApprovedRules / (allRuleList.totalApprovedRules +
                                                                        allRuleList.totalRejectedRules)) * 100;

            allRuleList.successRate = Math.Round(result, 2);

            return View(allRuleList);
        }


        public ActionResult ApproverReportForEditor()
        {

            AllRuleList allRuleList = new AllRuleList();
            var totalApprovedRulesAmy = rulesApprover.GetFixedRulesByStatusForEditor("Approved", "zhouamym@gmail.com").Count 
                          + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Approved", "zhouamym@gmail.com").Count;

            var totalRejectedRulesAmy = rulesApprover.GetFixedRulesByStatusForEditor("Rejected", "zhouamym@gmail.com").Count
                          + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Rejected", "zhouamym@gmail.com").Count;

            var totalUncheckedRulesAmy = rulesApprover.GetFixedRulesByStatusForEditor("Unchecked", "zhouamym@gmail.com").Count
                                        + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Unchecked", "zhouamym@gmail.com").Count;

            var resultAmy = ((double) totalApprovedRulesAmy / (totalApprovedRulesAmy + totalRejectedRulesAmy)) * 100;

            allRuleList.totalApprovedRulesAmy = totalApprovedRulesAmy;
            allRuleList.totalRejectedRulesAmy = totalRejectedRulesAmy;
            allRuleList.totalUncheckedRulesAmy = totalUncheckedRulesAmy;
            allRuleList.successRateAmy = Math.Round(resultAmy,2);

            var totalApprovedRulesCrys = rulesApprover.GetFixedRulesByStatusForEditor("Approved", "crysbui.depon@gmail.com").Count
                                        + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Approved", "crysbui.depon@gmail.com").Count;

            var totalRejectedRulesCrys = rulesApprover.GetFixedRulesByStatusForEditor("Rejected", "crysbui.depon@gmail.com").Count
                                        + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Rejected", "crysbui.depon@gmail.com").Count;

            var totalUncheckedRulesCrys = rulesApprover.GetFixedRulesByStatusForEditor("Unchecked", "crysbui.depon@gmail.com").Count
                                         + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Unchecked", "crysbui.depon@gmail.com").Count;

            var resultCrys = ((double)totalApprovedRulesCrys / (totalApprovedRulesCrys + totalRejectedRulesCrys)) * 100;

            allRuleList.totalApprovedRulesCrys = totalApprovedRulesCrys;
            allRuleList.totalRejectedRulesCrys = totalRejectedRulesCrys;
            allRuleList.totalUncheckedRulesCrys = totalUncheckedRulesCrys;
            allRuleList.successRateCrys = Math.Round(resultCrys, 2);


            var averageResult = ((double) (totalApprovedRulesAmy + totalApprovedRulesCrys) /
                                 (totalApprovedRulesAmy + totalApprovedRulesCrys + totalRejectedRulesAmy +
                                  totalRejectedRulesCrys)) * 100;

            allRuleList.averageSuccessRate = Math.Round(averageResult,2);

            return View(allRuleList);
        }
    }
}