using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterviewTests.Models;
using InterviewTests.Domain;
using InterviewTests.Interfaces;

namespace InterviewTests.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestionSerializer<IQuestion> _questionSerializer;

        public HomeController(IQuestionSerializer<IQuestion> questionSerializer)
        {
            _questionSerializer = questionSerializer;
        }

        public IActionResult Index()
        {
            ViewData["AjaxHiddenPath"] = Url.Action(nameof(HomeController.AddQuestion), "Home");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<JsonResult> AddQuestion(string question, string answer)
        {
            bool result = QuestionsList<Question>.GetInstance(_questionSerializer).AddQuestion(new Question { Quest = question, Answer = answer }, _questionSerializer);

            return Json(result);
        }
    }
}
