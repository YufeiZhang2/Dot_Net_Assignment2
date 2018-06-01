using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2.Database;


namespace Assignment2.Business
{
    /// <summary>
    /// The function used to manage the rules, including approving and rejecting rules, showing a
    /// list of rules by status and generating two approver reports.
    /// </summary>
    
    public class RuleApprover
    {
        //List fixed rules by status.
        public List<FixedRules> GetFixedRulesByStatus(string status)
        {
            using (Context context = new Context())
            {
                var rules = context.FixedRules
                    .Where(rule => rule.CurrentStatus == status).ToList();
                return rules;
            }
        }

        //List data-driven rules by stauts.
        public List<DataDrivenRules> GetDataDrivenRulesByStatus(string status)
        {
            using (Context context = new Context())
            {
                var rules = context.DataDrivenRules
                    .Where(rule => rule.CurrentStatus == status).ToList();
                return rules;
            }
        }

        //Approve unchecked fixed rules by id.
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

        //Approve unchecked data-driven rules by id.
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

        //Reject unchecked fixed rules by id.
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
        
        //Reject uncheck data-driven rules by id.
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


        //List fixed rules by status and editor id.
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

        //List data driven rules by status and editor id.
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
    