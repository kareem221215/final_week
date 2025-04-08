using final_project.Business.DTOs;
using final_project.Data.Repositories;
using final_project.Shared;

namespace final_project.Business.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllAsync()
        {
            var restaurants = await _restaurantRepository.GetAllAsync();
            var restaurantDtos = new List<RestaurantDTO>();

            foreach (var restaurant in restaurants)
            {
                restaurantDtos.Add(new RestaurantDTO
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Location = restaurant.Location
                });
            }

            return restaurantDtos;
        }

        public async Task<RestaurantDTO> GetByIdAsync(int id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
                return null;

            return new RestaurantDTO
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location
            };
        }

        public async Task<RestaurantDTO> CreateAsync(RestaurantDTO restaurantDto)
        {
            var restaurant = new Restaurant
            {
                Name = restaurantDto.Name,
                Location = restaurantDto.Location
            };

            await _restaurantRepository.AddAsync(restaurant);

            return new RestaurantDTO
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location
            };
        }

        public async Task<RestaurantDTO> UpdateAsync(int id, RestaurantDTO restaurantDto)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
                return null;

            restaurant.Name = restaurantDto.Name;
            restaurant.Location = restaurantDto.Location;

            await _restaurantRepository.UpdateAsync(restaurant);

            return new RestaurantDTO
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location
            };
        }

        public async Task<Restaurant> DeleteAsync(int id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
                return null;

            await _restaurantRepository.DeleteAsync(restaurant);

            return restaurant;
        }
        public async Task<RestaurantDTO> PatchAsync(int id, UpdateRestaurantRequest updateDto)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
                return null;

            if (!string.IsNullOrEmpty(updateDto.Name))
                restaurant.Name = updateDto.Name;

            if (!string.IsNullOrEmpty(updateDto.Location))
                restaurant.Location = updateDto.Location;

            if (updateDto.Rating.HasValue)
                restaurant.Rating = updateDto.Rating.Value;

            await _restaurantRepository.UpdateAsync(restaurant);

            return new RestaurantDTO
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
                Rating = restaurant.Rating,
                
            };
        }

    }
}
