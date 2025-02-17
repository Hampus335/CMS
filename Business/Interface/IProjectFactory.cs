using Business.Models;
using Data.Entities;

namespace Business.Interface
{
    public interface IProjectFactory
    {
        ProjectEntity? Create(ProjectRegistrationForm form);
        Project Create(ProjectEntity entity);
    }
}
