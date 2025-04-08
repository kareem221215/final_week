using final_project.Data.Entities;

namespace final_project.Data.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> DeleteAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
    }
}
