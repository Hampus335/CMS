using Business.Models;
using Business.Services;

namespace Business.Interface
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CustomerDTO form);

        Task<IEnumerable<Customer>> GetCustomerAsync();

        Task<Customer> GetCustomerAsync(int id);

        Task<Customer?> GetCustomerAsync(string customerName);
    }
}