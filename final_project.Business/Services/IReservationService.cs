using final_project.Business.DTOs;
using final_project.Data.Entities;
using System.Threading.Tasks;

namespace final_project.Business.Services
{
    public interface IReservationService
    {
        Task<ReservationDTO> CreateAsync(CreateReservationRequest reservationRequest);
        Task<ReservationDTO> UpdateAsync(int id, UpdateReservationRequest reservationRequest);
        Task<Reservation> DeleteAsync(int id);
        Task<IEnumerable<ReservationDTO>> GetAllAsync();
        Task<ReservationDTO> GetByIdAsync(int id);
        Task<ReservationDTO> PatchAsync(int id, UpdateReservationRequest updateDto);

    }
}
