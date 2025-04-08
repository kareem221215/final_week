namespace final_project.Business.DTOs
{
    public class UpdateReservationRequest
    {
        public int? CustomerId { get; set; }
        public int? RestaurantId { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int? NumberOfGuests { get; set; }
    }
}
