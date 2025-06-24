using System.Diagnostics;
using Microsoft.AspNetCore.Mvc; // Crucial: This using directive is vital
using Hotel_Booking.Models; // Make sure this namespace matches your project's root namespace + .Models

namespace Hotel_Booking.Controllers
{
    public class HomeController : Controller // Crucial: This inheritance is vital
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor for dependency injection
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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