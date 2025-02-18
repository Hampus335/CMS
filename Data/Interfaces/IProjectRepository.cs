using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IProjectRepository
    {
        // CREATE
        Task<bool> AddAsync(ProjectEntity entity);

        // READ
        Task<IEnumerable<ProjectEntity>> GetAllAsync();
        Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression);

        // UPDATE
        Task<bool> UpdateAsync(ProjectEntity entity);

        // DELETE
        Task<bool> DeleteAsync(Expression<Func<ProjectEntity, bool>> expression);
        Task<bool> ExistsAsync(Expression<Func<ProjectEntity, bool>> expression);
    }
}
