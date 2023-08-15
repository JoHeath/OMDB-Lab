using Microsoft.AspNetCore.Mvc;
using OMDB_Lab.Models;
using System.Diagnostics;

namespace OMDB_Lab.Controllers
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
        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSearchForm()
        {
            
            return View("MovieSearch");
        }

        [HttpPost]
        public IActionResult MovieSearchResults(string title)
        {
            SingleMovieModel result = SingleMovieDAL.GetMovie(title);

            return View("MovieSearch", result);
        }

        public IActionResult MovieNight()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieNightForm()
        {
            return View("MovieNight");
        }
        [HttpPost]
        public IActionResult MovieNightResults(string title1, string title2, string title3)
        {
            List<SingleMovieModel> result = new List<SingleMovieModel>();

            SingleMovieModel result1 = SingleMovieDAL.GetMovie(title1);
            result.Add(result1);
            SingleMovieModel result2 = SingleMovieDAL.GetMovie(title2);
            result.Add(result2);
            SingleMovieModel result3 = SingleMovieDAL.GetMovie(title3);
            result.Add(result3);



            return View("MovieNight", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}