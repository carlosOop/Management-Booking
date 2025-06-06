using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult History()
        {
            return View("~/Views/History/History.cshtml");
        }

        public IActionResult Manageroom()
        {
            return View("~/Views/ManageRoom/Manageroom.cshtml");
        }

        public IActionResult CustomerRegistration()
        {
            return View("~/Views/CustomerRegistration/Registration.cshtml");
        }

        public IActionResult Checkout()
        {
            return View("~/Views/Checkout/Checkout.cshtml");
        }
    }
}
