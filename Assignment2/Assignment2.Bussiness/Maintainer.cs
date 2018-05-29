using System;
using System.Collections.Generic;
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
        public static List<WeatherInfo> GetWeatherInfos()
        {
            using (Context context = new Context())
            {
                return context.WeatherInfo.ToList();
            }

        }

        public IEnumerable<WeatherInfo> GetWeatherInfo
        {
            get
            {
                using (Context context = new Context())
                {
                    // Materialize to a list because the context is closed
                    return context.WeatherInfo.ToList();
                }
            }
        }

        public static void AddWatherInfo(WeatherInfo weatherInfo)
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
        public void DeleteWeatherInfo(WeatherInfo weatherInfo)
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
                var stored = context.WeatherInfo.Find(weatherInfo.Day);
                context.Entry(stored).CurrentValues.SetValues(weatherInfo);
                context.SaveChanges();
            }
        }
    }
}