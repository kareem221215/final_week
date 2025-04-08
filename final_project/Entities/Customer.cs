
using final_project.Shared;

namespace final_project.Data.Entities
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
