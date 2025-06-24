using Microsoft.AspNetCore.Mvc;
using Hotel_Booking.Models;
using Hotel_Booking.Data;
using Microsoft.EntityFrameworkCore; // This one is key for ToListAsync()
using System;
using System.Collections.Generic;
using System.Linq; // Important for LINQ methods like OrderByDescending and ToList
using System.Threading.Tasks;

namespace Hotel_Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context; // Declare DbContext

        // Inject the DbContext into the controller's constructor
        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action to display the customer booking form (HTTP GET)
        [HttpGet]
        public IActionResult CustomerBooking()
        {
            var model = new BookingViewModel
            {
                Gender = "M",
                Bed = "Single",
                RoomType = "Suite",
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today.AddDays(1)
            };
            return View(model);
        }

        // Action to handle customer booking form submission (HTTP POST)
        [HttpPost]
        [ValidateAntiForgeryToken] // For security: prevents Cross-Site Request Forgery attacks
        public async Task<IActionResult> CustomerBooking(BookingViewModel model) // Make it async
        {
            // Custom validation from IValidatableObject will be checked by ModelState.IsValid
            if (!ModelState.IsValid)
            {
                return View(model); // If validation fails, return the same view with errors
            }

            // Add the new booking to the DbContext and save to the database
            _context.Bookings.Add(model);
            await _context.SaveChangesAsync(); // Saves changes to app.db

            TempData["BookingSuccessMessage"] = $"Booking for {model.Name} confirmed! Booking ID: {model.Id}";
            return RedirectToAction("BookingConfirmation"); // Redirect to a confirmation page
        }

        // Action to display booking confirmation
        public IActionResult BookingConfirmation()
        {
            ViewBag.Message = TempData["BookingSuccessMessage"] as string ?? "Your booking has been successfully submitted.";
            return View();
        }

        // Action to display all bookings from the database
        [HttpGet]
        public async Task<IActionResult> AllBookings()
        {
            // Retrieve all bookings from the database and order them by CheckIn date
            var allBookings = await _context.Bookings.OrderByDescending(b => b.CheckIn).ToListAsync();
            return View(allBookings); // Pass the list of bookings to the view
        }
    }
}