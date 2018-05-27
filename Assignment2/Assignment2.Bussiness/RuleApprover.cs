using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2.Database;




namespace Assignment2.Business
{
    /// <summary>
    /// The function used to manage the rules, including approving and rejecting rules, showing a
    /// list of rules and generating two approver reports.
    /// </summary>
    
    public class RuleApprover
    {
        
        //list fixed rules
        public List<FixedRules> GetFixedRulesByStatus(string status)
        {
            using (Context context = new Context())
            {
                var rules = context.FixedRules
                    .Where(rule => rule.CurrentStatus == status).ToList();
                return rules;
            }
        }

        //list data-driven rules
        public List<DataDrivenRules> GetDataDrivenRulesByStatus(string status)
        {
            using (Context context = new Context())
            {
                var rules = context.DataDrivenRules
                    .Where(rule => rule.CurrentStatus == status).ToList();
                return rules;
            }
        }

        //approve unchecked fixed rules.
        public void ApproveFixedRule(int id)
        {

            using (Context context = new Context())
            {
                var approvedRule = context.FixedRules.Find(id);
                if(approvedRule != null)
                approvedRule.CurrentStatus = "Approved";
                context.SaveChanges();
            }

        }

        //approve unchecked data-driven rules.
        public void ApproveDataDrivenRule(int id)
        {

            using (Context context = new Context())
            {
                var approvedRule = context.DataDrivenRules.Find(id);
                if (approvedRule != null)
                    approvedRule.CurrentStatus = "Approved";
                context.SaveChanges();
            }

        }

        //reject unchecked fixed rules
        public void RejectFixedRule(int id)
        {

            using (Context context = new Context())
            {
                var rejectedRule = context.FixedRules.Find(id);
                if (rejectedRule != null)
                    rejectedRule.CurrentStatus = "Rejected";
                context.SaveChanges();
            }

        }


        //reject uncheck data-driven rules
        public void RejectDataDrivenRule(int id)
        {

            using (Context context = new Context())
            {
                var rejectedRule = context.DataDrivenRules.Find(id);
                if (rejectedRule != null)
                    rejectedRule.CurrentStatus = "Rejected";
                context.SaveChanges();
            }

        }


        //list fixed rules of amy
        public List<FixedRules> GetFixedRulesByStatusForEditor(string status, string editorId)
        {
            using (Context context = new Context())
            {
                var rules = context.FixedRules
                    .Where(rule => rule.LastEditorID == editorId).ToList();

                var result = rules.Where(rule => rule.CurrentStatus == status).ToList();
                
                return result;
            }
        }

        //list data driven rules of amy
        public List<DataDrivenRules> GetDataDataDrivenRulesByStatusForEditor(string status, string editorId)
        {
            using (Context context = new Context())
            {
                var rules = context.DataDrivenRules
                    .Where(rule => rule.LastEditorID == editorId).ToList();

                var result = rules.Where(rule => rule.CurrentStatus == status).ToList();

                return result;
            }
        }

    }
    
    }
    