using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Database;

namespace Assignment2.Bussiness
{
    public class DataDrivenRuleEditor
    {
        public void AddDataDriveRule(DataDrivenRules rule)
        {
            using (var context = new Context())
            {
                context.DataDrivenRules.Add(rule);
                context.SaveChanges();
            }
        }

        public IEnumerable<DataDrivenRules> AllDataDrivenRules
        {
            get
            {
                using (var context = new Context())
                {
                    // Materialize to a list because the context is closed
                    return context.DataDrivenRules.ToList();
                }
            }
        }
    }
}
