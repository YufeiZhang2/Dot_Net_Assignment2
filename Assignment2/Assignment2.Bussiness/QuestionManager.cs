using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment2.Bussiness
{
    class AnswerToQuestion
    {
        public string answer;
        public string question;
    }

    public class QuestionManager
    {

        public string TryGetAnswer(string question)
        {
            // Check simple rules first
            // Clean the spaces of the question.
            string lowerUserQuestion = question.ToLower().Trim();
            string cleanUserQuestion = Regex.Replace(lowerUserQuestion, @"[^a-zA-Z0-9]", string.Empty, RegexOptions.Compiled);

            using (Model context = new Model())
            {
                //var simpleAnswer = from rule in context.FixedRules
                //                  where rule.Question == cleanUserQuestion
                //                  select rule.Answer.FirstOrDefault();
                //rule.Question.ToLower().Trim().Replace("!","")
                var answers = context.FixedRules
                    .Where(rule => rule.CurrentStatus == "Approved").ToList()
                    .Select(
                    rule => new AnswerToQuestion
                    { question = Regex.Replace(rule.Question.ToLower().Trim(), @"[^a-zA-Z0-9]", string.Empty, RegexOptions.Compiled),
                        answer = rule.Answer }
                    );

                var simpleAnswer = answers.Where(rule => rule.question == cleanUserQuestion).Select(rule => rule.answer);

                if(simpleAnswer.Count() > 0) {
                    return simpleAnswer.First();
                }
                else
                {
                    return null;
                }
            }
            
        }


    }

}
