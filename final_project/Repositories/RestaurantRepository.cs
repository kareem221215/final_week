using final_project.Data.Data;
using final_project.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(AppDbContext context) : base(context) { }

        public async Task<Restaurant> DeleteAsync(Restaurant restaurant)
        {
            restaurant.IsDeleted = true;
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task<Restaurant> UpdateAsync(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }
    }
}
