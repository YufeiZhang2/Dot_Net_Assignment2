using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Assignment2.Business;
using Assignment2.Database;
using Assignment2.WebApplication.Models;

namespace Assignment2.WebApplication.Controllers
{
    public class AllRuleList
    {
        public List<FixedRules> ApprovedFixedRules;
        public List<DataDrivenRules> ApprovedDataDrivenRules;
        public List<FixedRules> UncheckedFixedRules;
        public List<DataDrivenRules> UncheckedDataDrivenRules;
        public int TotalApprovedRules;
        public int TotalRejectedRules;
        public double SuccessRate;

        public int TotalApprovedRulesAmy;
        public int TotalRejectedRulesAmy;
        public int TotalUncheckedRulesAmy;
        public double SuccessRateAmy;

        public int TotalApprovedRulesCrys;
        public int TotalRejectedRulesCrys;
        public int TotalUncheckedRulesCrys;
        public double SuccessRateCrys;

        public double AverageSuccessRate;
    }

    [Authorize(Roles = RoleName.Approver)]
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

            allRuleList.TotalApprovedRules = rulesApprover.GetDataDrivenRulesByStatus("Approved").Count + rulesApprover.GetFixedRulesByStatus("Approved").Count;
            allRuleList.TotalRejectedRules = rulesApprover.GetFixedRulesByStatus("Rejected").Count + rulesApprover.GetDataDrivenRulesByStatus("Rejected").Count;

            double result = ((double) allRuleList.TotalApprovedRules / (allRuleList.TotalApprovedRules +
                                                                        allRuleList.TotalRejectedRules)) * 100;

            allRuleList.SuccessRate = Math.Round(result, 2);

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

            allRuleList.TotalApprovedRulesAmy = totalApprovedRulesAmy;
            allRuleList.TotalRejectedRulesAmy = totalRejectedRulesAmy;
            allRuleList.TotalUncheckedRulesAmy = totalUncheckedRulesAmy;
            allRuleList.SuccessRateAmy = Math.Round(resultAmy,2);

            var totalApprovedRulesCrys = rulesApprover.GetFixedRulesByStatusForEditor("Approved", "crysbui.depon@gmail.com").Count
                                        + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Approved", "crysbui.depon@gmail.com").Count;

            var totalRejectedRulesCrys = rulesApprover.GetFixedRulesByStatusForEditor("Rejected", "crysbui.depon@gmail.com").Count
                                        + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Rejected", "crysbui.depon@gmail.com").Count;

            var totalUncheckedRulesCrys = rulesApprover.GetFixedRulesByStatusForEditor("Unchecked", "crysbui.depon@gmail.com").Count
                                         + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Unchecked", "crysbui.depon@gmail.com").Count;

            var resultCrys = ((double)totalApprovedRulesCrys / (totalApprovedRulesCrys + totalRejectedRulesCrys)) * 100;

            allRuleList.TotalApprovedRulesCrys = totalApprovedRulesCrys;
            allRuleList.TotalRejectedRulesCrys = totalRejectedRulesCrys;
            allRuleList.TotalUncheckedRulesCrys = totalUncheckedRulesCrys;
            allRuleList.SuccessRateCrys = Math.Round(resultCrys, 2);


            var averageResult = ((double) (totalApprovedRulesAmy + totalApprovedRulesCrys) /
                                 (totalApprovedRulesAmy + totalApprovedRulesCrys + totalRejectedRulesAmy +
                                  totalRejectedRulesCrys)) * 100;

            allRuleList.AverageSuccessRate = Math.Round(averageResult,2);

            return View(allRuleList);
        }
    }
}