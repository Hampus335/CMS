using Business.Factories;
using Business.Interface;
using Business.Models;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository, ICustomerFactory customerFactory, DataContext context) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly ICustomerFactory _customerFactory = customerFactory;
    private readonly DataContext _context = context;

    public async Task<IEnumerable<Customer?>> GetCustomersAsync()
    {
        var entities = await _customerRepository.GetAllAsync();

        var customers = entities.Select(_customerFactory.Create);

        return customers;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        _context.Customers.Update(customerEntity);
        _context.SaveChanges();

        return customerEntity;
    }

    public async Task<bool> CreateCustomerAsync(CustomerDTO customerDTO)
    {
        var projectEntity = _customerFactory.Create(customerDTO);
        if (projectEntity == null)
            return false;

        bool result = await _customerRepository.AddAsync(projectEntity);
        return result;
    }
}