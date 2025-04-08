using final_project.Data.Data;
using final_project.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context) { }

        public async Task<Reservation> DeleteAsync(Reservation reservation)
        {
            reservation.IsDeleted = true;
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<Reservation> UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
    }
}
