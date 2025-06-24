using Microsoft.EntityFrameworkCore;
using Hotel_Booking.Models; // Make sure this matches your project's root namespace + .Models

namespace Hotel_Booking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // This DbSet represents your "Bookings" table in the database
        public DbSet<BookingViewModel> Bookings { get; set; }

        // Optional: Configure table/column names, relationships etc.
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<BookingViewModel>().ToTable("CustomerBookings"); // Custom table name
        // }
    }
}