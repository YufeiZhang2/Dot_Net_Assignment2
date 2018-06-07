using System;
using NUnit.Framework;
using Assignment2.Bussiness;

namespace Assignment2.UnitTests
{
    [TestFixture]
    class EditorQuestionTests
    {
        QuestionManager questionManager;

        /// <summary>
        /// Instantiate editor and manager classes.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            questionManager = new QuestionManager();
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
    }
}
