namespace final_project.Data.Entities
{
    public class RestaurantFeature
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
