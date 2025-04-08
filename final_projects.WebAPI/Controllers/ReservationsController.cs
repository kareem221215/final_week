using Microsoft.AspNetCore.Mvc;
using final_project.Business.Services;
using final_project.Business.DTOs;
using final_project.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace final_project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllAsync();
            return Ok(reservations);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequest reservationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdReservation = await _reservationService.CreateAsync(reservationRequest);
            return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.Id }, createdReservation);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] UpdateReservationRequest reservationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedReservation = await _reservationService.UpdateAsync(id, reservationRequest);
            if (updatedReservation == null)
                return NotFound();

            return Ok(updatedReservation);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var deletedReservation = await _reservationService.DeleteAsync(id);
            if (deletedReservation == null)
                return NotFound();

            return NoContent();
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PatchReservation(int id, [FromBody] UpdateReservationRequest updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _reservationService.PatchAsync(id, updateDto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

    }
}
