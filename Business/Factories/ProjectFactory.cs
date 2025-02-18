using Business.Models;
using Business.Interface;
using Data.Entities;
namespace Business.Factories
{
    public class ProjectFactory : IProjectFactory
    {
        public ProjectEntity? Create(ProjectRegistrationForm form) => new()
        {
            Name = form.Name,
            Description = form.Description,
            CustomerId = form.CustomerId
        };

        public ProjectEntity Create(ProjectUpdateForm form) => new()
        {
            Id = form.Id,
            Name = form.Name,
            Description = form.Description,
        };

        public Project Create(ProjectEntity entity)
        {
            if (entity == null)
                return null;

            var project = new Project
            {
                Id = entity.Id,
                Name = entity.Name,
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
