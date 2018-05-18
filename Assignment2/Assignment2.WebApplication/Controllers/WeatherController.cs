using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.WebApplication.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataMaintainer()
        {
            return View();
        }

        public ActionResult RuleEditor()
        {
            return View();
        }

        public ActionResult RuleApprover()
        {
            return View();
        }
    }
}