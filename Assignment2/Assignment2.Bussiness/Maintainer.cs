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
        /// <summary>
        /// Add new weatherInfo
        /// </summary>
        /// <param name="weatherInfo">The new weatheinfo to be added</param>
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
        /// <param name="weatherInfo">The weatherInfo to remove</param>
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
        /// Update weatherinfo 
        /// </summary>
        /// <param name="weatherInfo"></param>
        public void Update(WeatherInfo weatherInfo)
        {
            using (var context = new Context())
            {
                var toUpdate = context.WeatherInfo.Find(weatherInfo.Day);
                if (toUpdate != null)
                {
                    context.Entry(toUpdate).CurrentValues.SetValues(weatherInfo);
                    context.SaveChanges();
                }
               
            }
        }

        /// <summary>
        /// Search WeatherInfo by given ID
        /// </summary>
        /// <param name="id">ID of weatherInfo</param>
        /// <returns>The data with given ID</returns>
        public WeatherInfo SearchById(int id)
        {
            using (var context = new Context())
            {
                return (from w in context.WeatherInfo
                    where w.Id == id
                    select w).FirstOrDefault();

            }
        }

        /// <summary>
        /// Search WeatherInfo by given ID
        /// </summary>
        /// <param name="day">DAY of the WeatherInfo</param>
        /// <returns>The data with given day</returns>
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
    
