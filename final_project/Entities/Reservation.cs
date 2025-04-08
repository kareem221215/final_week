
using System;
using final_project.Shared;
namespace final_project.Data.Entities
{
    public class Reservation : BaseEntity
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; } //dd

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } //ddd
        public int NumberOfGuests { get; set; }
    }
}
