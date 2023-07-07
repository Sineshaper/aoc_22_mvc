using d1.Extensions;
using d1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace d1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FoodManager _foodManager = new FoodManager();

        public List<string> _totalSupply = FileReader.ReadFile(Resource.pathToFile.ToString());
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_foodManager.GetElfWithTheMostSupply(_foodManager.DistributeFoodToElves(_totalSupply)));
        }
        public IActionResult AllElves()
        {
            List<Elf> elves = _foodManager.DistributeFoodToElves(_totalSupply);
            return View(elves);
        }
        public IActionResult GetTopThreeElvesWithTheHighestCalories()
        {
            List<Elf> theThreeOnes = _foodManager.GetTopThreeElvesWithTheHighestCalories(_foodManager.DistributeFoodToElves(_totalSupply));
            return View(theThreeOnes);
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