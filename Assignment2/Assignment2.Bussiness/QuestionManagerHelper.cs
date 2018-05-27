using Assignment2.Database;
using Assignment2.Database.SmallDbForQuestionHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Assignment2.Bussiness
{
    partial class QuestionManager
    {

        public List<Table> GetQuestionHistory()
        {
            using (HistoryContext context = new HistoryContext())
            {
                return context.Table.ToList();
            }
        }

        public void CleanHistory()
        {
            using (HistoryContext context = new HistoryContext())
            {
                context.Table.RemoveRange(context.Table.ToList());
                context.SaveChanges();
            }
        }

        public void SaveAnswerToHistory(string question)
        {
            string answer = TryGetAnswer(question);
            using (HistoryContext context = new HistoryContext())
            {
                context.Table.Add(new Table { Question = question, Answer = answer });
                context.SaveChanges();

            }
        }



        /// <summary>
        /// Search weather table with the given day value. 
        /// </summary>
        /// <param name="questionValue"> Value of the day field. </param>
        /// <returns> A row that has the day value in day column. </returns>
        private WeatherInfo SearchByDay(string questionValue)
        {
            string pattern = questionValue.ToLower();

            using (Context context = new Context())
            {
                var temp = from c in context.WeatherInfo
                           where c.Day.ToLower().Equals(pattern)
                           select c;

                if (temp.Count() == 0) return null;
                return temp.First();
            }
        }

        /// <summary>
        /// Search weather table with the given weather value. 
        /// </summary>
        /// <param name="questionValue"> Value of the weather field. </param>
        /// <returns> A row that has the weather value in weather column. </returns>
        private WeatherInfo SearchByWeather(string questionValue)
        {
            string pattern = questionValue.ToLower();
            using (Context context = new Context())
            {
                var temp = from c in context.WeatherInfo
                           where c.Weather.ToLower().Equals(pattern)
                           select c;

                if (temp.Count() == 0)
                {
                    temp = from c in context.WeatherInfo
                           where c.Weather.ToLower().Contains(pattern)
                           select c;

                    if (temp.Count() == 0) return null;
                    else return temp.First();
                }
                return temp.First();
            }
        }

        /// <summary>
        /// Search weather table with the given outfit value. 
        /// </summary>
        /// <param name="questionValue"> Value of the outfit field. </param>
        /// <returns> A row that has the outfit value in outfit column. </returns>
        private WeatherInfo SearchByOutfit(string questionValue)
        {
            string pattern = questionValue.ToLower();

            using (Context context = new Context())
            {
                var temp = from c in context.WeatherInfo
                           where c.Outfit.ToLower().Equals(pattern)
                           select c;

                if (temp.Count() == 0)
                {
                    temp = from c in context.WeatherInfo
                           where c.Outfit.ToLower().Contains(pattern)
                           select c;

                    if (temp.Count() == 0) return null;
                    else return temp.First();
                }
                return temp.First();
            }
        }

        /// <summary>
        /// Search weather table with the given temperature value. 
        /// </summary>
        /// <param name="questionValue"> Value of the temperature field. </param>
        /// <returns> A row that has the temperature value in temperature column. </returns>
        private WeatherInfo SearchByTemperature(int questionValue)
        {
            using (Context context = new Context())
            {
                var temp = from c in context.WeatherInfo
                           where c.Temperature.Equals(questionValue)
                           select c;

                if (temp.Count() == 0) return null;
                return temp.First();
            }
        }
    }
}
