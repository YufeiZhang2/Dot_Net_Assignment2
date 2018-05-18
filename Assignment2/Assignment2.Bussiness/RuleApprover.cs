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
    /*
    [System.ComponentModel.DataObject]
    public class RuleApprover
    {
        
        private FixedRulesTableAdapter _simpleRulesAdapter;
        private FixedRulesTableAdapter SimpleRulesAdapter
        {
            get
            {
                if (_simpleRulesAdapter == null)
                {
                    _simpleRulesAdapter = new FixedRulesTableAdapter();
                }

                return _simpleRulesAdapter;
            }
        }

        private DataDrivenRulesTableAdapter _dataRulesAdapter;
        private DataDrivenRulesTableAdapter DataRulesAdapter
        {
            get
            {
                if (_dataRulesAdapter == null)
                {
                    _dataRulesAdapter = new DataDrivenRulesTableAdapter();
                }

                return _dataRulesAdapter;
            }
        }

        //list unchecked fixed rules
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public FixedRules.FixedRulesDataTable ListUncheckedFixedRules()
        {
            var rows = SimpleRulesAdapter.GetDataByStatus("Unchecked");

            return rows;
        }

        //list unchecked data-driven rules
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataDrivenRules.DataDrivenRulesDataTable ListUncheckedDataDrivenRule()
        {
            var rows = DataRulesAdapter.GetDataByStatus("Unchecked");
            return rows;
        }

        //list approved fixed rules.
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public FixedRules.FixedRulesDataTable ListApprovedFixedRules()
        {
            var rows = SimpleRulesAdapter.GetDataByStatus("Approved");

            return rows;
        }

        //list approved data-driven rules
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataDrivenRules.DataDrivenRulesDataTable ListApprovedDataDrivenRules()
        {
            var rows = DataRulesAdapter.GetDataByStatus("Approved");

            return rows;
        }


        //approve unchecked fixed rules.
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public void ApproveFixedRule(int id)
        {
            SimpleRulesAdapter.SetStatusByID(((Status)0).ToString(), id);
        }

        //approve unchecked data-driven rules.
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public void ApproveDataDrivenRule(int id)
        {
            DataRulesAdapter.SetStatusByID(((Status)0).ToString(), id);
        }

        //reject unchecked fixed rules
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public void RejectFixedRule(int id)
        {
            SimpleRulesAdapter.SetStatusByID(((Status)1).ToString(), id);
        }

        //reject uncheck data-driven rules
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public void RejectDataDrivenRule(int id)
        {
            DataRulesAdapter.SetStatusByID(((Status)1).ToString(), id);
        }


        //get total count of approved rules
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int GetTotalCountOfApprovedRules()
        {
            int totalApprovedFixedRules = SimpleRulesAdapter.GetDataByStatus(((Status)0).ToString()).Count;
            int totalApprovedDataDrivenRules = DataRulesAdapter.GetDataByStatus(((Status)0).ToString()).Count;

            return totalApprovedFixedRules + totalApprovedDataDrivenRules;
        }

        //get total count of rejected rules
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int GetTotalCountOfRejectedRules()
        {
            int totalRejectFixedRules = SimpleRulesAdapter.GetDataByStatus(((Status)1).ToString()).Count;
            int totalRejectedDataDrivenRules = DataRulesAdapter.GetDataByStatus(((Status)1).ToString()).Count;
            
            return totalRejectFixedRules + totalRejectedDataDrivenRules;
            
        }


        //show the success rate for appoval
        public double ShowSucessRate()
       {
            int totalApprovedRules = GetTotalCountOfApprovedRules();
            int totalRejectedRules = GetTotalCountOfRejectedRules();

            if (totalApprovedRules + totalRejectedRules != 0)
            {
                double successRate = ((double) totalApprovedRules / (totalApprovedRules + totalRejectedRules)) *100;
                
                return Math.Round(successRate, 2);
            }
            return 0;
       }

        //get total count of approved rules for an editor
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int GetEditorTotalCountOfApprovedRules(string editorId)
        {
            int approvedFixedRules = SimpleRulesAdapter.GetDataByStatusAndEditor(editorId, ((Status)0).ToString()).Count;
            int approveDataDrivenRules = DataRulesAdapter.GetDataByStatusAndEditor(editorId, ((Status)0).ToString()).Count;

            return approvedFixedRules + approveDataDrivenRules;
        }

        //get total count of rejected rules for an editor
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int GetEditorTotalCountOfRejectedRules(string editorId)
        {
            int rejectedFixedRules = SimpleRulesAdapter.GetDataByStatusAndEditor(editorId, ((Status)1).ToString()).Count;
            int rejectedDataDrivenRules = DataRulesAdapter.GetDataByStatusAndEditor(editorId, ((Status)1).ToString()).Count;

            return rejectedFixedRules + rejectedDataDrivenRules;
        }

        //get total count of unchecked rules for an editor
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int GetEditorTotalCountOfUncheckedRules(string editorId)
        {
            int uncheckedFixedRules = SimpleRulesAdapter.GetDataByStatusAndEditor(editorId, ((Status)2).ToString()).Count;
            int uncheckedDataDrivenRules = DataRulesAdapter.GetDataByStatusAndEditor(editorId, ((Status)2).ToString()).Count;

            return uncheckedFixedRules + uncheckedDataDrivenRules;
        }

        //show the success rate of an editor for approval
        public double ShowEditorSuccessRate(string editorId)
        {
            int totalApprovedRules = GetEditorTotalCountOfApprovedRules(editorId);
            int totalRejectedRules = GetEditorTotalCountOfRejectedRules(editorId);

            if ((totalApprovedRules + totalRejectedRules) != 0)
            {
                double successRate = ((double) totalApprovedRules / (totalApprovedRules + totalRejectedRules)) * 100;
                return Math.Round(successRate, 2);
            }

            return 0;
        }
            

        //show an average success rate of all editors
        public double ShowAverageSuccessRate(string editorId1, string editorId2)
        {
            int totalApprovedRules1 = GetEditorTotalCountOfApprovedRules(editorId1);
            int totalRejectedRules1 = GetEditorTotalCountOfRejectedRules(editorId1);

            int totalApprovedRules2 = GetEditorTotalCountOfApprovedRules(editorId2);
            int totalRejectedRules2 = GetEditorTotalCountOfRejectedRules(editorId2);


            if ((totalApprovedRules1 + totalRejectedRules1 + totalApprovedRules2 + totalRejectedRules2) != 0)
            {
                double successRate = ((double) (totalApprovedRules1 + totalApprovedRules2) / (totalApprovedRules1 + totalRejectedRules1 + totalApprovedRules2 + totalRejectedRules2)) * 100;
                return Math.Round(successRate, 2);
            }

            return 0;
        }
    

    }
    */
}
