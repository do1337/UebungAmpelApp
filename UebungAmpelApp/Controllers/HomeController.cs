using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UebungAmpelApp.Models;

namespace UebungAmpelApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ampel()
        {
            return View();
        }

        [HttpGet]
        public JsonResult SwitchAmpel(string currentLight)
        {
            bool error = false;
            string nextLight = string.Empty;

            switch (currentLight)
            {
                case "red":
                    nextLight = "red-yellow";
                    break;

                case "red-yellow":
                    nextLight = "green";
                    break;

                case "green":
                    nextLight = "yellow";
                    break;

                case "yellow":
                    nextLight = "red";
                    break;

                default:
                    error = true;
                    break;
            }

            JsonResult js = Json(data: new
            {
                success = error,
                nextLight
            });
            js.ContentType = "application/json; charset=UTF-8";

            // return JSON String
            return js;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
