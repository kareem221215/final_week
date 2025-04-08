using System;
using System.ComponentModel.DataAnnotations;

namespace final_project.Business.DTOs
{
    public class CreateReservationRequest
    {
        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Reservation date must be in the future.")]
        public DateTime ReservationDate { get; set; }

        [Range(1, 20, ErrorMessage = "Number of guests must be between 1 and 20.")]
        public int NumberOfGuests { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is DateTime date && date > DateTime.Now;
        }
    }
}
