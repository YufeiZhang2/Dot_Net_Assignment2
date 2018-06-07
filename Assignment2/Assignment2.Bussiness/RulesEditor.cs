using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Assignment2.Database;

namespace Assignment2.Bussiness
{

    public class RulesEditor
    {
        HashSet<string> validColumn = new HashSet<string>() { "day", "weather", "outfit", "temperature" };

        /// <summary>
        /// Get a list of fixed rules by given status
        /// </summary>
        /// <param name="status">the status of the rule</param>
        /// <returns></returns>
        public List<FixedRules> GetFixedRulesByStatus(string status)
        {
            using (Context context = new Context())
            {
                var rules = context.FixedRules
                    .Where(rule => rule.CurrentStatus == status).ToList();
                return rules;
            }
        }

        /// <summary>
        /// Get a list of data-driven rules by given status
        /// </summary>
        /// <param name="status">The status of the rules</param>
        /// <returns></returns>
        public List<DataDrivenRules> GetDataDrivenRulesByStatus(string status)
        {
            using (Context context = new Context())
            {
                var rules = context.DataDrivenRules
                    .Where(rule => rule.CurrentStatus == status).ToList();
                return rules;
            }
        }

        /// <summary>
        /// Get fixed rule by given status and username
        /// </summary>
        /// <param name="status">The status of the rule</param>
        /// <param name="username">The username of the last editor</param>
        /// <returns></returns>
        public List<FixedRules> GetYourFixedRulesByStatus(string status, string username)
        {
            using (Context context = new Context())
            {
                var rules = context.FixedRules
                    .Where(rule => rule.CurrentStatus == status && rule.LastEditorID == username).ToList();
                return rules;
            }
        }

        /// <summary>
        /// Get data-driven rule by given status and username
        /// </summary>
        /// <param name="status">The status of the rule</param>
        /// <param name="username">The username of the last editor</param>
        /// <returns>The rule with searching status and username</returns>
        public List<DataDrivenRules> GetYourDataDrivenRulesByStatus(string status, string username)
        {
            using (Context context = new Context())
            {
                var rules = context.DataDrivenRules
                    .Where(rule => rule.CurrentStatus == status && rule.LastEditorID == username).ToList();
                return rules;
            }
        }

        /// <summary>
        /// Search data-driven rule by given ID
        /// </summary>
        /// <param name="id">ID of the data-driven rule</param>
        /// <returns>The rule with given ID</returns>
        public DataDrivenRules SearchDataDrivenRuleById(int id)
        {
            using (Context context = new Context())
            {
                return (from c in context.DataDrivenRules
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// Search fixed rule by given ID
        /// </summary>
        /// <param name="id">ID of the rule</param>
        /// <returns>The rule with given ID</returns>
        public FixedRules SearchFixedRuleById(int id)
        {
            using (Context context = new Context())
            {
                return (from c in context.FixedRules
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// Count the approved rules of one editor. 
        /// </summary>
        /// <param name="editorID"> The editor ID. </param>
        /// <returns> The number of approved rules of this editor. </returns>
        public int CountApprovedRules(string editorID)
        {
            int count = GetYourFixedRulesByStatus("Approved", editorID).Count;
            count += GetYourDataDrivenRulesByStatus("Approved", editorID).Count;
            return count;
        }

        /// <summary>
        /// Count the rejected rules of one editor. 
        /// </summary>
        /// <param name="editorID"> The editor ID. </param>
        /// <returns> The number of rejected rules of this editor. </returns>
        public int CountRejectedRules(string editorID)
        {
            int count = GetYourFixedRulesByStatus("Rejected", editorID).Count;
            count += GetYourDataDrivenRulesByStatus("Rejected", editorID).Count;
            return count;
        }

        /// <summary>
        /// See the success rate of one editor. 
        /// </summary>
        /// <param name="editorID"> The editor ID. </param>
        /// <returns> The success rate of this user. </returns>
        public double SuccessRate(string editorID)
        {
            int approvedCount = CountApprovedRules(editorID);
            int rejectedCount = CountRejectedRules(editorID);
            if (approvedCount + rejectedCount != 0)
            {
                return (double)approvedCount / (approvedCount + rejectedCount);
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// Add new fixed rule
        /// </summary>
        /// <param name="rule">The new rule to be added</param>
        public void AddFixedRule(FixedRules rule)
        {
            // Check if this rule exists before adding and check if the rule itself is valid.
            ValidateFixedRule(rule.Question, rule.Answer, true, 0);

            // If data are valid, add them to the database. Clean the redundant spaces between words.
            rule.Question = Regex.Replace(rule.Question.Trim(), @"\s+", " ", RegexOptions.Compiled);
            rule.Answer = Regex.Replace(rule.Answer.Trim(), @"\s+", " ", RegexOptions.Compiled);

            using (Context context = new Context())
            {
                context.FixedRules.Add(rule);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add new data-driven rule
        /// </summary>
        /// <param name="rule">The new rule to be added</param>
        public void AddDataDrivenRule(DataDrivenRules rule)
        {
            // Check if this rule exists before adding and check if the rule itself is valid.
            ValidateDataDrivenRule(rule.Question, rule.QuestionColumn, rule.Answer, rule.AnswerColumn, true, 0);

            // If data are valid, add them to the database. Clean the redundant spaces between words.
            rule.Question = Regex.Replace(rule.Question.Trim(), @"\s+", " ", RegexOptions.Compiled);
            rule.Answer = Regex.Replace(rule.Answer.Trim(), @"\s+", " ", RegexOptions.Compiled);

            using (Context context = new Context())
            { 
                context.DataDrivenRules.Add(rule);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update given fixed rule
        /// </summary>
        /// <param name="rule">the given rule</param>
        public void UpdateFixedRule(FixedRules rule)
        {
            // Check if this rule exists before editing and check if the rule itself is valid.
            ValidateFixedRule(rule.Question, rule.Answer, false, rule.Id);

            // If data are valid, update them to the database. Clean the redundant spaces between words.
            rule.Question = Regex.Replace(rule.Question.Trim(), @"\s+", " ", RegexOptions.Compiled);
            rule.Answer = Regex.Replace(rule.Answer.Trim(), @"\s+", " ", RegexOptions.Compiled);

            using (Context context = new Context())
            {
                var updatedRule = context.FixedRules.Find(rule.Id);
                if (updatedRule != null)
                {
                    context.Entry(updatedRule).CurrentValues.SetValues(rule);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Update the given data-driven rule
        /// </summary>
        /// <param name="rule">the given rule</param>
        public void UpdateDataDrivenRule(DataDrivenRules rule)
        {
            // Check if this rule exists before editing and check if the rule itself is valid.
            ValidateDataDrivenRule(rule.Question, rule.QuestionColumn, rule.Answer, rule.AnswerColumn, false, rule.Id);

            // If data are valid, update them to the database. Clean the redundant spaces between words.
            rule.Question = Regex.Replace(rule.Question.Trim(), @"\s+", " ", RegexOptions.Compiled);
            rule.Answer = Regex.Replace(rule.Answer.Trim(), @"\s+", " ", RegexOptions.Compiled);

            using (Context context = new Context())
            {
                var updatedRule = context.DataDrivenRules.Find(rule.Id);
                if (updatedRule != null)
                {
                    context.Entry(updatedRule).CurrentValues.SetValues(rule);
                    context.SaveChanges();
                }     
            }
        }


        /// <summary>
        /// Validate fixed rule
        /// </summary>
        /// <param name="question">The question</param>
        /// <param name="answer">The answer</param>
        /// <param name="isNew">Whether this rule is new or and existing rule</param>
        /// <param name="ruleID">The rule ID</param>
        private void ValidateFixedRule(string question, string answer, bool isNew, int ruleID)
        {
            if (question == null || answer == null) throw new Exception("Your question or answer is empty");

            // Clean the question. 
            string lowerUserQuestion = question.ToLower().Trim();
            string lowerUserAnswer = answer.ToLower().Trim();

            if (lowerUserQuestion == string.Empty || lowerUserAnswer == string.Empty) throw new Exception("Your question or answer is empty");


            if ((lowerUserQuestion.Length > 15 && !lowerUserQuestion.Contains(" ")) || (lowerUserAnswer.Length > 15 && !lowerUserAnswer.Contains(" ")))
                throw new Exception("Sorry, this question or answer may be meaningless! Please try other words!");

            string cleanUserQuestion = Regex.Replace(lowerUserQuestion, @"[^a-zA-Z0-9]", string.Empty, RegexOptions.Compiled);

            // Question and answer should not be empty.
            if (lowerUserQuestion == "" || answer.Trim() == "") throw new Exception("Your question or answer is empty");

            using (Context context = new Context())
            {
                foreach (var rule in context.FixedRules)
                {
                    // Skip checking the rule itself if it is editing an old rule.
                    if (!isNew && ruleID == rule.Id) continue;

                    // Clean the question in the database.
                    string lowerDbQuestion = rule.Question.ToLower().Trim();
                    string cleanDbQuestion = Regex.Replace(lowerDbQuestion, @"[^a-zA-Z0-9]", string.Empty, RegexOptions.Compiled);

                    // If the new question is the same as a question in database, throw error to stop adding it to database. 
                    if (cleanDbQuestion == cleanUserQuestion)
                    {
                        throw new Exception("This rule exists! Don't make duplicate rules!");
                    }
                }
            }
            
        }


        /// <summary>
        /// Validate data-driven rule
        /// </summary>
        /// <param name="question">The question</param>
        /// <param name="questionColumn">The question column</param>
        /// <param name="answer">The answer</param>
        /// <param name="answerColumn">The answer column</param>
        /// <param name="isNew">Whether this rule is new or and existing rule</param>
        /// <param name="ruleID">The rule ID</param>
        private void ValidateDataDrivenRule(string question, string questionColumn, string answer, string answerColumn, bool isNew, int ruleID)
        {
            if (question == null || answer == null || questionColumn == null || answerColumn == null ||
                !validColumn.Contains(questionColumn.ToLower()) || !validColumn.Contains(answerColumn.ToLower()))
                throw new Exception("Your question, answer or column is empty");


            // The question and answer should have * symbol. 
            if (!question.Contains("*") || !answer.Contains("*"))
            {
                throw new Exception("The format of your question or answer is invalid! " +
                    "Please include a wildcard '*' symbol in your question and answer of the data driven rule!");
            }

            // The question should have only one * symbol. 
            if (question.Length - question.Replace("*", "").Length > 1)
            {
                throw new Exception("Your question should only contain one '*' symbol!");
            }

            // Clean the question. 
            string lowerUserQuestion = question.ToLower().Trim();
            string lowerUserAnswer = answer.ToLower().Trim();

            if ((lowerUserQuestion.Length > 15 && !lowerUserQuestion.Contains(" ")) || (lowerUserAnswer.Length>15 && !lowerUserAnswer.Contains(" ")))
                throw new Exception("Sorry, this question or answer may be meaningless! Please try other words!");


            string cleanUserQuestion = Regex.Replace(lowerUserQuestion, @"[^a-zA-Z0-9*]", string.Empty, RegexOptions.Compiled);


            using (Context context = new Context())
            {
                foreach (var rule in context.DataDrivenRules)
                {
                    // Skip the rule itself if it is editing an old rule. 
                    if (!isNew && ruleID == rule.Id) continue;

                    // Clean the question in the database.
                    string lowerDbQuestion = rule.Question.ToLower().Trim();
                    string cleanDbQuestion = Regex.Replace(lowerDbQuestion, @"[^a-zA-Z0-9*]", string.Empty, RegexOptions.Compiled);

                    // If question string is the same and the column it uses is also the same, it's invalid. 
                    if (cleanDbQuestion == cleanUserQuestion && rule.QuestionColumn == questionColumn)
                    {
                        throw new Exception("There is already a rule with the question: " + rule.Question + ". Don't make duplicate rules!");
                    }
                }
            }
        }


        /// <summary>
        /// Delete the given fixed rule
        /// </summary>
        /// <param name="rule">The given rule</param>
        public void DeleteFixedRule(FixedRules rule)
        {

            using (Context context = new Context())
            {
                var deletedRule = context.FixedRules.Find(rule.Id);
                context.FixedRules.Remove(deletedRule);
                context.SaveChanges();
            }

        }

        /// <summary>
        /// Delete the given data-driven rule
        /// </summary>
        /// <param name="rule">The given rule</param>
        public void DeleteDataDrivenRule(DataDrivenRules rule)
        {
            using (Context context = new Context())
            {
                var deletedRule = context.DataDrivenRules.Find(rule.Id);
                context.DataDrivenRules.Remove(deletedRule);
                context.SaveChanges();
            }
        }


    }
}
