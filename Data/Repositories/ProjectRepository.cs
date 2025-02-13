using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class ProjectReposetory(DataContext context) : IProjectRepository
    {
        private readonly DataContext _context = context;

        //CREATE
        public async Task<int> AddAsync(ProjectEntity entity)
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
        public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            var entities = await _context.Projects.ToListAsync();
            return entities;
        }

        public async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
        {
            var entity = await _context.Projects.FirstOrDefaultAsync(expression);
            return entity;
        }

        //UPDATE
        public async Task<int> UpdateAsync(ProjectEntity entity)
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
    }
}
