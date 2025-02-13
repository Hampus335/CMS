using Business.Models.Customer;
using Business.Services;
using Data.Entities;

namespace Business.Factories
{
    public static class CustomerFactory
    {
        public static CustomerEntity? Create(CustomerRegistrationForm form) => form == null ? default : new()
        {
            CustomerName = form.CustomerName
        };

        public static Customer? Create(CustomerEntity entity) => entity == null ? default : new()
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName
        };
    }
}
