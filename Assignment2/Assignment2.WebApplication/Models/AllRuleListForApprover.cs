using System.Collections.Generic;
using Assignment2.Database;

namespace Assignment2.WebApplication.Controllers
{
    /// <summary>
    /// Data model for the rules.
    /// </summary>
    public class AllRuleListForApprover
    {
        //property for managing rules and approver report.
        public List<FixedRules> ApprovedFixedRules;
        public List<DataDrivenRules> ApprovedDataDrivenRules;
        public List<FixedRules> UncheckedFixedRules;
        public List<DataDrivenRules> UncheckedDataDrivenRules;
        public int TotalApprovedRules;
        public int TotalRejectedRules;
        public double SuccessRate;

        //property for approver report for editors.
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
}