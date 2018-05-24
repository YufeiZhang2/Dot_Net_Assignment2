using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Database;
using Assignment2.WebApplication.Models;


namespace Assignment2.WebApplication.Controllers
{
    public class EditorController : Controller
    {
        private Bussiness.DataDrivenRuleEditor rules = new Bussiness.DataDrivenRuleEditor();

       // private ApplicationDbContext _context;

        //public EditorController()
        //{
        //    _context = new ApplicationDbContext();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}

        // GET: Editor
        public ActionResult Index()
        {
            return View(rules.AllDataDrivenRules.OfType<DataDrivenRules>().ToList());
        }

        public ActionResult AddDataDrivenRule()
        {
            return View();
        }

        public ActionResult AddFixedRule()
        {
            return View();
        }
    }
}