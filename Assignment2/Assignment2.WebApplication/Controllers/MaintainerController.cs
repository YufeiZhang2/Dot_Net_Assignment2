using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Assignment2.Bussiness;
using Assignment2.Database;
using Assignment2.WebApplication.Models;

namespace Assignment2.WebApplication.Controllers
{
    public class MaintainerData
    {
        public static List<WeatherInfo> WeatherInfos;

    }

    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    [Authorize(Roles = RoleName.Maintainer)]
    public class MaintainerController : Controller
    {
        private Maintainer maintainer = new Maintainer();

        // GET: Maitainer
        public ActionResult Index()
        {
            // Set the LastMaintainerID as the current logged-in user

            return View(Maintainer.GetWeatherInfos(User.Identity.Name).ToList());

        }

        public ActionResult AddWeatherInfo()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWeatherInfo(WeatherInfo weatherInfo, string day)
        {
            {
                if (ModelState.IsValid)
                {
                    var _weatherInfo = maintainer.SearchByDay((string)day);
                    if (_weatherInfo != null)
                    {
                        throw new Exception("The day already exist, please choose another day!");
                    }
                    else
                    {
                        weatherInfo.LastMaintainerId = User.Identity.Name;
                        Maintainer.AddWeatherInfo(weatherInfo);
                    }

                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult EditWeatherInfo(string day)
        {
            if (day == null)
            {
                throw new Exception ("Please choose the day you want to edit!");
            }
            var weatherInfo = maintainer.SearchByDay((string)day);
            if (weatherInfo == null)
            {
                throw new Exception("The day you want to edit does not exist!");
            }
            return View(weatherInfo);
        }

      
        [HttpPost]
        public ActionResult EditWeatherInfo(WeatherInfo weatherInfo)
        {
            weatherInfo.LastMaintainerId = User.Identity.Name;
            maintainer.Update(weatherInfo);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteWeatherInfo(string day)
        {
            if (day == null)
            {
                throw new Exception("Please choose the day you want to delete!");
            }
            var _weatherinfo = maintainer.SearchByDay((string)day);
            if (_weatherinfo == null)
            {
                throw new Exception("The day you want to delete does not exist!");
            }
            return View(_weatherinfo);
        }

        // POST: PersonalContacts/Delete/5
        // Delete a weatherinfo
        [HttpPost, ActionName("DeleteWeatherInfo")]
        public ActionResult DeleteConfirmed(string day)
        {
            var _weatherInfo = maintainer.SearchByDay((string)day);
            if (_weatherInfo == null)
            {
                throw new Exception("The day you want to edit does not exist!");
            }
            maintainer.Delete(_weatherInfo);
            return RedirectToAction("Index");
        }
    }

}





