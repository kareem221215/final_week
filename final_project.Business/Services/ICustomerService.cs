using final_project.Business.DTOs;
using final_project.Data.Entities;
using System.Threading.Tasks;

namespace final_project.Business.Services
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CreateAsync(CreateCustomerRequest customerRequest);
        Task<CustomerDTO> UpdateAsync(int id, CreateCustomerRequest customerRequest);
        Task<Customer> DeleteAsync(int id);
        Task<CustomerDTO> GetByIdAsync(int id);
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<CustomerDTO> PatchAsync(int id, UpdateCustomerRequest updateDto);

    }
}
