using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.WebApplication.Controllers
{
    public class ApproverController : Controller
    {
        // GET: Approver
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApproverReportForRule()
        {
            return View();
        }

        public ActionResult ApproverReportForEditor()
        {
            return View();
        }

    }
}