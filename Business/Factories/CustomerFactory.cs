using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        public CustomerEntity? Create(CustomerDTO form)
        {
            return new CustomerEntity()
            {
                Name = form.Name,
                Email = form.Email
            };
        }

        public Customer? Create(CustomerEntity entity)
        {
            var customer = new Customer()
            {
                Id = entity.Id,
                Name = entity.Name,
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
                        Name = project.Name,
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
