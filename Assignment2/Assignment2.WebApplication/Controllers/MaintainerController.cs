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

    // Redirecting to the error page when an exception occurs.
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    // Authorizing the role of maintainer
    [Authorize(Roles = RoleName.Maintainer)]
    public class MaintainerController : Controller
    {
        private Maintainer maintainer = new Maintainer();

        // Control the view of maintainer main page
        // GET: Maintainer
        public ActionResult Index()
        {
            try
            {
                // Set the LastMaintainerID as the current logged-in user
                return View(Maintainer.GetWeatherInfos(User.Identity.Name).ToList());
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Maintainer", "Index"));
            }
        }

        // Control the view when adding new weatherInfo
        public ActionResult AddWeatherInfo()
        {
            return View();
        }

        // Control the view and action after submitting the new WeatherInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWeatherInfo(WeatherInfo weatherInfo, string day)
        {
            try{
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
                        maintainer.AddWeatherInfo(weatherInfo);
                    }

                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Maintainer", "AddWeatherInfo"));
            }
        }

        // Control the view when updating the WeatherInfo
        // throws exception if day is not found
        public ActionResult EditWeatherInfo(string day)
        {
            try
            {
                if (day == null)
                {
                    throw new Exception("Please choose the day you want to edit!");
                }
                var weatherInfo = maintainer.SearchByDay((string)day);
                if (weatherInfo == null)
                {
                    throw new Exception("The day you want to edit does not exist!");
                }
                return View(weatherInfo);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Maintainer", "EditWeatherInfo"));
            }
        }

        // Control the view and action after submitting the update of the weatherInfo
        [HttpPost]
        public ActionResult EditWeatherInfo(WeatherInfo weatherInfo)
        {
            try
            {
                weatherInfo.LastMaintainerId = User.Identity.Name;
                maintainer.Update(weatherInfo);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Maintainer", "EditWeatherInfo"));
            }
        }

        // Control the view when deleting weatherInfo with the given day
        public ActionResult DeleteWeatherInfo(string day)
        {
            try
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
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Maintainer", "DeleteWeatherInfo"));
            }
        }

        // Control the view and action after confirming the deletion of weatherInfo
        // throws exception when the day does not exist
        [HttpPost, ActionName("DeleteWeatherInfo")]
        public ActionResult DeleteConfirmed(string day)
        {
            try
            {
                var _weatherInfo = maintainer.SearchByDay((string)day);
                if (_weatherInfo == null)
                {
                    throw new Exception("The day you want to delete does not exist!");
                }
                maintainer.Delete(_weatherInfo);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Maintainer", "DeleteConfirmed"));
            }
        }
    }

}





