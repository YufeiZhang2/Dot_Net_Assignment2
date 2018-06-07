using System;
using NUnit.Framework;
using Assignment2.Bussiness;
using Assignment2.Database;


namespace Assignment2.UnitTests
{
    [TestFixture]
    public class EditorTest
    {
        RulesEditor rulesEditor;


        /// <summary>
        /// Instantiate editor class
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            rulesEditor = new RulesEditor();
        }



        /// <summary>
        /// Check the deletion of existing data-driven rules
        /// </summary>
        /// <param name="ruleId">The rule Id</param>
        [Test]
        [TestCase(39)]
        [TestCase(1)]
        public void DeleteDataDrivenRules_DeleteData_DeleteSuccessfully(int ruleId)
        {
            var rule = rulesEditor.SearchDataDrivenRuleById(ruleId);
            rulesEditor.DeleteDataDrivenRule(rule);

            var ruleExistence = rulesEditor.SearchDataDrivenRuleById(ruleId);
            Assert.That(ruleExistence == null);
        }


        /// <summary>
        /// Check the counting of rules belonging to a given editor
        /// </summary>
        /// <param name="editorId">The editor Id</param>
        [Test]
        [TestCase("crysbui.depon@gmail.com")]
        [TestCase("zhouamym@gmail.com")]
        public void CountApprovedRules_CountRule_ReturnCountNumber(string editorId)
        {
            int count = rulesEditor.GetYourFixedRulesByStatus("Approved", editorId).Count;
            Assert.That(count != 0);
        }


        /// <summary>
        /// Try update an existing rule into a rule that already exists and it should throw an error
        /// </summary>
        [Test]
        public void UpdateFixedRules_DuplicateRules_ThrowError()
        {
            FixedRules rule = new FixedRules();
            rule.Id = 1;
            rule.Question = "Hello!";
            rule.Answer = "Hi";

            Assert.That(() => rulesEditor.UpdateFixedRule(rule), Throws.Exception);
        }


        /// <summary>
        /// Add invalid fixed rules.
        /// </summary>
        /// <param name="question"> Rule question </param>
        /// <param name="answer"> Rule answer </param>
        [Test]
        [TestCase("  ", " ")]
        [TestCase("", "\t")]
        [TestCase("No answer", "  ")]
        public void AddNewFixedRules_InvalidRules_ThrowError(string question, string answer)
        {
            FixedRules rule = new FixedRules();
            rule.Question = question;
            rule.Answer = answer;
            rule.CurrentStatus = "Unchecked";
            rule.LastEditorID = "zhouamym@gmail.com";
            Assert.That(() => rulesEditor.AddFixedRule(rule), Throws.Exception);
        }


        /// <summary>
        /// Add invalid data-driven rules.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="questionColumn"></param>
        /// <param name="answer"></param>
        /// <param name="answerColumn"></param>
        [Test]
        [TestCase("  ", "NoColumn", " *** ", "Day")]
        [TestCase("no correct symbol", "Day", " *** ", "Day")]
        [TestCase("hey *", "WrongColumn", " *** ", "Day")]
        public void AddNewDataDrivenRules_InvalidRules_ThrowError(string question, string questionColumn, string answer, string answerColumn)
        {
            DataDrivenRules rule = new DataDrivenRules();
            rule.Question = question;
            rule.QuestionColumn = questionColumn;
            rule.Answer = answer;
            rule.AnswerColumn = answerColumn;
            rule.CurrentStatus = "Unchecked";
            rule.LastEditorID = "zhouamym@gmail.com";

            Assert.That(() => rulesEditor.AddDataDrivenRule(rule), Throws.Exception);
        }

        /// <summary>
        /// Try add duplicate rules and it should throw error.
        /// </summary>
        [Test]
        public void AddNewDataDrivenRules_DuplicatedRules_ThrowError()
        {
            DataDrivenRules rule = new DataDrivenRules();
            rule.Question = "What outfit should be prepared on *?";
            rule.QuestionColumn = "Day";
            rule.Answer = "Probably *";
            rule.AnswerColumn = "Outfit";
            rule.CurrentStatus = "Unchecked";
            rule.LastEditorID = "zhouamym@gmail.com";

            rulesEditor.AddDataDrivenRule(rule);

            Assert.That(() => rulesEditor.AddDataDrivenRule(rule),
                Throws.Exception);
        }

        /// <summary>
        /// Try update a rule without changes and it should not throw error.
        /// </summary>
        [Test]
        public void UpdateDataDrivenRules_UnchangedRules_NoError()
        {
            DataDrivenRules rule = new DataDrivenRules();
            rule.Id = 33;
            rule.Question = "What should I wear on * ?";
            rule.QuestionColumn = "Day";
            rule.Answer = "You should wear *";
            rule.AnswerColumn = "Outfit";
            rule.CurrentStatus = "Unchecked";
            rule.LastEditorID = "zhouamym@gmail.com";

            Assert.That(() => rulesEditor.UpdateDataDrivenRule(rule),
                Throws.Nothing);
        }

        /// <summary>
        /// Check success rate of a user with approved/rejected rules. 
        /// </summary>
        /// <param name="editorID"></param>
        [Test]
        [TestCase("zhouamym@gmail.com")]
        [TestCase("crysbui.depon@gmail.com")]
        [TestCase("jenn_yl@yahoo.com")]
        public void SuccessRate_EditorWithOrWithoutApprovedRules_ReturnMoreThanZeroOrZero(string editorID)
        {
            double result = rulesEditor.SuccessRate(editorID);

            if (editorID == "jenn_yl@yahoo.com") Assert.That(result == 0);
            else Assert.That(result != 0);
        }


    }
}
