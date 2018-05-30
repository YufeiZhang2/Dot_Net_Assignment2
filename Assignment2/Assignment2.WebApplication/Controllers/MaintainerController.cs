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
           
            return View(Maintainer.GetWeatherInfos(User.Identity.Name).ToList());
               
        }
        
           public ActionResult Save()
            {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( WeatherInfo weatherInfo)
        {
            if (ModelState.IsValid)
            {
                Maintainer.AddWeatherInfo(weatherInfo);
            }

            return RedirectToAction("Index");
        }
        public ActionResult EditWeatherInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var weatherInfo = maintainer.SearchById((int)id);
            if (weatherInfo == null)
            {
                return HttpNotFound();
            }
            return View(weatherInfo);
        }

        //Bind to make sure that only the properties Day,Weather&outfit will be edited
        [HttpPost]
        
        public ActionResult EditWeatherInfo( WeatherInfo weatherInfo)
        {
            maintainer.Update(weatherInfo);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteWeatherInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = maintainer.SearchById((int)id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: PersonalContacts/Delete/5
        // Delete a contact
        [HttpPost, ActionName("DeleteWeatherInfo")]
        public ActionResult DeleteConfirmed(int id)
        {
            var weatherInfo = maintainer.SearchById((int)id);
            if (weatherInfo == null)
            {
                return HttpNotFound();
            }
            maintainer.Delete(weatherInfo);
            return RedirectToAction("Index");
        }
    }

}





