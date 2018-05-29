using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Bussiness;
using Assignment2.Database;
using Assignment2.WebApplication.Models;

namespace Assignment2.WebApplication.Controllers
{
    public class MaintainerData
    {
        public List<WeatherInfo> AllWeatherInfos;


    }

    public class MaintainerController : Controller
    {
        private Maintainer maintainer = new Maintainer();

        // GET: Maitainer
        /*    public ActionResult Index()
            {
                List<WeatherInfo> AllWeatherInfos = Maintainer.GetWeatherInfos().ToList();

                    return View();
                }
    */

        public ActionResult Index()
        {
            return View(
                new MaintainerViewModel
                {
                    WeatherInfos = Maintainer.GetWeatherInfos().ToList()
                }
            );
        }
        // GET: Maitainer/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MaintainerViewModel model)
        {

            Maintainer.AddWatherInfo
            (new WeatherInfo
                {
                    Day = model.Day,
                    Weather = model.Weather,
                    Outfit = model.Outfit,
                    Temperature = model.Temperature
                }
            );
            return RedirectToAction("Index");
        }
    }



}