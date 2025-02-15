using Business.Models;
using Business.Services;
using Data.Entities;

namespace Business.Factories
{
    public class CustomerFactory
    {
        public CustomerEntity? Create(CustomerDTO form) => form == null ? default : new()
        {
            CustomerName = form.Name,
            Email = form.Email
        };

        public Customer? Create(CustomerEntity entity)
        {
            var customer = new Customer()
            {
                Id = entity.Id,
                Name = entity.CustomerName,
                Email = entity.Email,
                Projects = []
            };  

            if (entity.Projects != null)
            {
                var projects = new List<Project>();

                foreach (var project in entity.Projects)
                {
                    projects.Add(new Project()
                    {
                        Id = project.Id,
                        Name = project.ProjectName,
                        Description = project.Description,
                        Customer = customer
                    });
                }

                customer.Projects = projects;
            }
            return customer;
        }

    }
}
