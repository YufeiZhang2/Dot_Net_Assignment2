using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Bussiness;
using Assignment2.Database.SmallDbForQuestionHistory;

namespace Assignment2.WebApplication.Controllers
{
    public class NewModel
    {
        public List<Table> history;
        public string NewQuestion { get; set; }
    }

    public class HomeController : Controller
    {
        QuestionManager manager = new QuestionManager();

        public ActionResult Index()
        {
            NewModel model = new NewModel();
            manager.CleanHistory();
            model.history = manager.GetQuestionHistory();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(NewModel model)
        {
            if (model.NewQuestion != null && model.NewQuestion != "")
            {
                manager.SaveAnswerToHistory(model.NewQuestion);
            }
            model.history = manager.GetQuestionHistory();

            return View(model);
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}