using Business.Services;

namespace Business.Interface
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CustomerRegistrationForm form);
    }
}