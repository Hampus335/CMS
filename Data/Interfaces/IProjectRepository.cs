using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IProjectRepository
    {
        // CREATE
        Task<bool> AddAsync(ProjectUpdateform entity);

        // READ
        Task<IEnumerable<ProjectUpdateform>> GetAllAsync();
        Task<ProjectUpdateform?> GetAsync(Expression<Func<ProjectUpdateform, bool>> expression);

        // UPDATE
        Task<bool> UpdateAsync(ProjectUpdateform entity);

        // DELETE
        Task<bool> DeleteAsync(Expression<Func<ProjectUpdateform, bool>> expression);
        Task<bool> ExistsAsync(Expression<Func<ProjectUpdateform, bool>> expression);
    }
}
