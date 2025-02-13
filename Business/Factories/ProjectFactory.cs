using Business.Models.Customer;
using Business.Models.Project;
using Business.Services;
using Data.Entities;

namespace Business.Factories
{
    public static class ProjectFactory
    {
        public static ProjectRegistrationForm Create(ProjectEntity entity) => new();

        public static ProjectEntity? Create(ProjectRegistrationForm form) => form == null ? default : new()
        {
            ProjectName = form.ProjectName,            
        };

        public static Project? Create(ProjectEntity entity) => entity == null ? default : new()
        {
            Id = entity.Id,
            ProjectName = entity.ProjectName
        };

        public static ProjectEntity Create(ProjectUpdateForm form) => form == null ? default : new()
        {
            Id = form.Id,
            ProjectName = form.ProjectName,
            CustomerId = form.CustomerId
        };
    }
}
