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
            using(Context context = new Context())
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
