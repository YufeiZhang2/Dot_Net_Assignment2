using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Database;

namespace Assignment2.Bussiness
{
    /// <summary>
    /// The function group used to manage the weather data.
    /// </summary>

    public class Maintainer
    {
        /// <summary>
        /// Get all weather data from WeatherInfo table
        /// </summary>
        /// <returns>weather data</returns>
        public static List<WeatherInfo> GetWeatherInfos(string username)
        {
            using (Context context = new Context())
            {
                
                return context.WeatherInfo.ToList();
            }

        }

        public static void AddWeatherInfo(WeatherInfo weatherInfo)
        {
            using (Context context = new Context())
            {

                context.WeatherInfo.Add(weatherInfo);
                context.SaveChanges();

            }
        }

        /// <summary>
        /// Remove a data in Weatherinfo
        /// </summary>
        /// <param name="weatherInfo">The contact to remove</param>
        public void Delete(WeatherInfo weatherInfo)
        {
            using (var context = new Context())
            {
                var saved = context.WeatherInfo.Find(weatherInfo.Day);
                context.WeatherInfo.Remove(saved);
                context.SaveChanges();

            }
        }


        /// <summary>
        /// Updates weatherinfo
        /// </summary>
        /// <param name="weatherInfo">The contact to be updated (matching is performed based on the Id)</param>
        public void Update(WeatherInfo weatherInfo)
        {
            using (var context = new Context())
            {
                var updated = context.WeatherInfo.Find(weatherInfo.Day);
                if (updated != null)
                {

                    context.Entry(updated).CurrentValues.SetValues(weatherInfo);
                    context.SaveChanges();
                }
               
            }
        }

        public WeatherInfo SearchById(int id)
        {
            using (var context = new Context())
            {
                return (from w in context.WeatherInfo
                    where w.Id == id
                    select w).FirstOrDefault();

            }
        }

        public WeatherInfo SearchByDay(string day)
            {
                using (var context = new Context())
                {
                    return (from w in context.WeatherInfo
                        where w.Day == day
                        select w).FirstOrDefault();

                }

            }
    }
}
    
