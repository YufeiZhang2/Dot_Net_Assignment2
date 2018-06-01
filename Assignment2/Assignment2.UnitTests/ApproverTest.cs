using System;
using System.Text;
using System.Collections.Generic;
using Assignment2.Business;
using NUnit;
using NUnit.Framework;

namespace Assignment2.UnitTests
{
    /// <summary>
    /// Summary description for ApproverTest
    /// </summary>
    [TestFixture]
    public class ApproverTest
    {
        private RuleApprover _approver;

        [SetUp]
        public void SetUp()
        {
            _approver = new RuleApprover();
        }

        /// <summary>
        /// Test if GetFixedRulesByStatus() can successfully retrive unchecked fixed rules.
        /// </summary>
        [Test]
        public void GetFixedRulesByStatus_RetriveUncheckedFixedRules_ReuturnUncheckedFixedRules()
        {
            var result = _approver.GetFixedRulesByStatus("Unchecked");

            foreach (var fixedRule in result)
            {
                Assert.That(fixedRule.CurrentStatus == "Unchecked");
            }

        }

        /// <summary>
        /// Test if GetFixedRulesByStatus() can successfully retrive approved fixed rules.
        /// </summary>
        [Test]
        public void GetFixedRulesByStatus_RetriveApprovedFixedRules_ReuturnApprovedFixedRules()
        {
            var result = _approver.GetFixedRulesByStatus("Approved");

            foreach (var fixedRule in result)
            {
                Assert.That(fixedRule.CurrentStatus == "Approved");
            }

        }

        /// <summary>
        /// Test if GetDataDrivenRulesByStatus() can successfully retrive unchecked data-driven rules.
        /// </summary>
        [Test]
        public void GetDataDrivenRulesByStatus_RetriveUncheckedDataDrivenRules_ReuturnUncheckedDataDrivenRules()
        {
            var result = _approver.GetDataDrivenRulesByStatus("Unchecked");

            foreach (var dataDrivenRule in result)
            {
                Assert.That(dataDrivenRule.CurrentStatus == "Unchecked");
            }

        }

        /// <summary>
        /// Test if GetDataDrivenRulesByStatus() can successfully retrive approved data-driven rules.
        /// </summary>
        [Test]
        public void GetDataDrivenRulesByStatus_RetriveApprovedDataDrivenRules_ReuturnApprovedDataDrivenRules()
        {
            var result = _approver.GetDataDrivenRulesByStatus("Approved");

            foreach (var dataDrivenRule in result)
            {
                Assert.That(dataDrivenRule.CurrentStatus == "Approved");
            }

        }
    }
}
