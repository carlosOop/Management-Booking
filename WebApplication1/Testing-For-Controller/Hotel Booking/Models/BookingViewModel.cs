using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Add this for [Key] and [DatabaseGenerated]

namespace Hotel_Booking.Models // Make sure this matches your project's root namespace + .Models
{
    public class BookingViewModel : IValidatableObject
    {
        // Primary Key for the database table
        [Key] // Explicitly marks Id as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures the database generates a unique ID automatically
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [Display(Name = "Mobile Number*")]
        [Phone(ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        [Display(Name = "Nationality*")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [Display(Name = "Gender*")]
        public string Gender { get; set; } // Consider using an enum or a dropdown with predefined options

        [Required(ErrorMessage = "ID Proof is required.")]
        [Display(Name = "ID Proof*")]
        public string IDProof { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address*")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bed type is required.")]
        [Display(Name = "Bed*")]
        public string Bed { get; set; }

        [Required(ErrorMessage = "Room Type is required.")]
        [Display(Name = "Room Type*")]
        public string RoomType { get; set; }

        [Required(ErrorMessage = "Room Number is required.")]
        [Display(Name = "Room Number*")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price*")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [Display(Name = "Date of Birth*")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; } // Nullable to handle empty date input properly

        [Required(ErrorMessage = "Check In date is required.")]
        [Display(Name = "Check In*")]
        [DataType(DataType.Date)]
        public DateTime? CheckIn { get; set; }

        [Required(ErrorMessage = "Check Out date is required.")]
        [Display(Name = "Check Out*")]
        [DataType(DataType.Date)]
        public DateTime? CheckOut { get; set; }

        // Custom validation to ensure CheckOut is after CheckIn
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckIn.HasValue && CheckOut.HasValue && CheckOut.Value <= CheckIn.Value)
            {
                yield return new ValidationResult(
                    "Check Out date must be after Check In date.",
                    new[] { nameof(CheckOut) });
            }
        }
    }
}