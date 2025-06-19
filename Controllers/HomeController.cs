using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSurvey.Data;
using WebSurvey.Interfaces;
using WebSurvey.Models;

namespace WebSurvey.Controllers
{
    public class HomeController : Controller
    {
        private ISurveyService _surveyService;
        public HomeController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public IActionResult Index()
        {
            ViewData["OnGetError"] = "";
            ViewData["OnSaveError"] = "";

            try
            {
                var model = _surveyService.LoadSurveyViewModel();
                return View(model);
            }
            catch (Exception ex)
            {
                var viewModel = new SurveyViewModel();
                ViewData["OnGetError"] = ex.Message.ToString();
                return View(viewModel);
            }
        }

        public IActionResult SaveSurvey(SurveyViewModel model) 
        {
            ViewData["OnGetError"] = "";
            ViewData["OnSaveError"] = "";

            if (ModelState.IsValid)
            {
                try
                {
                    _surveyService.SaveSurveyResponse(model);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewData["OnSaveError"] = "Something went wrong please try again later.";
                    throw;
                }
            }

            var viewModel = _surveyService.LoadSurveyViewModel();

            return View("Index",viewModel);
        }
        

        public IActionResult Privacy()
        {
            ViewData["Error"] = "";

            try
            {
                var statistics = _surveyService.Statistics();
                return View(statistics);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message.ToString();
                var statistics = new Statistics();
                return View(statistics);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Test()
        {
            return View();
        }
    }
}
