using Business.Factories;
using Business.Models;
using Data.Entities;

namespace Business.Interface
{
    public interface IProjectFactory
    {
        ProjectUpdateform? Create(ProjectRegistrationForm form);
        Project? Create(ProjectUpdateform entity);
    }
}
