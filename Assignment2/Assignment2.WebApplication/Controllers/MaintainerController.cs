using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.WebApplication.Models;
using Assignment2.WebApplication.ViewModels;
using Microsoft.Ajax.Utilities;

namespace Assignment2.WebApplication.Controllers
{
    public class MaintainerController : Controller
    {

        private ApplicationDbContext _context;

        public MaintainerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult AddWeatherinfo()
        {

            

            return View();
        }
        
        // GET: Maintainer
        public ActionResult Index()
        {
            var weatherInfo = new List<WeatherInfo>
            {
                new WeatherInfo { Day = "Sunday", Weather = "Sunny", Outfit = "Sando", Temperature = 34},
                new WeatherInfo { Day = "Monday", Weather = "Rainy", Outfit = "Jacket", Temperature = 15},
                new WeatherInfo { Day = "Tuesday", Weather = "Windy", Outfit = "Coat", Temperature = 25}
            };

            var viewModel = new MaintainerViewModel
            {
                Weatherinfos = weatherInfo
            };
            
            return View(viewModel);

        }


        
    }
}