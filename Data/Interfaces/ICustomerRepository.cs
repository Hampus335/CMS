using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> AddAsync(CustomerEntity entity);
        Task<bool> ExistsAsync(Expression<Func<CustomerEntity, bool>> value);
        Task<IEnumerable<CustomerEntity>> GetAllAsync();
        Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression);
        Task<int> UpdateAsync(CustomerEntity entity);
    }
}