using final_project.Data.Entities;

public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<RestaurantFeature> RestaurantFeatures { get; set; } = new List<RestaurantFeature>();
}

