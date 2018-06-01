using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Database;

namespace Assignment2.Bussiness
{

    public class RulesEditor
    {
        public List<FixedRules> GetFixedRulesByStatus(string status)
        {
            using (Context context = new Context())
            {
                var rules = context.FixedRules
                    .Where(rule => rule.CurrentStatus == status).ToList();
                return rules;
            }
        }

        public List<DataDrivenRules> GetDataDrivenRulesByStatus(string status)
        {
            using (Context context = new Context())
            {
                var rules = context.DataDrivenRules
                    .Where(rule => rule.CurrentStatus == status).ToList();
                return rules;
            }
        }

        public List<FixedRules> GetYourFixedRulesByStatus(string status, string username)
        {
            using (Context context = new Context())
            {
                var rules = context.FixedRules
                    .Where(rule => rule.CurrentStatus == status && rule.LastEditorID == username).ToList();
                return rules;
            }
        }

        public List<DataDrivenRules> GetYourDataDrivenRulesByStatus(string status, string username)
        {
            using (Context context = new Context())
            {
                var rules = context.DataDrivenRules
                    .Where(rule => rule.CurrentStatus == status && rule.LastEditorID == username).ToList();
                return rules;
            }
        }

        public DataDrivenRules SearchDataDrivenRuleById(int id)
        {
            using (Context context = new Context())
            {
                return (from c in context.DataDrivenRules
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public FixedRules SearchFixedRuleById(int id)
        {
            using (Context context = new Context())
            {
                return (from c in context.FixedRules
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// Count the approved rules of one editor. 
        /// </summary>
        /// <param name="editorID"> The editor ID. </param>
        /// <returns> The number of approved rules of this editor. </returns>
        public int CountApprovedRules(string editorID)
        {
            int count = GetYourFixedRulesByStatus("Approved", editorID).Count;
            count += GetYourDataDrivenRulesByStatus("Approved", editorID).Count;
            return count;
        }

        /// <summary>
        /// Count the rejected rules of one editor. 
        /// </summary>
        /// <param name="editorID"> The editor ID. </param>
        /// <returns> The number of rejected rules of this editor. </returns>
        public int CountRejectedRules(string editorID)
        {
            int count = GetYourFixedRulesByStatus("Rejected", editorID).Count;
            count += GetYourDataDrivenRulesByStatus("Rejected", editorID).Count;
            return count;
        }

        /// <summary>
        /// See the success rate of one editor. 
        /// </summary>
        /// <param name="editorID"> The editor ID. </param>
        /// <returns> The success rate of this user. </returns>
        public double SuccessRate(string editorID)
        {
            int approvedCount = CountApprovedRules(editorID);
            int rejectedCount = CountRejectedRules(editorID);
            if (approvedCount + rejectedCount != 0)
            {
                return (double)approvedCount / (approvedCount + rejectedCount);
            }
            else
            {
                return 0;
            }
        }



        public void AddFixedRule(FixedRules rule)
        {
            using (Context context = new Context())
            {
                context.FixedRules.Add(rule);
                context.SaveChanges();
            }
        }


        public void AddDataDrivenRule(DataDrivenRules rule)
        {
            using (Context context = new Context())
            { 
                context.DataDrivenRules.Add(rule);
                context.SaveChanges();
            }
        }


        public void UpdateFixedRule(FixedRules rule)
        {
            using (Context context = new Context())
            {
                var updatedRule = context.FixedRules.Find(rule.Id);
                if (updatedRule != null)
                {
                    context.Entry(updatedRule).CurrentValues.SetValues(rule);
                    context.SaveChanges();
                }
            }
        }


        public void UpdateDataDrivenRule(DataDrivenRules rule)
        {
            using (Context context = new Context())
            {
                var updatedRule = context.DataDrivenRules.Find(rule.Id);
                if (updatedRule != null)
                {
                    context.Entry(updatedRule).CurrentValues.SetValues(rule);
                    context.SaveChanges();
                }     
            }
        }

        public void DeleteFixedRule(FixedRules rule)
        {

            using (Context context = new Context())
            {
                var deletedRule = context.FixedRules.Find(rule.Id);
                context.FixedRules.Remove(deletedRule);
                context.SaveChanges();
            }

        }

        public void DeleteDataDrivenRule(DataDrivenRules rule)
        {
            using (Context context = new Context())
            {
                var deletedRule = context.DataDrivenRules.Find(rule.Id);
                context.DataDrivenRules.Remove(deletedRule);
                context.SaveChanges();
            }
        }


    }
}
