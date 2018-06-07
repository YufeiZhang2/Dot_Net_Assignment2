using System;
using System.Linq;
using System.Web.Mvc;
using Assignment2.Business;
using Assignment2.WebApplication.Models;
using Microsoft.Ajax.Utilities;

namespace Assignment2.WebApplication.Controllers
{ 
    /// <summary>
    /// The ApproverController controls the views at present layer by manipulating the data model AllRuleListForApprover at the model layer. 
    /// </summary>

    //Authorising the role of approver.
    [Authorize(Roles = RoleName.Approver)]
    //Redirecting to the error page when an exceprtion occurs.
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class ApproverController : Controller
    {
        RuleApprover rulesApprover = new RuleApprover();

        //Control the views of approver main page.
        public ActionResult Index()
        {
            try
            {
                AllRuleListForApprover allRuleList = new AllRuleListForApprover();

                allRuleList.UncheckedDataDrivenRules = rulesApprover.GetDataDrivenRulesByStatus("Unchecked");

                allRuleList.UncheckedFixedRules = rulesApprover.GetFixedRulesByStatus("Unchecked");


                return View(allRuleList);
            }
            catch (Exception e)
            {
                throw new Exception("Sorry, we have gotten a problem of finding the uncheck rules right now.",e);
            }
            
        }
        
        //Control the views of approver main page after the fixed rules are approved.
        public ActionResult FixedRulesApproved(int? id)
        {
            try
            {
                rulesApprover.ApproveFixedRule((int)id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception("Sorry, approving the rules has just failed.",e);
            }
               
        }

        //Control the views of approver main page after the data-driven rules are approved.
        public ActionResult DataDrivenRulesApproved(int? id)
        {
            try
            {
                rulesApprover.ApproveDataDrivenRule((int)id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                
                throw new Exception("Sorry, approving the rules has just failed.",e);
            }
            
        }

        //Control the views of approver main page after the fixed rules are rejected.
        public ActionResult FixedRulesRejected(int? id)
        {
            try
            {
                rulesApprover.RejectFixedRule((int)id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception("Sorry, rejecting the rules has just failed.",e);
            }
            
        }

        //Control the views of approver main page after the data-driven rules are rejected.
        public ActionResult DataDrivenRulesRejected(int? id)
        {
            try
            {
                rulesApprover.RejectDataDrivenRule((int)id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception("Sorry, rejecting the rules has just failed.",e);
            }
            
        }

        //Control the views of approver report;
        public ActionResult ApproverReportForRule()
        {
            try
            {
                AllRuleListForApprover allRuleList = new AllRuleListForApprover();
                allRuleList.ApprovedFixedRules = rulesApprover.GetFixedRulesByStatus("Approved");
                allRuleList.ApprovedDataDrivenRules = rulesApprover.GetDataDrivenRulesByStatus("Approved");

                allRuleList.TotalApprovedRules = rulesApprover.GetDataDrivenRulesByStatus("Approved").Count + rulesApprover.GetFixedRulesByStatus("Approved").Count;
                allRuleList.TotalRejectedRules = rulesApprover.GetFixedRulesByStatus("Rejected").Count + rulesApprover.GetDataDrivenRulesByStatus("Rejected").Count;

                double result = ((double)allRuleList.TotalApprovedRules / (allRuleList.TotalApprovedRules +
                                                                           allRuleList.TotalRejectedRules)) * 100;

                allRuleList.SuccessRate = Math.Round(result, 2);

                return View(allRuleList);
            }
            catch (Exception e)
            {
                throw new Exception("Sorry, we have gotten a problem of showing the approver report right now.", e);
            }
           
        }

        //Control the views of approver report for editors.
        public ActionResult ApproverReportForEditor()
        {
            try
            {
                AllRuleListForApprover allRuleList = new AllRuleListForApprover();
                var totalApprovedRulesAmy = rulesApprover.GetFixedRulesByStatusForEditor("Approved", "zhouamym@gmail.com").Count
                              + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Approved", "zhouamym@gmail.com").Count;

                var totalRejectedRulesAmy = rulesApprover.GetFixedRulesByStatusForEditor("Rejected", "zhouamym@gmail.com").Count
                              + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Rejected", "zhouamym@gmail.com").Count;

                var totalUncheckedRulesAmy = rulesApprover.GetFixedRulesByStatusForEditor("Unchecked", "zhouamym@gmail.com").Count
                                            + rulesApprover.GetDataDataDrivenRulesByStatusForEditor("Unchecked", "zhouamym@gmail.com").Count;

                var resultAmy = ((double)totalApprovedRulesAmy / (totalApprovedRulesAmy + totalRejectedRulesAmy)) * 100;

                allRuleList.TotalApprovedRulesAmy = totalApprovedRulesAmy;
                allRuleList.TotalRejectedRulesAmy = totalRejectedRulesAmy;
                allRuleList.TotalUncheckedRulesAmy = totalUncheckedRulesAmy;
                allRuleList.SuccessRateAmy = Math.Round(resultAmy, 2);

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


                var averageResult = ((double)(totalApprovedRulesAmy + totalApprovedRulesCrys) /
                                     (totalApprovedRulesAmy + totalApprovedRulesCrys + totalRejectedRulesAmy +
                                      totalRejectedRulesCrys)) * 100;

                allRuleList.AverageSuccessRate = Math.Round(averageResult, 2);

                return View(allRuleList);
            }
            catch (Exception e)
            {
                throw new Exception("Sorry, we have gotten a problem of showing the approver report for editors right now.", e);
            }
            
        }
    }
}