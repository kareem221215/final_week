using final_project.Data.Entities;
using final_project.Shared;

public class Restaurant : BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public int Rating { get; set; }

    public virtual ICollection<Reservation>? Reservations { get; set; }

    public virtual ICollection<RestaurantFeature> RestaurantFeatures { get; set; } = new List<RestaurantFeature>();
}
