using Business.Factories;
using Business.Interface;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository, ICustomerFactory customerFactory) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly ICustomerFactory _customerFactory = customerFactory;
       
    public async Task<IEnumerable<Customer?>> GetCustomersAsync()
    {
        var entities = await _customerRepository.GetAllAsync();

        var customers = entities.Select(_customerFactory.Create);

        return customers;
    }

    /*public async Task<bool> CreateCustomerAsync(CustomerRegistration customer)
    {

    }*/
}