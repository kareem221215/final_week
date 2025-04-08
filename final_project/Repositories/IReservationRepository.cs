using final_project.Data.Entities;

namespace final_project.Data.Repositories
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        // Reservation-specific queries can go here later
        Task<Reservation> DeleteAsync(Reservation reservation);
        Task<Reservation> UpdateAsync(Reservation reservation);
    }
}
