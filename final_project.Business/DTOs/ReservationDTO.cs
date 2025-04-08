namespace final_project.Business.DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }

    }
}
