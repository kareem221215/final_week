using final_project.Shared;

namespace RestaurantReservationSystem.Settings
{
    public class Setting : BaseEntity
    {
        public bool MaintenanceMode { get; set; }
        public int Id { get; internal set; }
    }
}
