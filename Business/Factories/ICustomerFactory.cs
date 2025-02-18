using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public interface ICustomerFactory
    {
        CustomerEntity? Create(CustomerDTO form);
        Customer? Create(CustomerEntity entity);

    }
}