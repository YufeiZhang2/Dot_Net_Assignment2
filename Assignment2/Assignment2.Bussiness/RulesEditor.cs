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




        public void AddFixedRule()
        {

            using (Context context = new Context())
            {

                context.SaveChanges();
            }
        }


        public void UpdateFixedRule()
        {

            using (Context context = new Context())
            {

                context.SaveChanges();
            }

        }

        public void DeleteFixedRule()
        {

            using (Context context = new Context())
            {

                context.SaveChanges();
            }

        }


    }
}
