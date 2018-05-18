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
        public void GetAnswerToAQuestion_ValidQuestion_ReturnNotNull(string question)
        {
            string result = questionManager.TryGetAnswer(question);

            Assert.That(result == "Hi! How are you?");
        }
    }
}
