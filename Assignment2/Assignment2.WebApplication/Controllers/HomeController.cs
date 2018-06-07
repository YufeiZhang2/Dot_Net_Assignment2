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

    //Redirecting to the error page when an exceprtion occurs.
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    // Allow everyone (including users who aren't logged in)
    [AllowAnonymous]
    public class HomeController : Controller
    {
        QuestionManager manager = new QuestionManager();

        // Control the view of main page after loading
        public ActionResult Index()
        {
            NewModel model = new NewModel();

            // Reset the chat box history to be empty
            manager.CleanHistory();
            model.history = manager.GetQuestionHistory();

            return View(model);

        }

        // Control the view of the page after submitting the question
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
    }
}