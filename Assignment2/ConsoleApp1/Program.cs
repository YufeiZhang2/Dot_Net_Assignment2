using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Assignment2.Database"));
            //AppDomain.CurrentDomain.SetData("DataDirectory", path);

            using (var db = new WeartherModel())
            {
                var query = from b in db.WeatherInfoes
                            orderby b.Day
                            select b;

                Console.WriteLine("All weather information: ");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Day + ": " + item.Weather);
                }

                Console.Read();
            }

        }
    }
}
