using d1.Extensions;
using d1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace d1.Controllers
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
            string pathToFile = @"J:\Repo\aoc_22_mvc\d1\Info\input.txt";
            var supply = FileReader.ReadFile(pathToFile);
            FoodManager foodManager = new FoodManager();
            var winner = foodManager.GetElfWithTheMostSupply(foodManager.DistributeFoodToElves(supply));

            return View(winner);
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