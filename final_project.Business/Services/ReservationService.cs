using final_project.Business.DTOs;
using final_project.Data.Entities;
using final_project.Data.Repositories;


namespace final_project.Business.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ReservationDTO> CreateAsync(CreateReservationRequest reservationRequest)
        {
            var reservation = new Reservation
            {
                CustomerId = reservationRequest.CustomerId,
                RestaurantId = reservationRequest.RestaurantId,
                ReservationDate = reservationRequest.ReservationDate,
                NumberOfGuests = reservationRequest.NumberOfGuests
            };

            await _reservationRepository.AddAsync(reservation);

            return new ReservationDTO
            {
                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                RestaurantId = reservation.RestaurantId,
                ReservationDate = reservation.ReservationDate,
                NumberOfGuests = reservation.NumberOfGuests
            };
        }

        public async Task<ReservationDTO> UpdateAsync(int id, UpdateReservationRequest reservationRequest)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                return null;

            if (reservationRequest.CustomerId.HasValue)
                reservation.CustomerId = reservationRequest.CustomerId.Value;

            if (reservationRequest.RestaurantId.HasValue)
                reservation.RestaurantId = reservationRequest.RestaurantId.Value;

            if (reservationRequest.ReservationDate.HasValue)
                reservation.ReservationDate = reservationRequest.ReservationDate.Value;

            if (reservationRequest.NumberOfGuests.HasValue)
                reservation.NumberOfGuests = reservationRequest.NumberOfGuests.Value;

            await _reservationRepository.UpdateAsync(reservation);

            return new ReservationDTO
            {
                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                RestaurantId = reservation.RestaurantId,
                ReservationDate = reservation.ReservationDate,
                NumberOfGuests = reservation.NumberOfGuests
            };
        }


        public async Task<Reservation> DeleteAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                return null;

            await _reservationRepository.DeleteAsync(reservation);

            return reservation;
        }

        // New methods added for GetAllAsync and GetByIdAsync

        public async Task<IEnumerable<ReservationDTO>> GetAllAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            var reservationDtos = new List<ReservationDTO>();

            foreach (var reservation in reservations)
            {
                reservationDtos.Add(new ReservationDTO
                {
                    Id = reservation.Id,
                    CustomerId = reservation.CustomerId,
                    RestaurantId = reservation.RestaurantId,
                    ReservationDate = reservation.ReservationDate,
                    NumberOfGuests = reservation.NumberOfGuests
                });
            }

            return reservationDtos;
        }

        public async Task<ReservationDTO> GetByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                return null;

            return new ReservationDTO
            {
                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                RestaurantId = reservation.RestaurantId,
                ReservationDate = reservation.ReservationDate,
                NumberOfGuests = reservation.NumberOfGuests
            };
        }
        public async Task<ReservationDTO> PatchAsync(int id, UpdateReservationRequest updateDto)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                return null;

            if (updateDto.CustomerId.HasValue)
                reservation.CustomerId = updateDto.CustomerId.Value;

            if (updateDto.RestaurantId.HasValue)
                reservation.RestaurantId = updateDto.RestaurantId.Value;

            if (updateDto.ReservationDate.HasValue)
                reservation.ReservationDate = updateDto.ReservationDate.Value;

            if (updateDto.NumberOfGuests.HasValue)
                reservation.NumberOfGuests = updateDto.NumberOfGuests.Value;

            await _reservationRepository.UpdateAsync(reservation);

            return new ReservationDTO
            {
                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                RestaurantId = reservation.RestaurantId,
                ReservationDate = reservation.ReservationDate,
                NumberOfGuests = reservation.NumberOfGuests
            };
        }

    }
}
