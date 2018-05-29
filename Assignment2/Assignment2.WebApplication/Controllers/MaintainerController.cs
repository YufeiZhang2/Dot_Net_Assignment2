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

    public class MaintainerController : Controller
    {
        private Maintainer maintainer = new Maintainer();

        // GET: Maitainer
           public ActionResult Index()
            {
                // Set the LastMaintainerID as the current logged-in user
                
                return View(Maintainer.GetWeatherInfos().ToList());
               
        }
        
           public ActionResult Save()
            {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Day,Weather,Outfit,Temperature")] WeatherInfo weatherInfo)
        {
            Maintainer.AddWeatherInfo(weatherInfo);
            return RedirectToAction("Index");
        }
    }



}