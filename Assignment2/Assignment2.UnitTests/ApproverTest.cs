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

        [Test]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
