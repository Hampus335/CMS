using Business.Models;
using Business.Interface;
using Data.Entities;
using Data.Contexts;
namespace Business.Factories
{
    public class ProjectFactory(DataContext context) : IProjectFactory
    {
        public DataContext _context { get; set; } = context;


        public ProjectUpdateform? Create(ProjectRegistrationForm form)
        {
            var customer = _context.Set<CustomerEntity>().Find(form.CustomerId);

            return new ProjectUpdateform()
            {
                Name = form.Name,
                Description = form.Description,
                CustomerId = form.CustomerId,
                CustomerName = customer.Name
            };
        }


        public Project? Create(ProjectUpdateform entity)
        {
            if (entity == null)
                return null;

            var customerEntity = _context.Set<CustomerEntity>().Find(entity.CustomerId);

            var project = new Project
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CustomerName = customerEntity.Name
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
