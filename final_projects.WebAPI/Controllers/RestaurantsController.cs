using Microsoft.AspNetCore.Mvc;
using final_project.Business.Services;
using final_project.Business.DTOs;
using final_project.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace final_project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await _restaurantService.GetAllAsync();
            return Ok(restaurants);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurant = await _restaurantService.GetByIdAsync(id);
            if (restaurant == null)
                return NotFound();
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantDTO restaurantDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdRestaurant = await _restaurantService.CreateAsync(restaurantDto);
            return CreatedAtAction(nameof(GetRestaurantById), new { id = createdRestaurant.Id }, createdRestaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] RestaurantDTO restaurantDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedRestaurant = await _restaurantService.UpdateAsync(id, restaurantDto);
            if (updatedRestaurant == null)
                return NotFound();

            return Ok(updatedRestaurant);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var deletedRestaurant = await _restaurantService.DeleteAsync(id);
            if (deletedRestaurant == null)
                return NotFound();

            return NoContent();
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PatchRestaurant(int id, [FromBody] UpdateRestaurantRequest updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _restaurantService.PatchAsync(id, updateDto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

    }
}
