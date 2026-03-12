using Docker.DTOs;
using Docker.Entities;
using Docker.Interfaces;

namespace Docker.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
    {
        var customers = await _repository.GetAllAsync();
        return customers.Select(MapToResponse);
    }

    public async Task<CustomerResponse?> GetByIdAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id);
        return customer is null ? null : MapToResponse(customer);
    }

    public async Task<CustomerResponse> CreateAsync(CreateCustomerRequest request)
    {
        var customer = new Customer(request.Name, request.Email, request.Phone);
        var created = await _repository.AddAsync(customer);
        return MapToResponse(created);
    }

    public async Task<CustomerResponse?> UpdateAsync(Guid id, UpdateCustomerRequest request)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer is null)
            return null;

        customer.Update(request.Name, request.Email, request.Phone);
        var updated = await _repository.UpdateAsync(customer);
        return MapToResponse(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer is null)
            return false;

        await _repository.DeleteAsync(customer);
        return true;
    }

    private static CustomerResponse MapToResponse(Customer customer) => new(
        customer.Id,
        customer.Name,
        customer.Email,
        customer.Phone,
        customer.CreatedAt
    );
}