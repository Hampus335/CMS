using Business.Models;
using Business.Services;

namespace Business.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<bool> CreateCustomerAsync(CustomerDTO form);
    }
}