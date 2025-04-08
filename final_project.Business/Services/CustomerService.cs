using final_project.Business.DTOs;
using final_project.Data.Entities;
using final_project.Data.Repositories;
using final_project.Business.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        var customerDtos = new List<CustomerDTO>();

        foreach (var customer in customers)
        {
            customerDtos.Add(new CustomerDTO
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                Phone = customer.Phone
            });
        }

        return customerDtos;
    }

    public async Task<CustomerDTO> GetByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
            return null;

        return new CustomerDTO
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Email = customer.Email,
            Phone = customer.Phone
        };
    }

    public async Task<CustomerDTO> CreateAsync(CreateCustomerRequest customerRequest)
    {
        var customer = new Customer
        {
            FullName = customerRequest.FullName,
            Email = customerRequest.Email,
            Phone = customerRequest.Phone

        };

        await _customerRepository.AddAsync(customer);

        return new CustomerDTO
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Email = customer.Email,
            Phone = customer.Phone
        };
    }

    public async Task<CustomerDTO> UpdateAsync(int id, CreateCustomerRequest customerRequest)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
            return null;

        customer.FullName = customerRequest.FullName;
        customer.Email = customerRequest.Email;

        await _customerRepository.UpdateAsync(customer);

        return new CustomerDTO
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Email = customer.Email

        };
    }

    public async Task<Customer> DeleteAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
            return null;

        await _customerRepository.DeleteAsync(customer);
        return customer;
    }
    public async Task<CustomerDTO> PatchAsync(int id, UpdateCustomerRequest updateDto)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
            return null;

        if (!string.IsNullOrEmpty(updateDto.FullName))
            customer.FullName = updateDto.FullName;

        if (!string.IsNullOrEmpty(updateDto.Email))
            customer.Email = updateDto.Email;

        if (!string.IsNullOrEmpty(updateDto.Phone))
            customer.Phone = updateDto.Phone;

        await _customerRepository.UpdateAsync(customer);

        return new CustomerDTO
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Email = customer.Email,
            Phone = customer.Phone
        };
    }

}
