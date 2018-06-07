using System;
using NUnit.Framework;
using Assignment2.Bussiness;
using Assignment2.Database;

namespace Assignment2.UnitTests
{
    [TestFixture]
    class EditorQuestionTests
    {
        QuestionManager questionManager;
        RulesEditor rulesEditor;

        /// <summary>
        /// Instantiate editor and manager classes.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            questionManager = new QuestionManager();
            rulesEditor = new RulesEditor();
        }

        /// <summary>
        /// Use invalid questions to receive null answers.
        /// </summary>
        /// <param name="question"> Various questions. </param>
        [Test]
        [TestCase("Damn")]
        [TestCase("I asked an invalid question here...")]
        [TestCase("Another invalid question.")]
        [TestCase("What is the temperature on this *?!")]
        [TestCase("What is the day when it is 99 Celsius degree?")]
        [TestCase("What is the day when it is NaN Celsius degree?")]
        [TestCase("What is the temperature on this thursday?")]
        [TestCase("When should I wear nothing?")]
        public void GetAnswerToAQuestion_InvalidQuestion_ReturnNull(string question)
        {
            string result = questionManager.TryGetAnswer(question);

            Assert.That(result == null);
        }

        /// <summary>
        /// Use invalid questions to receive null answers.
        /// </summary>
        /// <param name="question"> Various questions. </param>
        [Test]
        [TestCase("hello")]
        [TestCase("hel???lo")]
        [TestCase("hello#%@")]
        [TestCase("hello#%@world")]
        [TestCase("What is the day when it is 20 Celsius degree?")]
        [TestCase("What should I #%@wear when it is rainy?!")]
        [TestCase("What is the temperature on this tuesday???????!!??")]
        [TestCase("When should/// I wear??? coat?")]
        [TestCase("What can you do?")]
        public void GetAnswerToAQuestion_ValidQuestion_ReturnNotNull(string question)
        {
            string result = questionManager.TryGetAnswer(question);

            Assert.That(result != null);
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
