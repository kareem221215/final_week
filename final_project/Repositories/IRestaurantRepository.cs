using final_project.Data.Entities;

namespace final_project.Data.Repositories
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {

        Task<Restaurant> DeleteAsync(Restaurant restaurant);
        Task<Restaurant> UpdateAsync(Restaurant restaurant); 
    }
}
