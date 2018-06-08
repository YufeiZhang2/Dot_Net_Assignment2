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
        public void AddWeatherInfo_DuplicatedDay_ThrowError()
        {
            WeatherInfo _weatherInfo = new WeatherInfo();
            _weatherInfo.Day = "Sunday";
            _weatherInfo.Weather = "Sunny";
            _weatherInfo.Outfit = "Shorts *";
            _weatherInfo.Temperature = 32;
            _weatherInfo.LastMaintainerId = "jenn_yl@yahoo.com";

            maintainer.AddWeatherInfo(_weatherInfo);

            Assert.That(() => maintainer.AddWeatherInfo(_weatherInfo),
                Throws.Exception);
        }
    }
}