using System;
using System.Threading.Tasks;
using Assignment2.Bussiness;
using Assignment2.Database;
using NUnit.Framework;

namespace Assignment2.UnitTests
{
    [TestFixture]
    class MaintainerTest
    {
        Maintainer maintainer;

        /// <summary>
        /// Instantiate DataMaintainer class.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            maintainer = new Maintainer();
        }

        /// <summary>
        /// Try to add duplicate day and it should throw error.
        /// </summary>
        
        [Test]
        [TestCase(20, "Wsdas", "Rainy", "Sando", 34, "jenn_yl@yahoo.com")]
        public void AddWeatherInfo_InvalidEntry_ThrowError(int id, string day, string weather, string outfit, int temperature, string lastmaintainerId)
        {
            WeatherInfo _weatherInfo = new WeatherInfo();
            _weatherInfo.Id = id;
            _weatherInfo.Day = day;
            _weatherInfo.Weather = weather;
            _weatherInfo.Outfit = outfit;
            _weatherInfo.Temperature = temperature;
            _weatherInfo.LastMaintainerId = lastmaintainerId;

            maintainer.AddWeatherInfo(_weatherInfo);

            Assert.That(() => maintainer.AddWeatherInfo(_weatherInfo), Throws.Exception);
        }

        [Test]
        [TestCase(20, "Sunday", "Sunny", "Sando", 34, "jenn_yl@yahoo.com")]
        public void Update_UnchangedWeatherInfo_NoError(int id, string day, string weather, string outfit, int temperature, string lastmaintainerId)
        {
            WeatherInfo _weatherinfo = new WeatherInfo();
            _weatherinfo.Id = id;
            _weatherinfo.Day = day;
            _weatherinfo.Weather = weather;
            _weatherinfo.Outfit = outfit;
            _weatherinfo.Temperature = temperature;
            _weatherinfo.LastMaintainerId = lastmaintainerId;

            Assert.That(() => maintainer.Update(_weatherinfo), Throws.Nothing);
        }
    }
}