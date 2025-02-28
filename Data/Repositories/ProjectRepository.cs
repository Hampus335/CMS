using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class ProjectReposetory(DataContext context) :   BaseRepository<ProjectUpdateform>(context), IProjectRepository
    {
        private readonly DataContext _context = context;

        //CREATE
        public async Task<bool> AddAsync(ProjectUpdateform entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);

                await _context.AddAsync(entity);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.InnerException);
                return default;
            }
            return false;
        }
        //READ
        public async Task<IEnumerable<ProjectUpdateform>> GetAllAsync()
        {
            var entities = await _context.Projects.ToListAsync();
            return entities;
        }

        public async Task<ProjectUpdateform?> GetAsync(Expression<Func<ProjectUpdateform, bool>> expression)
        {
            var entity = await _context.Projects.FirstOrDefaultAsync(expression);
            return entity;
        }

        //UPDATE
        public async Task<bool> UpdateAsync(ProjectUpdateform entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);

                _context.Update(entity);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default;
            }   
            return false;
        }

        //DELETE

        public async Task<bool> DeleteAsync(Expression<Func<ProjectUpdateform, bool>> expression)
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

                _context.Projects.Remove(existingEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting project entity, {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ExistsAsync(Expression<Func<ProjectUpdateform, bool>> expression)
        {
            return await _context.Projects.AnyAsync(expression);
        }
    }
}
