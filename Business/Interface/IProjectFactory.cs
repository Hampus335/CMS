using Business.Factories;
using Business.Models;
using Data.Entities;

namespace Business.Interface
{
    public interface IProjectFactory
    {
        ProjectEntity? Create(ProjectRegistrationForm form);
        ProjectEntity Create(ProjectUpdateForm form);
        Project Create(ProjectEntity entity);
    }
}
