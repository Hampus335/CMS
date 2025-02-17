using Business.Models;
using Business.Interface;
using Data.Entities;
namespace Business.Factories
{
    public class ProjectFactory(ProjectFactory projectFactory) : IProjectFactory
    {
        public ProjectEntity? Create(ProjectRegistrationForm form) => form == null ? null : new()
        {
            ProjectName = form.Name,
            Description = form.Description,
            CustomerId = form.CustomerId
        };

        public Project Create(ProjectEntity entity)
        {   
            if (entity == null)
                return null;

            var project = new Project
            {
                Id = entity.Id,
                Name = entity.ProjectName,
                Description = entity.Description
            };

            if (entity.Customer != null)
            {
                project.Customer = new Customer()
                {
                    Id = entity.Customer.Id,
                    Name = entity.Customer.Name,
                    Email = entity.Customer.Email,
                };
            }

            return project;
        }
    }
}
