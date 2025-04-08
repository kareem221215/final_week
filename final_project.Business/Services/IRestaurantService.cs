using final_project.Business.DTOs;
using final_project.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace final_project.Business.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDTO>> GetAllAsync();
        Task<RestaurantDTO> GetByIdAsync(int id);
        Task<RestaurantDTO> CreateAsync(RestaurantDTO restaurantDto);
        Task<RestaurantDTO> UpdateAsync(int id, RestaurantDTO restaurantDto);
        Task<Restaurant> DeleteAsync(int id);
        Task<RestaurantDTO> PatchAsync(int id, UpdateRestaurantRequest updateDto);

    }
}
