using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
    {
        private readonly DataContext _context = context;

        //CREATE
        public async Task<int> AddAsync(CustomerEntity entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);

                await _context.AddAsync(entity);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default;
            }
        }


        //READ

        public async Task<bool> ExistsAsync(Expression<Func<CustomerEntity, bool>> expression)
        {
            return await _context.Customers.AnyAsync(expression);
        }


        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            var enteties = await _context.Customers.ToListAsync();
            return enteties;
        }

        public async Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(expression);
            return entity;
        }

        //UPDATE
        public async Task<int> UpdateAsync(CustomerEntity entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);

                _context.Update(entity);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default;
            }
        }

        //DELETE
        public async Task<bool> DeleteAsync(Expression<Func<CustomerEntity, bool>> expression)
        {
            if (expression == null)
                return false;

            try
            {
                var existingEntity = await GetAsync(expression);
                if (existingEntity == null)
                {
                    return false;
                }

                _context.Customers.Remove(existingEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting customer entity, {ex.Message}");
                return false;
            }
        }
    }
}
