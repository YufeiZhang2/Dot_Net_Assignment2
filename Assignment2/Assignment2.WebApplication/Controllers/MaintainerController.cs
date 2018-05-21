using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.WebApplication.Models;

namespace Assignment2.WebApplication.Controllers
{
    public class MaintainerController : Controller
    {
        // GET: Maintainer
        public ActionResult Index()
        {
            var maintainer = new MaintainerModels() {Day = "Sunday"};

            var viewResult = new ViewResult();
            viewResult.ViewData.Model

          return View(maintainer); 
        ;
        }

        public ActionResult Edit(string day)
        {
            
        }
        
    }
}