using Business.Models.Customer;
using Business.Models.Response;
using Business.Services;

namespace Business.Interface
{
    public interface ICustomerService
    {
        Task<ResponseResult> CreateCustomerAsync(CustomerRegistrationForm form);

        Task<ResponseResult<IEnumerable<Customer>>> GetCustomerAsync();

        Task<ResponseResult<Customer?>> GetCustomerAsync(int id);

        Task<ResponseResult<Customer?>> GetCustomerAsync(string customerName);
    }
}