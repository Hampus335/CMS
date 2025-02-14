using Business.Models;
using Business.Services;
using Data.Entities;

namespace Business.Factories
{
    public class CustomerFactory
    {
        public CustomerEntity? Create(CustomerRegistrationForm form) => form == null ? default : new()
        {
            CustomerName = form.CustomerName
        };

        public Customer? Create(CustomerEntity entity) => entity == null ? default : new()
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName
        };
    }
}
