using final_project.Data;
using final_project.Data.Data;
using final_project.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

        public async Task<Customer> DeleteAsync(Customer customer)
        {
            customer.IsDeleted = true;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
